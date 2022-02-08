using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Reportes.CtasPagar
{
    
    public abstract class baseFiltro
    {

        public enum enumEstatus { SinDefinir = -1, Activo = 1, Anulado };
        public DateTime? desde { get; set; }
        public DateTime? hasta { get; set; }
        public string idProv { get; set; }

    }

}