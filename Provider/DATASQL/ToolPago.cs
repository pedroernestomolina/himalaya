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

        public DTO.Resutado.Lista<DTO.ToolPago.ResumenPendPagar.Ficha> ToolPago_ResumenPendPagar_GetLista()
        {
            var rt = new DTO.Resutado.Lista<DTO.ToolPago.ResumenPendPagar.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("", "");
                    var p2 = new SqlParameter("", "");
                    var p3 = new SqlParameter("", "");
                    var p4 = new SqlParameter("", "");
                    var p5 = new SqlParameter("", "");
                    var sql_1 = @"SELECT 
                                    sum([importe]) as importe,
                                    sUM([acumulado]) as acumulado,
                                    [auto_proveedor] as provId,
                                    [proveedor] as provNombre,
                                    [ci_rif] as provCiRif,
                                    sum([resta]) as resta,
                                    count(*) as cntDoc
                                    FROM [cxp]
                                    where estatus='0' and cancelado='0'
                                    group by auto_proveedor, proveedor, ci_rif";
                    var sql = sql_1;
                    var list = cn.Database.SqlQuery<DTO.ToolPago.ResumenPendPagar.Ficha>(sql, p1, p2, p3, p4, p5).ToList();
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
        public DTO.Resutado.Entidad<DTO.ToolPago.ResumenPendPagar.Ficha> ToolPago_ResumenPendPagar_GetByIdProveedor(string idProv)
        {
            var rt = new DTO.Resutado.Entidad<DTO.ToolPago.ResumenPendPagar.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("@p1", idProv);
                    var sql_1 = @"SELECT 
                                    sum([importe]) as importe,
                                    sUM([acumulado]) as acumulado,
                                    [auto_proveedor] as provId,
                                    [proveedor] as provNombre,
                                    [ci_rif] as provCiRif,
                                    sum([resta]) as resta,
                                    count(*) as cntDoc
                                    FROM [cxp]
                                    where estatus='0' and cancelado='0' and auto_proveedor=@p1
                                    group by auto_proveedor, proveedor, ci_rif";
                    var sql = sql_1;
                    var ent = cn.Database.SqlQuery<DTO.ToolPago.ResumenPendPagar.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                        rt.MiEntidad = new DTO.ToolPago.ResumenPendPagar.Ficha();
                    else
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
        public DTO.Resutado.Lista<DTO.ToolPago.PendPagar.Ficha> ToolPago_PendPagar_GetByIdProv(string idProv)
        {
            var rt = new DTO.Resutado.Lista<DTO.ToolPago.PendPagar.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("@p1", idProv);
                    var sql_1 = @"SELECT 
                                    auto as autoDoc,
                                    [fecha] as fechaEmision
                                    ,[tipo_documento] as tipoDoc
                                    ,[documento] as numeroDoc
                                    ,[fecha_vencimiento] as fechaVence
                                    ,[detalle] as detalleDoc
                                    ,[importe] as importeDoc
                                    ,[acumulado] as acumuladoDoc
                                    ,[resta] as restaDoc
                                    ,[signo] as signoDoc
                                    FROM cxp ";
                    var sql_2 = "where estatus='0' and cancelado='0' and auto_proveedor = @p1 ";
                    var sql = sql_1 + sql_2;
                    var list = cn.Database.SqlQuery<DTO.ToolPago.PendPagar.Ficha>(sql, p1).ToList();
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
        public DTO.Resutado.AutoId ToolPago_GenerarPago(DTO.ToolPago.GenerarPago.Ficha ficha)
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


                        // ACTUALIZAR CONTADOR DE RECIBO DE PAGO
                        var sql = "update contadores set a_cxp_recibos=a_cxp_recibos+1, a_cxp_recibos_numero=a_cxp_recibos_numero+1";
                        var r1 = cn.Database.ExecuteSqlCommand(sql);
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


                        // ACTUALIZAR SALDOS DOCUMENTOS
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
                            entCxP.acumulado += r.montoAbonado;
                            entCxP.resta -= r.montoAbonado;
                            if (entCxP.resta == 0m)
                            {
                                entCxP.cancelado = "1";
                            }
                            cn.SaveChanges();
                        }

                        // ACTUALIZAR CONTADOR CXP
                        sql = "update contadores set a_cxp=a_cxp+1";
                        r1 = cn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            rt.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        var aCxP = cn.Database.SqlQuery<int>("select a_cxp from contadores").FirstOrDefault();
                        var autoCxP = aCxP.ToString().Trim().PadLeft(10, '0');

                        // GENERAR CXP EL MOVIMIENTO DE PAGO
                        var cxp = ficha.cxp;
                        var nEntCxP = new cxp()
                        {
                            acumulado = cxp.acumulado,
                            agencia = "",
                            auto = autoCxP,
                            auto_agencia = "",
                            auto_documento = autoRecibo,
                            auto_mov_entrada = "",
                            auto_movimiento = "",
                            auto_proveedor = cxp.autoProv,
                            cancelado = cxp.estatusPagado,
                            ci_rif = cxp.ciRifProv,
                            codigo_proveedor = cxp.codigoProv,
                            detalle = cxp.detalle,
                            documento = numRecibo,
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
                        

                        // GENERAR RECIBO DE PAGO
                        var rec = ficha.recibo;
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
                            detalle = rec.detalle,
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


                        // REGISTRAR DOCUMENTOS PAGADOS EN EL RECIBO
                        var sqlCxPDocumento = @"INSERT INTO cxp_documentos
                                            (item, operacion ,monto ,auto_cxp ,documento ,auto_cxp_pago ,tipo 
                                            ,fecha ,detalle ,auto_cxp_recibo ,numero_recibo ,origen)
                                            VALUES 
                                            (@item, @operacion ,@monto ,@auto_cxp ,@documento ,@auto_cxp_pago ,@tipo 
                                            ,@fecha ,@detalle ,@auto_cxp_recibo ,@numero_recibo ,@origen)";
                        foreach (var d in ficha.docInvRecibo)
                        {
                            var p1 = new SqlParameter("@item", d.nItem);
                            var p2 = new SqlParameter("@operacion", d.operacionEjecutar);
                            var p3 = new SqlParameter("@monto", d.montoImporte);
                            var p4 = new SqlParameter("@auto_cxp", d.autoCxPDocInv);
                            var p5 = new SqlParameter("@documento", d.numDocInv);
                            var p6 = new SqlParameter("@auto_cxp_pago", autoCxP);
                            var p7 = new SqlParameter("@tipo", d.tipoDocInv);
                            var p8 = new SqlParameter("@fecha", fechaSistema.Date);
                            var p9 = new SqlParameter("@detalle", d.detalle);
                            var p10 = new SqlParameter("@auto_cxp_recibo", autoRecibo);
                            var p11 = new SqlParameter("@numero_recibo", numRecibo);
                            var p12 = new SqlParameter("@origen", d.nombreDocInv);
                            var p13 = new SqlParameter("@monto_pendiente", 0m);
                            cn.Database.ExecuteSqlCommand(sqlCxPDocumento, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
                            cn.SaveChanges();
                        }


                        // REGISTRAR FORMAS DE PAGO
                        foreach (var mv in ficha.formasPago)
                        {
                            var mPag = mv;
                            var xp1 = new SqlParameter("@auto_recibo", autoRecibo);
                            var xp2 = new SqlParameter("@auto_movimientos", "");
                            var xp3 = new SqlParameter("@numero", "");
                            var xp4 = new SqlParameter("@banco", mPag.banco);
                            var xp5 = new SqlParameter("@importe", mPag.importe);
                            var xp6 = new SqlParameter("@nombre", "");
                            var xp7 = new SqlParameter("@fecha", fechaSistema.Date);
                            var xp8 = new SqlParameter("@estatus_anulado", mPag.estatusAnulado);
                            var xp9 = new SqlParameter("@codigo_medio_pago", mPag.codigoMedioPago);
                            var xp10 = new SqlParameter("@desc_medio_pago", mPag.descMedioPago);
                            var xp11 = new SqlParameter("@factorCambio", mPag.factorCambio);
                            var xp12 = new SqlParameter("@aplicaFactorCambio", mPag.aplicaFactorCambio);
                            var xp13 = new SqlParameter("@numeroChequeRef", mPag.numeroChequeRef);
                            var xp14 = new SqlParameter("@numeroCta", mPag.numeroChequeRef);
                            var xp15 = new SqlParameter("@fechaOperacion", mPag.fechaOperacion);
                            var xp16 = new SqlParameter("@detalleOperacion", mPag.detalleOperacion);
                            var xp17 = new SqlParameter("@monto", mPag.montoRecibido);
                            var sqlModoPago = @"INSERT INTO cxp_modo_pago
                                            (auto_recibo, auto_movimientos ,numero ,banco ,importe 
                                            ,nombre ,fecha ,estatus_anulado ,codigo_medio_pago ,desc_medio_pago,
                                            factorCambio, aplicaFactorCambio, numeroChequeRef, numeroCta,
                                            fechaOperacion, detalleOperacion, monto)
                                            VALUES
                                            (@auto_recibo, @auto_movimientos ,@numero ,@banco ,@importe 
                                            ,@nombre ,@fecha ,@estatus_anulado ,@codigo_medio_pago ,@desc_medio_pago,
                                            @factorCambio, @aplicaFactorCambio, @numeroChequeRef, @numeroCta,
                                            @fechaOperacion, @detalleOperacion, @monto)";
                            cn.Database.ExecuteSqlCommand(sqlModoPago, xp1, xp2, xp3, xp4, xp5, xp6, xp7, xp8, xp9, xp10, xp11, xp12, xp13, xp14, xp15, xp16, xp17);
                            cn.SaveChanges();
                        }
                        rt.Auto = autoRecibo;
                        rt.Id = -1;
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

    }

}