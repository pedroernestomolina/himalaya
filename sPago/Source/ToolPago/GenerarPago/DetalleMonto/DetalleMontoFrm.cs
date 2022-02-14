using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.GenerarPago.DetalleMonto
{

    public partial class DetalleMontoFrm : Form
    {


        private Gestion _controlador;
        

        public DetalleMontoFrm()
        {
            InitializeComponent();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void DetalleMontoFrm_Load(object sender, EventArgs e)
        {
            L_MONTO_PENDIENTE.Text = _controlador.MontoPendiente.ToString("n2");
            TB_MONTO_PAGAR.Text = _controlador.MontoPagar.ToString();
            TB_DETALLE.Text = _controlador.Detalle;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_MONTO_PAGAR_Leave(object sender, EventArgs e)
        {
            var rt= decimal.Parse(TB_MONTO_PAGAR.Text);
            _controlador.setMontoPagar(rt);
        }

        private void TB_DETALLE_Leave(object sender, EventArgs e)
        {
            _controlador.setDetalle(TB_DETALLE.Text.Trim());
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            _controlador.Aceptar();
            if (_controlador.AceptarIsOk) 
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

        private void DetalleMontoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.AceptarIsOk) 
            {
                e.Cancel = false;
            }
        }

    }

}