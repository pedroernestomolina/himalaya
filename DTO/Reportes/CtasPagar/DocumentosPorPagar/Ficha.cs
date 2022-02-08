using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.CtasPagar.DocumentosPorPagar
{
    
    public class Ficha
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
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public string provCodigo { get; set; }


        public Ficha() 
        {
            fechaEmision = DateTime.Now.Date;
            tipoDoc = "";
            numeroDoc = "";
            fechaVence = DateTime.Now.Date;
            detalleDoc = "";
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