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

        public DTO.Resutado.Entidad<int> RetISLR_ContadorUltimaRetencion()
        {
            var rt = new DTO.Resutado.Entidad<int>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var sql_1 = @"select a_retencion_compras_islr
                        FROM contadores ";
                    var sql = sql_1 ;
                    var ent = cn.Database.SqlQuery<int>(sql).FirstOrDefault();
                    if (ent == null) 
                    {
                        rt.Mensaje = "CONTADOR ISLR NO DEFINIDO";
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

        //

        public DTO.Resutado.Lista<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentosPendPorAplicar_GetLista(DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("", "");
                    var sql_1 = @"select 
                        c.auto as autoDoc,
                        c.documento as numDoc,
                        c.control as numControlDoc,
                        c.n_serie as serieDoc,
                        c.fecha as fechaDoc,
                        c.tipo as tipoDoc,
                        c.base  as montoBase,
                        c.exento as montoExento,
                        c.impuesto as montoIva,
                        c.total as total,
                        c.estatus as estatus
                        FROM compras as c ";
                    var sql_2= " where 1=1 and  c.estatus='0' and c.tipo in ('01','02','03') and c.comprobante_retencion_islr='' ";
                    if (filtro.idProv!= "")
                    {
                        p1.ParameterName = "idProv";
                        p1.Value = filtro.idProv;
                        sql_2 += " and c.auto_entidad=@idProv ";
                    }
                    var sql = sql_1 + sql_2;
                    var lst = cn.Database.SqlQuery<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>(sql, p1).ToList();
                    rt.ListaEntidad = lst;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.Entidad<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentoPendPorAplicar_GetByIdDoc(string idDoc)
        {
            var rt = new DTO.Resutado.Entidad<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("idDoc", idDoc);
                    var sql_1 = @"select 
                        c.auto as autoDoc,
                        c.documento as numDoc,
                        c.control as numControlDoc,
                        c.n_serie as serieDoc,
                        c.fecha as fechaDoc,
                        c.tipo as tipoDoc,
                        c.base  as montoBase,
                        c.exento as montoExento,
                        c.impuesto as montoIva,
                        c.total as total,
                        c.estatus as estatus,
                        c.base1 as base_1,
                        c.base2 as base_2,
                        c.base3 as base_3,
                        c.impuesto1 as iva_1,
                        c.impuesto2 as iva_2,
                        c.impuesto3 as iva_3,
                        c.tasa1 as tasaiva_1,
                        c.tasa2 as tasaiva_2,
                        c.tasa3 as tasaiva_3,
                        c.aplica as docAplica,
                        p.auto as autoCxp
                        FROM compras as c 
                        join cxp as p on c.auto=p.auto_documento and p.modulo_origen='07'";
                    var sql_2 = " where c.auto=@idDoc ";
                    var sql = sql_1 + sql_2;
                    var ent = cn.Database.SqlQuery<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        rt.Mensaje = "ID DOCUMENTO NO ENCONTRADO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
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
        public DTO.Resutado.Entidad<string> RetISLR_DocumentoPendPorAplicar_CtaxPagar(DTO.RetISLR.DocumentoPendPorAplicar.CxPagar.Filtro filtro)
        {
            var rt = new DTO.Resutado.Entidad<string>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("idDoc", filtro.idDoc);
                    var p2 = new SqlParameter("tipoDoc", filtro.tipoDoc);
                    var sql_1 = @"select 
                        auto as autoDoc
                        FROM cxp ";
                    var sql_2 = " where 1=1 and auto_documento=@idDoc and tipo_documento=@tipoDoc ";
                    var sql = sql_1 + sql_2;
                    var ent = cn.Database.SqlQuery<string>(sql, p1, p2).FirstOrDefault();
                    if (ent == null)
                    {
                        rt.Mensaje = "DOCUMENTO POR PAGAR NO ENCONTRADO";
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
        
        //

        public DTO.Resutado.AutoId RetISLR_GenerarRetencion(DTO.RetISLR.GenerarRetencion.Ficha ficha)
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

                        var sql = "update contadores set a_retencion_compras=a_retencion_compras+1";
                        var r1 = cn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            rt.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        var aRet = cn.Database.SqlQuery<int>("select a_retencion_compras from contadores").FirstOrDefault();

                        sql = "update contadores set a_retencion_compras_islr=a_retencion_compras_islr+1";
                        r1 = cn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            rt.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        var aDocRet = cn.Database.SqlQuery<int>("select a_retencion_compras_islr from contadores").FirstOrDefault();

                        var autoRet = aRet.ToString().Trim().PadLeft(10, '0');
                        var mesRel= fechaSistema.Month.ToString().Trim().PadLeft(2,'0');
                        var anoRel= fechaSistema.Year.ToString().Trim().PadLeft(4,'0');
                        var periodoRel= fechaSistema.Day>=15?2:1;
                        var documentoRet = aDocRet.ToString().Trim().PadLeft(10, '0');

                        var ent = new retenciones_compras()
                        {
                            ano_relacion = anoRel,
                            auto = autoRet,
                            auto_cxp = "",
                            auto_entidad = ficha.retencion.autoProv,
                            auto_recibo_cxp = "",
                            @base = ficha.retencion.montoBase,
                            ci_rif = ficha.retencion.ciRifProv,
                            codigo_entidad = ficha.retencion.codigoProv,
                            dir_fiscal = ficha.retencion.dirFiscalProv,
                            documento = documentoRet,
                            estatus = ficha.retencion.estatusAnulado,
                            exento = ficha.retencion.montoExento,
                            fecha = fechaSistema.Date,
                            fecha_relacion = fechaSistema.Date,
                            impuesto = ficha.retencion.montoIva,
                            mes_relacion = mesRel,
                            nombre = ficha.retencion.nombreRazonSocialProv,
                            periodo = periodoRel,
                            retencion = ficha.retencion.montoRetencion,
                            tasa_retencion = ficha.retencion.tasaRetencion,
                            tipo = ficha.retencion.tipoRetencion,
                            total = ficha.retencion.total,
                        };
                        cn.retenciones_compras.Add(ent);
                        cn.SaveChanges();

                        var sqlRetCompDet = @"INSERT INTO retenciones_compras_detalle
                        (auto_documento, documento, fecha ,exento ,base ,impuesto ,total ,tasa_retencion ,retencion ,control 
                        ,aplica ,tipo ,auto ,ci_rif ,comprobante ,tipo_retencion ,fecha_retencion ,estatus ,impuesto1 ,impuesto2
                        ,impuesto3 ,base1 ,base2 ,base3 ,tasa1 ,tasa2 ,tasa3)
                        VALUES
                        (@auto_documento, @documento, @fecha ,@exento ,@base ,@impuesto ,@total ,@tasa_retencion ,@retencion ,@control 
                        ,@aplica ,@tipo ,@auto ,@ci_rif ,@comprobante ,@tipo_retencion ,@fecha_retencion ,@estatus ,@impuesto1 ,@impuesto2
                        ,@impuesto3 ,@base1 ,@base2 ,@base3 ,@tasa1 ,@tasa2 ,@tasa3)";
                        foreach (var r in ficha.retencionDet) 
                        {
                            var p1 = new SqlParameter("@auto_documento", r.autoDoc);
                            var p2 = new SqlParameter("@documento", r.numDoc);
                            var p3 = new SqlParameter("@fecha", r.fechaDoc);
                            var p4 = new SqlParameter("@exento", r.montoExento);
                            var p5 = new SqlParameter("@base", r.montoBase);
                            var p6 = new SqlParameter("@impuesto", r.montoIva);
                            var p7 = new SqlParameter("@total", r.total);
                            var p8 = new SqlParameter("@tasa_retencion", r.tasaRetencion);
                            var p9 = new SqlParameter("@retencion", r.montoRetencion);
                            var p10 = new SqlParameter("@control", r.numControlDoc);
                            var p11 = new SqlParameter("@aplica", r.numDocAplica);
                            var p12 = new SqlParameter("@tipo", r.tipoDoc);
                            var p13 = new SqlParameter("@auto", autoRet);
                            var p14 = new SqlParameter("@ci_rif", r.ciRifProv);
                            var p15 = new SqlParameter("@comprobante", documentoRet);
                            var p16 = new SqlParameter("@tipo_retencion", r.tipoRetencion);
                            var p17 = new SqlParameter("@fecha_retencion", fechaSistema.Date);
                            var p18 = new SqlParameter("@estatus", r.estatusAnulado);
                            var p19 = new SqlParameter("@impuesto1", r.montoIva1);
                            var p20 = new SqlParameter("@impuesto2", r.montoIva2);
                            var p21 = new SqlParameter("@impuesto3", r.montoIva3);
                            var p22 = new SqlParameter("@base1", r.montoBase1);
                            var p23 = new SqlParameter("@base2", r.montoBase2);
                            var p24 = new SqlParameter("@base3", r.montoBase3);
                            var p25 = new SqlParameter("@tasa1", r.montoTasa1);
                            var p26 = new SqlParameter("@tasa2", r.montoTasa2);
                            var p27 = new SqlParameter("@tasa3", r.montoTasa3);
                            cn.Database.ExecuteSqlCommand(sqlRetCompDet,p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,
                                p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27);
                            cn.SaveChanges();
                        }
                        
                        foreach (var r in ficha.docAplicaRet) 
                        {
                            var entDocAplicaRet = cn.compras.Find(r.autoDoc);
                            if (entDocAplicaRet==null)
                            {
                                rt.Mensaje = "DOCUMENTO COMPRA AL CUAL APLICA RETENCION ESTATUS: NO ENCONTRADO";
                                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            if (entDocAplicaRet.estatus.Trim().ToUpper()=="1")
                            {
                                rt.Mensaje = "DOCUMENTO COMPRA AL CUAL APLICA RETENCION ESTATUS: ANULADO";
                                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            if (
                                (entDocAplicaRet.comprobante_retencion_islr.Trim()  != "" ) ||
                                (entDocAplicaRet.tasa_retencion_islr  != 0m) ||
                                (entDocAplicaRet.retencion_islr  != 0m )
                               )
                            {
                                rt.Mensaje = "DOCUMENTO COMPRA AL CUAL APLICA RETENCION ESTATUS: YA POSEE UNA RETENCION";
                                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            entDocAplicaRet.comprobante_retencion_islr = documentoRet;
                            entDocAplicaRet.tasa_retencion_islr = r.tasaAplica;
                            entDocAplicaRet.retencion_islr = r.montoAplica;
                            cn.SaveChanges();
                        }

                        foreach (var r in ficha.docActualizarSaldoCxP)
                        {
                            var entCxP= cn.cxp.Find(r.idDocCxP);
                            if (entCxP == null)
                            {
                                rt.Mensaje = "DOCUMENTO CXP ESTATUS: NO ENCONTRADO";
                                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            if (entCxP.estatus.Trim().ToUpper() == "1")
                            {
                                rt.Mensaje = "DOCUMENTO CXP ESTATUS: ANULADO";
                                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            if (entCxP.cancelado.Trim().ToUpper() == "1")
                            {
                                rt.Mensaje = "DOCUMENTO CXP ESTATUS: PAGADO";
                                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            if ((entCxP.acumulado + r.montoAbonado)> entCxP.importe)
                            {
                                rt.Mensaje = "DOCUMENTO CXP ESTATUS: MONTO PAGO INCORRECTO";
                                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            entCxP.acumulado += r.montoAbonado;
                            entCxP.resta -= r.montoAbonado;
                            cn.SaveChanges();
                        }

                        //

                        sql = "update contadores set a_cxp=a_cxp+1";
                        r1 = cn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            rt.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        var aCxP= cn.Database.SqlQuery<int>("select a_cxp from contadores").FirstOrDefault();
                        var autoCxP = aCxP.ToString().Trim().PadLeft(10, '0');

                        var cxp= ficha.cxp;
                        var nEntCxP = new cxp()
                        {
                            acumulado = cxp.acumulado,
                            agencia = "",
                            auto = autoCxP,
                            auto_agencia = "",
                            auto_documento = autoRet,
                            auto_mov_entrada = "",
                            auto_movimiento = "",
                            auto_proveedor = cxp.autoProv,
                            cancelado = cxp.estatusPagado,
                            ci_rif = cxp.ciRifProv,
                            codigo_proveedor = cxp.codigoProv,
                            detalle = cxp.detalle,
                            documento = documentoRet,
                            estatus = cxp.estatusAnulado,
                            fecha = fechaSistema.Date,
                            fecha_carga = fechaSistema.Date,
                            fecha_recepcion_devolucion = null,
                            fecha_vencimiento = fechaSistema.Date,
                            importe = cxp.importe,
                            modulo_origen = cxp.moduloOrigen,
                            numero = "",
                            numero_cuenta = "",
                            operacion = "",
                            proveedor = cxp.nombreRazonSocialProv,
                            resta = cxp.montoResta,
                            signo = cxp.signo,
                            tipo_cuenta = "",
                            tipo_documento = cxp.tipoDocGen,
                            titular = "",
                        };
                        cn.cxp.Add(nEntCxP);
                        cn.SaveChanges();

                        sql = "update contadores set a_cxp_recibos=a_cxp_recibos+1, a_cxp_recibos_numero=a_cxp_recibos_numero+1";
                        r1 = cn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            rt.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        var aRecibo = cn.Database.SqlQuery<int>("select a_cxp_recibos from contadores").FirstOrDefault();
                        var autoRecibo = aRecibo.ToString().Trim().PadLeft(10, '0');
                        var nRecibo = cn.Database.SqlQuery<int>("select a_cxp_recibos_numero from contadores").FirstOrDefault();
                        var numRecibo = nRecibo.ToString().Trim().PadLeft(10, '0');

                        var rec=ficha.recibo;
                        var eRecibo = new cxp_recibos()
                        {
                            auto = autoRecibo,
                            numero = numRecibo,
                            fecha = fechaSistema.Date,
                            auto_usuario = rec.autoUsuario,
                            importe = rec.importe,
                            usuario = rec.nombreUsuario,
                            importe_documentos = rec.importe,
                            total_documentos = rec.importe,
                            detalle = rec.detalle + ", DOC: " + documentoRet,
                            auto_proveedor = rec.autoProv,
                            nombre_proveedor = rec.nombreRazonSocialProv,
                            ci_rif_proveedor = rec.ciRifProv,
                            codigo_proveedor = rec.codigoProv,
                            estatus = rec.estatusAnulado,
                            cant_doc_rel = rec.cantDocInvolucrado,
                            tipo_pago = rec.tipoPagoOrigen,
                            monto_recibido = rec.montoRecibido,
                            monto_cambio = rec.montoCambio,
                            dirFiscal_proveedor = rec.dirFiscalProv,
                            telefono_proveedor = rec.telefonoProv,
                            nota = rec.notas,
                            auto_cxp = autoCxP,
                        };
                        cn.cxp_recibos.Add(eRecibo);
                        cn.SaveChanges();


                        // ACTUALIZO ENTIDAD RETENCION ENCABEZADO
                        ent.auto_cxp = autoCxP;
                        ent.auto_recibo_cxp = autoRecibo;
                        cn.SaveChanges();
                        //


                        var sqlCxPDocumento = @"INSERT INTO cxp_documentos
                                            (item, operacion ,monto ,auto_cxp ,documento ,auto_cxp_pago ,tipo 
                                            ,fecha ,detalle ,auto_cxp_recibo ,numero_recibo ,origen)
                                            VALUES 
                                            (@item, @operacion ,@monto ,@auto_cxp ,@documento ,@auto_cxp_pago ,@tipo 
                                            ,@fecha ,@detalle ,@auto_cxp_recibo ,@numero_recibo ,@origen)";
                        foreach(var d in ficha.docInvRecibo)
                        {
                            var p1 = new SqlParameter("@item", d.nItem);
                            var p2 = new SqlParameter("@operacion", d.operacionEjecutar);
                            var p3 = new SqlParameter("@monto", d.montoImporte);
                            var p4 = new SqlParameter("@auto_cxp", d.autoCxPDocInv);
                            var p5 = new SqlParameter("@documento", d.numDocInv);
                            var p6 = new SqlParameter("@auto_cxp_pago", autoCxP);
                            var p7 = new SqlParameter("@tipo", d.tipoDocInv);
                            var p8 = new SqlParameter("@fecha", fechaSistema.Date);
                            var p9 = new SqlParameter("@detalle", d.detalle + documentoRet);
                            var p10 = new SqlParameter("@auto_cxp_recibo",autoRecibo);
                            var p11 = new SqlParameter("@numero_recibo", numRecibo);
                            var p12 = new SqlParameter("@origen", d.nombreDocInv);
                            var p13 = new SqlParameter("@monto_pendiente", 0m);
                            cn.Database.ExecuteSqlCommand(sqlCxPDocumento, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
                            cn.SaveChanges();
                        }

                        var mPag= ficha.medioPago;
                        var xp1 = new SqlParameter("@auto_recibo", autoRecibo);
                        var xp2 = new SqlParameter("@auto_movimientos", "");
                        var xp3 = new SqlParameter("@numero", "");
                        var xp4 = new SqlParameter("@banco", "");
                        var xp5 = new SqlParameter("@importe", mPag.montoRecibido );
                        var xp6 = new SqlParameter("@nombre", "");
                        var xp7 = new SqlParameter("@fecha", fechaSistema.Date);
                        var xp8 = new SqlParameter("@estatus_anulado", mPag.estatusAnulado);
                        var xp9 = new SqlParameter("@codigo_medio_pago", mPag.codigoMedioPago);
                        var xp10 = new SqlParameter("@desc_medio_pago", mPag.descMedioPago);
                        var sqlModoPago = @"INSERT INTO cxp_modo_pago
                                            (auto_recibo, auto_movimientos ,numero ,banco ,importe 
                                            ,nombre ,fecha ,estatus_anulado ,codigo_medio_pago ,desc_medio_pago)
                                            VALUES
                                            (@auto_recibo, @auto_movimientos ,@numero ,@banco ,@importe 
                                            ,@nombre ,@fecha ,@estatus_anulado ,@codigo_medio_pago ,@desc_medio_pago)";
                        cn.Database.ExecuteSqlCommand(sqlModoPago, xp1, xp2, xp3, xp4, xp5, xp6, xp7, xp8, xp9, xp10);
                        cn.SaveChanges();

                        ts.Complete();
                        rt.Auto = autoRet;
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
        public DTO.Resutado.Entidad<DTO.RetISLR.AnularRetencion.CapturarData.Ficha> RetISLR_AnularRetencion_GetData(string idRetencion)
        {
            var rt = new DTO.Resutado.Entidad<DTO.RetISLR.AnularRetencion.CapturarData.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var eRet = cn.retenciones_compras.Find(idRetencion);
                    if (eRet == null)
                    {
                        rt.Mensaje = "DOCUMENTO RETENCION A ANULAR NO ENCONTRADO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    var nr = new DTO.RetISLR.AnularRetencion.CapturarData.Ficha()
                    {
                        autoDocRetencion = eRet.auto,
                        autoPago = eRet.auto_cxp,
                        autoRecibo = eRet.auto_recibo_cxp,
                    };

                    var lst = new List<DTO.RetISLR.AnularRetencion.CapturarData.DocCompraAplicaRetencion>();
                    var eRetDet = cn.retenciones_compras_detalle.Where(w => w.auto == idRetencion).ToList();
                    foreach (var d in eRetDet)
                    {
                        var rg = new DTO.RetISLR.AnularRetencion.CapturarData.DocCompraAplicaRetencion()
                        {
                            autoDocCompra = d.auto_documento,
                            montoAplica = d.retencion,
                        };

                        var eCxP = cn.cxp.FirstOrDefault(f => f.auto_documento == rg.autoDocCompra && f.modulo_origen == "07");
                        if (eCxP == null)
                        {
                            rt.Mensaje = "DOCUMENTO CXP NO ENCONTRADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        rg.autoCxP = eCxP.auto;
                        lst.Add(rg);
                    }
                    nr.docCompraAplicaRetencion = lst;

                    rt.MiEntidad = nr;
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
        public DTO.Resutado.Ficha RetISLR_AnularRetencion(DTO.RetISLR.AnularRetencion.Anular.Ficha ficha)
        {
            var rt = new DTO.Resutado.Ficha();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var fechaSistema = cn.Database.SqlQuery<DateTime>("select getDate()").FirstOrDefault();

                        var eRet = cn.retenciones_compras.Find(ficha.autoDocRetencion);
                        if (eRet == null) 
                        {
                            rt.Mensaje = "ID DOCUMENTO RETENCION NO ENCONTRADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (eRet.estatus =="1")
                        {
                            rt.Mensaje = "DOCUMENTO RETENCION YA ANULADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        eRet.estatus = "1";
                        cn.SaveChanges();

                        var p2 = new SqlParameter("@autoDoc", ficha.autoDocRetencion);
                        var sql = "update retenciones_compras_detalle set estatus='1' where auto_documento=@autoDoc";
                        cn.Database.ExecuteSqlCommand(sql, p2);
                        cn.SaveChanges();

                        foreach (var r in ficha.docCompraAplicaRetencion)
                        {
                            var xp1 = new SqlParameter("@autoDoc", r.autoDocCompra);
                            sql = @"update compras set tasa_retencion_islr=0, retencion_islr=0, 
                            comprobante_retencion_islr='' where auto=@autoDoc";
                            cn.Database.ExecuteSqlCommand(sql, xp1);
                            cn.SaveChanges();

                            var xp2 = new SqlParameter("@autoCxP", r.autoCxP);
                            var xp3 = new SqlParameter("@monto", r.montoAplica);
                            sql = @"update cxp set acumulado=acumulado-@monto, resta=resta+@monto 
                            where auto=@autoCxP";
                            cn.Database.ExecuteSqlCommand(sql, xp2, xp3);
                            cn.SaveChanges();
                        }

                        var p3 = new SqlParameter("@autoPago", ficha.autoPago);
                        sql = "update cxp set estatus='1' where auto=@autoPago";
                        cn.Database.ExecuteSqlCommand(sql, p3);
                        cn.SaveChanges();

                        var p4 = new SqlParameter("@autoRecibo", ficha.autoRecibo);
                        sql = "update cxp_recibos set estatus='1' where auto=@autoRecibo";
                        cn.Database.ExecuteSqlCommand(sql, p4);
                        cn.SaveChanges();

                        var p5 = new SqlParameter("@autoRecibo", ficha.autoRecibo);
                        sql = "update cxp_modo_pago set estatus_anulado='1' where auto_recibo=@autoRecibo";
                        cn.Database.ExecuteSqlCommand(sql, p5);
                        cn.SaveChanges();

                        sql = "update contadores set a_documentos_anulados=a_documentos_anulados+1";
                        cn.Database.ExecuteSqlCommand(sql);
                        cn.SaveChanges();

                        sql = "select a_documentos_anulados from contadores";
                        var aDoc=cn.Database.SqlQuery<int>(sql).FirstOrDefault();
                        var autoDoc = aDoc.ToString().Trim().PadLeft(10, '0');

                        var anu= ficha.registroAnulacion;
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
        public DTO.Resutado.Ficha RetISLR_GenerarRetencion_Veirificar(DTO.RetISLR.GenerarRetencion.Verifica ficha)
        {
            var rt = new DTO.Resutado.Ficha();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {

                    foreach (var r in ficha.docAplicaRet)
                    {
                        var entDocAplicaRet = cn.compras.Find(r.autoDoc);
                        if (entDocAplicaRet == null)
                        {
                            rt.Mensaje = "DOCUMENTO COMPRA AL CUAL APLICA RETENCION ESTATUS: NO ENCONTRADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (entDocAplicaRet.estatus.Trim().ToUpper() == "1")
                        {
                            rt.Mensaje = "DOCUMENTO COMPRA AL CUAL APLICA RETENCION ESTATUS: ANULADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (
                            (entDocAplicaRet.comprobante_retencion_islr.Trim() != "") ||
                            (entDocAplicaRet.tasa_retencion_islr != 0m) ||
                            (entDocAplicaRet.retencion_islr != 0m)
                           )
                        {
                            rt.Mensaje = "DOCUMENTO COMPRA AL CUAL APLICA RETENCION ESTATUS: YA POSEE UNA RETENCION";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (!new[] {"01","02","03"}.Contains(entDocAplicaRet.tipo))
                        {
                            rt.Mensaje = "DOCUMENTO COMPRA: TIPO DOCUMENTO INCORRECTO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                    }

                    foreach (var r in ficha.docActualizarSaldoCxP)
                    {
                        var entCxP = cn.cxp.Find(r.idDocCxP);
                        if (entCxP == null)
                        {
                            rt.Mensaje = "DOCUMENTO CXP ESTATUS: NO ENCONTRADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (entCxP.estatus.Trim().ToUpper() == "1")
                        {
                            rt.Mensaje = "DOCUMENTO CXP ESTATUS: ANULADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (entCxP.cancelado.Trim().ToUpper() == "1")
                        {
                            rt.Mensaje = "DOCUMENTO CXP ESTATUS: PAGADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if ((entCxP.acumulado + r.montoAbonado) > entCxP.importe)
                        {
                            rt.Mensaje = "DOCUMENTO CXP ESTATUS: MONTO PAGO INCORRECTO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
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

        public DTO.Resutado.Lista<DTO.RetISLR.Lista.Ficha> RetISLR_GetLista(DTO.RetISLR.Lista.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.RetISLR.Lista.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("", "");
                    var p2 = new SqlParameter("", "");
                    var p3 = new SqlParameter("", "");
                    var p4 = new SqlParameter("", "");
                    var p5 = new SqlParameter("", "");
                    var sql_1 = @"select 
                        r.auto as id,
                        r.documento as documento,
                        r.fecha as deFecha,
                        r.nombre as nombreProv,
                        r.ci_rif as ciRifProv,
                        r.tipo as tipoRetencion,
                        r.tasa_retencion as tasaRet,
                        r.retencion as montoRet,
                        r.estatus as estatus,
                        r.exento as mexento, 
                        r.base as mbase, 
                        r.impuesto as miva, 
                        r.total as mtotal
                        FROM retenciones_compras as r ";
                    var sql_2 = " where 1=1 ";

                    if (filtro.desde.HasValue) 
                    {
                        sql_2 += " and r.fecha>=@desde ";
                        p1.ParameterName = "@desde";
                        p1.Value = filtro.desde.Value;
                    }
                    if (filtro.hasta.HasValue)
                    {
                        sql_2 += " and r.fecha<=@hasta ";
                        p2.ParameterName = "@hasta";
                        p2.Value = filtro.hasta.Value;
                    }
                    if (filtro.tipoRetencion!="")
                    {
                        sql_2 += " and r.tipo=@tipoRet ";
                        p3.ParameterName = "@tipoRet";
                        p3.Value = filtro.tipoRetencion;
                    }
                    if (filtro.idProv != "")
                    {
                        sql_2 += " and r.auto_entidad=@idProv ";
                        p4.ParameterName = "@idProv";
                        p4.Value = filtro.idProv;
                    }
                    if (filtro.estatus != DTO.RetISLR.Lista.Filtro.enumEstatus.SinDefinir)
                    {
                        sql_2 += " and r.estatus=@estatus ";
                        p5.ParameterName = "@estatus";
                        p5.Value = filtro.estatus == DTO.RetISLR.Lista.Filtro.enumEstatus.Anulado?"1":"0";
                    }
                    var sql = sql_1 + sql_2;
                    var lst = cn.Database.SqlQuery<DTO.RetISLR.Lista.Ficha>(sql, p1, p2, p3, p4, p5).ToList();
                    rt.ListaEntidad = lst;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.Entidad<DTO.RetISLR.Entidad.Ficha> RetISLR_GetById(string id)
        {
            var rt = new DTO.Resutado.Entidad<DTO.RetISLR.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var ent = cn.retenciones_compras.Find(id);
                    if (ent==null)
                    {
                        rt.Mensaje = "ID DOCUMENTO NO ENCONTRADO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    var enc = new DTO.RetISLR.Entidad.Ficha()
                    {
                        anoRelacion = ent.ano_relacion,
                        ciRifProv = ent.ci_rif,
                        codigoProv = ent.codigo_entidad,
                        deFecha = ent.fecha,
                        documento = ent.documento,
                        estatus = ent.estatus,
                        id = ent.auto,
                        idProv = ent.auto_entidad,
                        mBase = ent.@base,
                        mesRelacion = ent.mes_relacion,
                        mExento = ent.exento,
                        mIva = ent.impuesto,
                        montoRet = ent.retencion,
                        mTotal = ent.total,
                        nombreProv = ent.nombre,
                        tasaRet = ent.tasa_retencion,
                        tipoRetencion = ent.tipo,
                    };

                    var lst = new List<DTO.RetISLR.Entidad.Detalle>();
                    var entDet = cn.retenciones_compras_detalle.Where(w => w.auto== id).ToList();
                    foreach (var d in entDet) 
                    {
                        var nr = new DTO.RetISLR.Entidad.Detalle()
                        {
                            autoDoc = d.auto_documento,
                            ciRifProv = d.ci_rif,
                            estatusAnulado = d.estatus,
                            fechaDoc = d.fecha,
                            montoBase = d.@base,
                            montoBase1 = d.base1.Value ,
                            montoBase2 = d.base2.Value ,
                            montoBase3 = d.base3.Value ,
                            montoExento = d.exento,
                            montoIva = d.impuesto,
                            montoIva1 = d.impuesto1.Value ,
                            montoIva2 = d.impuesto2.Value ,
                            montoIva3 = d.impuesto3.Value ,
                            montoRetencion = d.retencion,
                            montoTasa1 = d.tasa1.Value ,
                            montoTasa2 = d.tasa2.Value ,
                            montoTasa3 = d.tasa3.Value ,
                            numControlDoc = d.control,
                            numDoc = d.documento,
                            numDocAplica = d.aplica,
                            tasaRetencion = d.tasa_retencion,
                            tipoDoc = d.tipo,
                            total = d.total,
                        };
                        lst.Add(nr);
                    }
                    enc.Detalles = lst;

                    rt.MiEntidad = enc;
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