using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.PorPagar
{

    public partial class PorPagarFrm : Form
    {


        private Gestion _controlador;


        public PorPagarFrm()
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


            var xc1 = new DataGridViewTextBoxColumn();
            xc1.DataPropertyName = "FechaEmision";
            xc1.HeaderText = "Fecha/Doc";
            xc1.Visible = true;
            xc1.Width = 80;
            xc1.HeaderCell.Style.Font = f;
            xc1.DefaultCellStyle.Font = f1;
            xc1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var xc2 = new DataGridViewTextBoxColumn();
            xc2.DataPropertyName = "TipoDoc";
            xc2.HeaderText = "Tipo/Doc";
            xc2.Visible = true;
            xc2.Width = 80;
            xc2.HeaderCell.Style.Font = f;
            xc2.DefaultCellStyle.Font = f1;
            xc2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var xc3 = new DataGridViewTextBoxColumn();
            xc3.DataPropertyName = "NumeroDoc";
            xc3.HeaderText = "Numero/Doc";
            xc3.Visible = true;
            xc3.MinimumWidth = 100;
            xc3.HeaderCell.Style.Font = f;
            xc3.DefaultCellStyle.Font = f1;
            xc3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc3.AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;

            var xc4 = new DataGridViewTextBoxColumn();
            xc4.DataPropertyName = "FechaVence";
            xc4.HeaderText = "Fecha/Vto";
            xc4.Visible = true;
            xc4.Width = 80;
            xc4.HeaderCell.Style.Font = f;
            xc4.DefaultCellStyle.Font = f1;
            xc4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var xcB = new DataGridViewTextBoxColumn();
            xcB.DataPropertyName = "DiasPend";
            xcB.HeaderText = "Dias/Pend";
            xcB.Name = "DIASPEND_CTAPAGAR";
            xcB.Visible = true;
            xcB.Width = 80;
            xcB.HeaderCell.Style.Font = f;
            xcB.DefaultCellStyle.Font = f1;
            xcB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var xc5 = new DataGridViewTextBoxColumn();
            xc5.DataPropertyName = "DiasTransc";
            xc5.HeaderText = "Dias/Transc";
            xc5.Name = "DIAS_CTAPAGAR";
            xc5.Visible = true;
            xc5.Width = 80;
            xc5.HeaderCell.Style.Font = f;
            xc5.DefaultCellStyle.Font = f1;
            xc5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var xc8 = new DataGridViewTextBoxColumn();
            xc8.DataPropertyName = "ImporteDoc";
            xc8.HeaderText = "Importe";
            xc8.Visible = true;
            xc8.Width = 120;
            xc8.HeaderCell.Style.Font = f;
            xc8.DefaultCellStyle.Font = f1;
            xc8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc8.DefaultCellStyle.Format = "n2";

            var xc9 = new DataGridViewTextBoxColumn();
            xc9.DataPropertyName = "AcumuladoDoc";
            xc9.HeaderText = "Acumulado";
            xc9.Visible = true;
            xc9.Width = 120;
            xc9.HeaderCell.Style.Font = f;
            xc9.DefaultCellStyle.Font = f1;
            xc9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc9.DefaultCellStyle.Format = "n2";

            var xcA = new DataGridViewTextBoxColumn();
            xcA.DataPropertyName = "RestaDoc";
            xcA.HeaderText = "Resta";
            xcA.Visible = true;
            xcA.Width = 120;
            xcA.HeaderCell.Style.Font = f;
            xcA.DefaultCellStyle.Font = f1;
            xcA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xcA.DefaultCellStyle.Format = "n2";


            DGV.Columns.Add(xc1);
            DGV.Columns.Add(xc2);
            DGV.Columns.Add(xc3);
            DGV.Columns.Add(xc4);
            DGV.Columns.Add(xcB);
            DGV.Columns.Add(xc5);
            DGV.Columns.Add(xc8);
            DGV.Columns.Add(xc9);
            DGV.Columns.Add(xcA);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void PorPagarFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            L_PROVEEDOR.Text = _controlador.Proveedor;
            L_IMPORTE.Text = _controlador.Importe.ToString("n2");
            L_ACUMULADO.Text = _controlador.Acumulado.ToString("n2");
            L_RESTA.Text = _controlador.Resta.ToString("n2");
            L_ITEMS.Text = "Items Encontrados: " + _controlador.CntItem.ToString("n0");
        }

    }

}