using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.__.Componente
{
    public interface ILista
    {
        int Get_CntItems { get; }
        object Get_Source { get; }
        object ItemActual { get; }
        //
        void Inicializa();
        void LimpiarItems();
    }
}