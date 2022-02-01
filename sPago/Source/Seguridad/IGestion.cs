using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Seguridad
{
    
    public interface IGestion
    {

        bool IsOk { get; }


        void Inicializa();
        void Verifica(OOB.Permiso.Solictud.Ficha ficha);

    }

}