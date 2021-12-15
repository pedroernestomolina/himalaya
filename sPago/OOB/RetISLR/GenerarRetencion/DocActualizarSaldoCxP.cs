using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.GenerarRetencion
{
    
    public class DocActualizarSaldoCxP
    {

        public string idDocCxP { get; set; }
        public decimal montoAbonado { get; set; }


        public DocActualizarSaldoCxP()
        {
            idDocCxP = "";
            montoAbonado = 0m;
        }

    }

}