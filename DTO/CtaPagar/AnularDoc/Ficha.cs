using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaPagar.AnularDoc
{
    
    public class Ficha
    {

        public string autoDoc { get; set; }
        public Auditoria regAuditoria { get; set; }


        public Ficha() 
        {
            autoDoc = "";
            regAuditoria = new Auditoria();
        }

    }

}
