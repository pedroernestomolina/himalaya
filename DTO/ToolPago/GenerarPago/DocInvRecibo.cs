using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.ToolPago.GenerarPago
{
    
    public class DocInvRecibo
    {

        public int nItem { get; set; }
        public DateTime fechaDocInv { get; set; }
        public string tipoDocInv { get; set; }
        public string numDocInv { get; set; }
        public string autoCxPDocInv { get; set; }
        public decimal montoImporte { get; set; }
        public string operacionEjecutar { get; set; }
        public string detalle { get; set; }
        public string nombreDocInv { get; set; }


        public DocInvRecibo()
        {
            nItem = 0;
            fechaDocInv = DateTime.Now;
            tipoDocInv = "";
            numDocInv = "";
            autoCxPDocInv = "";
            montoImporte = 0m;
            operacionEjecutar = "";
            detalle = "";
            nombreDocInv = "";
        }

    }

}