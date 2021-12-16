using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.RetISLR.Administrador
{
    
    public class Gestion
    {

        private Filtro.Gestion _gFiltro;
        private Items.Gestion _gItem;


        public int CntItems { get { return _gItem.CntItem; } }
        public DateTime Desde { get { return _gFiltro.GetDesde; } }
        public DateTime Hasta { get { return _gFiltro.GetHasta; } }
        public object ItemSource { get { return _gItem.ItemSource; } }


        public Gestion()
        {
            _gFiltro = new Filtro.Gestion();
            _gItem = new Items.Gestion();
        }


        public void Inicializa()
        {
            _gFiltro.Inicializa();
            _gItem.Inicializa();
        }

        AdmDocFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AdmDocFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setFechaDesde(DateTime fecha)
        {
            _gFiltro.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _gFiltro.setFechaHasta(fecha);
        }

        public void Buscar()
        {
            GenerarBusqueda();
        }

        private void GenerarBusqueda()
        {
            _gItem.Limpiar();
            var filtro = new OOB.RetISLR.Lista.Filtro()
            {
                desde = _gFiltro.GetDesde,
                hasta = _gFiltro.GetHasta,
                tipoRetencion="02",
            };
            var r01 = Sistema.MyData.RetISLR_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gItem.setLista(r01.ListaEntidad);
        }

        public void LimpiarFiltros()
        {
            _gFiltro.Inicializa();
        }

        public void LimpiarItems()
        {
            _gItem.Limpiar();
        }

        public void Imprimir()
        {
            var rp = new Reportes.RetISLR.AdmLista.Gestion();
            rp.setLista(_gItem.ListaItems);
            rp.setFiltro(_gFiltro.Filtros);
            rp.Generar();
        }

        public void VisualizarDocumento()
        {
            if (_gItem.ItemActual != null)
            {
                var r01 = Sistema.MyData.RetISLR_GetById(_gItem.ItemActual.Id);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Helpers.Utils.VisualizarRetISLR(r01.MiEntidad);
            }
        }

    }

}