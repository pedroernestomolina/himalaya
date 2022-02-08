using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.GenerarPago
{

    public class ListaDocPagar: IListaDocPagar
    {

        private List<item> _lst;
        private BindingList<item> _bl;
        private BindingSource _bs;


        public item ItemActual { get { return (item)_bs.Current; } }
        public System.Windows.Forms.BindingSource SourceDocPagar { get { return _bs; } }
        public int CntDocPagar { get { return _bs.Count; } }
        public decimal MontoPagar { get { return _bl.Sum(s => s.MontoPagar); } }
        public bool HayItemsMarcados { get { return _bl.Count(c => c.IsPagarActiva) > 0; } }
        List<item> IListaDocPagar.ListaDocPagar { get { return _bl.Where(s => s.IsPagarActiva).ToList(); } }


        public ListaDocPagar()
        {
            _lst = new List<item>();
            _bl = new BindingList<item>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void setLista(List<OOB.ToolPago.PendPagar.Ficha> list)
        {
            foreach (var rg in list.OrderByDescending(o=>o.fechaEmision).ToList())
            {
                _bl.Add(new item(rg));
            }
        }

        public void setPagarActivar(decimal xmonto)
        {
            ItemActual.setActivarPagar(xmonto);
            _bs.CurrencyManager.Refresh();
        }

    }

}