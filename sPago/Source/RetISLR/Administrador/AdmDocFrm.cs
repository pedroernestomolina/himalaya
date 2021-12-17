using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.RetISLR.Administrador
{

    public partial class AdmDocFrm : Form
    {


        private Gestion _controlador;


        public AdmDocFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }


        private void InicializarGrid()
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

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Fecha";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Documento";
            c3.HeaderText = "Documento";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "PROVEEDOR";
            c4.HeaderText = "Proveedor";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.MinimumWidth = 220;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CIRIFPROV";
            c5.HeaderText = "CI/RIF";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.Width = 100;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "TASARETENCION";
            c6.HeaderText = "(%) Ret";
            c6.Visible = true;
            c6.Width = 80;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Format = "n2";
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "MONTORETENCION";
            c7.HeaderText = "Monto Ret";
            c7.Visible = true;
            c7.Width = 120;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Format="n2";
            c7.DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight ;
            
            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "ISACTIVO";
            c8.HeaderText = "Estatus";
            c8.Name = "ESTATUS";
            c8.Visible = true;
            c8.Width = 100;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f2;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ESTATUS"].Value.ToString() !="")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.Cells["ESTATUS"].Style.BackColor = Color.Red;
                    row.Cells["ESTATUS"].Style.ForeColor = Color.White;
                }
            }
        }

        private void AdministradorFrm_Load(object sender, EventArgs e)
        {
            DTP_DESDE.Value = _controlador.Desde;
            DTP_HASTA.Value = _controlador.Hasta;
            DGV.DataSource = _controlador.ItemSource;
            DGV.Refresh();
            Actualizar();
        }

        private void Actualizar()
        {
            L_ITEMS.Text = "Items Encontrados: "+_controlador.CntItems.ToString();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.Buscar();
            Actualizar();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            AnularItem();
        }

        private void AnularItem()
        {
            _controlador.AnularItem();
            DGV.Refresh();
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setFechaDesde(DTP_DESDE.Value);
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setFechaHasta(DTP_HASTA.Value);
        }

        private void BT_LIMPIAR_FILTROS_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            _controlador.LimpiarFiltros();
            DTP_DESDE.Value = _controlador.Desde;
            DTP_HASTA.Value = _controlador.Hasta;
        }

        private void BT_LIMPIAR_DATA_Click(object sender, EventArgs e)
        {
            LimpiarData();
        }

        private void LimpiarData()
        {
            _controlador.LimpiarItems();
            Actualizar();
        }

        private void BT_VISUALIZAR_Click(object sender, EventArgs e)
        {
            VisualizarDocumento();
        }

        private void VisualizarDocumento()
        {
            _controlador.VisualizarDocumento();
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            _controlador.Imprimir();
        }

        private void BT_CORRECTOR_Click(object sender, EventArgs e)
        {
            CorrectorDocumentos();
        }

        private void CorrectorDocumentos()
        {
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex !=-1 && e.ColumnIndex!=-1)
            {
                VisualizarDocAnulado();
            }
        }

        private void VisualizarDocAnulado()
        {
            _controlador.VisualizarDocAnulado();
        }

    }

}