using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Proveedor.Lista
{
    
    public class data
    {

        private OOB.Proveedor.Entidad.Ficha _ficha;


        public string auto { get { return _ficha.id; } }
        public string ciRif { get { return _ficha.ciRif; } }
        public string razonSocial { get { return _ficha.nombreRazonSocial; } }
        public bool isActivo { get { return _ficha.estatus.Trim().ToUpper() == "ACTIVO" ? true : false; } }
        public string Estatus { get { return isActivo ? "ACTIVO" : "INACTIVO"; } }
        public OOB.Proveedor.Entidad.Ficha Ficha { get { return _ficha; } }


        public data(OOB.Proveedor.Entidad.Ficha ficha)
        {
            _ficha = ficha;
        }

    }

}