using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.Lista
{
    
    public class Filtro
    {

        public enum enumEstatus { SinDefinir = -1, Activo = 1, Anulado };
        public string tipoRetencion { get; set; }
        public DateTime? desde { get; set; }
        public DateTime? hasta { get; set; }
        public string idProv { get; set; }
        public enumEstatus estatus { get; set; }


        public Filtro()
        {
            tipoRetencion = "";
            desde = null;
            hasta = null;
            idProv = "";
            estatus =  enumEstatus.SinDefinir;
        }

    }

}