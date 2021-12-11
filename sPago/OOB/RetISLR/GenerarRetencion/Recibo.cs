using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.GenerarRetencion
{
    
    public class Recibo
    {

        public string autoUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public decimal importe { get; set; }
        public string autoProv { get; set; }
        public string ciRifProv { get; set; }
        public string codigoProv { get; set; }
        public string nombreRazonSocialProv { get; set; }
        public string dirFiscalProv { get; set; }
        public string telefonoProv { get; set; }
        public string estatusAnulado { get; set; }
        public int cantDocInvolucrado { get; set; }
        public decimal montoRecibido { get; set; }
        public decimal montoCambio { get; set; }
        public string notas { get; set; }


        public Recibo() 
        {
            autoUsuario = "";
            nombreUsuario = "";
            importe = 0m;
            autoProv = "";
            codigoProv = "";
            ciRifProv = "";
            nombreRazonSocialProv = "";
            dirFiscalProv = "";
            telefonoProv = "";
            estatusAnulado= "";
            cantDocInvolucrado = 0;
            montoRecibido = 0m;
            montoCambio = 0m;
            notas = "";
        }

    }

}