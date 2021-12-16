using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.RetISLR.Administrador.Items
{
    
    public class Gestion
    {

        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public BindingSource ItemSource { get { return _bs; } }
        public int CntItem { get { return _bs.Count; } }
        public List<data> ListaItems { get { return _bl.ToList(); } }
        public data ItemActual { get { return (data)_bs.Current; } }


        public Gestion()
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

        public void setLista(List<OOB.RetISLR.Entidad.Ficha> lst)
        {
            foreach(var r in lst.OrderByDescending(o=>o.documento).ToList())
            {
                _bl.Add(new data(r));
            }
        }

        public void Limpiar()
        {
            _bl.Clear();
        }

    }

}