using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Sistema.DocAnulado.Buscar
{
    
    public class Ficha
    {

        public string autoDoc { get; set; }
        public string moduloOrigen { get; set; }


        public Ficha() 
        {
            autoDoc = "";
            moduloOrigen = "";
        }

    }

}