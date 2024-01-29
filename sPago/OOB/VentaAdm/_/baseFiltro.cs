using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.VentaAdm.__
{
    public abstract class baseFiltro
    {
        public DateTime? desde { get; set; }
        public DateTime? hasta { get; set; }
        public baseFiltro()
        {
        }
    }
}