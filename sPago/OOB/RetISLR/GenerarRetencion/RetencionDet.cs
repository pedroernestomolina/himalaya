using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.GenerarRetencion
{
    
    public class RetencionDet
    {

        public string autoDoc { get; set; }
        public string numDoc { get; set; }
        public DateTime fechaDoc { get; set; }
        public decimal montoExento { get; set; }
        public decimal montoBase { get; set; }
        public decimal montoIva { get; set; }
        public decimal total { get; set; }
        public decimal tasaRetencion { get; set; }
        public decimal montoRetencion { get; set; }
        public string numControlDoc { get; set; }
        public string numDocAplica { get; set; }
        public string tipoDoc { get; set; }
        public string ciRifProv { get; set; }
        public string tipoRetencion { get; set; }
        public string estatusAnulado { get; set; }
        public decimal montoIva1 { get; set; }
        public decimal montoIva2 { get; set; }
        public decimal montoIva3 { get; set; }
        public decimal montoBase1 { get; set; }
        public decimal montoBase2 { get; set; }
        public decimal montoBase3 { get; set; }
        public decimal montoTasa1 { get; set; }
        public decimal montoTasa2 { get; set; }
        public decimal montoTasa3 { get; set; }
        public int signoDoc { get; set; }


        public RetencionDet() 
        {
            autoDoc = "";
            numDoc = "";
            fechaDoc = DateTime.Now.Date;
            montoExento = 0m;
            montoBase = 0m;
            montoIva = 0m;
            total = 0m;
            tasaRetencion = 0m;
            montoRetencion = 0m;
            numControlDoc = "";
            numDocAplica = "";
            tipoDoc = "";
            ciRifProv = "";
            tipoRetencion = "";
            estatusAnulado = "";
            montoIva1 = 0m;
            montoIva2 = 0m;
            montoIva3 = 0m;
            montoBase1 = 0m;
            montoBase2 = 0m;
            montoBase3 = 0m;
            montoTasa1 = 0m;
            montoTasa2 = 0m;
            montoTasa3 = 0m;
            signoDoc = 1;
        }

    }

}