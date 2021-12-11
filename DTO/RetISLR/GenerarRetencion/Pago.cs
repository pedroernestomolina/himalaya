using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.RetISLR.GenerarRetencion
{
    
    public class Pago
    {

        public string autoDocGen { get; set; }
        public string tipoDocGen { get; set; }
        public string numDocGen { get; set; }
        public string detalle { get; set; }
        public decimal importe { get; set; }
        public decimal acumulado { get; set; }
        public string autoProv { get; set; }
        public string nombreRazonSocialProv { get; set; }
        public string ciRifProv { get; set; }
        public string codigoProv { get; set; }
        public string estatusAnulado { get; set; }
        public string estatusPagado { get; set; }
        public decimal montoResta { get; set; }
        public string operacion { get; set; }
        public int signo { get; set; }


        public Pago()
        {
            autoDocGen = "";
            tipoDocGen = "";
            numDocGen = "";
            detalle = "";
            importe = 0m;
            acumulado = 0m;
            autoProv = "";
            nombreRazonSocialProv = "";
            ciRifProv = "";
            codigoProv = "";
            estatusAnulado = "";
            estatusPagado = "";
            montoResta = 0m;
            operacion = "";
            signo = 1;
        }

    }

}