using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.AdministradorDoc
{

    public partial class AdmDocFrm : Form
    {


        private Gestion _controlador;


        public AdmDocFrm()
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
            xc1.DataPropertyName = "FechaEmiDoc";
            xc1.HeaderText = "Fecha/Doc";
            xc1.Visible = true;
            xc1.Width = 80;
            xc1.HeaderCell.Style.Font = f;
            xc1.DefaultCellStyle.Font = f1;
            xc1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var xc2 = new DataGridViewTextBoxColumn();
            xc2.DataPropertyName = "TipoDoc";
            xc2.HeaderText = "Tipo/Doc";
            xc2.Name = "TIPODOC_CTAPAGAR";
            xc2.Visible = true;
            xc2.Width = 80;
            xc2.HeaderCell.Style.Font = f;
            xc2.DefaultCellStyle.Font = f1;
            xc2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var xc3 = new DataGridViewTextBoxColumn();
            xc3.DataPropertyName = "NumDoc";
            xc3.HeaderText = "Numero/Doc";
            xc3.Visible = true;
            xc3.Width = 100;
            xc3.HeaderCell.Style.Font = f;
            xc3.DefaultCellStyle.Font = f1;
            xc3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var xc4 = new DataGridViewTextBoxColumn();
            xc4.DataPropertyName = "FechaVtoDoc";
            xc4.HeaderText = "Fecha/Vto";
            xc4.Name = "FECHAVTO_CTAPAGAR";
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

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "TASARETENCION";
            c6.HeaderText = "(%) Ret";
            c6.Name= "TASARET_ISLR";
            c6.Visible = true;
            c6.Width = 80;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Format = "n2";
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "MONTORETENCION";
            c7.HeaderText = "Monto Ret";
            c7.Name = "MONTORET_ISLR";
            c7.Visible = true;
            c7.Width = 120;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Format = "n2";
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var xc8 = new DataGridViewTextBoxColumn();
            xc8.DataPropertyName = "MontoDebe";
            xc8.HeaderText = "Debe";
            xc8.Name = "DEBE_CTAPAGAR";
            xc8.Visible = true;
            xc8.Width = 100;
            xc8.HeaderCell.Style.Font = f;
            xc8.DefaultCellStyle.Font = f1;
            xc8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc8.DefaultCellStyle.Format = "n2";

            var xc9 = new DataGridViewTextBoxColumn();
            xc9.DataPropertyName = "MontoHaber";
            xc9.HeaderText = "Haber";
            xc9.Name = "HABER_CTAPAGAR";
            xc9.Visible = true;
            xc9.Width = 100;
            xc9.HeaderCell.Style.Font = f;
            xc9.DefaultCellStyle.Font = f1;
            xc9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc9.DefaultCellStyle.Format = "n2";

            var xcA = new DataGridViewTextBoxColumn();
            xcA.DataPropertyName = "EstatusDocDesc";
            xcA.Name = "ESTATUS";
            xcA.HeaderText = "Estatus";
            xcA.Visible = true;
            xcA.Width = 80;
            xcA.HeaderCell.Style.Font = f;
            xcA.DefaultCellStyle.Font = f1;
            xcA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns.Add(xc1);
            DGV.Columns.Add(xc2);
            DGV.Columns.Add(xc3);
            DGV.Columns.Add(xc4);
            DGV.Columns.Add(xcB);
            DGV.Columns.Add(xc5);
            DGV.Columns.Add(xc6);
            DGV.Columns.Add(xc7);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(xc8);
            DGV.Columns.Add(xc9);
            DGV.Columns.Add(xcA);
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ESTATUS"].Value.ToString() != "")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.Cells["ESTATUS"].Style.BackColor = Color.Red;
                    row.Cells["ESTATUS"].Style.ForeColor = Color.White;
                }
            }
        }

        private void AdministradorFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.ItemSource;
            L_TITULO.Text = _controlador.TituloAdministrador;
            InicializarFechas();
            Actualizar();

            DGV.Columns["TIPODOC_CTAPAGAR"].Visible = true;
            DGV.Columns["FECHAVTO_CTAPAGAR"].Visible = true;
            DGV.Columns["DIAS_CTAPAGAR"].Visible = true;
            DGV.Columns["DEBE_CTAPAGAR"].Visible = true;
            DGV.Columns["HABER_CTAPAGAR"].Visible = true;
            DGV.Columns["TASARET_ISLR"].Visible = true;
            DGV.Columns["MONTORET_ISLR"].Visible = true;
            DGV.Columns["DIASPEND_CTAPAGAR"].Visible = true;
            if (_controlador.TipoAdminstrador == Enumerados.EnumTipoAdministrador.RetencionISLR)
            {            
                DGV.Columns["TIPODOC_CTAPAGAR"].Visible = false;
                DGV.Columns["FECHAVTO_CTAPAGAR"].Visible = false;
                DGV.Columns["DIAS_CTAPAGAR"].Visible = false;
                DGV.Columns["DEBE_CTAPAGAR"].Visible = false;
                DGV.Columns["HABER_CTAPAGAR"].Visible = false;
                DGV.Columns["DIASPEND_CTAPAGAR"].Visible = false;
            }
            else if (_controlador.TipoAdminstrador == Enumerados.EnumTipoAdministrador.CtasxPagar)
            {
                DGV.Columns["TASARET_ISLR"].Visible = false;
                DGV.Columns["MONTORET_ISLR"].Visible = false;
            }
            DGV.Refresh();
        }

        private void Actualizar()
        {
            L_ITEMS.Text = "Items Encontrados: " + _controlador.CntItems.ToString();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.BuscarDocs();
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
            if (_modoInicializar) { return; }

            _controlador.setFechaDesde(DTP_DESDE.Value);
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }

            _controlador.setFechaHasta(DTP_HASTA.Value);
        }

        private void BT_LIMPIAR_FILTROS_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            _controlador.LimpiarFiltros();
            InicializarFechas();
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
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                VisualizarDocAnulado();
            }
        }

        private void VisualizarDocAnulado()
        {
            _controlador.VisualizarDocAnulado();
        }

        private void BT_FILTROS_Click(object sender, EventArgs e)
        {
            FiltrarDocs();
        }

        bool _modoInicializar = false;
        private void FiltrarDocs()
        {
            _controlador.FiltrarDocs();
            InicializarFechas();
        }

        private void InicializarFechas()
        {
            _modoInicializar = true;
            CHB_DESDE.Checked = _controlador.GetFechaDesde_Habilitar;
            DTP_DESDE.Enabled = _controlador.GetFechaDesde_Habilitar;
            DTP_DESDE.Value = _controlador.Desde;

            CHB_HASTA.Checked = _controlador.GetFechaHasta_Habilitar;
            DTP_HASTA.Enabled = _controlador.GetFechaHasta_Habilitar;
            DTP_HASTA.Value = _controlador.Hasta;
            _modoInicializar = false;
        }

        private void CHB_DESDE_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }

            _controlador.setHabilitarDesde();
            DTP_DESDE.Enabled = _controlador.GetFechaDesde_Habilitar;
        }

        private void CHB_HASTA_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }

            _controlador.setHabilitarHasta();
            DTP_HASTA.Enabled = _controlador.GetFechaHasta_Habilitar;
        }

    }

}