using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.GenerarRetencion
{
    
    public class DocActualizarSaldo
    {

        public string idDoc { get; set; }
        public decimal montoAbonado { get; set; }


        public DocActualizarSaldo()
        {
            idDoc = "";
            montoAbonado = 0m;
        }

    }

}