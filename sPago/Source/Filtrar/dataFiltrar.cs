using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Filtrar
{
    
    public class dataFiltrar
    {

        private bool _habilitar_FechaDesde;
        private bool _habilitar_FechaHasta;
        private DateTime _desde;
        private DateTime _hasta;
        private ficha _tipoDoc;
        private ficha _proveedor;
        private ficha _estatus;


        public bool GetFechaDesde_Habilitar { get { return _habilitar_FechaDesde; } }
        public bool GetFechaHasta_Habilitar { get { return _habilitar_FechaHasta; } }
        public DateTime GetDesde { get { return _desde; } }
        public DateTime GetHasta { get { return _hasta; } }
        public ficha TipoDoc { get { return _tipoDoc; } }
        public ficha Proveedor { get { return _proveedor; } }
        public ficha Esatus { get { return _estatus; } }


        public dataFiltrar() 
        {
            limpiar();
        }


        public void Inicializa()
        {
            limpiar();
        }

        public void LimpiarFiltros()
        {
            limpiar();
        }

        //

        public void setFechaDesde(DateTime fecha)
        {
            _desde = fecha.Date;
        }

        public void setFechaHasta(DateTime fecha)
        {
            _hasta = fecha.Date;
        }

        public void setTipoDoc(ficha ent)
        {
            _tipoDoc = ent;
        }

        public void setEstatus(ficha ent)
        {
            _estatus = ent;
        }

        public void setProveedor(ficha ent)
        {
            _proveedor = ent;
        }

        public void setHabilitarDesde()
        {
            _habilitar_FechaDesde = !_habilitar_FechaDesde;
        }

        public void setHabilitarHasta()
        {
            _habilitar_FechaHasta = !_habilitar_FechaHasta;
        }

        //

        private void limpiar()
        {
            _habilitar_FechaDesde = false;
            _habilitar_FechaHasta = false;
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _tipoDoc = null;
            _proveedor = null;
            _estatus = null;
        }

    }

}