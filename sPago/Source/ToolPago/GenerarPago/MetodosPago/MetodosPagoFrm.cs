using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.GenerarPago.MetodosPago
{
    
    public partial class MetodosPagoFrm : Form
    {


        private Gestion _controlador;


        public MetodosPagoFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void MetodosPagoFrm_Load(object sender, EventArgs e)
        {
            L_MONTO_PAGAR.Text = _controlador.MontoPagar.ToString("n2");
        }

    }

}