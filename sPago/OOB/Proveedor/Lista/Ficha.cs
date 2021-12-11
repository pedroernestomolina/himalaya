using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Proveedor.Lista
{
    
    public class Ficha
    {

        public string id { get; set; }
        public string ciRif { get; set; }
        public string codigo { get; set; }
        public string nombreRazonSocial { get; set; }
        public string dirFiscal { get; set; }
        private string estatus { get; set; }


        public Ficha() 
        {
            id = "";
            ciRif = "";
            codigo = "";
            nombreRazonSocial = "";
            dirFiscal = "";
            estatus = "";
        }

    }

}