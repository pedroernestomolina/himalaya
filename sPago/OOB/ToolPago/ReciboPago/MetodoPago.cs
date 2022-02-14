using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.ToolPago.ReciboPago
{
    
    public class MetodoPago
    {

        public string banco { get; set; }
        public decimal importe { get; set; }
        public string codigoMedioPago { get; set; }
        public string descMedioPago { get; set; }
        public decimal factorCambio { get; set; }
        public string aplicaFactorCambio { get; set; }
        public string numeroChequeRef { get; set; }
        public string numeroCta { get; set; }
        public DateTime fechaOperacion { get; set; }
        public string detalleOperacion { get; set; }
        public decimal montoRecibido { get; set; }
        public bool factorCambioIsActivo { get { return aplicaFactorCambio == "1" ? true : false; } }


        public MetodoPago() 
        {
            codigoMedioPago = "";
            descMedioPago = "";
            importe = 0m;
            montoRecibido = 0m;
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