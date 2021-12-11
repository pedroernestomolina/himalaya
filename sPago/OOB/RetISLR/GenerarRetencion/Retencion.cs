using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.GenerarRetencion
{
    
    public class Retencion
    {

        public string nombreRazonSocialProv { get; set; }
        public string dirFiscalProv { get; set; }
        public string ciRifProv { get; set; }
        public string tipoRetencion { get; set; }
        public decimal montoExento { get; set; }
        public decimal montoBase { get; set; }
        public decimal montoIva { get; set; }
        public decimal total { get; set; }
        public decimal tasaRetencion { get; set; }
        public decimal montoRetencion { get; set; }
        public string autoProv { get; set; }
        public string codigoProv { get; set; }
        public string estatusAnulado { get; set; }


        public Retencion() 
        {
            nombreRazonSocialProv = "";
            dirFiscalProv = "";
            ciRifProv = "";
            tipoRetencion = "";
            montoExento = 0m;
            montoBase = 0m;
            montoIva = 0m;
            total = 0m;
            tasaRetencion = 0m;
            montoRetencion = 0m;
            autoProv="";
            codigoProv="";
            estatusAnulado="";
        }

    }

}