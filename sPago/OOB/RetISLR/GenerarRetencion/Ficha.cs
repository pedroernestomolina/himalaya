using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.GenerarRetencion
{
    
    public class Ficha
    {

        public Retencion retencion { get; set; }
        public List<RetencionDet> retencionDet { get; set; }
        public List<DocAplicaRet> docAplicaRet { get; set; }
        public List<DocActualizarSaldoCxP> docActualizarSaldoCxP { get; set; }
        public CxP cxp { get; set; }
        public Recibo recibo { get; set; }
        public List<DocInvRecibo> docInvRecibo { get; set; }
        public MedioPago medioPago { get; set; }
        public ProvActualizar proveedorAct { get; set; }


        public Ficha() 
        {
            retencion = new Retencion();
            retencionDet = new List<RetencionDet>();
            docAplicaRet = new List<DocAplicaRet>();
            docActualizarSaldoCxP = new List<DocActualizarSaldoCxP>();
            cxp= new CxP();
            recibo = new Recibo();
            docInvRecibo = new List<DocInvRecibo>();
            medioPago = new MedioPago();
            proveedorAct = new ProvActualizar();
        }

    }

}