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

    }

}