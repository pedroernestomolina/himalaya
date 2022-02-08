using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.MedioPago.Entidad
{
    
    public class Ficha
    {

        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }


        public Ficha() 
        {
            id = -1;
            codigo = "";
            descripcion = "";
        }

    }

}