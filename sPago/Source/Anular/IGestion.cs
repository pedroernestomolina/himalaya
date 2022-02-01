using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Anular
{
    
    public interface IGestion
    {

        bool ProcesarIsOK { get; }
        string Motivo { get;  }


        void Inicializa();
        void Inicia();

    }

}