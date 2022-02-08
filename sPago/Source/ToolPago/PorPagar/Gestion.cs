using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.PorPagar
{
    
    public class Gestion: IGestion
    {


        private OOB.Proveedor.Entidad.Ficha _proveedor;
        private List<data> _lst;
        private BindingSource _bs;


        public string Proveedor { get { return _proveedor.ciRif + Environment.NewLine + _proveedor.nombreRazonSocial + Environment.NewLine + _proveedor.dirFiscal; } }
        public decimal Importe { get { return _lst.Sum(s => s.importeDoc * s.signoDoc); } }
        public decimal Acumulado { get { return _lst.Sum(s => s.acumuladoDoc * s.signoDoc); } }
        public decimal Resta { get { return _lst.Sum(s => s.restaDoc * s.signoDoc); } }
        public int CntItem { get { return _lst.Count; } }
        public BindingSource Source { get { return _bs; } }


        public Gestion()
        {
            _lst = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
        }


        public void Inicializa()
        {
            _proveedor = null;
            _lst.Clear();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }

        PorPagarFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new PorPagarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setLista(List<data> lst)
        {
            _lst.Clear();
            foreach (var rg in lst)
            {
                _lst.Add(rg);
            }
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }

        public void setProveedor(OOB.Proveedor.Entidad.Ficha ficha)
        {
            _proveedor = ficha;
        }

    }

}