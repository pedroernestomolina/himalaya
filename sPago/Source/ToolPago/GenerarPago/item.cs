using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.GenerarPago
{
    
    public class item
    {

        private OOB.ToolPago.PendPagar.Ficha _ficha;
        private decimal _montoPagar;
        private bool _isPagarActiva;
        private string _detallePago;


        public decimal MontoPagar { get { return _montoPagar; } }
        public DateTime FechaDoc { get { return _ficha.fechaEmision; } }
        public string TipoDoc { get { return _ficha.tipoDoc; } }
        public string NumeroDoc { get { return _ficha.numeroDoc; } }
        public DateTime FechaVence { get { return _ficha.fechaVence; } }
        public int DiasPend { get { return _ficha.diasPend; } }
        public decimal ImporteDoc { get { return _ficha.importeDoc; } }
        public decimal AcumuladoDoc { get { return _ficha.acumuladoDoc; } }
        public decimal RestaDoc { get { return _ficha.restaDoc; } }
        public bool IsPagarActiva { get { return _isPagarActiva; } }
        public OOB.ToolPago.PendPagar.Ficha Ficha { get { return _ficha; } }
        public string DetallePago { get { return _detallePago; } }


        public item(OOB.ToolPago.PendPagar.Ficha ficha)
        {
            _isPagarActiva = false;
            _montoPagar = 0;
            this._ficha  = ficha;
        }

        public void setActivarPagar(decimal monto, string detalle)
        {
            _isPagarActiva = false;
            _montoPagar = 0m;
            _detallePago = "";
            if (monto > 0)
            {
                _isPagarActiva = true;
                _montoPagar = monto * _ficha.signoDoc;
                _detallePago = detalle;
            }
        }

    }

}