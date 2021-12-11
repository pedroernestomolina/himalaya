using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Resultado
{

    public class Entidad<T> : Ficha
    {
        public T MiEntidad { get; set; }

        public Entidad()
            : base()
        {
        }
    }

}