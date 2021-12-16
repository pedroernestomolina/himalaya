using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.Lista
{
    
    public class Filtro
    {

        public string tipoRetencion { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public string idProv { get; set; }
        public string estatus { get; set; }


        public Filtro()
        {
            tipoRetencion = "";
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
            idProv = "";
            estatus = "";
        }

    }

}