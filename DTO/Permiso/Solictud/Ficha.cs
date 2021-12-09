using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Permiso.Solictud
{
    
    public class Ficha
    {

        public string estatus { get; set; }
        public string nivelSeguridad { get; set; }


        public Ficha() 
        {
            estatus = "";
            nivelSeguridad = "";
        }

    }

}