using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Filtrar
{
    
    public class Gestion: IGestion
    {

        private dataFiltrar _data;
        private bool _abandonarIsOk;
        private bool _filtrarIsOK;
        private string _cadenaBusProv;
        private List<ficha> _lstTipoDoc;
        private BindingSource _bsTipoDoc;
        private List<ficha> _lstEstatus;
        private BindingSource _bsEstatus;
        private IFiltrar _gFiltrar;
        private IListaProv _gListaProv;


        public BindingSource SourceTipoDoc { get { return _bsTipoDoc; } }
        public BindingSource SourceEstatus { get { return _bsEstatus; } }
        public bool GetFechaDesde_Habilitar { get { return _data.GetFechaDesde_Habilitar; } }
        public bool GetFechaHasta_Habilitar { get { return _data.GetFechaHasta_Habilitar; } }
        public DateTime GetDesde { get { return _data.GetDesde; } }
        public DateTime GetHasta { get { return _data.GetHasta; } }
        public string GetIdTipoDoc { get { return _data.TipoDoc == null ? "" : _data.TipoDoc.id; } }
        public string GetIdEstatus { get { return _data.Esatus == null ? "" : _data.Esatus.id; } }
        public bool ProveedorSeleccionadoIsOK { get { return _data.Proveedor != null ? true : false; } }
        public string GetNombreProveedor { get { return ProveedorSeleccionadoIsOK ? _data.Proveedor.desc : ""; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool FiltrarIsOK { get { return _filtrarIsOK; } }
        public dataFiltrar GetFiltros { get { return _data; } }


        public Gestion(IListaProv ctrListaProv) 
        {
            _lstTipoDoc = new List<ficha>();
            _bsTipoDoc = new BindingSource();
            _bsTipoDoc.DataSource = _lstTipoDoc;
            _lstEstatus= new List<ficha>();
            _bsEstatus= new BindingSource();
            _bsEstatus.DataSource = _lstEstatus;
            _abandonarIsOk = false;
            _filtrarIsOK = false;
            _data = new dataFiltrar();
            _cadenaBusProv = "";
            _gListaProv = ctrListaProv;
        }


        public void Inicializa() 
        {
            _abandonarIsOk = false;
            _filtrarIsOK = false;
            _data.Inicializa();
            _cadenaBusProv = "";
        }

        FiltroFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new FiltroFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void LimpiarFiltros()
        {
            _cadenaBusProv = "";
            _data.LimpiarFiltros();
        }

        public void Abandonar()
        {
            _abandonarIsOk = true;
        }

        public void BuscarProveedor()
        {
            if (_cadenaBusProv.Trim() != "")
            {
                var filtro = new OOB.Proveedor.Lista.Filtro()
                {
                    cadena = _cadenaBusProv,
                    metodoBusq = OOB.Proveedor.enumerados.metodosBusq.PorRazonSocial,
                };
                var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _gListaProv.Inicializa();
                _gListaProv.setLista(r01.ListaEntidad);
                _gListaProv.Inicia();
                if (_gListaProv.ItemSeleccionadoIsOk) 
                {
                    var prv = (OOB.Proveedor.Entidad.Ficha) _gListaProv.ProveedorSeleccionado;
                    var ent = new ficha(prv.id, prv.nombreRazonSocial);
                    _data.setProveedor(ent);
                }
            }
        }

        public void Filtrar()
        {
            _filtrarIsOK = true;
        }

        public void LimpiarProveedor()
        {
            _cadenaBusProv = "";
            _data.setProveedor(null);
        }

        public bool FiltrosIsValido()
        {
            var rt = true;
            if (_data.GetFechaDesde_Habilitar && _data.GetFechaHasta_Habilitar)
            {
                if (_data.GetDesde > _data.GetHasta)
                {
                    Helpers.Msg.Alerta("FECHAS INCORRECTAS, VERIFIQUE POR FAVOR");
                    return false;
                }
            }
            return rt;
        }

        //

        public void setGestionFiltro(IFiltrar ctr)
        {
            _gFiltrar = ctr;
        }

        public void setGestionListaProv (IListaProv ctr)
        {
            _gListaProv= ctr;
        }

        public void setFechaDesde(DateTime fecha)
        {
            _data.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _data.setFechaHasta(fecha);
        }

        public void setCadenaProv(string p)
        {
            _cadenaBusProv = p;
        }

        public void setTipoDoc(string id)
        {
            var ent = _lstTipoDoc.FirstOrDefault(f => f.id == id);
            _data.setTipoDoc(ent);
        }

        public void setEstatus(string id)
        {
            var ent = _lstEstatus.FirstOrDefault(f => f.id == id);
            _data.setEstatus(ent);
        }

        public void setHabilitarDesde()
        {
            _data.setHabilitarDesde();
        }

        public void setHabilitarHasta()
        {
            _data.setHabilitarHasta();
        }

        //
        //
        //

        private bool CargarData()
        {
            var rt = true;

            if (_gFiltrar.CargarData())
            {
                _lstTipoDoc = _gFiltrar.ListTipoDoc;
                _bsTipoDoc.DataSource = _lstTipoDoc;
                _bsTipoDoc.CurrencyManager.Refresh();

                _lstEstatus = _gFiltrar.ListEstatus;
                _bsEstatus.DataSource = _lstEstatus;
                _bsEstatus.CurrencyManager.Refresh();
            }

            return rt;
        }

    }

}