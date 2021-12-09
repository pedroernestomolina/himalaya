using Provider.IDATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
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

    }

}