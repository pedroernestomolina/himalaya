using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes
{
    
    public class Gestion
    {


        private IReportes _gReporte;
        private Filtrar.IGestion _gFiltrar;


        public Gestion(Filtrar.IGestion ctrFiltrar) 
        {
            _gFiltrar = ctrFiltrar; // new Filtrar.Gestion(new Proveedor.Lista.Gestion());
        }


        public void setGestion(IReportes ctr)
        {
            _gFiltrar.setGestionFiltro(ctr.Filtrar);
            _gReporte = ctr;
        }

        public void Inicializa()
        {
            _gFiltrar.Inicializa();
        }

        public void Inicia() 
        {
            _gFiltrar.Inicia();
            if (_gFiltrar.FiltrarIsOK)
            {
                _gReporte.Generar(_gFiltrar.GetFiltros);
            }
        }

    }

}