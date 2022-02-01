using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.CtaPagar.Lista
{

    public class Ficha
    {

        public string autoDoc { get; set; }
        public string autoProveedor { get; set; }
        public string numDoc { get; set; }
        public DateTime fechaEmisionDoc {get;set;}
        public DateTime fechaVenceDoc {get;set;}
        public decimal importeDoc { get; set; }
        public decimal restaDoc { get; set; }
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public string estatusDoc { get; set; }
        public int signoDoc { get; set; }
        public decimal abonadoDoc { get; set; }
        public string tipoDoc { get; set; }
        public string detalleDoc { get; set; }


        public Ficha() 
        {
            autoDoc = "";
            autoProveedor = "";
            numDoc = "";
            importeDoc = 0m;
            restaDoc = 0m;
            provNombre = "";
            provCiRif = "";
            estatusDoc = "";
            signoDoc = 1;
            fechaEmisionDoc = DateTime.Now.Date;
            fechaVenceDoc = DateTime.Now.Date;
            abonadoDoc = 0m;
            tipoDoc = "";
            detalleDoc = "";
        }

    }

}