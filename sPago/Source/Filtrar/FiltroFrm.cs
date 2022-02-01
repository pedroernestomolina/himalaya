using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Filtrar
{

    public partial class FiltroFrm : Form
    {

        private Gestion _controlador;


        public FiltroFrm()
        {
            InitializeComponent();
            InicializaControles();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }


        private void InicializaControles()
        {
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
            CB_TIPO_DOC.DisplayMember = "desc";
            CB_TIPO_DOC.ValueMember = "id";
        }

        private bool modoInicializar; 
        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            modoInicializar = true;
            CB_TIPO_DOC.DataSource = _controlador.SourceTipoDoc;
            CB_ESTATUS.DataSource = _controlador.SourceEstatus;
            CB_TIPO_DOC.SelectedValue= _controlador.GetIdTipoDoc;
            CB_ESTATUS.SelectedValue = _controlador.GetIdEstatus;

            CHB_DESDE.Checked = _controlador.GetFechaDesde_Habilitar;
            DTP_DESDE.Enabled = _controlador.GetFechaDesde_Habilitar;
            DTP_DESDE.Value = _controlador.GetDesde;

            CHB_HASTA.Checked = _controlador.GetFechaHasta_Habilitar;
            DTP_HASTA.Value = _controlador.GetHasta;
            DTP_HASTA.Enabled = _controlador.GetFechaHasta_Habilitar;

            TB_PROVEEDOR.Text = "";
            TB_PROVEEDOR.Enabled = true;
            BT_PROVEED_BUSCAR.Enabled = true;
            if (_controlador.ProveedorSeleccionadoIsOK)
            {
                TB_PROVEEDOR.Text = _controlador.GetNombreProveedor;
                TB_PROVEEDOR.Enabled = false;
                BT_PROVEED_BUSCAR.Enabled = false;
            }
            modoInicializar = false;
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            _controlador.LimpiarFiltros();
            Limpiar();
        }

        private void Limpiar()
        {
            modoInicializar = true;
            CB_TIPO_DOC.SelectedIndex = -1;
            CB_ESTATUS.SelectedIndex = -1;
            CHB_DESDE.Checked = _controlador.GetFechaDesde_Habilitar;
            CHB_HASTA.Checked = _controlador.GetFechaHasta_Habilitar;
            DTP_DESDE.Enabled = _controlador.GetFechaDesde_Habilitar;
            DTP_HASTA.Enabled = _controlador.GetFechaHasta_Habilitar;
            DTP_DESDE.Value = DateTime.Now.Date;
            DTP_HASTA.Value = DateTime.Now.Date;
            TB_PROVEEDOR.Text = "";
            TB_PROVEEDOR.Enabled = true;
            BT_PROVEED_BUSCAR.Enabled = true;
            modoInicializar = false;
        }


        private void L_DESDE_Click(object sender, EventArgs e)
        {
            LimpiarFechaDesde();
        }

        private void LimpiarFechaDesde()
        {
            DTP_DESDE.Value = DateTime.Now.Date;
        }

        private void L_HASTA_Click(object sender, EventArgs e)
        {
            LimpiarFechaHasta();
        }

        private void LimpiarFechaHasta()
        {
            DTP_HASTA.Value = DateTime.Now.Date;
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;
            _controlador.setFechaDesde(DTP_DESDE.Value);
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setFechaHasta(DTP_HASTA.Value);
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

        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {
            _controlador.Filtrar();
            if (_controlador.FiltrarIsOK)
            {
                Salir();
            }
        }

        private void FiltroFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.FiltrarIsOK || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }
    
        private void CTR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void CB_TIPO_DOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            if (CB_TIPO_DOC.SelectedIndex != -1)
                _controlador.setTipoDoc(CB_TIPO_DOC.SelectedValue.ToString());
        }

        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            if (CB_ESTATUS.SelectedIndex != -1)
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
        }

        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            LimpiarEstatus();
        }

        private void LimpiarEstatus()
        {
            _controlador.setEstatus("");
            CB_ESTATUS.SelectedIndex = -1;
        }

        private void L_TIPO_DOC_Click(object sender, EventArgs e)
        {
            LimpiarTipoDoc();
        }

        private void LimpiarTipoDoc()
        {
            _controlador.setTipoDoc("");
            CB_TIPO_DOC.SelectedIndex = -1;
        }

        private void L_PROVEEDOR_Click(object sender, EventArgs e)
        {
            LimpiarProveedor();
        }

        private void LimpiarProveedor()
        {
            _controlador.LimpiarProveedor();
            TB_PROVEEDOR.Text = "";
            TB_PROVEEDOR.Enabled = true;
            BT_PROVEED_BUSCAR.Enabled = true;
        }

        private void BT_PROVEED_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarProveedor();
            if (_controlador.ProveedorSeleccionadoIsOK) 
            {
                TB_PROVEEDOR.Text = _controlador.GetNombreProveedor;
                TB_PROVEEDOR.Enabled = false;
                BT_PROVEED_BUSCAR.Enabled = false;
            }
        }

        private void BuscarProveedor()
        {
            _controlador.BuscarProveedor();
            if (_controlador.ProveedorSeleccionadoIsOK)
            {
                TB_PROVEEDOR.Text = _controlador.GetNombreProveedor;
            }
            else
            {
                TB_PROVEEDOR.Text = "";
            }
        }

        private void TB_PROVEEDOR_Leave(object sender, EventArgs e)
        {
            _controlador.setCadenaProv(TB_PROVEEDOR.Text);
        }

        private void CHB_DESDE_CheckedChanged(object sender, EventArgs e)
        {
            if (modoInicializar) { return; }

            _controlador.setHabilitarDesde();
            DTP_DESDE.Enabled = _controlador.GetFechaDesde_Habilitar;
        }

        private void CHB_HASTA_CheckedChanged(object sender, EventArgs e)
        {
            if (modoInicializar) { return; }

            _controlador.setHabilitarHasta();
            DTP_HASTA.Enabled = _controlador.GetFechaHasta_Habilitar;
        }
  
    }

}