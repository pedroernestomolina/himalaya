using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.GenerarPago.MetodosPago
{
    
    public class ficha
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string desc { get; set; }
        public int id { get; set; }


        public ficha(string xauto, string xcod, string xdes, int xid) 
        {
            this.auto = xauto;
            this.id = xid;
            this.codigo = xcod;
            this.desc = xdes;
        }

    }

}