using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago
{

    public partial class PrincipalFrm : Form
    {


        private Gestion _controlador;


        public PrincipalFrm()
        {
            InitializeComponent();
            InicializarGrid_1();
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
            DGV.ReadOnly = true;


            var xc6 = new DataGridViewTextBoxColumn();
            xc6.DataPropertyName = "ProvNombre";
            xc6.HeaderText = "Proveedor";
            xc6.Visible = true;
            xc6.MinimumWidth = 200;
            xc6.HeaderCell.Style.Font = f;
            xc6.DefaultCellStyle.Font = f1;
            xc6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var xc7 = new DataGridViewTextBoxColumn();
            xc7.DataPropertyName = "ProvCiRif";
            xc7.HeaderText = "CI/Rif";
            xc7.Visible = true;
            xc7.Width = 100;
            xc7.HeaderCell.Style.Font = f;
            xc7.DefaultCellStyle.Font = f1;

            var xc5 = new DataGridViewTextBoxColumn();
            xc5.DataPropertyName = "CntDoc";
            xc5.HeaderText = "Cnt/Doc";
            xc5.Visible = true;
            xc5.Width = 70;
            xc5.HeaderCell.Style.Font = f;
            xc5.DefaultCellStyle.Font = f1;
            xc5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc5.DefaultCellStyle.Format = "n0";

            var xc8 = new DataGridViewTextBoxColumn();
            xc8.DataPropertyName = "Importe";
            xc8.HeaderText = "Importe";
            xc8.Visible = true;
            xc8.Width = 100;
            xc8.HeaderCell.Style.Font = f;
            xc8.DefaultCellStyle.Font = f1;
            xc8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc8.DefaultCellStyle.Format = "n2";

            var xc9 = new DataGridViewTextBoxColumn();
            xc9.DataPropertyName = "Acumulado";
            xc9.HeaderText = "Acumulado";
            xc9.Visible = true;
            xc9.Width = 100;
            xc9.HeaderCell.Style.Font = f;
            xc9.DefaultCellStyle.Font = f1;
            xc9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc9.DefaultCellStyle.Format = "n2";

            var xcA = new DataGridViewTextBoxColumn();
            xcA.DataPropertyName = "Resta";
            xcA.HeaderText = "Resta";
            xcA.Visible = true;
            xcA.Width = 100;
            xcA.HeaderCell.Style.Font = f;
            xcA.DefaultCellStyle.Font = f1;
            xcA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xcA.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(xc6);
            DGV.Columns.Add(xc7);
            DGV.Columns.Add(xc5);
            DGV.Columns.Add(xc8);
            DGV.Columns.Add(xc9);
            DGV.Columns.Add(xcA);
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void PrincipalFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.SourceItems;
            ActualizarMontos();
        }

        private void ActualizarMontos()
        {
            L_ACUMULADO.Text = _controlador.Acumulado.ToString("n2");
            L_RESTA.Text = _controlador.Resta.ToString("n2");
            L_IMPORTE.Text = _controlador.Importe.ToString("n2");
            L_ITEMS.Text = "Items Encontrados: " + _controlador.CntItem.ToString("n0");
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 || e.RowIndex != -1) 
            {
                VisualizarProveedor();
            }
        }

        private void VisualizarProveedor()
        {
            _controlador.VisualizarProveedor();
        }

        private void BT_VISUALIZAR_DOCUMENTOS_Click(object sender, EventArgs e)
        {
            VisualizarDocumentosPendientes();
        }

        private void VisualizarDocumentosPendientes()
        {
            _controlador.VisualizarDocumentosPendientes();
        }

        private void BT_AGREGAR_DOCUMENTO_Click(object sender, EventArgs e)
        {
            AgregarDocumento();
        }

        private void AgregarDocumento()
        {
            _controlador.AgregarDocumento();
            if (_controlador.AgregarDocumentoIsOk)
            {
                ActualizarMontos();
            };
        }

        private void BT_PAGO_Click(object sender, EventArgs e)
        {
            GenerarPago();
        }

        private void GenerarPago()
        {
            _controlador.GenerarPago();
            if (_controlador.GenerarPagIsOk)
            {
                ActualizarMontos();
            };
        }

    }

}