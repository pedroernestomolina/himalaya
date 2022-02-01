using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Filtrar
{
    
    public interface IGestion
    {

        bool FiltrarIsOK { get; }
        dataFiltrar GetFiltros { get; }
        bool GetFechaDesde_Habilitar { get; }
        bool GetFechaHasta_Habilitar { get; }
        DateTime GetDesde { get; }
        DateTime GetHasta { get; }


        void setGestionFiltro(IFiltrar filtrar);
        void setFechaDesde(DateTime fecha);
        void setFechaHasta(DateTime fecha);


        void Inicializa();
        void Inicia();
        void LimpiarFiltros();
        bool FiltrosIsValido();
        void setHabilitarDesde();
        void setHabilitarHasta();

    }

}