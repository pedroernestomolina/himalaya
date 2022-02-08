using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Reportes.CtasPagar.RelacionPagoDiario
{
    
    public class Ficha
    {

        public string numeroRecibo { get; set; }
        public DateTime fechaRecibo { get; set; }
        public decimal importeRecibo { get; set; }
        public string detalleRecibo { get; set; }
        public string estatusRecibo { get; set; }
        public decimal montoRecibido { get; set; }

        public decimal cambioDar { get; set; }
        public int cntDocRel { get; set; }
        public string nota { get; set; }

        public string provCodigo { get; set; }
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public string provTelefono { get; set; }
        public string provDir { get; set; }


        public Ficha() 
        {
            numeroRecibo = "";
            fechaRecibo = DateTime.Now;
            importeRecibo = 0m;
            detalleRecibo = "";
            estatusRecibo = "";
            montoRecibido = 0;

            cambioDar = 0m;
            cntDocRel = 0;
            nota = "";

            provCiRif = "";
            provCodigo = "";
            provNombre = "";
            provTelefono = "";
            provDir = "";
        }

    }

}