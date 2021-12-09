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

        public DTO.Resutado.AutoId Login_Identificacion(DTO.Login.Identificacion.Ficha ficha)
        {
            var result = new DTO.Resutado.AutoId();

            try
            {
                using (var cn = new  EPago(_cn.ConnectionString))
                {
                    var ent = cn.usuarios.FirstOrDefault(f => f.codigo.Trim().ToUpper() == ficha.codigo &&
                            f.clave.Trim().ToUpper() == ficha.clave);
                    if (ent == null)
                    {
                        result.Mensaje = "USUARIO NO ENCONTRADO";
                        result.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return result;
                    }
                    result.Auto = ent.auto;
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