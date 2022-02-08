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

        public OOB.Resultado.Lista<OOB.MedioPago.Entidad.Ficha> MedioPago_GetLista()
        {
            var rt = new OOB.Resultado.Lista<OOB.MedioPago.Entidad.Ficha>();

            var r01 = MyData.MedioPago_GetLista();
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var lst = new List<OOB.MedioPago.Entidad.Ficha >();
            if (r01.ListaEntidad != null)
            {
                if (r01.ListaEntidad.Count > 0)
                {
                    lst = r01.ListaEntidad.Select(s =>
                    {
                        var rg = new OOB.MedioPago.Entidad.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            descripcion = s.descripcion,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaEntidad = lst;

            return rt;
        }
        public OOB.Resultado.Entidad<OOB.MedioPago.Entidad.Ficha> MedioPago_GetById(int id)
        {
            var rt = new OOB.Resultado.Entidad<OOB.MedioPago.Entidad.Ficha>();

            var r01 = MyData.MedioPago_GetById(id);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.MiEntidad;
            var rg = new OOB.MedioPago.Entidad.Ficha()
            {
                id = s.id,
                codigo = s.codigo.Trim(),
                descripcion = s.descripcion.Trim(),
            };
            rt.MiEntidad = rg;

            return rt;
        }
        public OOB.Resultado.AutoId MedioPago_Agregar(OOB.MedioPago.Agregar.Ficha ficha)
        {
            var rt = new OOB.Resultado.AutoId();

            var fichaDTO = new DTO.MedioPago.Agregar.Ficha()
            {
                codigo = ficha.codigo,
                descripcion = ficha.descripcion,
            };
            var r01 = MyData.MedioPago_Agregar(fichaDTO);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Id = r01.Id;

            return rt;
        }
        public OOB.Resultado.Ficha MedioPago_Editar(OOB.MedioPago.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado.Ficha();

            var fichaDTO = new DTO.MedioPago.Editar.Ficha()
            {
                id = ficha.id,
                codigo = ficha.codigo,
                descripcion = ficha.descripcion,
            };
            var r01 = MyData.MedioPago_Editar(fichaDTO);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado.Ficha MedioPago_Eliminar(int id)
        {
            var rt = new OOB.Resultado.Ficha();

            var r01 = MyData.MedioPago_Eliminar(id);
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