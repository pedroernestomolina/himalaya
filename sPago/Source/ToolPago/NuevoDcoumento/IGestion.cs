using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.NuevoDcoumento
{
    
    public interface IGestion
    {

        bool AgregarDocIsOk { get; }
        string DocumentoAgregadoGetId { get; }


        void Inicializa();
        void Inicia();

    }

}