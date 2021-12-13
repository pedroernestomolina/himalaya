using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Proveedor.Lista
{

    public class Gestion
    {

        private List<data> _lst;
        private BindingSource _bs;
        private data _itemSeleccionado;
        private string _aBuscar;


        public string ItemsEncontrados { get { return string.Format("{0}", _bs.Count); } }
        public BindingSource Source { get { return _bs; } }
        public data ItemSeleccionado { get { return _itemSeleccionado; } }
        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionado!=null; } }


        public Gestion()
        {
            _aBuscar = "";
            _itemSeleccionado = null;
            _lst = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
        }


        public void setLista(List<OOB.Proveedor.Entidad.Ficha> list)
        {
            _lst.Clear();
            foreach (var rg in list.OrderBy(o=>o.nombreRazonSocial).ToList())
            {
                _lst.Add(new data(rg.id, rg.ciRif, rg.nombreRazonSocial, rg.estatus));
            }
            _bs.CurrencyManager.Refresh();
        }

        ListaFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ListaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt= true;

            //if (_aBuscar != "")
            //{
            //    var filt = new OOB.Maestro.Cliente.Lista.Filtro()
            //    {
            //        cadena = _aBuscar,
            //        metodoBusqueda = OOB.Maestro.Cliente.Lista.Enumerados.enumMetodoBusqueda.PorNombre,
            //    };
            //    var r01 = Sistema.MyData.Cliente_GetLista(filt);
            //    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            //    {
            //        Helpers.Msg.Error(r01.Mensaje);
            //        return false;
            //    }
            //    setLista(r01.ListaD);
            //}

            return rt;
        }

        public void SeleccionarItem()
        {
            var it = (data)_bs.Current;
            if (it != null)
            {
                if (!it.isActivo)
                {
                    Helpers.Msg.Alerta("PROVEEDOR EN ESTADO INACTIVO");
                    return;
                }
                _itemSeleccionado = it;
            }
        }

        public void Cerrar()
        {
            frm.Close();
        }

        public void Inicializa()
        {
            _aBuscar = "";
            _itemSeleccionado = null;
            _lst.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void setBuscar(string aBuscar)
        {
            this._aBuscar= aBuscar;
        }

    }

}