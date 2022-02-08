using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.ToolPago.PendPagar
{
    
    public class Ficha
    {

        public string autoDoc { get; set; }
        public DateTime fechaEmision { get; set; }
        public string tipoDoc { get; set; }
        public string numeroDoc { get; set; }
        public DateTime fechaVence { get; set; }
        public string detalleDoc { get; set; }
        public decimal importeDoc { get; set; }
        public decimal acumuladoDoc { get; set; }
        public decimal restaDoc { get; set; }
        public int signoDoc { get; set; }
        public int diasPend 
        {
            get 
            {
                var rt = DateTime.Now.Subtract(fechaVence).Days;
                if (rt < 0)
                    rt = 0;
                return rt;
            }
        }


        public Ficha()
        {
            autoDoc = "";
            fechaEmision = DateTime.Now.Date;
            tipoDoc = "";
            numeroDoc = "";
            fechaVence = DateTime.Now.Date;
            detalleDoc = "";
            importeDoc = 0m;
            acumuladoDoc = 0m;
            restaDoc = 0m;
            signoDoc = 1;
        }

    }

}