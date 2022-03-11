using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.GenerarPago.MetodosPago
{
    
    public class Gestion: IMetodosPago
    {


        private data _data;
        private decimal _montoPagar;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private List<ficha> _lstMP;
        private BindingSource _bsMP;
        private bool _habilitarFicha;
        private bool _aceptarFichaIsOk;
        private bool _descartarIsOk;
        private List<data> _lstPago;
        private BindingList<data> _blPago;
        private BindingSource _bsPago;
        private bool _editarMetodoPagoIsOk;


        public decimal MontoPagar { get { return _montoPagar; } }
        public List<data> ListaMetodosPago { get { return _blPago.ToList(); } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public BindingSource SourceMedioPago { get { return _bsMP; } }
        public bool HabilitarFichaIsOk { get { return _habilitarFicha; } }
        public decimal GetMonto { get { return _data.GetMonto; } }
        public string GetIdMedioPago { get { return _data.GetIdMedioPago; } }
        public string GetNumeroCta { get { return _data.GetNumeroCta; } }
        public string GetNumeroChequeRef { get { return _data.GetNumeroChequeRef; } }
        public string GetDetalleOperacion { get { return _data.GetDetalleOperacion; } }
        public string GetBanco { get { return _data.GetBanco; } }
        public decimal GetfactorCambio { get { return _data.GetFactorCambio; } }
        public bool GetAplicaFactorCambio { get { return _data.GetAplicaFactorCambio; } }
        public DateTime GetFechaOperacion { get { return _data.GetFechaOperacion; } }
        public bool AceptarFichaIsOk { get { return _aceptarFichaIsOk; } }
        public BindingSource SourcePago { get { return _bsPago; } }
        public decimal MontoRecibido { get { return _blPago.Sum(s => s.Importe); } }
        public decimal MontoPend { get { return MontoPagar - MontoRecibido; } }
        public bool DescartarIsOk { get { return _descartarIsOk; } }
        public string RestaCambio { get { return MontoPend > 0 ? "Resta:" : "Cambio:"; } }
        public bool EditarMetodoPagoIsOk { get { return _editarMetodoPagoIsOk; } }


        public Gestion() 
        {
            _lstMP = new List<ficha>();
            _bsMP = new BindingSource();
            _bsMP.DataSource = _lstMP;
            _habilitarFicha = false;
            _data = new data();
            _lstPago = new List<data>();
            _blPago = new BindingList<data>(_lstPago);
            _bsPago = new BindingSource();
            _bsPago.DataSource = _blPago;
        }


        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            _blPago.Clear();
            _descartarIsOk = false;
            _aceptarFichaIsOk = false;
            _editarMetodoPagoIsOk = false;
            _habilitarFicha = false;
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _montoPagar = 0m;
            _data.Limpiar();
        }

        public void setMontoPagar(decimal monto)
        {
            _montoPagar = monto;
        }

        MetodosPagoFrm frm;
        public void Inicia()
        {
            if (CargarDta()) 
            {
                if (frm == null) 
                {
                    frm = new MetodosPagoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarDta()
        {
            var r01 = Sistema.MyData.MedioPago_GetLista();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _lstMP.Clear();
            foreach (var rg in r01.ListaEntidad.OrderBy(o => o.descripcion).ToList())
            {
                _lstMP.Add(new ficha(rg.id.ToString(), rg.codigo, rg.descripcion, rg.id));
            }
            _bsMP.DataSource = _lstMP;
            _bsMP.CurrencyManager.Refresh();

            return true;
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

        public void setMonto(decimal m)
        {
            _data.setMonto(m);
        }
        public void setMedioPago(string auto)
        {
            _data.setMedioPago(_lstMP.FirstOrDefault(f => f.auto == auto));
        }
        public void setAplicarFactorCambio()
        {
            _data.setAplicarFactorCambio();
        }
        public void setFactorCambio(decimal rt)
        {
            _data.setFactorCambio(rt);
        }
        public void setBanco(string p)
        {
            _data.setBanco(p);
        }
        public void setNumeroCta(string p)
        {
            _data.setNumeroCta(p);
        }
        public void setDetalle(string p)
        {
            _data.setDetalle(p);
        }
        public void setFechaOperacion(DateTime fecha)
        {
            _data.setFechaOperacion(fecha);
        }
        public void setNumeroChequeRef(string p)
        {
            _data.setNumeroChequeRef(p);
        }

        public void AgregarFicha()
        {
            if (_habilitarFicha)
                return;

            _editarMetodoPagoIsOk = false;
            _aceptarFichaIsOk = false;
            _habilitarFicha = true;
            _data.Limpiar();
            _descartarIsOk = false;
        }

        public void AceptarFicha()
        {
            _descartarIsOk = false;
            if (_data.IsValida())
            {
                _editarMetodoPagoIsOk = false;
                _blPago.Add(new data(_data));
                _aceptarFichaIsOk = true;
                _habilitarFicha = false;
                _data.Limpiar();
            }
        }

        public void EliminarMetodoPago()
        {
            _editarMetodoPagoIsOk = false;
            if (_bsPago.Current != null) 
            {
                if (_habilitarFicha) { return; }

                var it = (data)_bsPago.Current;
                _blPago.Remove(it);
                _bsPago.CurrencyManager.Refresh();
            }
        }

        public void DescartarFicha()
        {
            _editarMetodoPagoIsOk = false;
            _descartarIsOk = true;
            _aceptarFichaIsOk = false;
            _habilitarFicha = false;
            _data.Limpiar();
        }

        public void Procesar()
        {
            if (_montoPagar > MontoRecibido)
            {
                Helpers.Msg.Error("MONTO RECIBIDO INFERIOR AL MONTO A PAGAR");
                return;
            }
            if (MontoRecibido > _montoPagar)
            {
                Helpers.Msg.Error("MONTO RECIBIDO SUPERIOR AL MONTO A PAGAR");
                return;
            }

            if (MontoRecibido >= _montoPagar) 
            {
                _procesarIsOk = false;
                var msg = "Procesar y Guardar Los Cambios ?";
                var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (r == DialogResult.Yes)
                {
                    _procesarIsOk = true;
                }
            }
        }

        public void EditarMetodoPago()
        {
            _editarMetodoPagoIsOk = false;
            if (_habilitarFicha)
            {
                return;
            }
            if (_bsPago.Current != null)
            {
                var it = (data)_bsPago.Current;
                _aceptarFichaIsOk = false;
                _habilitarFicha = true;
                _data.setData(it);
                _blPago.Remove(it);
                _descartarIsOk = false;
                _editarMetodoPagoIsOk = true;
            }
        }

    }

}