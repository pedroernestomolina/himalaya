using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.ToolPago.ReciboPago
{
    
    public class Recibo
    {

        public string numeroRecibo { get; set; }
        public DateTime fechaRecibo { get; set; }
        public decimal importe { get; set; }
        public string nombreUsuario { get; set; }
        public string detalle { get; set; }
        public string ciRifProv { get; set; }
        public string codigoProv { get; set; }
        public string nombreRazonSocialProv { get; set; }
        public string dirFiscalProv { get; set; }
        public string telefonoProv { get; set; }
        public string estatusAnulado { get; set; }
        public int cantDocInvolucrado { get; set; }
        public decimal montoRecibido { get; set; }
        public decimal montoCambio { get; set; }


        public Recibo()
        {
            numeroRecibo = "";
            fechaRecibo = DateTime.Now.Date;
            importe = 0m;
            nombreUsuario = "";
            detalle = "";
            ciRifProv = "";
            codigoProv = "";
            nombreRazonSocialProv = "";
            dirFiscalProv = "";
            telefonoProv = "";
            estatusAnulado = "";
            cantDocInvolucrado = 0;
            montoRecibido = 0m;
            montoCambio = 0m;
        }

    }

}