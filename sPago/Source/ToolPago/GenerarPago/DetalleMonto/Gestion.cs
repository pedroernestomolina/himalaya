using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.GenerarPago.DetalleMonto
{

    public class Gestion : IDetalleMonto
    {

        private string _detalle;
        private decimal _monto;
        private decimal _montoPendiente;
        private bool _detalleMontoIsOk;
        private bool _aceptartIsOk;
        private bool _abandonarIsOk;


        public decimal MontoPendiente { get { return _montoPendiente; } }
        public decimal MontoPagar { get { return _monto; } }
        public string Detalle { get { return _detalle; } }
        public bool DetalleMontoIsOk { get { return _detalleMontoIsOk; } }
        public bool AceptarIsOk { get { return _aceptartIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }


        public Gestion() 
        {
            limpiar();
        }


        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            _aceptartIsOk = false;
            _abandonarIsOk = false;
            _detalleMontoIsOk = false;
            _montoPendiente = 0m;
            _monto = 0m;
            _detalle = "";
        }

        DetalleMontoFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new DetalleMontoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setData(decimal montoPendiente, decimal montoPagar, string detalle)
        {
            if (montoPagar == 0m)
                _monto = montoPendiente;
            else
                _monto = montoPagar;

            _montoPendiente = montoPendiente;
            _detalle = detalle;
        }

        public void setMontoPagar(decimal rt)
        {
            _monto = rt;
        }

        public void setDetalle(string p)
        {
            _detalle = p;
        }

        public void Aceptar()
        {
            _aceptartIsOk = false;
            _detalleMontoIsOk = false;
            if (_monto > _montoPendiente) 
            {
                Helpers.Msg.Error("MONTO A PAGAR INCORRECTO");
                return;
            }
            _aceptartIsOk = true;
            _detalleMontoIsOk = true;
        }

        public void Abandonar()
        {
            _abandonarIsOk = false;
            var msg = "Abandonar y Perder Los Cambios ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

    }

}