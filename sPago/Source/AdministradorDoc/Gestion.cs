using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.AdministradorDoc
{
    
    public class Gestion
    {

        private IGestion _gestion;
        private Filtrar.IGestion _gFiltrar;
        private GestionLista _gLista;
        private Seguridad.IGestion _gSeguridad;
        private Anular.IGestion _gAnular;
        private SistemaCtrl.VerAnulacion.IGestion _gAuditoria;


        public string TituloAdministrador { get { return _gestion.TituloAdministrador; } }
        public  Enumerados.EnumTipoAdministrador TipoAdminstrador { get { return _gestion.TipoAdminstrador; } }
        public BindingSource ItemSource { get { return _gLista.ItemSource; } }
        public data ItemActual { get { return _gLista.ItemActual; } }
        public List<data> ListaItems { get { return _gLista.ListaItems; } }
        public bool GetFechaDesde_Habilitar { get { return _gFiltrar.GetFechaDesde_Habilitar; } }
        public bool GetFechaHasta_Habilitar { get { return _gFiltrar.GetFechaHasta_Habilitar; } }
        public DateTime Desde { get { return _gFiltrar.GetDesde; } }
        public DateTime Hasta { get { return _gFiltrar.GetHasta; } }
        public int CntItems { get { return _gLista.CntItems; } }


        public Gestion(Seguridad.IGestion ctrSeguridad, 
            Anular.IGestion ctrAnular, 
            SistemaCtrl.VerAnulacion.IGestion ctrAuditoria,
            Filtrar.IGestion ctrFiltrar) 
        {
            _gSeguridad = ctrSeguridad;
            _gAnular = ctrAnular;
            _gAuditoria = ctrAuditoria;
            _gFiltrar = ctrFiltrar;
            _gLista = new GestionLista();
        }


        public void setGestionAdmDoc(IGestion ctr)
        {
            _gestion = ctr;
            _gestion.setGestionSeguridad(_gSeguridad);
            _gestion.setGestionAnular(_gAnular);
            _gestion.setGestionAuditoria(_gAuditoria);
            _gFiltrar.setGestionFiltro(ctr.GestionFiltro);
        }


        public void setFechaDesde(DateTime fecha)
        {
            _gFiltrar.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _gFiltrar.setFechaHasta(fecha);
        }

        public void Inicializa() 
        {
            _gestion.Inicializa();
            _gLista.Inicializa();
            _gFiltrar.Inicializa();
        }

        private AdmDocFrm frm;
        public void Inicia() 
        {
            if (_gestion.CargarData())
            {
                if (frm == null) 
                {
                    frm = new AdmDocFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void Imprimir()
        {
            if (ListaItems.Count()>0)
                _gestion.ReporteDocumentos(ListaItems);
        }

        public void VisualizarDocAnulado()
        {
            if (ItemActual != null)
            {
                if (ItemActual.isAnulado) 
                {
                    _gestion.VisualizarDocAnulado(ItemActual);
                }
            }
        }

        public void VisualizarDocumento()
        {
            if (ItemActual != null) 
            {
                _gestion.VisualizarDocumento(ItemActual);
            }
        }

        public void LimpiarItems()
        {
            _gLista.Limpiar();
        }

        public void LimpiarFiltros()
        {
            _gFiltrar.LimpiarFiltros();
        }

        public void AnularItem()
        {
            if (ItemActual != null)
            {
                _gestion.AnularItem(ItemActual);
                if (_gestion.AnularItemIsOk) 
                {
                    _gLista.setItemEstatusAnulado();
                    ItemSource.CurrencyManager.Refresh();
                }
            }
        }

        public void BuscarDocs()
        {
            if (_gFiltrar.FiltrosIsValido()) 
            {
                var filtro = _gFiltrar.GetFiltros;
                _gLista.setLista(_gestion.BuscarDocs(filtro));
            }
        }

        public void FiltrarDocs()
        {
            _gFiltrar.Inicia();
        }

        public void setHabilitarDesde()
        {
            _gFiltrar.setHabilitarDesde();
        }
        public void setHabilitarHasta()
        {
            _gFiltrar.setHabilitarHasta();
        }

    }

}