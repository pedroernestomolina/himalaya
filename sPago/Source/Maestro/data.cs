using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Maestro
{
    
    public class data
    {

        public string auto { get; set; }
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }


        public data(int id, string cod, string desc)
        {
            this.auto = id.ToString().Trim();
            this.id = id;
            this.codigo = cod;
            this.descripcion= desc;
        }

    }

}