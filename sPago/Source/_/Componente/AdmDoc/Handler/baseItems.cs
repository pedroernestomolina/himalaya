using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.__.Componente.AdmDoc.Handler
{
    public abstract class baseItems: Vista.IItems
    {
        private BindingSource _bs;
        //
        public object Get_Source { get { return _bs; } }
        public int Get_CntItems { get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; ; } }
        //
        public baseItems()
        {
            _bs = new BindingSource();
        }
        //
        public abstract void setDataCargar(IEnumerable<Vista.IdataItem> list);
        public void Inicializa()
        {
            _bs.Clear();
        }
        public void LimpiarItems()
        {
            _bs.Clear();
        }
    }
}
