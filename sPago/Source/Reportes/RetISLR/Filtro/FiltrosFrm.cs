using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Reportes.RetISLR.Filtro
{

    public partial class FiltrosFrm : Form
    {

        private Gestion _controlador;


        public FiltrosFrm()
        {
            InitializeComponent();
            InicializaControles();
        }


        private void InicializaControles()
        {
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
        }

        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            DTP_DESDE.Value = _controlador.Desde;
            DTP_HASTA.Value = _controlador.Hasta;
            CB_ESTATUS.DataSource = _controlador.EstatusSource;
            CB_ESTATUS.SelectedIndex = -1;
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            _controlador.LimpiarFiltros();
            DTP_DESDE.Value = _controlador.Desde;
            DTP_HASTA.Value = _controlador.Hasta;
        }

        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            LimpiarEstatus();
        }

        private void LimpiarEstatus()
        {
            CB_ESTATUS.SelectedIndex = -1;
        }

        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_ESTATUS.SelectedIndex == -1) 
            {
                _controlador.setEstatus("");
                return;
            }
            _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setFechaDesde(DTP_DESDE.Value);
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setFechaHasta(DTP_HASTA.Value);
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk) 
            {
                this.Close();
            }
        }

        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            AceptarFiltros();
        }

        private void AceptarFiltros()
        {
            _controlador.AceptarFiltros();
            if (_controlador.FiltrosIsOk)
            {
                Salir();
            }
        }

        private void FiltrosFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.FiltrosIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }

        private void BT_PROVEEDOR_BUSCAR_Click(object sender, EventArgs e)
        {
        }
       
    }

}