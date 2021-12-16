using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.RetISLR.Administrador.Filtro
{
    
    public class Gestion
    {

        private data _data;


        public DateTime GetDesde { get { return _data.GetDesde; } }
        public DateTime GetHasta { get { return _data.GetHasta; } }
        public string Filtros { get; set; }


        public Gestion()
        {
            _data = new data();
        }


        public void Inicializa()
        {
            _data.Limpiar();
        }

        public void setFechaDesde(DateTime fecha)
        {
            _data.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _data.setFechaHasta(fecha);
        }

    }

}