using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaPagar.AnularDoc
{
    
    public class ProvActualizar
    {

        public string autoProv { get; set; }
        public decimal debito { get; set; }
        public decimal credito { get; set; }


        public ProvActualizar() 
        {
            autoProv = "";
            debito = 0m;
            credito = 0m;
        }

    }

}