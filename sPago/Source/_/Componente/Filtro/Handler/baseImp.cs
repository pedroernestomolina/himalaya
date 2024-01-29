using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.__.Componente.Filtro.Handler
{
    public abstract class baseImp: Vista.IbaseFiltro
    {
        private Ctrl.FiltroFecha.IFecha _desde;
        private Ctrl.FiltroFecha.IFecha _hasta;
        //
        public Ctrl.FiltroFecha.IFecha Desde { get { return _desde; } }
        public Ctrl.FiltroFecha.IFecha Hasta { get { return _hasta; } }
        //
        public baseImp()
        {
            _desde = new Ctrl.FiltroFecha.Imp();
            _hasta = new Ctrl.FiltroFecha.Imp();
        }
        abstract public void Inicializa();
        abstract public void Inicia();
        abstract public bool ValidacionIsOk();
        abstract public object ObtenerFiltros();
        abstract public void Limpiar();
    }
}