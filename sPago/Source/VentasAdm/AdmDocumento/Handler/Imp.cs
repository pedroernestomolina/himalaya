using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.VentasAdm.AdmDocumento.Handler
{
    public class Imp: __.Componente.AdmDoc.Handler.baseImp, Vista.IVista
    {
        private __.Componente.AdmDoc.Vista.IItems _items;
        private AdmFiltro.Vista.IFiltroAdm _filtro;
        //
        public override __.Componente.AdmDoc.enumerados.tipoAdministrador AdministradorTipo { get { return __.Componente.AdmDoc.enumerados.tipoAdministrador.Ventas; } }
        public override string TituloAdministrador { get { return "Administrador de Documentos: VENTAS"; } }
        public override string CntItems { get { return "Cantidad Items Encontrados: "+_items.Get_CntItems; } }
        public override __.Componente.AdmDoc.Vista.IItems Items { get { return _items; } }
        public AdmFiltro.Vista.IFiltroAdm Filtro { get { return _filtro; } }
        //
        public Imp()
            : base()
        {
            _items = new Items();
            _filtro = new AdmFiltro.Handler.ImpFiltro();
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _filtro.Inicializa();
        }
        Vista.Frm frm;
        public override void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public override void Buscar()
        {
            if (_filtro.ValidacionIsOk()) 
            {
                activarBusqueda();
            }
        }
        public override void VisualizarDoc()
        {
            visualizar();
        }
        public override void LimpiarItems()
        {
            limpiarItems();
        }
        //
        private bool cargarData()
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void visualizar()
        {
            if (_items.ItemActual != null) 
            {
                var _doc = (dataVenta)_items.ItemActual;
                Helpers.Venta.Utils.Visualiza(_doc.Ficha.tipoDoc, _doc.Ficha.idDoc);
            }
        }
        private void limpiarItems()
        {
            _items.LimpiarItems();
        }
        private void activarBusqueda()
        {
            try
            {
                var _misFiltro= (AdmFiltro.Handler.data)_filtro.ObtenerFiltros();
                var filtroOOb = new OOB.VentaAdm.AdmDoc.Filtro()
                {
                    desde = _misFiltro.desde,
                    hasta = _misFiltro.hasta,
                    PorTipoDocumento=  OOB.VentaAdm.__.enumerados.DescTipoDocumento.Factura,
                };
                var r01 = Sistema.MyData.VentasAdm_AdmDocumento_GetLista(filtroOOb);
                var _lst = new List<dataVenta>();
                foreach (var rg in r01.ListaEntidad.OrderByDescending(o => o.numeroDoc).ToList()) 
                {
                    var nr = new dataVenta()
                    {
                        FechaEmisionDoc = rg.fechaEmision,
                        FechaVenceDoc = rg.fechaVence,
                        NumeroDoc = rg.numeroDoc,
                        TipoDoc = rg.nombreDoc,
                        CiRifEnt = rg.ciRifEnt,
                        DiasCredito = rg.diasCredito,
                        ImporteDoc = rg.importeDoc,
                        NombreEnt = rg.nombreEnt,
                        EstatusAnuladoDoc = (rg.isAnulado ? "ANULADO" : ""),
                        Ficha = rg,
                    };
                    _lst.Add(nr);
                }
                _items.setDataCargar(_lst);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}