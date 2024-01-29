using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.VentasAdm.AdmDocumento.Vista
{
    public partial class Frm : Form
    {
        private IVista _controlador;

    //    private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    //    {
    //        foreach (DataGridViewRow row in DGV.Rows)
    //        {
    //            if (row.Cells["ESTATUS"].Value.ToString() != "")
    //            {
    //                row.DefaultCellStyle.ForeColor = Color.Red;
    //                row.Cells["ESTATUS"].Style.BackColor = Color.Red;
    //                row.Cells["ESTATUS"].Style.ForeColor = Color.White;
    //            }
    //        }
    //    }

    //    private void AdministradorFrm_Load(object sender, EventArgs e)
    //    {
    //        DGV.DataSource = _controlador.ItemSource;
    //        L_TITULO.Text = _controlador.TituloAdministrador;
    //        InicializarFechas();
    //        Actualizar();

    //        DGV.Columns["TIPODOC_CTAPAGAR"].Visible = true;
    //        DGV.Columns["FECHAVTO_CTAPAGAR"].Visible = true;
    //        DGV.Columns["DIAS_CTAPAGAR"].Visible = true;
    //        DGV.Columns["DEBE_CTAPAGAR"].Visible = true;
    //        DGV.Columns["HABER_CTAPAGAR"].Visible = true;
    //        DGV.Columns["TASARET_ISLR"].Visible = true;
    //        DGV.Columns["MONTORET_ISLR"].Visible = true;
    //        DGV.Columns["DIASPEND_CTAPAGAR"].Visible = true;
    //        if (_controlador.TipoAdminstrador == Enumerados.EnumTipoAdministrador.RetencionISLR)
    //        {            
    //            DGV.Columns["TIPODOC_CTAPAGAR"].Visible = false;
    //            DGV.Columns["FECHAVTO_CTAPAGAR"].Visible = false;
    //            DGV.Columns["DIAS_CTAPAGAR"].Visible = false;
    //            DGV.Columns["DEBE_CTAPAGAR"].Visible = false;
    //            DGV.Columns["HABER_CTAPAGAR"].Visible = false;
    //            DGV.Columns["DIASPEND_CTAPAGAR"].Visible = false;
    //        }
    //        else if (_controlador.TipoAdminstrador == Enumerados.EnumTipoAdministrador.CtasxPagar)
    //        {
    //            DGV.Columns["TASARET_ISLR"].Visible = false;
    //            DGV.Columns["MONTORET_ISLR"].Visible = false;
    //        }
    //        DGV.Refresh();
    //    }

    //    private void Actualizar()
    //    {
    //        L_ITEMS.Text = "Items Encontrados: " + _controlador.CntItems.ToString();
    //    }

    //    private void BT_BUSCAR_Click(object sender, EventArgs e)
    //    {
    //        Buscar();
    //    }

    //    private void Buscar()
    //    {
    //        _controlador.BuscarDocs();
    //        Actualizar();
    //    }

    //    private void BT_SALIR_Click(object sender, EventArgs e)
    //    {
    //        Salir();
    //    }

    //    private void Salir()
    //    {
    //        this.Close();
    //    }

    //    private void BT_ANULAR_Click(object sender, EventArgs e)
    //    {
    //        AnularItem();
    //    }

    //    private void AnularItem()
    //    {
    //        _controlador.AnularItem();
    //        DGV.Refresh();
    //    }

    //    private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
    //    {
    //        if (_modoInicializar) { return; }

    //        _controlador.setFechaDesde(DTP_DESDE.Value);
    //    }

    //    private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
    //    {
    //        if (_modoInicializar) { return; }

    //        _controlador.setFechaHasta(DTP_HASTA.Value);
    //    }

    //    private void BT_LIMPIAR_FILTROS_Click(object sender, EventArgs e)
    //    {
    //        LimpiarFiltros();
    //    }

    //    private void LimpiarFiltros()
    //    {
    //        _controlador.LimpiarFiltros();
    //        InicializarFechas();
    //    }

    //    private void BT_LIMPIAR_DATA_Click(object sender, EventArgs e)
    //    {
    //        LimpiarData();
    //    }

    //    private void LimpiarData()
    //    {
    //        _controlador.LimpiarItems();
    //        Actualizar();
    //    }

    //    private void BT_VISUALIZAR_Click(object sender, EventArgs e)
    //    {
    //        VisualizarDocumento();
    //    }

    //    private void VisualizarDocumento()
    //    {
    //        _controlador.VisualizarDocumento();
    //    }

    //    private void BT_IMPRIMIR_Click(object sender, EventArgs e)
    //    {
    //        Imprimir();
    //    }

    //    private void Imprimir()
    //    {
    //        _controlador.Imprimir();
    //    }

    //    private void BT_CORRECTOR_Click(object sender, EventArgs e)
    //    {
    //        CorrectorDocumentos();
    //    }

    //    private void CorrectorDocumentos()
    //    {
    //    }

    //    public void setControlador(Gestion ctr)
    //    {
    //        _controlador = ctr;
    //    }

    //    private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    //    {
    //        if (e.RowIndex != -1 && e.ColumnIndex != -1)
    //        {
    //            VisualizarDocAnulado();
    //        }
    //    }

    //    private void VisualizarDocAnulado()
    //    {
    //        _controlador.VisualizarDocAnulado();
    //    }

    //    private void BT_FILTROS_Click(object sender, EventArgs e)
    //    {
    //        FiltrarDocs();
    //    }

    //    bool _modoInicializar = false;
    //    private void FiltrarDocs()
    //    {
    //        _controlador.FiltrarDocs();
    //        InicializarFechas();
    //    }

    //    private void InicializarFechas()
    //    {
    //        _modoInicializar = true;
    //        CHB_DESDE.Checked = _controlador.GetFechaDesde_Habilitar;
    //        DTP_DESDE.Enabled = _controlador.GetFechaDesde_Habilitar;
    //        DTP_DESDE.Value = _controlador.Desde;

    //        CHB_HASTA.Checked = _controlador.GetFechaHasta_Habilitar;
    //        DTP_HASTA.Enabled = _controlador.GetFechaHasta_Habilitar;
    //        DTP_HASTA.Value = _controlador.Hasta;
    //        _modoInicializar = false;
    //    }

    //    private void CHB_DESDE_CheckedChanged(object sender, EventArgs e)
    //    {
    //        if (_modoInicializar) { return; }

    //        _controlador.setHabilitarDesde();
    //        DTP_DESDE.Enabled = _controlador.GetFechaDesde_Habilitar;
    //    }

    //    private void CHB_HASTA_CheckedChanged(object sender, EventArgs e)
    //    {
    //        if (_modoInicializar) { return; }

    //        _controlador.setHabilitarHasta();
    //        DTP_HASTA.Enabled = _controlador.GetFechaHasta_Habilitar;
    //    }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 10, FontStyle.Bold);
            //
            DGV.RowHeadersVisible= false;
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;
            //
            var xc1 = new DataGridViewTextBoxColumn();
            xc1.DataPropertyName = "FechaEmisionDoc";
            xc1.HeaderText = "F/Emision";
            xc1.Visible = true;
            xc1.Width = 80;
            xc1.HeaderCell.Style.Font = f;
            xc1.DefaultCellStyle.Font = f1;
            xc1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var xc2 = new DataGridViewTextBoxColumn();
            xc2.DataPropertyName = "TipoDoc";
            xc2.HeaderText = "Tipo/Doc";
            xc2.Visible = true;
            xc2.HeaderCell.Style.Font = f;
            xc2.DefaultCellStyle.Font = f1;
            xc2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            xc2.MinimumWidth = 120;
            xc2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var xc3 = new DataGridViewTextBoxColumn();
            xc3.DataPropertyName = "NumeroDoc";
            xc3.HeaderText = "Numero/Doc";
            xc3.Visible = true;
            xc3.Width = 100;
            xc3.HeaderCell.Style.Font = f;
            xc3.DefaultCellStyle.Font = f1;
            xc3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var xc4 = new DataGridViewTextBoxColumn();
            xc4.DataPropertyName = "FechaVenceDoc";
            xc4.HeaderText = "F/Vence";
            xc4.Visible = true;
            xc4.Width = 80;
            xc4.HeaderCell.Style.Font = f;
            xc4.DefaultCellStyle.Font = f1;
            xc4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var xc5 = new DataGridViewTextBoxColumn();
            xc5.DataPropertyName = "DiasCredito";
            xc5.HeaderText = "Dias/Cred";
            xc5.Visible = true;
            xc5.Width = 80;
            xc5.HeaderCell.Style.Font = f;
            xc5.DefaultCellStyle.Font = f1;
            xc5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var xc6 = new DataGridViewTextBoxColumn();
            xc6.DataPropertyName = "NombreEnt";
            xc6.HeaderText = "Nombre";
            xc6.Visible = true;
            xc6.MinimumWidth = 240;
            xc6.HeaderCell.Style.Font = f;
            xc6.DefaultCellStyle.Font = f1;
            xc6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var xc7 = new DataGridViewTextBoxColumn();
            xc7.DataPropertyName = "CiRifEnt";
            xc7.HeaderText = "CI/Rif";
            xc7.Visible = true;
            xc7.HeaderCell.Style.Font = f;
            xc7.DefaultCellStyle.Font = f1;
            xc7.MinimumWidth = 120;
            xc7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var xc8 = new DataGridViewTextBoxColumn();
            xc8.DataPropertyName = "ImporteDoc";
            xc8.HeaderText = "Importe";
            xc8.Visible = true;
            xc8.Width = 100;
            xc8.HeaderCell.Style.Font = f;
            xc8.DefaultCellStyle.Font = f1;
            xc8.DefaultCellStyle.Format = "n2";
            xc8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var xc9 = new DataGridViewTextBoxColumn();
            xc9.DataPropertyName = "EstatusAnuladoDoc";
            xc9.HeaderText = "";
            xc9.Name = "EstatusAnulado";
            xc9.Visible = true;
            xc9.Width = 80;
            xc9.HeaderCell.Style.Font = f;
            xc9.DefaultCellStyle.Font = f1;
            xc9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            DGV.Columns.Add(xc1);
            DGV.Columns.Add(xc2);
            DGV.Columns.Add(xc3);
            DGV.Columns.Add(xc4);
            DGV.Columns.Add(xc5);
            DGV.Columns.Add(xc6);
            DGV.Columns.Add(xc7);
            DGV.Columns.Add(xc8);
            DGV.Columns.Add(xc9);
        }
        public Frm()
        {
            InitializeComponent();
            InicializarGrid();
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Items.Get_Source;
            L_TITULO.Text = _controlador.TituloAdministrador;
            L_ITEMS.Text =  _controlador.CntItems;
            actualizarGrid();
            actualizarFechas();
        }
        public void setControlador(IVista ctr)
        {
            _controlador = ctr;
        }
        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["EstatusAnulado"].Value.ToString() != "")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.Cells["EstatusAnulado"].Style.BackColor = Color.Red;
                    row.Cells["EstatusAnulado"].Style.ForeColor = Color.White;
                }
            }
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Filtro.Desde.setActivar(DTP_DESDE.Checked);
            if (DTP_DESDE.Checked)
            {
                _controlador.Filtro.Desde.setFecha(DTP_DESDE.Value.Date);
            }
        }
        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Filtro.Hasta.setActivar(DTP_HASTA.Checked);
            if (DTP_HASTA.Checked)
            {
                _controlador.Filtro.Hasta.setFecha(DTP_HASTA.Value.Date);
            }
        }

        private void BT_LIMPIAR_FILTROS_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            actualizarFechas();
        }
        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void BT_VISUALIZAR_Click(object sender, EventArgs e)
        {
            VisualizaDoc();
        }
        private void BT_LIMPIAR_DATA_Click(object sender, EventArgs e)
        {
            LimpiarItems();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Buscar()
        {
            _controlador.Buscar();
            actualizarFicha();
        }
        private void LimpiarFiltros()
        {
            _controlador.Filtro.Limpiar();
        }
        private void VisualizaDoc()
        {
            _controlador.VisualizarDoc();
        }
        private void LimpiarItems()
        {
            _controlador.LimpiarItems();
            L_ITEMS.Text = _controlador.CntItems;
        }
        private void Salir()
        {
            _controlador.BtSalida.Opcion();
            if (_controlador.BtSalida.OpcionIsOK)
            {
                salida();
            }
        }


        private void actualizarGrid()
        {
            switch (_controlador.AdministradorTipo) 
            {
                case __.Componente.AdmDoc.enumerados.tipoAdministrador.Ventas:
                    activarVenta();
                    break;
                default:
                    break;
            }
        }
        private void activarVenta()
        {
            DGV.Columns[0].Visible = true;
            DGV.Columns[1].Visible = true;
            DGV.Columns[2].Visible = true;
            DGV.Columns[3].Visible = true;
            DGV.Columns[4].Visible = true;
            DGV.Columns[5].Visible = true;
            DGV.Columns[6].Visible = true;
            DGV.Columns[7].Visible = true;
            DGV.Columns[8].Visible = true;
        }
        private void salida()
        {
            this.Close();
        }
        private void actualizarFicha()
        {
            L_ITEMS.Text = _controlador.CntItems;
        }
        private void actualizarFechas()
        {
            DTP_DESDE.Checked = _controlador.Filtro.Desde.IsActiva;
            DTP_HASTA.Checked = _controlador.Filtro.Hasta.IsActiva;
            DTP_DESDE.Value = _controlador.Filtro.Desde.Fecha;
            DTP_HASTA.Value = _controlador.Filtro.Hasta.Fecha;
        }
    }
}