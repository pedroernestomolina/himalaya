using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Filtrar
{
    
    public interface IListaProv
    {

        bool ItemSeleccionadoIsOk { get; }
        OOB.Proveedor.Entidad.Ficha ProveedorSeleccionado { get; }


        void Inicializa();
        void Inicia();
        void setLista(List<OOB.Proveedor.Entidad.Ficha> list);

    }

}