using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.RetISLR.Reportes
{
    
    public class Gestion
    {

        private Filtro.Gestion _gFiltro;
        private IGestion _gReporte;


        public Gestion() 
        {
            _gFiltro = new Filtro.Gestion();
        }


        public void Inicializa()
        {
            _gFiltro.Inicializa();
        }

        public void Inicia()
        {
            _gFiltro.Inicia();
            if (_gFiltro.FiltrosIsOk)
            {
                _gReporte.Generar(_gFiltro.Filtros);
            }
        }

        public void setGestion(IGestion gestion)
        {
            _gReporte = gestion;
        }

    }

}