using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.RetISLR.Administrador.Filtro
{
    
    public class data
    {

        private DateTime _desde;
        private DateTime _hasta;


        public DateTime GetDesde { get { return _desde; } }
        public DateTime GetHasta { get { return _hasta; } }


        public data()
        {
            Limpiar();
        }


        public void Limpiar()
        {
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
       }

        public void setFechaDesde(DateTime fecha)
        {
            _desde = fecha;
        }

        public void setFechaHasta(DateTime fecha)
        {
            _hasta = fecha;
        }

    }

}