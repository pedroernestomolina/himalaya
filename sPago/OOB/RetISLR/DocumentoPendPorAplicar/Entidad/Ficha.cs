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