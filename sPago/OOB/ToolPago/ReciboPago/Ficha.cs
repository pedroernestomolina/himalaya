using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.ToolPago.ReciboPago
{
    
    public class Ficha
    {

        public Recibo recibo { get; set; }
        public List<Documento> documentos { get; set; }
        public List<MetodoPago> metodosPago { get; set; }


        public Ficha()
        {
            recibo = new Recibo();
            documentos = new List<Documento>();
            metodosPago = new List<MetodoPago>();
        }

    }

}