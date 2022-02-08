using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Principal
{

    public partial class MainFrm : Form
    {


        private Gestion _controlador;
        private Timer timer;


        public MainFrm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            timer.Start();
            L_VERSION.Text = _controlador.VersionSistema;
            L_HOST.Text = _controlador.Host;
            L_USUARIO.Text = _controlador.UsuarioActivo;
            L_FECHA.Text = "";
            L_HORA.Text = "";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var s = DateTime.Now;
            L_FECHA.Text = s.ToLongDateString();
            L_HORA.Text = s.ToLongTimeString();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TSM_ARCHIVO_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        public void setVisibilidadOff()
        {
            this.Visible = false;
        }

        public void setVisibilidadOn()
        {
            this.Visible = true;
        }

        private void M_PAGO_ELABORAR_RETENCION_ISLR_Click(object sender, EventArgs e)
        {
            ElaborarRetencionISLR();
        }

        private void ElaborarRetencionISLR()
        {
            _controlador.ElaborarRetencionISLR();
        }

        private void M_PAGO_ADMINISTRADOR_RETENCION_ISLR_Click(object sender, EventArgs e)
        {
            AdministradorDocRetencionISLR();
        }

        private void AdministradorDocRetencionISLR()
        {
            _controlador.AdministradorDocRetencionISLR();
        }

        private void M_PAGO_REPORTE_RETENCION_ISL_Click(object sender, EventArgs e)
        {
            ReporteRetencionISLR();
        }

        private void ReporteRetencionISLR()
        {
            _controlador.ReporteRetencionISLR();
        }

        private void M_CTAS_PAGAR_ADMINISTRADOR_Click(object sender, EventArgs e)
        {
            CtasPagar_AdministradorDoc();
        }

        private void CtasPagar_AdministradorDoc()
        {
            _controlador.CtasPagar_AdministradorDoc();
        }

        private void MENU_CTAPAGAR_REPORTES_DOCUMENTO_POR_PAGAR_Click(object sender, EventArgs e)
        {
            ReporteDocumentoPorPagarProveed();
        }

        private void ReporteDocumentoPorPagarProveed()
        {
            _controlador.ReporteDocumentoPorPagarProveed();
        }

        private void MENU_CTAPAGAR_REPORTES_PAGOS_EMITIDOS_Click(object sender, EventArgs e)
        {
            ReportePagosEmitidosProveed();
        }

        private void ReportePagosEmitidosProveed()
        {
            _controlador.ReportePagosEmitidosProveed();
        }

        private void MENU_CTAPAGAR_REPORTES_RELACION_PAGO_Click(object sender, EventArgs e)
        {
            ReporteRelacionPagoProveed();
        }

        private void ReporteRelacionPagoProveed()
        {
            _controlador.ReporteRelacionPagoProveed();
        }

        private void MENU_CTAPAGAR_REPORTES_ANALISIS_VENCIMIENTO_Click(object sender, EventArgs e)
        {
            ReporteAnalisisVencimientoProveed();
        }

        private void ReporteAnalisisVencimientoProveed()
        {
            _controlador.ReporteAnalisisVencimientoProveed();
        }

        private void M_CTAS_PAGAR_TOOL_PAGO_Click(object sender, EventArgs e)
        {
            ToolPago();
        }

        private void ToolPago()
        {
            _controlador.ToolPago();
        }

        private void M_MAESTRO_MEDIOS_PAGO_Click(object sender, EventArgs e)
        {
            MaestrosMedioPago();
        }

        private void MaestrosMedioPago()
        {
            _controlador.MaestrosMedioPago();
        }

    }

}