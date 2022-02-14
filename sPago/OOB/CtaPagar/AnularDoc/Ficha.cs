using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.CtaPagar.AnularDoc
{
    
    public class Ficha
    {

        public string autoDoc { get; set; }
        public ProvActualizar proveedorAct { get; set; }
        public Auditoria regAuditoria { get; set; }


        public Ficha() 
        {
            autoDoc = "";
            proveedorAct = new ProvActualizar();
            regAuditoria = new Auditoria();
        }

    }

}
