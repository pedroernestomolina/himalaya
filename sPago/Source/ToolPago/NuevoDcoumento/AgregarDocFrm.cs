using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.NuevoDcoumento
{

    public partial class AgregarDocFrm : Form
    {


        private Gestion _controlador;


        public AgregarDocFrm()
        {
            InitializeComponent();
            CB_COND_PAGO.DisplayMember = "desc";
            CB_COND_PAGO.ValueMember = "id";
            CB_TIPO_DOC.DisplayMember = "desc";
            CB_TIPO_DOC.ValueMember = "id";
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
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

        private void AgregarDocFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.AgregarDocIsOk)
            {
                e.Cancel = false;
            }
        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void AgregarDocFrm_Load(object sender, EventArgs e)
        {
            CB_COND_PAGO.DataSource = _controlador.SourceCondPago;
            CB_TIPO_DOC.DataSource = _controlador.SourceTipoDoc;

            CB_COND_PAGO.SelectedIndex = -1;
            CB_TIPO_DOC.SelectedIndex = -1;
            DTP_FECHA_EMISION.Value = _controlador.FechaEmision;
            TB_DIAS_CREDITO.Text = _controlador.DiasCredito.ToString("n0");
            L_FECHA_VENC.Text = _controlador.FechaVencimiento.ToShortDateString();
            TB_DOCUMENTO_NUM.Text = _controlador.NumeroDoc;
            TB_DETALLE.Text = _controlador.Detalle;
            TB_IMPORTE.Text = _controlador.Importe.ToString("n2");
            L_PROVEEDOR.Text = _controlador.Proveedor;
        }

        private void CB_COND_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.setCondPago("");
            if (CB_COND_PAGO.SelectedIndex == -1)
            {
                return;
            }
            _controlador.setCondPago(CB_COND_PAGO.SelectedValue.ToString());
        }

        private void CB_TIPO_DOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.setTipoDoc("");
            if (CB_TIPO_DOC.SelectedIndex == -1)
            {
                return;
            }
            _controlador.setTipoDoc(CB_TIPO_DOC.SelectedValue.ToString());
        }

        private void DTP_FECHA_EMISION_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setFechaEmision(DTP_FECHA_EMISION.Value.Date);
        }

        private void TB_DIAS_CREDITO_Leave(object sender, EventArgs e)
        {
            _controlador.setDiasCredito(int.Parse(TB_DIAS_CREDITO.Text));
            L_FECHA_VENC.Text = _controlador.FechaVencimiento.ToShortDateString();
        }

        private void TB_DOCUMENTO_NUM_Leave(object sender, EventArgs e)
        {
            _controlador.setDocumentoNumero(TB_DOCUMENTO_NUM.Text);
        }

        private void TB_IMPORTE_Leave(object sender, EventArgs e)
        {
            _controlador.setImporte(decimal.Parse(TB_IMPORTE.Text));
        }

        private void TB_DETALLE_Leave(object sender, EventArgs e)
        {
            _controlador.setDetalle(TB_DETALLE.Text);
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.AgregarDocIsOk)
            {
                Salir();
            }
        }

        private void TB_CADENA_Leave(object sender, EventArgs e)
        {
            _controlador.setCadenaBuscarProv(TB_CADENA.Text);
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarProveedor();
        }

        private void BuscarProveedor()
        {
            _controlador.BuscarProveedor();
            L_PROVEEDOR.Text = _controlador.Proveedor;
            TB_CADENA.Text = "";
        }

    }

}