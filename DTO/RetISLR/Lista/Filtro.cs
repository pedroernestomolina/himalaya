using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.RetISLR.Lista
{
    
    public class Filtro
    {

        public string tipoRetencion { get; set; }
        public DateTime? desde { get; set; }
        public DateTime? hasta { get; set; }
        public string idProv { get; set; }
        public string estatus { get; set; }


        public Filtro() 
        {
            tipoRetencion = "";
            desde = null;
            hasta = null;
            idProv = "";
            estatus = "";
        }

    }

}