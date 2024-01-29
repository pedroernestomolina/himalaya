using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.VentasAdm.AdmFiltro.Handler
{
    public class data: Vista.Idata
    {
        public DateTime? desde { get; set; }
        public DateTime? hasta { get; set; }
        //
        public data()
        {
        }
    }
}