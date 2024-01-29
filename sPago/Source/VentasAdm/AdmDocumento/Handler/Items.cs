using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.VentasAdm.AdmDocumento.Handler
{
    public class Items: __.Componente.AdmDoc.Handler.baseItems
    {
        private List<__.Componente.AdmDoc.Vista.IdataItem> _lst;
        private BindingList<__.Componente.AdmDoc.Vista.IdataItem> _bl;
        private BindingSource _bs;
        //
        public Items()
            : base()
        {
            _lst = new List<__.Componente.AdmDoc.Vista.IdataItem>();
            _bl = new BindingList<__.Componente.AdmDoc.Vista.IdataItem>(_lst);
            _bs = (BindingSource)Get_Source;
            _bs.DataSource = _bl;
        }
        public override void setDataCargar(IEnumerable<__.Componente.AdmDoc.Vista.IdataItem> list)
        {
            _lst.Clear();
            foreach (var it in list)
            {
                _lst.Add(it);
            }
            _bs.CurrencyManager.Refresh();
        }
    }
}
