using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.GenerarPago
{
    
    public interface IGestion
    {

        string IdReciboPago { get; }
        bool GenerarPagIsOk { get; }


        void setProveedor(string p);
        void Inicializa();
        void Inicia();

    }

}