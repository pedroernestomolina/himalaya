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

        public OOB.Resultado.Entidad<int> RetISLR_ContadorUltimaRetencion()
        {
            var rt = new OOB.Resultado.Entidad<int>();

            var r01 = MyData.RetISLR_ContadorUltimaRetencion ();
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.MiEntidad = r01.MiEntidad;

            return rt;
        }

        //
        public OOB.Resultado.Lista<OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentosPendPorAplicar_GetLista(OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>();

            var filtroDto = new DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro()
            {
                idProv = filtro.idProv,
            };
            var r01 = MyData.RetISLR_DocumentosPendPorAplicar_GetLista(filtroDto);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha()
                        {
                            autoDoc = s.autoDoc.Trim().ToUpper(),
                            estatus = s.estatus.Trim().ToUpper(),
                            fechaDoc = s.fechaDoc,
                            montoBase = s.montoBase,
                            montoExento = s.montoExento,
                            montoIva = s.montoIva,
                            numControlDoc = s.numControlDoc.Trim().ToUpper(),
                            numDoc = s.numDoc.Trim().ToUpper(),
                            serieDoc = s.serieDoc.Trim().ToUpper(),
                            tipoDoc = s.tipoDoc.Trim().ToUpper(),
                            total = s.total,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaEntidad = lst;

            return rt;
        }
        public OOB.Resultado.Entidad<OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentoPendPorAplicar_GetByIdDoc(string idDoc)
        {
            var rt = new OOB.Resultado.Entidad<OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>();

            var r01 = MyData.RetISLR_DocumentoPendPorAplicar_GetByIdDoc(idDoc);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var ent = r01.MiEntidad;
            rt.MiEntidad = new OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha()
            {
                autoDoc = ent.autoDoc.Trim().ToUpper(),
                autoCxP=ent.autoCxP.Trim().ToUpper(),
                estatus = ent.estatus.Trim().ToUpper(),
                fechaDoc = ent.fechaDoc,
                montoBase = ent.montoBase,
                montoExento = ent.montoExento,
                montoIva = ent.montoIva,
                numControlDoc = ent.numControlDoc.Trim().ToUpper(),
                numDoc = ent.numDoc.Trim().ToUpper(),
                serieDoc = ent.serieDoc.Trim().ToUpper(),
                tipoDoc = ent.tipoDoc.Trim().ToUpper(),
                total = ent.total,
                Base_1 = ent.Base_1,
                Base_2 = ent.Base_2,
                Base_3 = ent.Base_3,
                DocAplica = ent.DocAplica.Trim().ToUpper(),
                Iva_1 = ent.Iva_1,
                Iva_2 = ent.Iva_2,
                Iva_3 = ent.Iva_3,
                TasaIva_1 = ent.TasaIva_1,
                TasaIva_2 = ent.TasaIva_2,
                TasaIva_3 = ent.TasaIva_3,
            };

            return rt;
        }

        //
        public OOB.Resultado.Lista<OOB.RetISLR.Entidad.Ficha> RetISLR_GetLista(OOB.RetISLR.Lista.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.RetISLR.Entidad.Ficha>();

            var filtroDto = new DTO.RetISLR.Lista.Filtro()
            {
                desde = filtro.desde,
                hasta = filtro.hasta,
                tipoRetencion = filtro.tipoRetencion,
                estatus = filtro.estatus,
                idProv = filtro.idProv,
            };
            var r01 = MyData.RetISLR_GetLista(filtroDto);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.RetISLR.Entidad.Ficha>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.RetISLR.Entidad.Ficha()
                        {
                            ciRifProv = s.ciRifProv.Trim().ToUpper(),
                            deFecha = s.deFecha,
                            documento = s.documento.Trim().ToUpper(),
                            estatus = s.estatus.Trim().ToUpper(),
                            id = s.id.Trim().ToUpper(),
                            montoRet = s.montoRet,
                            nombreProv = s.nombreProv.Trim().ToUpper(),
                            tasaRet = s.tasaRet,
                            tipoRetencion = s.tipoRetencion.Trim().ToUpper(),
                            mBase = s.mBase,
                            mExento = s.mExento,
                            mIva = s.mIva,
                            mTotal = s.mTotal,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaEntidad = lst;

            return rt;
        }
        public OOB.Resultado.Entidad<OOB.RetISLR.Entidad.Ficha> RetISLR_GetById(string id)
        {
            var rt = new OOB.Resultado.Entidad<OOB.RetISLR.Entidad.Ficha>();

            var r01 = MyData.RetISLR_GetById(id);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.MiEntidad;
            var rg = new OOB.RetISLR.Entidad.Ficha()
            {
                ciRifProv = s.ciRifProv.Trim().ToUpper(),
                deFecha = s.deFecha,
                documento = s.documento.Trim().ToUpper(),
                estatus = s.estatus.Trim().ToUpper(),
                id = s.id.Trim().ToUpper(),
                montoRet = s.montoRet,
                nombreProv = s.nombreProv.Trim().ToUpper(),
                tasaRet = s.tasaRet,
                tipoRetencion = s.tipoRetencion.Trim().ToUpper(),
                mBase = s.mBase,
                mExento = s.mExento,
                mIva = s.mIva,
                mTotal = s.mTotal,
                anoRelacion = s.anoRelacion,
                codigoProv = s.codigoProv,
                idProv = s.idProv,
                mesRelacion = s.mesRelacion,
                Detalles = s.Detalles.Select(ss => 
                {
                    var nr = new OOB.RetISLR.Entidad.Detalle()
                    {
                        autoDoc = ss.autoDoc,
                        ciRifProv = ss.ciRifProv,
                        estatusAnulado = ss.estatusAnulado,
                        fechaDoc = ss.fechaDoc,
                        montoBase = ss.montoBase,
                        montoBase1 = ss.montoBase1,
                        montoBase2 = ss.montoBase2,
                        montoBase3 = ss.montoBase3,
                        montoExento = ss.montoExento,
                        montoIva = ss.montoIva,
                        montoIva1 = ss.montoIva1,
                        montoIva2 = ss.montoIva2,
                        montoIva3 = ss.montoIva3,
                        montoRetencion = ss.montoRetencion,
                        montoTasa1 = ss.montoTasa1,
                        montoTasa2 = ss.montoTasa2,
                        montoTasa3 = ss.montoTasa3,
                        numControlDoc = ss.numControlDoc,
                        numDoc = ss.numDoc,
                        numDocAplica = ss.numDocAplica,
                        tasaRetencion = ss.tasaRetencion,
                        tipoDoc = ss.tipoDoc,
                        total = ss.total,
                    };
                    return nr;
                }).ToList(),
            };
            rt.MiEntidad = rg;

            return rt;
        }

        //
        public OOB.Resultado.AutoId RetISLR_GenerarRetencion(OOB.RetISLR.GenerarRetencion.Ficha ficha)
        {
            var rt = new OOB.Resultado.AutoId();

            var fichaDTO = new DTO.RetISLR.GenerarRetencion.Ficha();
            var e1 = ficha.retencion;
            fichaDTO.retencion = new DTO.RetISLR.GenerarRetencion.Retencion()
            {
                autoProv = e1.autoProv,
                ciRifProv = e1.ciRifProv,
                codigoProv = e1.codigoProv,
                dirFiscalProv = e1.dirFiscalProv,
                estatusAnulado = e1.estatusAnulado,
                montoBase = e1.montoBase,
                montoExento = e1.montoExento,
                montoIva = e1.montoIva,
                montoRetencion = e1.montoRetencion,
                nombreRazonSocialProv = e1.nombreRazonSocialProv,
                tasaRetencion = e1.tasaRetencion,
                tipoRetencion = e1.tipoRetencion,
                total = e1.total,
            };
            fichaDTO.retencionDet = ficha.retencionDet.Select(s =>
            {
                var nr = new DTO.RetISLR.GenerarRetencion.RetencionDet()
                {
                    autoDoc = s.autoDoc,
                    ciRifProv = s.ciRifProv,
                    estatusAnulado = s.estatusAnulado,
                    fechaDoc = s.fechaDoc,
                    montoBase = s.montoBase,
                    montoBase1 = s.montoBase1,
                    montoBase2 = s.montoBase2,
                    montoBase3 = s.montoBase3,
                    montoExento = s.montoExento,
                    montoIva = s.montoIva,
                    montoIva1 = s.montoIva1,
                    montoIva2 = s.montoIva2,
                    montoIva3 = s.montoIva3,
                    montoRetencion = s.montoRetencion,
                    montoTasa1 = s.montoTasa1,
                    montoTasa2 = s.montoTasa2,
                    montoTasa3 = s.montoTasa3,
                    numControlDoc = s.numControlDoc,
                    numDoc = s.numDoc,
                    numDocAplica = s.numDocAplica,
                    signoDoc = s.signoDoc,
                    tasaRetencion = s.tasaRetencion,
                    tipoDoc = s.tipoDoc,
                    tipoRetencion = s.tipoRetencion,
                    total = s.total,
                };
                return nr;
            }).ToList();
            fichaDTO.docAplicaRet = ficha.docAplicaRet.Select(s =>
            {
                var nr = new DTO.RetISLR.GenerarRetencion.DocAplicaRet()
                {
                    autoDoc = s.autoDoc,
                    montoAplica = s.montoAplica,
                    tasaAplica = s.tasaAplica,
                };
                return nr;
            }).ToList();
            fichaDTO.docActualizarSaldoCxP = ficha.docActualizarSaldoCxP.Select(s =>
            {
                var nr = new DTO.RetISLR.GenerarRetencion.DocActualizarSaldoCxP()
                {
                    idDocCxP = s.idDocCxP,
                    montoAbonado = s.montoAbonado,
                };
                return nr;
            }).ToList();
            var e2 = ficha.cxp;
            fichaDTO.cxp = new DTO.RetISLR.GenerarRetencion.CxP()
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
            fichaDTO.recibo = new DTO.RetISLR.GenerarRetencion.Recibo()
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
                tipoPagoOrigen = e3.origenModuloPago,
            };
            fichaDTO.docInvRecibo = ficha.docInvRecibo.Select(s =>
            {
                var nr = new DTO.RetISLR.GenerarRetencion.DocInvRecibo()
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
            var e4 = ficha.medioPago;
            fichaDTO.medioPago = new DTO.RetISLR.GenerarRetencion.MedioPago()
            {
                codigoMedioPago = e4.codigoMedioPago,
                descMedioPago = e4.descMedioPago,
                estatusAnulado = e4.estatusAnulado,
                montoRecibido = e4.montoRecibido,
            };

            var r01 = MyData.RetISLR_GenerarRetencion(fichaDTO);
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
        public OOB.Resultado.Entidad<OOB.RetISLR.AnularRetencion.Ficha> RetISLR_AnularRetencion_GetData(string idRetencion)
        {
            var rt = new OOB.Resultado.Entidad<OOB.RetISLR.AnularRetencion.Ficha>();

            var r01 = MyData.RetISLR_AnularRetencion_GetData(idRetencion);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.MiEntidad;
            var rg = new OOB.RetISLR.AnularRetencion.Ficha()
            {
                autoDocRetencion = s.autoDocRetencion,
                autoPago = s.autoPago,
                autoRecibo = s.autoRecibo,
                docCompraAplicaRetencion = s.docCompraAplicaRetencion.Select(ss =>
                {
                    var nr = new OOB.RetISLR.AnularRetencion.DocCompraAplicaRetencion()
                    {
                        autoCxP = ss.autoCxP,
                        autoDocCompra = ss.autoDocCompra,
                        montoAplica = ss.montoAplica,
                    };
                    return nr;
                }).ToList(),
            };
            rt.MiEntidad = rg;

            return rt;
        }
        public OOB.Resultado.Ficha RetISLR_AnularRetencion(OOB.RetISLR.AnularRetencion.Ficha ficha)
        {
            var rt = new OOB.Resultado.Ficha();

            var s = ficha;
            var fichaDTO = new DTO.RetISLR.AnularRetencion.Ficha()
            {
                autoDocRetencion = s.autoDocRetencion,
                autoPago = s.autoPago,
                autoRecibo = s.autoRecibo,
                docCompraAplicaRetencion = s.docCompraAplicaRetencion.Select(ss =>
                {
                    var nr = new DTO.RetISLR.AnularRetencion.DocCompraAplicaRetencion()
                    {
                        autoCxP = ss.autoCxP,
                        autoDocCompra = ss.autoDocCompra,
                        montoAplica = ss.montoAplica,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.RetISLR_AnularRetencion (fichaDTO);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}