using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.GenerarPago
{
    
    public interface IMetodosPago
    {

        object ListaMetodosPago { get; }
        bool ProcesarIsOk { get; }


        void Inicializa();
        void setMontoPagar(decimal MontoPagar);
        void Inicia();

    }

}