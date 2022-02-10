using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.GenerarPago
{
    
    public interface IDetalleMonto
    {

        string Detalle { get; }
        decimal MontoPagar { get; }
        bool DetalleMontoIsOk { get; }


        void Inicializa();
        void Inicia();
        void setData(decimal montoPendiente, decimal montoPagar, string detalle);

    }

}