using sPago.DataProvider.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.Data
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.Lista<OOB.CtaPagar.Lista.Ficha> CtaPagar_GetLista(OOB.CtaPagar.Lista.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.CtaPagar.Lista.Ficha>();

            var filtroDto = new DTO.CtaPagar.Lista.Filtro()
            {
                autoProv = filtro.autoProv,
                desde = filtro.desde,
                estatus = (DTO.CtaPagar.Lista.Filtro.enumEstatus)filtro.estatus,
                hasta = filtro.hasta,
                tipoDoc = (DTO.CtaPagar.Lista.Filtro.enumTipoDoc)filtro.tipoDoc,
            };
            var r01 = MyData.CtaPagar_GetLista(filtroDto);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.CtaPagar.Lista.Ficha>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.CtaPagar.Lista.Ficha()
                        {
                            abonadoDoc = Math.Abs(s.abonadoDoc),
                            autoDoc = s.autoDoc.Trim(),
                            autoProveedor = s.autoProveedor.Trim(),
                            estatusDoc = s.estatusDoc.Trim(),
                            fechaEmisionDoc = s.fechaEmisionDoc,
                            fechaVenceDoc = s.fechaVenceDoc,
                            importeDoc = Math.Abs(s.importeDoc),
                            numDoc = s.numDoc.Trim(),
                            provCiRif = s.provCiRif.Trim(),
                            provNombre = s.provNombre.Trim(),
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
        public OOB.Resultado.Entidad<OOB.CtaPagar.Entidad.Ficha> CtaPagar_GetById(string id)
        {
            var rt = new OOB.Resultado.Entidad<OOB.CtaPagar.Entidad.Ficha>();

            var r01 = MyData.CtaPagar_GetById(id);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.MiEntidad;
            var rg = new OOB.CtaPagar.Entidad.Ficha()
            {
                autoDocRef = s.autoDocRef.Trim(),
                autoProv = s.autoProv.Trim(),
                codigoModuloOrigen = s.codigoModuloOrigen.Trim(),
                estatusCanceladoDoc = s.estatusCanceladoDoc.Trim(),
                fechaRegistro = s.fechaRegistro,
                numeroDoc = s.numeroDoc.Trim(),
                provCodigo = s.provCodigo.Trim(),
                abonadoDoc = Math.Abs(s.abonadoDoc),
                autoDoc = s.autoDoc.Trim(),
                estatusDoc = s.estatusDoc.Trim(),
                fechaEmisionDoc = s.fechaEmisionDoc,
                fechaVenceDoc = s.fechaVenceDoc,
                importeDoc = Math.Abs(s.importeDoc),
                provCiRif = s.provCiRif.Trim(),
                provNombre = s.provNombre.Trim(),
                restaDoc = Math.Abs(s.restaDoc),
                signoDoc = s.signoDoc,
                detalleDoc = s.detalleDoc.Trim(),
                tipoDoc = s.tipoDoc.Trim(),
            };
            rt.MiEntidad = rg;

            return rt;
        }
        public OOB.Resultado.AutoId CtaPagar_Agregar(OOB.CtaPagar.Agregar.Ficha ficha)
        {
            var rt = new OOB.Resultado.AutoId();

            var fichaDTO = new DTO.CtaPagar.Agregar.Ficha()
            {
                abonadoDoc = ficha.abonadoDoc,
                autoProv = ficha.autoProv,
                codigoModuloOrigen = ficha.codigoModuloOrigen,
                detalleDoc = ficha.detalleDoc,
                estatusCanceladoDoc = ficha.estatusCanceladoDoc,
                estatusDoc = ficha.estatusDoc,
                fechaEmisionDoc = ficha.fechaEmisionDoc,
                fechaVenceDoc = ficha.fechaVenceDoc,
                importeDoc = ficha.importeDoc,
                numeroDoc = ficha.numeroDoc,
                provCiRif = ficha.provCiRif,
                provCodigo = ficha.provCodigo,
                provNombre = ficha.provNombre,
                restaDoc = ficha.restaDoc,
                signoDoc = ficha.signoDoc,
                tipoDoc = ficha.tipoDoc,
                proveedorAct = new DTO.CtaPagar.Agregar.ProvActualizar()
                {
                    autoProv = ficha.proveedorAct.autoProv,
                    credito = ficha.proveedorAct.credito,
                    debito = ficha.proveedorAct.debito,
                },
            };
            var r01 = MyData.CtaPagar_Agregar(fichaDTO);
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
        public OOB.Resultado.Ficha CtaPagar_AnularDoc(OOB.CtaPagar.AnularDoc.Ficha ficha)
        {
            var rt = new OOB.Resultado.Ficha();

            var ss = ficha.regAuditoria;
            var fichaDTO = new DTO.CtaPagar.AnularDoc.Ficha()
            {
                autoDoc = ficha.autoDoc,
                proveedorAct = new DTO.CtaPagar.AnularDoc.ProvActualizar()
                {
                    autoProv = ficha.proveedorAct.autoProv,
                    credito = ficha.proveedorAct.credito,
                    debito = ficha.proveedorAct.debito,
                },
                regAuditoria = new DTO.CtaPagar.AnularDoc.Auditoria()
                {
                    autoDoc = ss.autoDoc,
                    detalle = ss.detalle,
                    equipoEstacion = ss.equipoEstacion,
                    moduloOrigen = ss.moduloOrigen,
                    usuCodigo = ss.usuCodigo,
                    usuNombre = ss.usuNombre,
                },
            };
            var r01 = MyData.CtaPagar_AnularDoc(fichaDTO);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado.Lista<OOB.CtaPagar.AnularPago.CtaPagarActualizar> CtaPagar_AnularPago_DocumentosInvolucrados(string autoCxP)
        {
            var rt = new OOB.Resultado.Lista<OOB.CtaPagar.AnularPago.CtaPagarActualizar>() ;

            var r01 = MyData.CtaPagar_AnularPago_DocumentosInvolucrados (autoCxP);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var lst = new List<OOB.CtaPagar.AnularPago.CtaPagarActualizar>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.CtaPagar.AnularPago.CtaPagarActualizar()
                        {
                            autoCxP = s.autoCxP,
                            monto = s.monto,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaEntidad = lst;

            return rt;
        }
        public OOB.Resultado.Ficha CtaPagar_AnularPago(OOB.CtaPagar.AnularPago.Ficha ficha)
        {
            var rt = new OOB.Resultado.Ficha();

            var ss = ficha.regAuditoria;
            var fichaDTO = new DTO.CtaPagar.AnularPago.Ficha()
            {
                autoCxP = ficha.autoCxP,
                autoRecibo = ficha.autoRecibo,
                proveedorAct = new DTO.CtaPagar.AnularPago.ProvActualizar()
                {
                    autoProv = ficha.proveedorAct.autoProv,
                    credito = ficha.proveedorAct.credito,
                    debito = ficha.proveedorAct.debito,
                },
                regAuditoria = new DTO.CtaPagar.AnularPago.Auditoria()
                {
                    autoDoc = ss.autoDoc,
                    detalle = ss.detalle,
                    equipoEstacion = ss.equipoEstacion,
                    moduloOrigen = ss.moduloOrigen,
                    usuCodigo = ss.usuCodigo,
                    usuNombre = ss.usuNombre,
                },
                ctasActualizar = ficha.ctasActualizar.Select(s =>
                {
                    var nr = new DTO.CtaPagar.AnularPago.CtaPagarActualizar()
                    {
                        autoCxP = s.autoCxP,
                        monto = s.monto,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.CtaPagar_AnularPago(fichaDTO);
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