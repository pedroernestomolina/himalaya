using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Reportes.CtasPagar.AnalisisVencimiento
{
    
    public class Ficha
    {                
        
        public DateTime fechaEmision { get; set; }
        public string tipoDoc { get; set; }
        public string numeroDoc { get; set; }
        public DateTime fechaVence { get; set; }
        public decimal importeDoc { get; set; }
        public decimal acumuladoDoc { get; set; }
        public decimal restaDoc { get; set; }
        public int signoDoc { get; set; }
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public string provCodigo { get; set; }
        public int diasVencida 
        {
            get
            {
                var rt = 0;
                rt = DateTime.Now.Subtract(fechaVence).Days;
                return rt;
            }
        }
        public decimal porVencer
        {
            get
            {
                var rt = 0m;
                if (fechaVence>=DateTime.Now.Date)
                {
                    rt = restaDoc;
                }
                return rt;
            }
        }
        public decimal vencido 
        {
            get 
            {
                var rt = 0m;
                if (DateTime.Now.Date > fechaVence) 
                {
                    rt = restaDoc;
                }
                return rt;
            }
        }
        public decimal a7Dias
        {
            get
            {
                var rt = 0m;
                if (diasVencida>0 && diasVencida<=7)
                {
                    rt = restaDoc;
                }
                return rt;
            }
        }
        public decimal a15Dias
        {
            get
            {
                var rt = 0m;
                if (diasVencida > 7 && diasVencida <= 15)
                {
                    rt = restaDoc;
                }
                return rt;
            }
        }
        public decimal a30Dias
        {
            get
            {
                var rt = 0m;
                if (diasVencida > 15 && diasVencida <= 30)
                {
                    rt = restaDoc;
                }
                return rt;
            }
        }
        public decimal a45Dias
        {
            get
            {
                var rt = 0m;
                if (diasVencida > 30 && diasVencida <= 45)
                {
                    rt = restaDoc;
                }
                return rt;
            }
        }
        public decimal aMas45Dias
        {
            get
            {
                var rt = 0m;
                if (diasVencida > 45 )
                {
                    rt = restaDoc;
                }
                return rt;
            }
        }


        public Ficha() 
        {
            fechaEmision = DateTime.Now.Date;
            tipoDoc = "";
            numeroDoc = "";
            fechaVence = DateTime.Now.Date;
            importeDoc = 0m;
            acumuladoDoc = 0m;
            restaDoc = 0m;
            signoDoc = 1;
            provCiRif = "";
            provCodigo = "";
            provNombre = "";
        }

    }

}
