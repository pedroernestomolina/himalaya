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
            DGV_1.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Origen";
            c1.HeaderText = "Origen/Tipo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 120;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Documento";
            c2.HeaderText = "Documento";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 100;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Control";
            c3.HeaderText = "Control";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Serie";
            c4.HeaderText = "Serie";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Fecha";
            c5.HeaderText = "Fecha";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Monto";
            c6.HeaderText = "Monto";
            c6.Visible = true;
            c6.Width = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c7 = new DataGridViewCheckBoxColumn();
            c7.DataPropertyName = "IsActivo";
            c7.HeaderText = "";
            c7.Visible = true;
            c7.Width = 20;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV_1.Columns.Add(c1);
            DGV_1.Columns.Add(c2);
            DGV_1.Columns.Add(c3);
            DGV_1.Columns.Add(c4);
            DGV_1.Columns.Add(c5);
            DGV_1.Columns.Add(c6);
            DGV_1.Columns.Add(c7);
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void GenerarFrm_Load(object sender, EventArgs e)
        {
            DGV_1.DataSource = _controlador.SourceDoc;
            _modoInicializar = true;
            L_PROVEEDOR.Text = _controlador.DataProveedor;
            L_FECHA_APLICAR.Text = _controlador.Fecha.ToShortDateString();
            L_ULTIMO_RETENCION.Text = _controlador.UltimaRetISLR.ToString().Trim().PadLeft(10, '0');
            L_CNT_ITEM.Text = "0";
            L_MONTO.Text = "Bs 0.00";
            TB_PORCT_RET.Text = "0.0";
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
        }

        private void ActualizarDataProveedor()
        {
            L_PROVEEDOR.Text = _controlador.DataProveedor;
            TB_PORCT_RET.Text = _controlador.DataProveedorRetISLR.ToString();
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

    }

}