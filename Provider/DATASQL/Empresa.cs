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

        public DTO.Resutado.Entidad<DTO.Empresa.Entidad.Ficha> Empresa_GetFicha()
        {
            var result = new DTO.Resutado.Entidad<DTO.Empresa.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var sql = @"select nombre as nombreRazonSocial, direccion as dirFiscal, rif as ciRif, telefono_1,
                                telefono_2, telefono_3, telefono_4
                                from empresa";
                    var ent = cn.Database.SqlQuery<DTO.Empresa.Entidad.Ficha>(sql).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "ENTIDAD EMPRESA NO ENCONTRADO";
                        result.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return result;
                    }
                    result.MiEntidad = ent;
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