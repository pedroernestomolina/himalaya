using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaPagar.AnularPago
{
    
    public class CtaPagarActualizar
    {

        public string autoCxP { get; set; }
        public decimal monto { get; set; }


        public CtaPagarActualizar() 
        {
            autoCxP = "";
            monto = 0m;
        }

    }

}