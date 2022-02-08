using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.CtaPagar.Entidad
{
    
    public class Ficha
    {

        public string autoDoc { get; set; }
        public string autoProv { get; set; }
        public string autoDocRef { get; set; }
        public DateTime fechaEmisionDoc { get; set; }
        public DateTime fechaVenceDoc { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string tipoDoc { get; set; }
        public string numeroDoc { get; set; }
        public string detalleDoc { get; set; }
        public decimal importeDoc { get; set; }
        public decimal abonadoDoc { get; set; }
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public string provCodigo { get; set; }
        public decimal restaDoc { get; set; }
        public string estatusDoc { get; set; }
        public string estatusCanceladoDoc { get; set; }
        public int signoDoc { get; set; }
        public string codigoModuloOrigen { get; set; }
        public bool isAnulado { get { return estatusDoc == "1" ? true : false; } }
        public bool isCancelado { get { return estatusCanceladoDoc == "1" ? true : false; } }


        public Ficha()
        {
            autoDoc = "";
            autoProv = "";
            autoDocRef = "";
            fechaEmisionDoc = DateTime.Now.Date;
            fechaVenceDoc = DateTime.Now.Date;
            fechaRegistro = DateTime.Now.Date;
            tipoDoc = "";
            numeroDoc = "";
            detalleDoc = "";
            importeDoc = 0m;
            abonadoDoc = 0m;
            provNombre = "";
            provCiRif = "";
            provCodigo = "";
            restaDoc = 0m;
            estatusDoc = "";
            estatusCanceladoDoc = "";
            signoDoc = 1;
            codigoModuloOrigen = "";
        }

    }

}