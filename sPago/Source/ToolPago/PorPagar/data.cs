using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.PorPagar
{
    
    public class data
    {
        
        public DateTime fechaEmision { get; set; }
        public string tipoDoc { get; set; }
        public string numeroDoc { get; set; }
        public DateTime fechaVence { get; set; }
        public string detalleDoc { get; set; }
        public decimal importeDoc { get; set; }
        public decimal acumuladoDoc { get; set; }
        public decimal restaDoc { get; set; }
        public int signoDoc { get; set; }
        public int diasTransc
        {
            get
            {
                var rt = 0;
                rt = DateTime.Now.Date.Subtract(fechaVence).Days;
                if (rt <= 0)
                    rt = 0;
                return rt;
            }
        }
        public int diasPend
        {
            get
            {
                var rt = 0;
                rt = DateTime.Now.Date.Subtract(fechaVence).Days;
                if (rt > 0)
                    rt = 0;
                return Math.Abs(rt);
            }
        }


        public data(DateTime fechaEmi, string tipo, string num, DateTime fechaVence, string detalle, 
            decimal importe, decimal acum, decimal resta, int signo) 
        {
            this.fechaEmision =fechaEmi;
            this.tipoDoc = tipo;
            this.numeroDoc = num;
            this.fechaVence = fechaVence;
            this.detalleDoc = detalle;
            this.importeDoc = importe;
            this.acumuladoDoc = acum;
            this.restaDoc = resta;
            this.signoDoc = signo;
        }

    }
    
}