using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.RetISLR.AnularRetencion.Anular
{
    
    public class Ficha
    {

        public string autoDocRetencion { get; set; }
        public string autoPago { get; set; }
        public string autoRecibo { get; set; }
        public List<DocCompraAplicaRetencion> docCompraAplicaRetencion { get; set; }
        public docRegistro registroAnulacion { get; set; }


        public Ficha() 
        {
            autoDocRetencion = "";
            autoPago = "";
            autoRecibo = "";
            docCompraAplicaRetencion = new List<DocCompraAplicaRetencion>();
            registroAnulacion = new docRegistro();
        }

    }

}