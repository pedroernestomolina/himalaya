using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.DocumentoPendPorAplicar.CxPagar
{
    
    public class Filtro
    {

        public string idDoc { get; set; }
        public string tipoDoc { get; set; }


        public Filtro() 
        {
            idDoc= "";
            tipoDoc = "";
        }

    }

}