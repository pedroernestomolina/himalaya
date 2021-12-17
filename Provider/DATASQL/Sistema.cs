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

        public DTO.Resutado.Entidad<DTO.Sistema.DocAnulado.Entidad.Ficha> Sistema_DocAnulado_Buscar(DTO.Sistema.DocAnulado.Buscar.Ficha ficha)
        {
            var result = new DTO.Resutado.Entidad<DTO.Sistema.DocAnulado.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("@autoDoc", ficha.autoDoc);
                    var p2 = new SqlParameter("@origenModulo", ficha.moduloOrigen);
                    var sql= @"select fecha as fechaAnu, hora as horaAnu, estacion, 
                                usuario as usuNombre, codigo_usuario as usuCodigo, detalle as detalleAnu 
                                from documentos_anulados
                                where auto_documento=@autoDoc and codigo=@origenModulo";
                    var ent = cn.Database.SqlQuery<DTO.Sistema.DocAnulado.Entidad.Ficha>(sql,p1,p2).FirstOrDefault();
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