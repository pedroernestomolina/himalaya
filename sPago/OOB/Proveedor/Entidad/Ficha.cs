using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Proveedor.Entidad
{
    
    public class Ficha
    {

        public string id { get; set; }
        public string codigo { get; set; }
        public string ciRif { get; set; }
        public string nombreRazonSocial { get; set; }
        public string dirFiscal { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string telefono3 { get; set; }
        public string telefono4 { get; set; }
        public string celular1{ get; set; }
        public string celular2{ get; set; }
        public string estatus { get; set; }
        public string contacto { get; set; }
        public string email { get; set; }
        public decimal retISLR { get; set; }
        public decimal retIVA { get; set; }
        public DateTime fechaAlta { get; set; }


        public Ficha()
        {
            id = "";
            codigo = "";
            ciRif = "";
            nombreRazonSocial = "";
            dirFiscal = "";
            telefono1 = "";
            telefono2 = "";
            telefono3 = "";
            telefono4 = "";
            celular1 = "";
            celular2 = "";
            estatus = "";
            contacto = "";
            email = "";
            retISLR = 0m;
            retIVA = 0m;
            fechaAlta = DateTime.Now.Date;
        }

    }

}