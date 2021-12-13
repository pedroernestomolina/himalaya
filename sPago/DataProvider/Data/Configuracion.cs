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

        public OOB.Resultado.Entidad<string> Configuracion_Proveedor_PreferenciaBusqueda()
        {
            var rt = new OOB.Resultado.Entidad<string>();

            var r01 = MyData.Configuracion_Proveedor_PreferenciaBusqueda();
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.MiEntidad = r01.MiEntidad.Trim().ToUpper();

            return rt;
        }

        public OOB.Resultado.Entidad<string> Configuracion_Sistema_ClaveNivelMaximo()
        {
            var rt = new OOB.Resultado.Entidad<string>();

            var r01 = MyData.Configuracion_Sistema_ClaveNivelMaximo();
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.MiEntidad = r01.MiEntidad.Trim();

            return rt;
        }

        public OOB.Resultado.Entidad<string> Configuracion_Sistema_ClaveNivelMedio()
        {
            var rt = new OOB.Resultado.Entidad<string>();

            var r01 = MyData.Configuracion_Sistema_ClaveNivelMedio();
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.MiEntidad = r01.MiEntidad.Trim();

            return rt;
        }

        public OOB.Resultado.Entidad<string> Configuracion_Sistema_ClaveNivelMinimo()
        {
            var rt = new OOB.Resultado.Entidad<string>();

            var r01 = MyData.Configuracion_Sistema_ClaveNivelMinimo();
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.MiEntidad = r01.MiEntidad.Trim();

            return rt;
        }

    }

}