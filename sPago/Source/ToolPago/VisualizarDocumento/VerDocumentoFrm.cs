using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sPago.Source.ToolPago.VisualizarDocumento
{

    public partial class VerDocumentoFrm : Form
    {


        private Gestion _controlador;


        public VerDocumentoFrm()
        {
            InitializeComponent();
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

        private void VerDocumentoFrm_Load(object sender, EventArgs e)
        {
            L_PROVEEDOR.Text = _controlador.Proveedor;
            L_FECHA_EMISION.Text = _controlador.FechaEmision.ToShortDateString();
            L_COND_PAGO.Text = _controlador.CondPago;
            L_DIAS_CREDITO.Text = _controlador.DiasCredito.ToString();
            L_FECHA_VENCE.Text = _controlador.FechaVence.ToShortDateString();
            L_TIPO_DOCUMENTO.Text = _controlador.TipoDocumento;
            L_NUMERO_DOC.Text = _controlador.NumeroDocumento;
            L_IMPORTE_DOC.Text = _controlador.ImporteDocumento.ToString("n2");
            L_DETALLE_DOC.Text = _controlador.DetalleDocumento;

        }

    }

}
