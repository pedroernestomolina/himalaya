using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.DocumentoPendPorAplicar.Entidad
{

    public class Ficha
    {

        public string autoDoc { get; set; }
        public string autoCxP { get; set; }
        public string numDoc { get; set; }
        public string numControlDoc { get; set; }
        public string serieDoc { get; set; }
        public DateTime fechaDoc { get; set; }
        public string tipoDoc { get; set; }
        public decimal montoBase { get; set; }
        public decimal montoExento { get; set; }
        public decimal montoIva { get; set; }
        public decimal total { get; set; }
        public string estatus { get; set; }
        public decimal Base_1 { get; set; }
        public decimal Base_2 { get; set; }
        public decimal Base_3 { get; set; }
        public decimal Iva_1 { get; set; }
        public decimal Iva_2 { get; set; }
        public decimal Iva_3 { get; set; }
        public decimal TasaIva_1 { get; set; }
        public decimal TasaIva_2 { get; set; }
        public decimal TasaIva_3 { get; set; }
        public string DocAplica { get; set; }
        public int signo
        {
            get
            {
                var rt = 1;
                if (tipoDoc=="03")
                {
                    rt = -1;
                }
                return rt;
            }
        }

        public string TipoDocumento
        {
            get 
            {
                var rt = "";
                switch (tipoDoc) 
                {
                    case "01":
                        rt = "FACTURA";
                        break;
                    case "02":
                        rt = "NOTA DEBITO";
                        break;
                    case "03":
                        rt = "NOTA CREDITO";
                        break;
                    case "04":
                        rt = "NOTA ENTREGA";
                        break;
                }
                return rt;
            }
        }


        public Ficha() 
        {
            autoDoc = "";
            autoCxP = "";
            numDoc = "";
            numControlDoc = "";
            serieDoc = "";
            fechaDoc = DateTime.Now.Date;
            tipoDoc = "";
            montoBase = 0m;
            montoExento = 0m;
            montoIva = 0m;
            total = 0m;
            estatus = "";
            Base_1 = 0m;
            Base_2 = 0m;
            Base_3 = 0m;
            Iva_1 = 0m;
            Iva_2 = 0m;
            Iva_3 = 0m;
            TasaIva_1 = 0m;
            TasaIva_2 = 0m;
            TasaIva_3 = 0m;
            DocAplica = "";
        }

    }

}