using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.GenerarRetencion
{
    
    public class DocInvRecibo
    {

        public DateTime fechaDocInv { get; set; }
        public string tipoDocInv { get; set; }
        public string numDocInv { get; set; }
        public decimal montoImporte { get; set; }
        public string operacionEjecutar { get; set; }
        public string autoCxPDocInv { get; set; }
        public string detalle { get; set; }
        public int nItem { get; set; }
        public string nombreDocInv { get; set; }


        public DocInvRecibo()
        {
            fechaDocInv = DateTime.Now;
            tipoDocInv = "";
            numDocInv = "";
            montoImporte = 0m;
            operacionEjecutar = "";
            autoCxPDocInv = "";
            detalle = "";
            nItem = 0;
            nombreDocInv = "";
        }

    }

}