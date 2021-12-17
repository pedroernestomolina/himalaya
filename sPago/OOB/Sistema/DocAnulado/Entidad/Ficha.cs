using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Sistema.DocAnulado.Entidad
{
    
    public class Ficha
    {

        public DateTime fechaAnu { get; set; }
        public string horaAnu { get; set; }
        public string usuNombre { get; set; }
        public string usuCodigo { get; set; }
        public string detalleAnu { get; set; }
        public string estacion { get; set; }


        public Ficha() 
        {
            fechaAnu= DateTime.Now.Date;
            horaAnu = "";
            usuNombre = "";
            usuCodigo = "";
            detalleAnu = "";
            estacion = "";
        }

    }

}