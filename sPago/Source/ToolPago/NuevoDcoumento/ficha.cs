using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.NuevoDcoumento
{
    
    public class ficha
    {
        private string p1;
        private string p2;


        public string id { get; set; }
        public string desc { get; set; }


        public ficha() 
        {
            id = "";
            desc = "";
        }

        public ficha(string id, string desc)
            :this()
        {
            this.id = id;
            this.desc = desc;
        }

    }

}