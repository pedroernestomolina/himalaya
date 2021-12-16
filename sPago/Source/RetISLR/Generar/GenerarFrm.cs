using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.RetISLR.Generar
{

    public partial class GenerarFrm : Form
    {

        private Gestion _controlador;
        private bool _modoInicializar;


        public GenerarFrm()
        {
            InitializeComponent();
            InicializaGrid_1();
            InicializaGrid_2();
        }

        private void InicializaGrid_1()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

            DGV_1.AllowUserToAddRows = false;
            DGV_1.AllowUserToDeleteRows = false;
            DGV_1.AutoGenerateColumns = false;
            DGV_1.AllowUserToResizeRows = false;
            DGV_1.AllowUserToResizeColumns = false;
            DGV_1.AllowUserToOrderColumns = false;
            DGV_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_1.MultiSelect = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Origen";
            c1.HeaderText = "Origen/Tipo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 120;
            c1.ReadOnly = true;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Documento";
            c2.HeaderText = "Documento";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 100;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Control";
            c3.HeaderText = "Control";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c3.ReadOnly = true;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Serie";
            c4.HeaderText = "Serie";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c4.ReadOnly = true;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Fecha";
            c5.HeaderText = "Fecha";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c5.ReadOnly = true;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Monto";
            c6.HeaderText = "Monto";
            c6.Visible = true;
            c6.Width = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.ReadOnly = true;

            var c7 = new DataGridViewCheckBoxColumn();
            c7.DataPropertyName = "IsActivo";
            c7.HeaderText = "";
            c7.Visible = true;
            c7.Width = 20;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c7.ReadOnly = false;

            DGV_1.Columns.Add(c1);
            DGV_1.Columns.Add(c2);
            DGV_1.Columns.Add(c3);
            DGV_1.Columns.Add(c4);
            DGV_1.Columns.Add(c5);
            DGV_1.Columns.Add(c6);
            DGV_1.Columns.Add(c7);
        }

        private void InicializaGrid_2()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

            DGV_2.AllowUserToAddRows = false;
            DGV_2.AllowUserToDeleteRows = false;
            DGV_2.AutoGenerateColumns = false;
            DGV_2.AllowUserToResizeRows = false;
            DGV_2.AllowUserToResizeColumns = false;
            DGV_2.AllowUserToOrderColumns = false;
            DGV_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_2.MultiSelect = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Origen";
            c1.HeaderText = "Origen/Tipo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 100;
            c1.ReadOnly = true;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Documento";
            c2.HeaderText = "Documento";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 100;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Control";
            c3.HeaderText = "Control";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c3.ReadOnly = true;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Serie";
            c4.HeaderText = "Serie";
            c4.Visible = true;
            c4.Width = 60;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c4.ReadOnly = true;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Fecha";
            c5.HeaderText = "Fecha";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c5.ReadOnly = true;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Monto";
            c6.HeaderText = "Monto";
            c6.Visible = true;
            c6.Width = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";
            c6.ReadOnly = true;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "EXENTO";
            c7.HeaderText = "Exento";
            c7.Visible = true;
            c7.Width = 100;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";
            c7.ReadOnly = true;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "BASE";
            c8.HeaderText = "Base";
            c8.Visible = true;
            c8.Width = 100;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";
            c8.ReadOnly = true;

            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "IVA";
            c9.HeaderText = "Iva";
            c9.Visible = true;
            c9.Width = 100;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f1;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c9.DefaultCellStyle.Format = "n2";
            c9.ReadOnly = true;

            var cA = new DataGridViewTextBoxColumn();
            cA.DataPropertyName = "MontoRetencion";
            cA.Name = "RETENCION";
            cA.HeaderText = "MONTO/RET";
            cA.Visible = true;
            cA.Width = 100;
            cA.HeaderCell.Style.Font = f;
            cA.DefaultCellStyle.Font = f1;
            cA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cA.DefaultCellStyle.Format = "n2";
            cA.ReadOnly = true;

            DGV_2.Columns.Add(c1);
            DGV_2.Columns.Add(c2);
            DGV_2.Columns.Add(c3);
            DGV_2.Columns.Add(c4);
            DGV_2.Columns.Add(c5);
            DGV_2.Columns.Add(c6);
            DGV_2.Columns.Add(c7);
            DGV_2.Columns.Add(c8);
            DGV_2.Columns.Add(c9);
            DGV_2.Columns.Add(cA);
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void GenerarFrm_Load(object sender, EventArgs e)
        {
            DGV_1.DataSource = _controlador.SourceDocProv;
            DGV_2.DataSource = _controlador.SourceDocRet;
            _modoInicializar = true;
            L_PROVEEDOR.Text = _controlador.DataProveedor;
            L_FECHA_APLICAR.Text = _controlador.Fecha.ToShortDateString();
            L_ULTIMO_RETENCION.Text = _controlador.UltimaRetISLR.ToString().Trim().PadLeft(10, '0');
            L_DOC_ENCONTRADOS.Text = _controlador.CntDocEncontrados.ToString();
            ActualizarTotales();
            ActualizarDataProveedor();

            switch (_controlador.PrefBusqueda)
            {
                case  Gestion.enumPrefBusqueda.PorCodigo:
                    R_CODIGO.Checked = true;
                    break;
                case Gestion.enumPrefBusqueda.PorRazonSocial:
                    R_NOMBRE.Checked = true;
                    break;
                case Gestion.enumPrefBusqueda.PorCiRif:
                    R_CIRIF.Checked = true;
                    break;
            }
            _modoInicializar = false;
            IrFoco();
        }

        private void IrFoco()
        {
            TB_CADENA.Focus();
        }

        private void TB_CADENA_Leave(object sender, EventArgs e)
        {
            _controlador.setCadenaBuscar(TB_CADENA.Text.Trim());
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.Buscar();
            ActualizarDataProveedor();
            TB_CADENA.Text = "";
            IrFoco();
        }

        private void ActualizarDataProveedor()
        {
            L_PROVEEDOR.Text = _controlador.DataProveedor;
            TB_PORCT_RET.Text = _controlador.DataProveedorRetISLR.ToString();
            L_DOC_ENCONTRADOS.Text = _controlador.CntDocEncontrados.ToString();
        }

        private void R_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            IrFoco();
            if (_modoInicializar)
                return;
            _controlador.setPrefBusquedaPorCodigo();
        }

        private void R_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            IrFoco();
            if (_modoInicializar)
                return;
            _controlador.setPrefBusquedaPorNombre();

        }

        private void R_CIRIF_CheckedChanged(object sender, EventArgs e)
        {
            IrFoco();
            if (_modoInicializar)
                return;
            _controlador.setPrefBusquedaPorCiRif();
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_APLICAR_RET_Click(object sender, EventArgs e)
        {
            AplicarRetDocSeleccionados();
        }

        private void AplicarRetDocSeleccionados()
        {
            _controlador.AplicarRetDocSeleccionados();
            DGV_2.Refresh();
            ActualizarTotales();
        }

        private void TB_PORCT_RET_Leave(object sender, EventArgs e)
        {
            _controlador.setTasaRetencion(decimal.Parse(TB_PORCT_RET.Text));
            DGV_2.Refresh();
            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            L_CNT_ITEM.Text = _controlador.Items.ToString();
            L_MONTO.Text = "Bs "+_controlador.Monto.ToString("n2");
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

        private void GenerarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarRetencionIsOK) 
            {
                e.Cancel = false;
            }
        }

        private void DGV_2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV_2.Rows)
            {
                decimal rt=0m;
                decimal.TryParse(row.Cells["RETENCION"].Value.ToString(),out rt);
                if (rt < 0m)
                {
                    row.Cells["RETENCION"].Style.ForeColor = Color.White;
                    row.Cells["RETENCION"].Style.BackColor = Color.Red;
                }
            }

        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFicha();
        }

        private void LimpiarFicha()
        {
            _controlador.LimpiarFicha();
            ActualizarDataProveedor();
            ActualizarTotales();
            DGV_1.Refresh();
            DGV_2.Refresh();
            IrFoco();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }

        private void ProcesarFicha()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarRetencionIsOK)
            {
                Salir();
            }
        }

        public void ActualizarSaldos()
        {
            ActualizarTotales();
        }

    }

}