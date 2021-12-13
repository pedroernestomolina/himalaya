using Provider.IDATA;
using SQL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.DATASQL
{
    
    public partial class Provider: IProvider
    {

        static EntityConnectionStringBuilder _cn;
        private string _usuario;
        private string _password;
        private string _bd;
        private string _instancia;


        public Provider(string instancia, string bd)
        {
            _usuario = "usuario";
            _password = "112233-fs";
            _instancia = instancia;
            _bd= bd;
            setConexion();
        }

        private void setConexion()
        {
            _cn = new EntityConnectionStringBuilder();
            _cn.Metadata = "res://*/MPago.csdl|res://*/MPago.ssdl|res://*/MPago.msl";
            _cn.Provider = "System.Data.SqlClient";
            _cn.ProviderConnectionString = "data source=" + _instancia + ";initial catalog=" + _bd+ ";user id=" + _usuario + ";Password=" + _password+";";
        }


        public DTO.Resutado.Entidad<DateTime> FechaSistema()
        {
            var rt = new DTO.Resutado.Entidad<DateTime>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("", "");
                    var sql_1 = @"select getdate()";
                    var sql = sql_1;
                    var ent = cn.Database.SqlQuery<DateTime>(sql, p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        rt.Mensaje = "ERROR AL CAPTURAR FECHA DEL SERVIDOR";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    rt.MiEntidad= ent;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }

    }

}