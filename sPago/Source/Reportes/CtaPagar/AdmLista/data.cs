using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.CtaPagar.AdmLista
{
    
    public class data
    {

        private AdministradorDoc.data r;


        public AdministradorDoc.data Ficha { get { return r; } }


        public data(AdministradorDoc.data r)
        {
            this.r = r;
        }

    }

}