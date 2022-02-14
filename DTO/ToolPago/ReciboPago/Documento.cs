using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.ToolPago.ReciboPago
{

    public class Documento
    {
        
        public int nItem { get; set; }
        public DateTime fechaDoc { get; set; }
        public string tipoDoc { get; set; }
        public string numDoc { get; set; }
        public decimal monto { get; set; }
        public string operacion { get; set; }
        public string detalle { get; set; }
        public string nombreDoc { get; set; }


        public Documento ()
        {
            nItem = 0;
            fechaDoc = DateTime.Now;
            tipoDoc= "";
            numDoc= "";
            monto = 0m;
            operacion = "";
            detalle = "";
            nombreDoc = "";
        }

    }

}