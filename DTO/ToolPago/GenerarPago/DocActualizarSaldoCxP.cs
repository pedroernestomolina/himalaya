using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.ToolPago.GenerarPago
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