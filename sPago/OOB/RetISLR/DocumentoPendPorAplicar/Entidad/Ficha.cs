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
        }

    }

}