using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Reportes.RetISLR.Filtro
{
    
    public class Gestion
    {

        private data _data;
        private bool _filtrarIsOk;
        private bool _abandonarIsOk;
        private List<ficha> _lEstatus;
        private BindingSource _bsEstatus;


        public DateTime Desde { get { return _data.GetDesde; } }
        public DateTime Hasta { get { return _data.GetHasta; } }
        public bool FiltrosIsOk { get { return _filtrarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public BindingSource EstatusSource { get { return _bsEstatus; } }
        public data Filtros { get { return _data; } }

        
        public Gestion() 
        {
            _filtrarIsOk = false;
            _abandonarIsOk = false;
            _data = new data();
            _lEstatus = new List<ficha>();
            _bsEstatus = new BindingSource();
            _bsEstatus.DataSource = _lEstatus;
        }


        public void Inicializa()
        {
            _lEstatus.Clear();
            _bsEstatus.DataSource = _lEstatus;
            _filtrarIsOk = false;
            _abandonarIsOk = false;
            _data.Limpiar();
        }

        FiltrosFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new FiltrosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            _lEstatus.Clear();
            _lEstatus.Add(new ficha("01", "ACTIVO"));
            _lEstatus.Add(new ficha("02", "ANULADO"));
            _bsEstatus.DataSource = _lEstatus;
            return true;
        }

        public void setEstatus(string id)
        {
            _data.setEstatus(_lEstatus.FirstOrDefault(s=>s.id==id));
        }

        public void setFechaDesde(DateTime fecha)
        {
            _data.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _data.setFechaHasta(fecha);
        }

        public void LimpiarFiltros()
        {
            _data.Limpiar();
        }

        public void AceptarFiltros()
        {
            _filtrarIsOk = _data.IsValida();
        }
        public void Abandonar()
        {
            _abandonarIsOk = true;
        }

    }

}