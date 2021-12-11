using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Proveedor.Lista
{
    
    public class Filtro
    {

        public string cadena { get; set; }
        public enumerados.metodosBusq metodoBusq { get; set; }


        public Filtro()
        {
            cadena = "";
            metodoBusq = enumerados.metodosBusq.SinDefinir;
        }

    }

}