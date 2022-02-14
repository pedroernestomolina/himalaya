using sPago.DataProvider.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.Data
{
    
    public partial class Provider: IProvider
    {

        public OOB.Resultado.Lista<OOB.ToolPago.ResumenPendPagar.Ficha> ToolPago_ResumenPendPagar_GetLista()
        {
            var rt = new OOB.Resultado.Lista<OOB.ToolPago.ResumenPendPagar.Ficha>();

            var r01 = MyData.ToolsPago_ResumenPendPagar_GetLista();
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.ToolPago.ResumenPendPagar.Ficha>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.ToolPago.ResumenPendPagar.Ficha()
                        {
                            acumulado = s.acumulado,
                            cntDoc = s.cntDoc,
                            importe = s.importe,
                            provCiRif = s.provCiRif,
                            provId = s.provId,
                            provNombre = s.provNombre,
                            resta = s.resta,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaEntidad = lst;

            return rt;
        }
        public OOB.Resultado.Entidad<OOB.ToolPago.ResumenPendPagar.Ficha> ToolPago_ResumenPendPagar_GetByIdProv(string idProv)
        {
            var rt = new OOB.Resultado.Entidad<OOB.ToolPago.ResumenPendPagar.Ficha>();

            var r01 = MyData.ToolsPago_ResumenPendPagar_GetByIdProveedor(idProv);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.MiEntidad;
            var rg = new OOB.ToolPago.ResumenPendPagar.Ficha()
            {
                acumulado = s.acumulado,
                cntDoc = s.cntDoc,
                importe = s.importe,
                provCiRif = s.provCiRif,
                provId = s.provId,
                provNombre = s.provNombre,
                resta = s.resta,
            };
            rt.MiEntidad = rg;

            return rt;
        }
        public OOB.Resultado.Lista<OOB.ToolPago.PendPagar.Ficha> ToolPago_PendPagar_GetByIdProv(string _idProv)
        {
            var rt = new OOB.Resultado.Lista<OOB.ToolPago.PendPagar.Ficha>();

            var r01 = MyData.ToolsPago_PendPagar_GetByIdProv(_idProv);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.ToolPago.PendPagar.Ficha>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.ToolPago.PendPagar.Ficha()
                        {
                            autoDoc=s.autoDoc,
                            numeroDoc = s.numeroDoc.Trim(),
                            acumuladoDoc = Math.Abs(s.acumuladoDoc),
                            fechaEmision = s.fechaEmision,
                            fechaVence = s.fechaVence,
                            importeDoc = Math.Abs(s.importeDoc),
                            restaDoc = Math.Abs(s.restaDoc),
                            signoDoc = s.signoDoc,
                            detalleDoc = s.detalleDoc.Trim(),
                            tipoDoc = s.tipoDoc.Trim(),
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaEntidad = lst;

            return rt;
        }
        public OOB.Resultado.AutoId ToolPago_GenerarPago(OOB.ToolPago.GenerarPago.Ficha ficha)
        {
            var rt = new OOB.Resultado.AutoId();

            var fichaDTO = new DTO.ToolPago.GenerarPago.Ficha();
            fichaDTO.docActualizarSaldoCxP = ficha.docActualizarSaldoCxP.Select(s =>
            {
                var nr = new DTO.ToolPago.GenerarPago.DocActualizarSaldoCxP()
                {
                    idDocCxP = s.idDocCxP,
                    montoAbonado = s.montoAbonado,
                };
                return nr;
            }).ToList();
            var e2 = ficha.cxp;
            fichaDTO.cxp = new DTO.ToolPago.GenerarPago.CxP()
            {
                acumulado = e2.acumulado,
                autoProv = e2.autoProv,
                ciRifProv = e2.ciRifProv,
                codigoProv = e2.codigoProv,
                detalle = e2.detalle,
                estatusAnulado = e2.estatusAnulado,
                estatusPagado = e2.estatusPagado,
                importe = e2.importe,
                moduloOrigen = e2.moduloOrigen,
                montoResta = e2.montoResta,
                nombreRazonSocialProv = e2.nombreRazonSocialProv,
                signo = e2.signo,
                tipoDocGen = e2.tipoDocGen,
            };
            var e3 = ficha.recibo;
            fichaDTO.recibo = new DTO.ToolPago.GenerarPago.Recibo()
            {
                autoProv = e3.autoProv,
                autoUsuario = e3.autoUsuario,
                cantDocInvolucrado = e3.cantDocInvolucrado,
                ciRifProv = e3.ciRifProv,
                codigoProv = e3.codigoProv,
                dirFiscalProv = e3.dirFiscalProv,
                estatusAnulado = e3.estatusAnulado,
                importe = e3.importe,
                montoCambio = e3.montoCambio,
                montoRecibido = e3.montoRecibido,
                nombreRazonSocialProv = e3.nombreRazonSocialProv,
                nombreUsuario = e3.nombreUsuario,
                notas = e3.notas,
                telefonoProv = e3.telefonoProv,
                detalle = e3.detalle,
                tipoPagoOrigen = e3.tipoPagoOrigen,
            };
            fichaDTO.docInvRecibo = ficha.docInvRecibo.Select(s =>
            {
                var nr = new DTO.ToolPago.GenerarPago.DocInvRecibo()
                {
                    autoCxPDocInv = s.autoCxPDocInv,
                    detalle = s.detalle,
                    fechaDocInv = s.fechaDocInv,
                    montoImporte = s.montoImporte,
                    nItem = s.nItem,
                    numDocInv = s.numDocInv,
                    operacionEjecutar = s.operacionEjecutar,
                    tipoDocInv = s.tipoDocInv,
                    nombreDocInv = s.nombreDocInv,
                };
                return nr;
            }).ToList();
            fichaDTO.formasPago = ficha.formasPago.Select(s=> 
            {
                var nr = new DTO.ToolPago.GenerarPago.FormaPago()
                {
                    codigoMedioPago = s.codigoMedioPago,
                    descMedioPago = s.descMedioPago,
                    estatusAnulado = s.estatusAnulado,
                    importe = s.importe,
                    montoRecibido = s.montoRecibido,
                    aplicaFactorCambio = s.aplicaFactorCambio,
                    banco = s.banco,
                    detalleOperacion = s.detalleOperacion,
                    factorCambio = s.factorCambio,
                    fechaOperacion = s.fechaOperacion,
                    numeroChequeRef = s.numeroChequeRef,
                    numeroCta = s.numeroCta,
                };
                return nr;
            }).ToList();
            fichaDTO.proveedorAct = new DTO.ToolPago.GenerarPago.ProvActualizar()
            {
                autoProv = ficha.proveedorAct.autoProv,
                credito = ficha.proveedorAct.credito,
                debito = ficha.proveedorAct.debito,
            };

            var r01 = MyData.ToolsPago_GenerarPago(fichaDTO);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;
            rt.Id = r01.Id;

            return rt;
        }
        public OOB.Resultado.Entidad<OOB.ToolPago.ReciboPago.Ficha> ToolPago_ReciboPago_GetByAutoRecibo(string autoRecibo)
        {
            var rt = new OOB.Resultado.Entidad<OOB.ToolPago.ReciboPago.Ficha>();

            var r01 = MyData.ToolPago_ReciboPago_GetByAutoRecibo(autoRecibo);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.MiEntidad = new OOB.ToolPago.ReciboPago.Ficha();
            var r = r01.MiEntidad.recibo;
            var recibo = new OOB.ToolPago.ReciboPago.Recibo()
            {
                cantDocInvolucrado = r.cantDocInvolucrado,
                ciRifProv = r.ciRifProv.Trim(),
                codigoProv = r.codigoProv.Trim(),
                detalle = r.detalle.Trim(),
                dirFiscalProv = r.dirFiscalProv.Trim(),
                estatusAnulado = r.estatusAnulado.Trim(),
                fechaRecibo = r.fechaRecibo,
                importe = r.importe,
                montoCambio = r.montoCambio,
                montoRecibido = r.montoRecibido,
                nombreRazonSocialProv = r.nombreRazonSocialProv.Trim(),
                nombreUsuario = r.nombreUsuario.Trim(),
                numeroRecibo = r.numeroRecibo.Trim(),
                telefonoProv = r.telefonoProv.Trim(),
            };
            rt.MiEntidad.recibo = recibo;

            rt.MiEntidad.documentos = r01.MiEntidad.documentos.Select(s =>
            {
                var nr = new OOB.ToolPago.ReciboPago.Documento()
                {
                    detalle = s.detalle.Trim(),
                    fechaDoc = s.fechaDoc,
                    monto = s.monto,
                    nItem = s.nItem,
                    nombreDoc = s.nombreDoc.Trim(),
                    numDoc = s.numDoc.Trim(),
                    operacion = s.operacion.Trim(),
                    tipoDoc = s.tipoDoc.Trim(),
                };
                return nr;
            }).ToList();

            rt.MiEntidad.metodosPago = r01.MiEntidad.metodosPago.Select(s =>
            {
                var nr = new OOB.ToolPago.ReciboPago.MetodoPago()
                {
                    aplicaFactorCambio = s.aplicaFactorCambio.Trim(),
                    banco = s.banco.Trim(),
                    codigoMedioPago = s.codigoMedioPago.Trim(),
                    descMedioPago = s.descMedioPago.Trim(),
                    detalleOperacion = s.detalleOperacion.Trim(),
                    factorCambio = s.factorCambio,
                    fechaOperacion = s.fechaOperacion,
                    importe = s.importe,
                    montoRecibido = s.montoRecibido,
                    numeroChequeRef = s.numeroChequeRef.Trim(),
                    numeroCta = s.numeroCta.Trim(),
                };
                return nr;
            }).ToList();

            return rt;
        }

    }

}