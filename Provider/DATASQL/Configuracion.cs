using Provider.IDATA;
using SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.DATASQL
{

    public partial class Provider: IProvider
    {

        public DTO.Resutado.Entidad<string> Configuracion_Proveedor_PreferenciaBusqueda()
        {
            var result = new DTO.Resutado.Entidad<string>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var ent = cn.opciones.FirstOrDefault(f => f.codigo == "GLOBAL_06");
                    if (ent == null)
                    {
                        result.Mensaje = "OPCION NO DEFINIDA";
                        result.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return result;
                    }
                    result.MiEntidad = ent.usuario;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return result;
        }

    }

}