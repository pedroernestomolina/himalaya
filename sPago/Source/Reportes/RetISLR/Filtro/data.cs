using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.RetISLR.Filtro
{
    
    public class data
    {

        private ficha _estatus;
        private DateTime _desde;
        private DateTime _hasta;
        private Proveedor.Lista.data _prov;


        public string GetEstatus 
        {
            get 
            {
                var rt = "";
                if (_estatus != null) 
                {
                    rt = _estatus.id == "01" ? "0" : "1";
                }
                return rt;
            }
        }
        public string GetNombreProveedor 
        {
            get 
            {
                var rt = "";
                if (_prov != null)
                {
                    rt = _prov.razonSocial ;
                }
                return rt;
            } 
        }
        public string GetIdProveedor 
        {
            get
            {
                var rt = "";
                if (_prov != null)
                {
                    rt = _prov.auto;
                }
                return rt;
            } 
        }
        public DateTime GetDesde { get { return _desde; } }
        public DateTime GetHasta { get { return _hasta; } }
        public string FiltrarPor { get { return filtrar(); } }


        public data() 
        {
            Limpiar();
        }

        public void Limpiar()
        {
            _estatus = null;
            _desde = DateTime.Now.Date;
            _hasta= DateTime.Now.Date;
            _prov = null;
        }

        public void setFechaDesde(DateTime fecha)
        {
            _desde = fecha;
        }

        public void setFechaHasta(DateTime fecha)
        {
            _hasta = fecha;
        }

        public bool IsValida()
        {
            if (_desde>_hasta)
            {
                Helpers.Msg.Error("FECHAS INCORRECTAS");
                return false;
            }
            return true;
        }

        public void setEstatus(ficha ficha)
        {
            _estatus = ficha;
        }

        private string filtrar()
        {
            var rt = "";
            rt += "Desde: " + _desde.ToShortDateString();
            rt += ", Hasta: " + _hasta.ToShortDateString();
            if (_estatus !=null)
            {
                rt += ", Estatus: " + _estatus.desc;
            };
            if (_prov != null)
            {
                rt += ", Proveedor: " + _prov.razonSocial;
            };

            return rt;
        }

        public void setProveedor(Proveedor.Lista.data ficha)
        {
            _prov = ficha;
        }

    }

}