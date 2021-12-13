using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Seguridad
{

    public partial class SeguridadFrm : Form
    {

        private Gestion _controlador;


        public SeguridadFrm()
        {
            InitializeComponent();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void SeguridadFrm_Load(object sender, EventArgs e)
        {
            TB_CLAVE.Text = "";
            IrFoco();
        }

        private void IrFoco()
        {
            TB_CLAVE.Focus();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            IrFoco();
            _controlador.Aceptar();
            if (_controlador.IsOk) 
            {
                Salir();
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TB_CLAVE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_CLAVE_Leave(object sender, EventArgs e)
        {
            _controlador.setClave(TB_CLAVE.Text.Trim().ToUpper());
        }

    }

}