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

        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloPago(string idGrupo)
        {
            var result = new DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("p1", idGrupo);
                    var p2 = new SqlParameter("p2", "0500000000");
                    var sql = @"select estatus, seguridad as nivelSeguridad
                    from grupo_opciones 
                    where codigo_grupo=@p1 and codigo_opcion=@p2";
                    var ent = cn.Database.SqlQuery<DTO.Permiso.Solictud.Ficha>(sql, p1, p2).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "OPCION NO DEFINIDA";
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

        //

        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ElaborarRetencionISLR(string idGrupo)
        {
            var result = new DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("p1", idGrupo);
                    var p2 = new SqlParameter("p2", "0530010000");
                    var sql = @"select estatus, seguridad as nivelSeguridad
                    from grupo_opciones 
                    where codigo_grupo=@p1 and codigo_opcion=@p2";
                    var ent = cn.Database.SqlQuery<DTO.Permiso.Solictud.Ficha>(sql, p1, p2).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "OPCION NO DEFINIDA";
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
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloRetencionISLR(string idGrupo)
        {
            var result = new DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("p1", idGrupo);
                    var p2 = new SqlParameter("p2", "0530000000");
                    var sql = @"select estatus, seguridad as nivelSeguridad
                    from grupo_opciones 
                    where codigo_grupo=@p1 and codigo_opcion=@p2";
                    var ent = cn.Database.SqlQuery<DTO.Permiso.Solictud.Ficha>(sql, p1, p2).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "OPCION NO DEFINIDA";
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
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_AdministradorRetencionISLR(string idGrupo)
        {
            var result = new DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("p1", idGrupo);
                    var p2 = new SqlParameter("p2", "0530020000");
                    var sql = @"select estatus, seguridad as nivelSeguridad
                    from grupo_opciones 
                    where codigo_grupo=@p1 and codigo_opcion=@p2";
                    var ent = cn.Database.SqlQuery<DTO.Permiso.Solictud.Ficha>(sql, p1, p2).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "OPCION NO DEFINIDA";
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
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_AnularRetencionISLR(string idGrupo)
        {
            var result = new DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("p1", idGrupo);
                    var p2 = new SqlParameter("p2", "0530030000");
                    var sql = @"select estatus, seguridad as nivelSeguridad
                    from grupo_opciones 
                    where codigo_grupo=@p1 and codigo_opcion=@p2";
                    var ent = cn.Database.SqlQuery<DTO.Permiso.Solictud.Ficha>(sql, p1, p2).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "OPCION NO DEFINIDA";
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
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ReportesRetencionISLR(string idGrupo)
        {
            var result = new DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("p1", idGrupo);
                    var p2 = new SqlParameter("p2", "0530990000");
                    var sql = @"select estatus, seguridad as nivelSeguridad
                    from grupo_opciones 
                    where codigo_grupo=@p1 and codigo_opcion=@p2";
                    var ent = cn.Database.SqlQuery<DTO.Permiso.Solictud.Ficha>(sql, p1, p2).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "OPCION NO DEFINIDA";
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