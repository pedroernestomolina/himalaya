using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.__.Componente.AdmDoc.Vista
{
    public interface IbaseVista: IGestion
    {
        enumerados.tipoAdministrador AdministradorTipo { get; }
        string TituloAdministrador { get; }
        string CntItems { get;  }
        IItems Items { get; }
        __.Ctrl.Boton.Salir.ISalir BtSalida { get; }
        //
        void Buscar();
        void VisualizarDoc();
        void LimpiarItems();
    }
}