using Provider.IDATA;
using SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace Provider.DATASQL
{
 
    public partial class Provider: IProvider
    {

        public DTO.Resutado.Lista<DTO.CtaPagar.Lista.Ficha> CtaPagar_GetLista(DTO.CtaPagar.Lista.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.CtaPagar.Lista.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("","");
                    var p2 = new SqlParameter("","");
                    var p3 = new SqlParameter("","");
                    var p4 = new SqlParameter("","");
                    var p5 = new SqlParameter("","");
                    var sql_1 = @"select auto as autoDoc, auto_proveedor as autoProveedor, documento as numDoc, 
                                fecha as fechaEmisionDoc, fecha_vencimiento as fechaVenceDoc, importe as importeDoc,
                                resta as restaDoc, proveedor as provNombre, ci_rif as provCiRif, estatus as estatusDoc, 
                                signo as signoDoc, acumulado as abonadoDoc, tipo_documento as tipoDoc, detalle as detalleDoc
                                from cxp";
                    var sql_2=" where 1=1 ";
                    if (filtro.desde .HasValue)
                    {
                        p1.Value = filtro.desde.Value;
                        p1.ParameterName = "@desde";
                        sql_2 += " and fecha>=@desde ";
                    }
                    if (filtro.hasta.HasValue)
                    {
                        p2.Value = filtro.hasta.Value;
                        p2.ParameterName = "@hasta";
                        sql_2 += " and fecha<=@hasta ";
                    }
                    if (filtro.autoProv != "")
                    {
                        p3.Value = filtro.autoProv;
                        p3.ParameterName = "@autoProv";
                        sql_2 += " and auto_proveedor=@autoProv ";
                    }
                    if (filtro.estatus !=  DTO.CtaPagar.Lista.Filtro.enumEstatus.SinDefinir)
                    {
                        p4.Value = filtro.estatus == DTO.CtaPagar.Lista.Filtro.enumEstatus.Activo ? "0" : "1";
                        p4.ParameterName = "@estatus";
                        sql_2 += " and estatus=@estatus ";
                    }
                    if (filtro.tipoDoc != DTO.CtaPagar.Lista.Filtro.enumTipoDoc.SinDefinir)
                    {
                        var tipo = "";
                        switch (filtro.tipoDoc) 
                        {
                            case DTO.CtaPagar.Lista.Filtro.enumTipoDoc.Factura:
                                tipo = "FAC";
                                break;
                            case DTO.CtaPagar.Lista.Filtro.enumTipoDoc.NtaCredito:
                                tipo = "NCF";
                                break;
                            case DTO.CtaPagar.Lista.Filtro.enumTipoDoc.Pago:
                                tipo = "PAG";
                                break;
                            case DTO.CtaPagar.Lista.Filtro.enumTipoDoc.Retencion:
                                tipo = "IR";
                                break;
                            case DTO.CtaPagar.Lista.Filtro.enumTipoDoc.DocPorLiquidar:
                                sql_2 += " and cancelado='0' ";
                                break;
                        }
                        if (tipo != "") 
                        {
                            p5.Value = tipo;
                            p5.ParameterName = "@tipo";
                            sql_2 += " and tipo_documento=@tipo ";
                        }
                    }
                    var sql = sql_1 + sql_2;
                    var list = cn.Database.SqlQuery<DTO.CtaPagar.Lista.Ficha>(sql, p1, p2, p3, p4, p5).ToList();
                    rt.ListaEntidad = list;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.Entidad<DTO.CtaPagar.Entidad.Ficha> CtaPagar_GetById(string idDoc)
        {
            var rt = new DTO.Resutado.Entidad<DTO.CtaPagar.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("@auto", idDoc);
                    var sql_1 = @"select
                                        auto as autoDoc, 
                                        auto_proveedor as autoProv, 
                                        auto_documento as autoDocRef, 
                                        fecha as fechaEmisionDoc, 
                                        fecha_vencimiento as fechaVenceDoc, 
                                        fecha_carga as fechaREgistro, 
                                        tipo_documento as tipoDoc, 
                                        documento as numeroDoc, 
                                        detalle as detalleDoc,
                                        importe as importeDoc,
                                        acumulado as abonadoDoc, 
                                        proveedor as provNombre, 
                                        ci_rif as provCiRif, 
                                        codigo_proveedor as provCodigo, 
                                        resta as restaDoc, 
                                        estatus as estatusDoc, 
                                        cancelado as estatusCanceladoDoc, 
                                        signo as signoDoc,
                                        modulo_origen as codigoModuloOrigen
                                    from cxp ";
                    var sql_2 = " where auto=@auto ";
                    var sql = sql_1 + sql_2;
                    var ent = cn.Database.SqlQuery<DTO.CtaPagar.Entidad.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        rt.Mensaje = "";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    rt.MiEntidad = ent;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.AutoId CtaPagar_Agregar(DTO.CtaPagar.Agregar.Ficha ficha)
        {
            var rt = new DTO.Resutado.AutoId();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var fechaSistema = cn.Database.SqlQuery<DateTime>("select getDate()").FirstOrDefault();
                        var fechaNula = new DateTime(2000, 1, 1);


                        var ent = cn.cxp.FirstOrDefault(f => f.auto_proveedor == ficha.autoProv &&
                            f.documento.Trim() == ficha.numeroDoc &&
                            f.tipo_documento.Trim() == ficha.tipoDoc &&
                            f.estatus.Trim() == ficha.estatusDoc);
                        if (ent != null)
                        {
                            rt.Mensaje = "DOCUMENTO YA REGISTRADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        };
                        if (ficha.fechaEmisionDoc> fechaSistema.Date )
                        {
                            rt.Mensaje = "FECHA EMISION DOCUMENTO INCORRECTA";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }

                        var sql = "update contadores set a_cxp=a_cxp+1";
                        var r1 = cn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            rt.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        var aCxP = cn.Database.SqlQuery<int>("select a_cxp from contadores").FirstOrDefault();
                        var autoCxP = aCxP.ToString().Trim().PadLeft(10, '0');

                        var cxp = ficha;
                        var nEntCxP = new cxp()
                        {
                            acumulado = cxp.abonadoDoc,
                            agencia = "",
                            auto = autoCxP,
                            auto_agencia = "",
                            auto_documento = "",
                            auto_mov_entrada = "",
                            auto_movimiento = "",
                            auto_proveedor = cxp.autoProv,
                            cancelado = cxp.estatusCanceladoDoc,
                            ci_rif = cxp.provCiRif,
                            codigo_proveedor = cxp.provCodigo,
                            detalle = cxp.detalleDoc,
                            documento = cxp.numeroDoc,
                            estatus = cxp.estatusDoc,
                            fecha = cxp.fechaEmisionDoc ,
                            fecha_carga = fechaSistema.Date,
                            fecha_recepcion_devolucion = null,
                            fecha_vencimiento = cxp.fechaVenceDoc ,
                            importe = cxp.importeDoc,
                            modulo_origen = cxp.codigoModuloOrigen,
                            numero = "",
                            numero_cuenta = "",
                            operacion = "",
                            proveedor = cxp.provNombre ,
                            resta = cxp.restaDoc,
                            signo = cxp.signoDoc,
                            tipo_cuenta = "",
                            tipo_documento = cxp.tipoDoc,
                            titular = "",
                        };
                        cn.cxp.Add(nEntCxP);
                        cn.SaveChanges();

                        ts.Complete();
                        rt.Auto = autoCxP;
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                var dbUpdateEx = ex as System.Data.Entity.Infrastructure.DbUpdateException;
                var sqlEx = dbUpdateEx.InnerException;
                if (sqlEx != null)
                {
                    var exx = (SqlException)sqlEx.InnerException;
                    if (exx != null)
                    {
                        if (exx.Number == 1452)
                        {
                            rt.Mensaje = "PROBLEMA DE CLAVE FORANEA" + Environment.NewLine + exx.Message;
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        else
                        {
                            rt.Mensaje = exx.Message;
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                    }
                }
                rt.Mensaje = ex.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.Ficha CtaPagar_AnularDoc(DTO.CtaPagar.AnularDoc.Ficha ficha)
        {
            var rt = new DTO.Resutado.Ficha();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var fechaSistema = cn.Database.SqlQuery<DateTime>("select getDate()").FirstOrDefault();

                        var ent = cn.cxp.Find(ficha.autoDoc);
                        if (ent == null)
                        {
                            rt.Mensaje = "ID DOCUMENTO NO ENCONTRADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (ent.estatus == "1")
                        {
                            rt.Mensaje = "DOCUMENTO YA ANULADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (ent.acumulado>0)
                        {
                            rt.Mensaje = "DOCUMENTO TIENE PAGOS RELACIONADOS";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (ent.modulo_origen != "05")
                        {
                            rt.Mensaje = "DOCUMENTO NO APLICA PARA ESTE MODULO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        ent.estatus = "1";
                        cn.SaveChanges();
                      

                        var sql = "update contadores set a_documentos_anulados=a_documentos_anulados+1";
                        cn.Database.ExecuteSqlCommand(sql);
                        cn.SaveChanges();

                        sql = "select a_documentos_anulados from contadores";
                        var aDoc = cn.Database.SqlQuery<int>(sql).FirstOrDefault();
                        var autoDoc = aDoc.ToString().Trim().PadLeft(10, '0');

                        var anu = ficha.regAuditoria;
                        var tp1 = new SqlParameter("@codigo", anu.moduloOrigen);
                        var tp2 = new SqlParameter("@fecha", fechaSistema.Date);
                        var tp3 = new SqlParameter("@hora", fechaSistema.ToShortTimeString());
                        var tp4 = new SqlParameter("@detalle", anu.detalle);
                        var tp5 = new SqlParameter("@estacion", anu.equipoEstacion);
                        var tp6 = new SqlParameter("@usuario", anu.usuNombre);
                        var tp7 = new SqlParameter("@codigo_usuario ", anu.usuCodigo);
                        var tp8 = new SqlParameter("@auto ", autoDoc);
                        var tp9 = new SqlParameter("@auto_documento", anu.autoDoc);
                        sql = @"INSERT INTO documentos_anulados
                                (codigo ,fecha ,hora ,detalle ,estacion ,usuario ,codigo_usuario ,auto ,auto_documento)
                                VALUES
                                (@codigo ,@fecha ,@hora ,@detalle ,@estacion ,@usuario ,@codigo_usuario ,@auto ,@auto_documento)";
                        cn.Database.ExecuteSqlCommand(sql, tp1, tp2, tp3, tp4, tp5, tp6, tp7, tp8, tp9);
                        cn.SaveChanges();

                        ts.Complete();
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                var dbUpdateEx = ex as System.Data.Entity.Infrastructure.DbUpdateException;
                var sqlEx = dbUpdateEx.InnerException;
                if (sqlEx != null)
                {
                    var exx = (SqlException)sqlEx.InnerException;
                    if (exx != null)
                    {
                        if (exx.Number == 1452)
                        {
                            rt.Mensaje = "PROBLEMA DE CLAVE FORANEA" + Environment.NewLine + exx.Message;
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        else
                        {
                            rt.Mensaje = exx.Message;
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                    }
                }
                rt.Mensaje = ex.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }

        //

        public DTO.Resutado.Ficha CtaPagar_Agregar_Verficar(DTO.CtaPagar.Agregar.Ficha ficha)
        {
            var rt = new DTO.Resutado.Ficha();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var ent = cn.cxp.FirstOrDefault(f => f.auto_proveedor == ficha.autoProv &&
                        f.documento.Trim() == ficha.numeroDoc &&
                        f.tipo_documento.Trim() == ficha.tipoDoc && 
                        f.estatus.Trim()==ficha.estatusDoc);
                    if (ent != null)
                    {
                        rt.Mensaje = "DOCUMENTO YA REGISTRADO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    };
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.Ficha CtaPagar_AnularDoc_Verficar(string autoDoc)
        {
            var rt = new DTO.Resutado.Ficha();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var ent = cn.cxp.Find(autoDoc);
                    if (ent == null)
                    {
                        rt.Mensaje = "ID DOCUMENTO NO ENCONTRADO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (ent.estatus == "1")
                    {
                        rt.Mensaje = "DOCUMENTO YA ANULADO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (ent.acumulado > 0)
                    {
                        rt.Mensaje = "DOCUMENTO TIENE PAGOS RELACIONADOS";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (ent.modulo_origen != "05")
                    {
                        rt.Mensaje = "DOCUMENTO NO APLICA PARA ESTE MODULO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }

    }

}