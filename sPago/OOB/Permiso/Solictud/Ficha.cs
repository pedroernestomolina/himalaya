using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Permiso.Solictud
{
    
    public class Ficha
    {

        public string estatus { get; set; }
        public string nivelSeguridad { get; set; }
        public bool IsEstatusActivo { get { return estatus.Trim().ToUpper() == "1"; } }


        public Ficha() 
        {
            estatus = "";
            nivelSeguridad = "";
        }

    }

}