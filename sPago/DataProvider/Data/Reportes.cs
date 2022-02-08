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

        public OOB.Resultado.Lista<OOB.Reportes.CtasPagar.DocumentosPorPagar.Ficha> Reportes_CtaPagar_DocumentosPorPagar(OOB.Reportes.CtasPagar.DocumentosPorPagar.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Reportes.CtasPagar.DocumentosPorPagar.Ficha>();

            var filtroDto = new DTO.Reportes.CtasPagar.DocumentosPorPagar.Filtro()
            {
                idProv = filtro.idProv,
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Reportes_CtaPagar_DocumentosPorPagar(filtroDto);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.Reportes.CtasPagar.DocumentosPorPagar.Ficha>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.Reportes.CtasPagar.DocumentosPorPagar.Ficha()
                        {
                            numeroDoc = s.numeroDoc.Trim(),
                            acumuladoDoc = Math.Abs(s.acumuladoDoc),
                            fechaEmision = s.fechaEmision,
                            fechaVence = s.fechaVence,
                            provCodigo = s.provCodigo.Trim(),
                            importeDoc = Math.Abs(s.importeDoc),
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
        public OOB.Resultado.Lista<OOB.Reportes.CtasPagar.PagosEmitidos.Ficha> Reportes_CtaPagar_PagosEmitidos(OOB.Reportes.CtasPagar.PagosEmitidos.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Reportes.CtasPagar.PagosEmitidos.Ficha>();

            var filtroDto = new DTO.Reportes.CtasPagar.PagosEmitidos.Filtro()
            {
                idProv = filtro.idProv,
                desde = filtro.desde,
                hasta = filtro.hasta,
                estatus = (DTO.Reportes.CtasPagar.baseFiltro.enumEstatus) filtro.estatus,
            };
            var r01 = MyData.Reportes_CtaPagar_PagosEmitidos(filtroDto);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.Reportes.CtasPagar.PagosEmitidos.Ficha>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.Reportes.CtasPagar.PagosEmitidos.Ficha()
                        {
                            cambioDar = s.cambioDar,
                            cntDocRel = s.cntDocRel,
                            codMedioPago = s.codMedioPago.Trim(),
                            descMedioPago = s.descMedioPago.Trim(),
                            detalleRecibo = s.descMedioPago.Trim(),
                            estatusRecibo = s.estatusRecibo.Trim(),
                            fechaRecibo = s.fechaRecibo,
                            importePago = s.importePago,
                            importeRecibo = s.importeRecibo,
                            montoRecibido = s.montoRecibido,
                            nota = s.nota.Trim(),
                            numeroRecibo = s.numeroRecibo.Trim(),
                            provCiRif = s.provCiRif.Trim(),
                            provCodigo = s.provCodigo.Trim(),
                            provDir = s.provDir.Trim(),
                            provNombre = s.provNombre.Trim(),
                            provTelefono = s.provTelefono.Trim(),
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaEntidad = lst;

            return rt;
        }
        public OOB.Resultado.Lista<OOB.Reportes.CtasPagar.RelacionPagoDiario.Ficha> Reportes_CtaPagar_RelacionPagoDiario(OOB.Reportes.CtasPagar.RelacionPagoDiario.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Reportes.CtasPagar.RelacionPagoDiario.Ficha>();

            var filtroDto = new DTO.Reportes.CtasPagar.RelacionPagoDiario.Filtro()
            {
                idProv = filtro.idProv,
                desde = filtro.desde,
                hasta = filtro.hasta,
                estatus = (DTO.Reportes.CtasPagar.baseFiltro.enumEstatus)filtro.estatus,
            };
            var r01 = MyData.Reportes_CtaPagar_RelacionPagoDiario(filtroDto);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.Reportes.CtasPagar.RelacionPagoDiario.Ficha>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.Reportes.CtasPagar.RelacionPagoDiario.Ficha()
                        {
                            cambioDar = s.cambioDar,
                            cntDocRel = s.cntDocRel,
                            detalleRecibo = s.detalleRecibo.Trim(),
                            estatusRecibo = s.estatusRecibo.Trim(),
                            fechaRecibo = s.fechaRecibo,
                            importeRecibo = Math.Abs(s.importeRecibo),
                            montoRecibido = Math.Abs(s.importeRecibo),
                            nota = s.nota.Trim(),
                            numeroRecibo = s.numeroRecibo.Trim(),
                            provCiRif = s.provCiRif.Trim(),
                            provCodigo = s.provCodigo.Trim(),
                            provDir = s.provDir.Trim(),
                            provNombre = s.provNombre.Trim(),
                            provTelefono = s.provTelefono.Trim(),
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaEntidad = lst;

            return rt;
        }
        public OOB.Resultado.Lista<OOB.Reportes.CtasPagar.AnalisisVencimiento.Ficha> Reportes_CtaPagar_AnalisisVencimiento(OOB.Reportes.CtasPagar.DocumentosPorPagar.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Reportes.CtasPagar.AnalisisVencimiento.Ficha>();

            var filtroDto = new DTO.Reportes.CtasPagar.DocumentosPorPagar.Filtro()
            {
                idProv = filtro.idProv,
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Reportes_CtaPagar_DocumentosPorPagar(filtroDto);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.Reportes.CtasPagar.AnalisisVencimiento.Ficha>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.Reportes.CtasPagar.AnalisisVencimiento.Ficha()
                        {
                            numeroDoc = s.numeroDoc.Trim(),
                            acumuladoDoc = Math.Abs(s.acumuladoDoc),
                            fechaEmision = s.fechaEmision,
                            fechaVence = s.fechaVence,
                            provCodigo = s.provCodigo.Trim(),
                            importeDoc = Math.Abs(s.importeDoc),
                            provCiRif = s.provCiRif.Trim(),
                            provNombre = s.provNombre.Trim(),
                            restaDoc = Math.Abs(s.restaDoc),
                            signoDoc = s.signoDoc,
                            tipoDoc = s.tipoDoc.Trim(),
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaEntidad = lst;

            return rt;

        }
    }

}