using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.__.Componente.AdmDoc.Handler
{
    public abstract class baseImp: Vista.IbaseVista
    {
        private Ctrl.Boton.Salir.ISalir _btSalida;
        //
        public abstract Vista.IItems Items { get; }        
        public abstract string TituloAdministrador { get; }
        public abstract string CntItems { get; }
        public Ctrl.Boton.Salir.ISalir BtSalida { get { return _btSalida; } }
        //
        public baseImp()
        {
            _btSalida = new __.Ctrl.Boton.Salir.Imp();
        }
        public virtual void Inicializa()
        {
            Items.Inicializa();
            _btSalida.Inicializa();
        }
        public abstract void Inicia();
        //
        public abstract enumerados.tipoAdministrador AdministradorTipo { get; }
        public abstract void Buscar();
        public abstract void VisualizarDoc();
        public abstract void LimpiarItems();
    }
}