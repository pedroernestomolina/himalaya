using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.RetISLR.GenerarRetencion
{
    
    public class MedioPago
    {

        public string codigoMedioPago { get; set; }
        public string descMedioPago { get; set; }
        public decimal montoRecibido { get; set; }
        public string estatusAnulado { get; set; }


        public MedioPago() 
        {
            codigoMedioPago = "";
            descMedioPago = "";
            montoRecibido = 0m;
            estatusAnulado = "";
        }

    }

}