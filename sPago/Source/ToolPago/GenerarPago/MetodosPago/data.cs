using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.GenerarPago.MetodosPago
{

    public class data
    {

        private ficha _medioPago;
        private decimal _monto;
        private bool _aplicarFactorCambio;
        private decimal _factorCambio;
        private string _banco;
        private string _numeroCta;
        private string _detalle;
        private DateTime _fechaOperacion;
        private string _numeroChequeRef;


        public ficha GetMedioPago { get { return _medioPago; } }
        public decimal GetMonto { get { return _monto; } }
        public string GetNumeroCta { get { return _numeroCta; } }
        public string GetNumeroChequeRef { get { return _numeroChequeRef; } }
        public string GetDetalleOperacion { get { return _detalle; } }
        public string GetBanco { get { return _banco; } }
        public decimal GetFactorCambio { get { return _factorCambio; } }
        public bool GetAplicaFactorCambio { get { return _aplicarFactorCambio; } }
        public DateTime GetFechaOperacion { get { return _fechaOperacion; } }
        public string GetIdMedioPago 
        { 
            get 
            {
                var id="";
                if (_medioPago != null) { id = _medioPago.auto; }
                return id;
            }
        }
        public string DescMedioPago
        {
            get
            {
                var id = "";
                if (_medioPago != null) { id = _medioPago.desc; }
                return id;
            }
        }
        public decimal Importe 
        {
            get 
            {
                var rt = _monto;
                if (_aplicarFactorCambio) 
                {
                    rt = _monto * _factorCambio;
                }
                return rt;
            }
        }


        public data()
        {
            Limpiar();
        }

        public data(data _data)
            :this()
        {
            _medioPago = _data._medioPago;
            _monto = _data._monto;
            _aplicarFactorCambio = _data._aplicarFactorCambio;
            _factorCambio = _data._factorCambio;
            _banco = _data._banco;
            _numeroCta = _data._numeroCta;
            _detalle = _data._detalle;
            _fechaOperacion = _data._fechaOperacion;
            _numeroChequeRef = _data._numeroChequeRef;
        }


        public void Limpiar()
        {
            _medioPago = null;
            _monto = 0m;
            _aplicarFactorCambio = false;
            _factorCambio = 0m;
            _banco = "";
            _numeroCta = "";
            _detalle = "";
            _fechaOperacion = DateTime.Now.Date;
            _numeroChequeRef = "";
        }


        public void setMonto(decimal m)
        {
            _monto = m;
        }
        public void setMedioPago(ficha ficha)
        {
            _medioPago = ficha;
        }
        public void setAplicarFactorCambio()
        {
            _aplicarFactorCambio = !_aplicarFactorCambio;
        }
        public void setFactorCambio(decimal rt)
        {
            _factorCambio = rt;
        }
        public void setBanco(string p)
        {
            _banco = p;
        }
        public void setNumeroCta(string p)
        {
            _numeroCta = p;
        }
        public void setDetalle(string p)
        {
            _detalle = p;
        }
        public void setFechaOperacion(DateTime fecha)
        {
            _fechaOperacion = fecha;
        }
        public void setNumeroChequeRef(string p)
        {
            _numeroChequeRef = p;
        }

        public bool IsValida()
        {
            if (_medioPago == null)
            {
                Helpers.Msg.Error("MEDIO DE PAGO NO SELECCIONADO");
                return false;
            }
            if (Importe ==0m)
            {
                Helpers.Msg.Error("MONTO IMPORTE INCORRECTO");
                return false;
            }

            return true;
        }

    }

}