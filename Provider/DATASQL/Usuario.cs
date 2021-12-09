using Provider.IDATA;
using SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.DATASQL
{

    public partial class Provider: IProvider
    {

        public DTO.Resutado.Entidad<DTO.Usuario.Entidad.Ficha> Usuario_GetById(string id)
        {
            var result = new DTO.Resutado.Entidad<DTO.Usuario.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("p1", id);
                    var sql = @"select u.auto as id, u.nombre as nombreUsu, u.codigo as codigoUsu, 
                    u.estatus as estatusUsu, g.nombre as nombreGrup, g.auto as idGrupo 
                    from usuarios as u 
                    join grupo_usuario as g on u.codigo_grupo=g.auto 
                    where u.auto=@p1";
                    var ent= cn.Database.SqlQuery<DTO.Usuario.Entidad.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "ID USUARIO NO ENCONTRADO";
                        result.Result =  DTO.Resutado.Enumerados.EnumResult.isError ;
                        return result;
                    }
                    result.MiEntidad= ent;
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