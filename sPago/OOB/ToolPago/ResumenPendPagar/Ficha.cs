using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.ToolPago.ResumenPendPagar
{

    public class Ficha
    {

        public string provId { get; set; }
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public decimal importe { get; set; }
        public decimal acumulado { get; set; }
        public decimal resta { get; set; }
        public int cntDoc { get; set; }


        public Ficha() 
        {
            provId = "";
            provNombre = "";
            provCiRif = "";
            importe = 0m;
            resta = 0m;
            acumulado = 0m;
            cntDoc = 0;
        }

    }

}