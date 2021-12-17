using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.RetISLR.AnularRetencion.Anular
{
    
    public class docRegistro
    {

        public string moduloOrigen { get; set; }
        public string detalle { get; set; }
        public string equipoEstacion { get; set; }
        public string usuNombre { get; set; }
        public string usuCodigo { get; set; }
        public string autoDoc { get; set; }


        public docRegistro() 
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