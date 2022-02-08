using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.PorPagar
{
    
    public interface IGestion
    {

        void setLista(List<data> lst);
        void setProveedor(OOB.Proveedor.Entidad.Ficha ficha);
        void Inicializa();
        void Inicia();

    }

}