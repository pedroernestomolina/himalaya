using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.MedioPago.Agregar
{
    
    public class Ficha
    {

        public string codigo { get; set; }
        public string descripcion { get; set; }


        public Ficha()
        {
            codigo = "";
            descripcion = "";
        }

    }

}