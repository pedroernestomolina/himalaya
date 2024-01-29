using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.__.Componente.Filtro.Vista
{
    public interface IbaseFiltro: IFiltro
    {
        Ctrl.FiltroFecha.IFecha Desde { get; }
        Ctrl.FiltroFecha.IFecha Hasta { get; }
        //
        bool ValidacionIsOk();
        object ObtenerFiltros();
        void Limpiar();
    }
}