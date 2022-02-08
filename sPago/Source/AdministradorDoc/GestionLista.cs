using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sPago.Source.AdministradorDoc
{
    
    public class GestionLista: IAdmLista
    {
        
        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public BindingSource ItemSource { get { return _bs; } }
        public int CntItems { get { return _bs.Count; } }
        public List<data> ListaItems { get { return _bl.ToList(); } }
        public data ItemActual { get { return (data)_bs.Current; } }


        public GestionLista()
        {
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _bl.Clear();
        }

        public void setLista(List<data> lst)
        {
            _bl.Clear();
            foreach (var r in lst.ToList())
            {
                _bl.Add(new data(r));
            }
        }

        public void Limpiar()
        {
            _bl.Clear();
        }

        public void setItemEstatusAnulado()
        {
            ItemActual.setEstatusAnulado();
            _bs.CurrencyManager.Refresh();
        }

    }

}