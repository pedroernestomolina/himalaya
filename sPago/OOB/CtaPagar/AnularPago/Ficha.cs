using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.CtaPagar.AnularPago
{
    
    public class Ficha
    {

        public string autoCxP { get; set; }
        public string autoRecibo { get; set; }
        public List<CtaPagarActualizar> ctasActualizar { get; set; }
        public ProvActualizar proveedorAct { get; set; }
        public Auditoria regAuditoria { get; set; }


        public Ficha() 
        {
            autoCxP = "";
            autoRecibo = "";
            ctasActualizar = new List<CtaPagarActualizar>();
            proveedorAct = new ProvActualizar();
            regAuditoria = new Auditoria();
        }

    }

}
