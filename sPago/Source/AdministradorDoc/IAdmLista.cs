using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.AdministradorDoc
{
    
    public interface IAdmLista
    {

        System.Windows.Forms.BindingSource ItemSource { get; }
        data ItemActual { get; }
        List<data> ListaItems { get; }
        int CntItems { get; }


        void setItemEstatusAnulado();
        void setLista(List<data> list);


        void Inicializa();
        void Limpiar();

    }

}