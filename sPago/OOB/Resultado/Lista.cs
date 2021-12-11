using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Resultado
{

    public class Lista<T> : Ficha
    {

        public List<T> ListaEntidad {get; set;}
        public int cntRegistro 
        {
            get 
            {
                var x = 0;
                if (ListaEntidad != null) { x = ListaEntidad.Count(); }
                return x;
            }
        }

        public Lista()
            :base()
        {
            ListaEntidad = null;
        }

    }

}