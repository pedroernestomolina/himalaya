using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.RetISLR.AnularRetencion.Anular
{

    
    public class DocCompraAplicaRetencion
    {

        public string autoDocCompra { get; set; }
        public string autoCxP { get; set; }
        public decimal montoAplica { get; set; }


        public DocCompraAplicaRetencion()
        {
            autoDocCompra = "";
            autoCxP = "";
            montoAplica = 0m;
        }

    }

}