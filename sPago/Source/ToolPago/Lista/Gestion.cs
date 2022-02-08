using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.Lista
{
    
    public class Gestion
    {


        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public data ItemActual { get { return (data)_bs.Current; } }
        public decimal Importe { get { return _bl.Sum(s => s.importe); } }
        public decimal Acumulado { get { return _bl.Sum(s => s.acumulado); } }
        public decimal Resta { get { return _bl.Sum(s => s.resta); } }
        public BindingSource SourceItems { get { return _bs; } }
        public int CntItems { get { return _bs.Count; } }


        public Gestion() 
        {
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void setLista(List<data> lst)
        {
            _bl.Clear();
            foreach (var rg in lst)
            {
                _bl.Add(rg);
            }
            _bs.CurrencyManager.Refresh();
        }

        public void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void AgregarDoc(OOB.CtaPagar.Entidad.Ficha ficha)
        {
            var ent = _bl.FirstOrDefault(f=>f.provId==ficha.autoProv);
            if (ent == null)
            {
                var rg = new data(ficha.autoProv, ficha.provNombre, ficha.provCiRif, ficha.importeDoc, ficha.restaDoc, ficha.abonadoDoc, 1);
                _bl.Add(rg);
            }
            else 
            {
                ent.AgregarDoc(ficha.importeDoc * ficha.signoDoc);
            }
            _bs.CurrencyManager.Refresh();
        }

        public void ActualizarItem(data data)
        {
            var ent = _bl.FirstOrDefault(f => f.provId == data.provId);
            if (ent != null)
            {
                ent.ActualizarItem(data);
            }
            _bs.CurrencyManager.Refresh();
        }

    }

}