using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaPagar.AnularPago
{
    
    public class Ficha
    {

        public string autoCxP { get; set; }
        public string autoRecibo { get; set; }
        public List<CtaPagarActualizar> ctasActualizar { get; set; }
        public Auditoria regAuditoria { get; set; }
        public ProvActualizar proveedorAct { get; set; }


        public Ficha() 
        {
            autoCxP = "";
            autoRecibo = "";
            ctasActualizar = new List<CtaPagarActualizar>();
            regAuditoria = new Auditoria();
            proveedorAct = new ProvActualizar();
        }

    }

}