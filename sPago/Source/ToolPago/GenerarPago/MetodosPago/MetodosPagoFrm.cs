using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.GenerarPago.MetodosPago
{
    
    public partial class MetodosPagoFrm : Form
    {


        private Gestion _controlador;


        public MetodosPagoFrm()
        {
            InitializeComponent();
            InicializarGrid_1();
            InicializarCombos();
        }

        private void InicializarCombos()
        {
            CB_MEDIO_PAGO.DisplayMember = "desc";
            CB_MEDIO_PAGO.ValueMember = "auto";
        }

        private void InicializarGrid_1()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 10, FontStyle.Bold);

            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;


            var xc1 = new DataGridViewTextBoxColumn();
            xc1.DataPropertyName = "DescMedioPago";
            xc1.HeaderText = "Medio Pago";
            xc1.Visible = true;
            xc1.MinimumWidth = 100;
            xc1.HeaderCell.Style.Font = f;
            xc1.DefaultCellStyle.Font = f1;
            xc1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc1.AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;
            xc1.ReadOnly = true;

            var xc2 = new DataGridViewTextBoxColumn();
            xc2.DataPropertyName = "Importe";
            xc2.HeaderText = "Importe";
            xc2.Visible = true;
            xc2.Width = 120;
            xc2.HeaderCell.Style.Font = f;
            xc2.DefaultCellStyle.Font = f1;
            xc2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc2.DefaultCellStyle.Format = "n2";
            xc2.ReadOnly = true;

            DGV.Columns.Add(xc1);
            DGV.Columns.Add(xc2);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void MetodosPagoFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.SourcePago;
            CB_MEDIO_PAGO.DataSource = _controlador.SourceMedioPago;
            L_MONTO_PAGAR.Text = _controlador.MontoPagar.ToString("n2");
            TB_FACTOR.Enabled = CHB_APLICA_FACTOR.Checked;
            ActualizarFicha();
            ActualizarTotal();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            AceptarFicha();
        }

        private void AceptarFicha()
        {
            _controlador.AceptarFicha();
            if (_controlador.AceptarFichaIsOk) 
            {
                ActualizarFicha();
                ActualizarTotal();
            }
        }

        private void ActualizarTotal()
        {
            L_MONTO_RECIBIDO.Text = _controlador.MontoRecibido.ToString("n2");
            L_MONTO_PEND.Text = _controlador.MontoPend.ToString("n2");
            L_RESTA_CAMBIO.Text = _controlador.RestaCambio;
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }

        private void Abandonar()
        {
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void MetodosPagoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_MONTO_Leave(object sender, EventArgs e)
        {
            var rt=decimal.Parse(TB_MONTO.Text );
            _controlador.setMonto(rt);
        }

        private void CB_MEDIO_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_MEDIO_PAGO.SelectedIndex == -1)
            {
                _controlador.setMedioPago("");
                return;
            }
            _controlador.setMedioPago(CB_MEDIO_PAGO.SelectedValue.ToString());
        }

        private void CHB_APLICA_FACTOR_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoEditar)
                return;
            TB_FACTOR.Enabled = CHB_APLICA_FACTOR.Checked;
            _controlador.setAplicarFactorCambio();
        }

        private void TB_FACTOR_Leave(object sender, EventArgs e)
        {
            var rt = decimal.Parse(TB_FACTOR.Text);
            _controlador.setFactorCambio(rt);
        }

        private void TB_BANCO_Leave(object sender, EventArgs e)
        {
            _controlador.setBanco(TB_BANCO.Text.Trim().ToUpper());
        }

        private void TB_NUM_CTA_Leave(object sender, EventArgs e)
        {
            _controlador.setNumeroCta(TB_NUM_CTA.Text.Trim().ToUpper());
        }

        private void TB_NUM_CGEQ_REF_Leave(object sender, EventArgs e)
        {
            _controlador.setNumeroChequeRef(TB_NUM_CGEQ_REF.Text.Trim().ToUpper());
        }

        private void DTP_FECHA_OPERACION_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setFechaOperacion(DTP_FECHA_OPERACION.Value);
        }

        private void TB_DETALLE_OPERACION_Leave(object sender, EventArgs e)
        {
            _controlador.setDetalle(TB_DETALLE_OPERACION.Text.Trim());
        }

        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarFicha();
        }

        private void AgregarFicha()
        {
            if (_controlador.HabilitarFichaIsOk)
            {
                return;
            }
            _controlador.AgregarFicha();
            ActualizarFicha();
        }

        private void ActualizarFicha()
        {
            P_FICHA.Enabled = _controlador.HabilitarFichaIsOk;
            CB_MEDIO_PAGO.SelectedValue = _controlador.GetIdMedioPago;
            TB_MONTO.Text = _controlador.GetMonto.ToString();
            TB_NUM_CTA.Text = _controlador.GetNumeroCta;
            TB_NUM_CGEQ_REF.Text = _controlador.GetNumeroChequeRef;
            TB_DETALLE_OPERACION.Text = _controlador.GetDetalleOperacion;
            TB_BANCO .Text = _controlador.GetBanco;
            TB_FACTOR.Text = _controlador.GetfactorCambio.ToString();
            CHB_APLICA_FACTOR.Checked = _controlador.GetAplicaFactorCambio;
            DTP_FECHA_OPERACION.Value = _controlador.GetFechaOperacion;
            TB_FACTOR.Enabled = _controlador.GetAplicaFactorCambio;
        }

        private void BT_ELIMINAR_METODO_PAGO_Click(object sender, EventArgs e)
        {
            EliminarMetodoPago();
        }

        private void EliminarMetodoPago()
        {
            _controlador.EliminarMetodoPago();
            ActualizarTotal();
        }

        private void BT_DESCARTAR_Click(object sender, EventArgs e)
        {
            DescartarFicha();
        }

        private void DescartarFicha()
        {
            _controlador.DescartarFicha();
            if (_controlador.DescartarIsOk) 
            {
                ActualizarFicha();
                ActualizarTotal();
            }
        }

        bool _modoEditar;
        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarMetodoPago();
            if (_controlador.EditarMetodoPagoIsOk)
            {
                _modoEditar = true;
                ActualizarFicha();
                ActualizarTotal();
                _modoEditar = false;
            }
        }

        private void EditarMetodoPago()
        {
            _controlador.EditarMetodoPago();
        }
   
    }

}