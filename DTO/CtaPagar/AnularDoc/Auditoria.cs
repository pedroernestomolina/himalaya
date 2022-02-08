using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaPagar.AnularDoc
{
    
    public class Auditoria
    {

        public string moduloOrigen { get; set; }
        public string detalle { get; set; }
        public string equipoEstacion { get; set; }
        public string usuNombre { get; set; }
        public string usuCodigo { get; set; }
        public string autoDoc { get; set; }


        public Auditoria() 
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