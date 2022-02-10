using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.ToolPago.GenerarPago
{
    
    public class FormaPago
    {

        public string codigoMedioPago { get; set; }
        public string descMedioPago { get; set; }
        public decimal importe { get; set; }
        public decimal montoRecibido { get; set; }
        public string estatusAnulado { get; set; }
        public decimal factorCambio { get; set; }
        public string aplicaFactorCambio { get; set; }
        public string banco { get; set; }
        public string numeroCta { get; set; }
        public string numeroChequeRef { get; set; }
        public DateTime fechaOperacion { get; set; }
        public string detalleOperacion { get; set; }


        public FormaPago() 
        {
            codigoMedioPago = "";
            descMedioPago = "";
            importe = 0m;
            montoRecibido = 0m;
            estatusAnulado = "";
            factorCambio = 0m;
            aplicaFactorCambio = "";
            banco = "";
            numeroCta = "";
            numeroChequeRef="";
            fechaOperacion = DateTime.Now.Date;
            detalleOperacion = "";
        }

    }

}