using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Empresa.Entidad
{
    
    public class Ficha
    {

        public string nombreRazonSocial { get; set; }
        public string ciRif { get; set; }
        public string dirFiscal { get; set; }
        public string telefono_1 { get; set; }
        public string telefono_2 { get; set; }
        public string telefono_3 { get; set; }
        public string telefono_4 { get; set; }


        public Ficha()
        {
            nombreRazonSocial = "";
            ciRif = "";
            dirFiscal = "";
            telefono_1 = "";
            telefono_2 = "";
            telefono_3 = "";
            telefono_4 = "";
        }

    }

}