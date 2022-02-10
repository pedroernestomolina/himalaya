using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.GenerarPago
{
    
    public interface IListaDocPagar
    {

        System.Windows.Forms.BindingSource SourceDocPagar { get; }
        int CntDocPagar { get;  }
        decimal MontoPagar { get; }
        item ItemActual { get; }
        bool HayItemsMarcados { get; }
        List<item> ListaDocPagar { get; }


        void Inicializa();
        void setLista(List<OOB.ToolPago.PendPagar.Ficha> list);
        void setPagarActivar(decimal monto , string detalle);

    }

}