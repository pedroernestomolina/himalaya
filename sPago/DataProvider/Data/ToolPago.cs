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

    }

}