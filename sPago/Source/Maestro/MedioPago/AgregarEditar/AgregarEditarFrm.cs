using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Maestro.MedioPago.AgregarEditar
{

    public partial class AgregarEditarFrm : Form
    {

        private AgregarEditar _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
        }


        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.TituloVentana;
            TB_CODIGO.Text = _controlador.Codigo;
            TB_NOMBRE.Text = _controlador.Nombre;
            TB_CODIGO.Focus();
        }

        public void setControlador(AgregarEditar ctr)
        {
            _controlador = ctr;
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                Salir();
            }
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOK)
            {
                    e.Cancel = false;
            }
        }

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.setCodigo(TB_CODIGO.Text.Trim().ToUpper());
        }

        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setDescripcion(TB_NOMBRE.Text.Trim().ToUpper());
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }

        private void Abandonar()
        {
            _controlador.Abandonar();
        }

        private void Salir()
        {
            TB_CODIGO.Focus();
            this.Close();
        }

    }

}