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

        public OOB.Resultado.Lista<OOB.Proveedor.Entidad.Ficha> Proveedor_GetLista(OOB.Proveedor.Lista.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Proveedor.Entidad.Ficha>();

            var filtroDto = new DTO.Proveedor.Lista.Filtro()
            {
                cadena = filtro.cadena,
                metodoBusq = (DTO.Proveedor.enumerados.metodosBusq)filtro.metodoBusq,
            };
            var r01 = MyData.Proveedor_GetLista (filtroDto);
            if (r01.Result ==  DTO.Resutado.Enumerados.EnumResult.isError )
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result =  OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.Proveedor.Entidad.Ficha>();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.Proveedor.Entidad.Ficha()
                        {
                            ciRif = s.ciRif.Trim().ToUpper(),
                            codigo = s.codigo.Trim().ToUpper(),
                            dirFiscal = s.dirFiscal.Trim(),
                            id = s.id.Trim(),
                            nombreRazonSocial = s.nombreRazonSocial.Trim().ToUpper(),
                            estatus = s.estatus.Trim().ToUpper(),
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaEntidad = lst;

            return rt;
        }

        public OOB.Resultado.Entidad<OOB.Proveedor.Entidad.Ficha> Proveedor_GetById(string idProv)
        {
            var rt = new OOB.Resultado.Entidad<OOB.Proveedor.Entidad.Ficha>();

            var r01 = MyData.Proveedor_GetById(idProv);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent = r01.MiEntidad;
            rt.MiEntidad = new OOB.Proveedor.Entidad.Ficha()
            {
                celular1 = ent.celular1.Trim().ToUpper(),
                celular2 = ent.celular2.Trim().ToUpper(),
                contacto = ent.contacto.Trim().ToUpper(),
                email = ent.email.Trim(),
                fechaAlta = ent.fechaAlta,
                retISLR = ent.retISLR,
                retIVA = ent.retIVA,
                telefono1 = ent.telefono1.Trim().ToUpper(),
                telefono2 = ent.telefono2.Trim().ToUpper(),
                telefono3 = ent.telefono3.Trim().ToUpper(),
                telefono4 = ent.telefono4.Trim().ToUpper(),
                ciRif = ent.ciRif.Trim().ToUpper(),
                codigo = ent.codigo.Trim().ToUpper(),
                dirFiscal = ent.dirFiscal.Trim(),
                id = ent.id.Trim(),
                nombreRazonSocial = ent.nombreRazonSocial.Trim().ToUpper(),
                estatus = ent.estatus.Trim(),
            };

            return rt;
        }

    }

}