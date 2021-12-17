using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.AnularRetencion.Anular
{
    
    public class DocRegistro
    {
        
        public string moduloOrigen { get; set; }
        public string detalle { get; set; }
        public string equipoEstacion { get; set; }
        public string usuNombre { get; set; }
        public string usuCodigo { get; set; }
        public string autoDoc { get; set; }


        public DocRegistro() 
        {
            moduloOrigen = "";
            detalle = "";
            equipoEstacion = "";
            usuNombre = "";
            usuCodigo = "";
            autoDoc = "";
        }

    }

}
