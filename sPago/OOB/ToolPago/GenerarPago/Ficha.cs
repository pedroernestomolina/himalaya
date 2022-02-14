using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.ToolPago.GenerarPago
{
    
    public class Ficha
    {

        public CxP cxp{ get; set; }
        public Recibo recibo { get; set; }
        public List<DocInvRecibo> docInvRecibo { get; set; }
        public List<FormaPago> formasPago { get; set; }
        public List<DocActualizarSaldoCxP> docActualizarSaldoCxP { get; set; }
        public ProvActualizar proveedorAct { get; set; }


        public Ficha() 
        {
            cxp= new CxP();
            recibo = new Recibo();
            docInvRecibo = new List<DocInvRecibo>();
            formasPago  = new List<FormaPago>();
            docActualizarSaldoCxP = new List<DocActualizarSaldoCxP>();
            proveedorAct = new ProvActualizar();
        }

    }

}