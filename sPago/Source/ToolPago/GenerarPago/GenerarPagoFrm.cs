using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.GenerarPago
{

    public partial class GenerarPagoFrm : Form
    {


        private GenerarPago.Gestion _controlador;


        public GenerarPagoFrm()
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


            var xc1 = new DataGridViewTextBoxColumn();
            xc1.DataPropertyName = "FechaDoc";
            xc1.HeaderText = "Fecha/Doc";
            xc1.Visible = true;
            xc1.Width = 80;
            xc1.HeaderCell.Style.Font = f;
            xc1.DefaultCellStyle.Font = f1;
            xc1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc1.ReadOnly = true;

            var xc2 = new DataGridViewTextBoxColumn();
            xc2.DataPropertyName = "TipoDoc";
            xc2.HeaderText = "Tipo/Doc";
            xc2.Visible = true;
            xc2.Width = 80;
            xc2.HeaderCell.Style.Font = f;
            xc2.DefaultCellStyle.Font = f1;
            xc2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            xc2.ReadOnly = true;

            var xc3 = new DataGridViewTextBoxColumn();
            xc3.DataPropertyName = "NumeroDoc";
            xc3.HeaderText = "Numero/Doc";
            xc3.Visible = true;
            xc3.MinimumWidth = 100;
            xc3.HeaderCell.Style.Font = f;
            xc3.DefaultCellStyle.Font = f1;
            xc3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            xc3.ReadOnly = true;

            var xc4 = new DataGridViewTextBoxColumn();
            xc4.DataPropertyName = "FechaVence";
            xc4.HeaderText = "Fecha/Vto";
            xc4.Visible = true;
            xc4.Width = 80;
            xc4.HeaderCell.Style.Font = f;
            xc4.DefaultCellStyle.Font = f1;
            xc4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc4.ReadOnly = true;

            var xcB = new DataGridViewTextBoxColumn();
            xcB.DataPropertyName = "DiasPend";
            xcB.HeaderText = "Dias/Pend";
            xcB.Name = "DIASPEND_CTAPAGAR";
            xcB.Visible = true;
            xcB.Width = 80;
            xcB.HeaderCell.Style.Font = f;
            xcB.DefaultCellStyle.Font = f1;
            xcB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xcB.ReadOnly = true;

            var xc8 = new DataGridViewTextBoxColumn();
            xc8.DataPropertyName = "ImporteDoc";
            xc8.HeaderText = "Importe";
            xc8.Visible = true;
            xc8.Width = 120;
            xc8.HeaderCell.Style.Font = f;
            xc8.DefaultCellStyle.Font = f1;
            xc8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc8.DefaultCellStyle.Format = "n2";
            xc8.ReadOnly = true;

            var xc9 = new DataGridViewTextBoxColumn();
            xc9.DataPropertyName = "AcumuladoDoc";
            xc9.HeaderText = "Acumulado";
            xc9.Visible = true;
            xc9.Width = 120;
            xc9.HeaderCell.Style.Font = f;
            xc9.DefaultCellStyle.Font = f1;
            xc9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc9.DefaultCellStyle.Format = "n2";
            xc9.ReadOnly = true;

            var xcA = new DataGridViewTextBoxColumn();
            xcA.DataPropertyName = "RestaDoc";
            xcA.HeaderText = "Resta";
            xcA.Visible = true;
            xcA.Width = 120;
            xcA.HeaderCell.Style.Font = f;
            xcA.DefaultCellStyle.Font = f1;
            xcA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xcA.DefaultCellStyle.Format = "n2";
            xcA.ReadOnly = true;

            var xcC = new DataGridViewCheckBoxColumn();
            xcC.DataPropertyName = "IsPagarActiva";
            xcC.HeaderText = "";
            xcC.Visible = true;
            xcC.Width = 40;
            xcC.ReadOnly = true;

            var xcD = new DataGridViewTextBoxColumn();
            xcD.DataPropertyName = "MontoPagar";
            xcD.HeaderText = "Monto Pagar";
            xcD.Visible = true;
            xcD.Width = 120;
            xcD.HeaderCell.Style.Font = f;
            xcD.DefaultCellStyle.Font = f1;
            xcD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xcD.DefaultCellStyle.Format = "n2";
            xcD.ReadOnly=true;

            DGV.Columns.Add(xc1);
            DGV.Columns.Add(xc2);
            DGV.Columns.Add(xc3);
            DGV.Columns.Add(xc4);
            DGV.Columns.Add(xcB);
            DGV.Columns.Add(xc8);
            DGV.Columns.Add(xc9);
            DGV.Columns.Add(xcA);
            DGV.Columns.Add(xcC);
            DGV.Columns.Add(xcD);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void GenerarPagoFrm_Load(object sender, EventArgs e)
        {
            L_MONTO_PAGAR.Text = _controlador.MontoPagar.ToString("n2");
            L_PROVEEDOR.Text = _controlador.DataProveedor;
            L_CNT_DOC_PAGAR.Text = "Documentos Pendientes Por Pagar: " + _controlador.CntDocPagar.ToString();
            DGV.DataSource = _controlador.SourceDocPagar;
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarPago();
        }

        private void ProcesarPago()
        {
            _controlador.ProcesarPago();
            if (_controlador.ProcesarPagoIsOk)
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

        private void BT_MARCAR_Click(object sender, EventArgs e)
        {
            MarcarItemPagar();
        }

        private void MarcarItemPagar()
        {
            _controlador.MarcarItemPagar();
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            L_MONTO_PAGAR.Text = _controlador.MontoPagar.ToString("n2");
        }

        private void BT_DESMARCAR_Click(object sender, EventArgs e)
        {
            LimpiarItemPagar();
        }

        private void LimpiarItemPagar()
        {
            _controlador.LimpiarItemPagar();
            ActualizarTotal();
        }

        private void GenerarPagoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarPagoIsOk)
            {
                e.Cancel = false;
            }
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                _controlador.MarcarDesmarcarDoc();
                ActualizarTotal();
            }
        }

    }

}