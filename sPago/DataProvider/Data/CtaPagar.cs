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
                            abonadoDoc = s.abonadoDoc,
                            autoDoc = s.autoDoc.Trim(),
                            autoProveedor = s.autoProveedor.Trim(),
                            estatusDoc = s.estatusDoc.Trim(),
                            fechaEmisionDoc = s.fechaEmisionDoc,
                            fechaVenceDoc = s.fechaVenceDoc,
                            importeDoc = s.importeDoc,
                            numDoc = s.numDoc.Trim(),
                            provCiRif = s.provCiRif.Trim(),
                            provNombre = s.provNombre.Trim(),
                            restaDoc = s.restaDoc,
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