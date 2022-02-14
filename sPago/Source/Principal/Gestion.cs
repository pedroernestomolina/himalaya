using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Principal
{

    public class Gestion
    {

        //VARIABLES DE TRABAJO
        private Login.Gestion _gestionLogin;
        private RetISLR.Generar.Gestion _gestionRetIslrGenerar;
        private Seguridad.Gestion _gSeguridad;
        private Anular.Gestion _gAnular;
        private SistemaCtrl.VerAnulacion.IGestion _gAuditoria;
        private Filtrar.IGestion _gFiltrar;
        private Filtrar.IListaProv _gListaProv;
        private AdministradorDoc.IAdmLista _gAdmLista;
        private AdministradorDoc.Gestion _gAdmDoc;
        private CtasPagar.AdministradorDoc.Gestion _gAdmDocCtaPagar;
        private RetISLR.AdministradorDoc.Gestion _gAdmDocRetIslr;
        private Reportes.Gestion _gReport;
        private ToolPago.Gestion _gToolPago;
        private Maestro.IGestion _gMaestro;
        private Maestro.IMaestro _gMedioPago;
        private Maestro.ILista _gListaMaestro;
        private Maestro.MedioPago.AgregarEditar.IAgregarEditar _gAgregEditMedioPago;
        private ToolPago.PorPagar.IGestion _gPorPagar;
        private ToolPago.GenerarPago.IListaDocPagar _gListaDocPago;
        private ToolPago.GenerarPago.IMetodosPago _gMetodoPago;
        private ToolPago.GenerarPago.IDetalleMonto _gDetalleMontoPago;
        private ToolPago.GenerarPago.IGestion _gGeneradorPago;
        private CtasPagar.AdministradorDoc.IVerDocumento _gVisualizarDoc;
        private Filtrar.IFiltrar _gCtaPagarAdmFiltro; 


        public string Host { get { return Sistema.Instancia + "/" + Sistema.BaseDatos; } }
        public string VersionSistema { get { return "Ver. " + Application.ProductVersion; } }
        public string UsuarioActivo { get {return Sistema.Usuario.codigoUsu + Environment.NewLine + Sistema.Usuario.nombreUsu; } }


        public Gestion() 
        {
            _gestionLogin = new Login.Gestion();
            _gSeguridad = new Seguridad.Gestion();
            _gAnular = new Anular.Gestion();
            _gAuditoria = new SistemaCtrl.VerAnulacion.Gestion();
            _gListaProv = new Proveedor.Lista.Gestion();
            _gFiltrar = new Filtrar.Gestion(_gListaProv);
            _gAdmLista = new AdministradorDoc.GestionLista();
            _gListaMaestro = new Maestro.Lista();
            _gMaestro = new Maestro.Gestion(_gListaMaestro);
            _gAgregEditMedioPago = new Maestro.MedioPago.AgregarEditar.AgregarEditar();
            _gMedioPago = new Maestro.MedioPago.Gestion(_gAgregEditMedioPago);
            _gPorPagar = new ToolPago.PorPagar.Gestion();
            _gListaDocPago = new ToolPago.GenerarPago.ListaDocPagar();
            _gMetodoPago = new ToolPago.GenerarPago.MetodosPago.Gestion();
            _gDetalleMontoPago = new ToolPago.GenerarPago.DetalleMonto.Gestion();
            _gGeneradorPago = new ToolPago.GenerarPago.Gestion(_gListaDocPago, _gMetodoPago, _gDetalleMontoPago);
            _gVisualizarDoc = new ToolPago.VisualizarDocumento.Gestion();
            _gCtaPagarAdmFiltro = new CtasPagar.AdministradorDoc.GestionFiltro();

            //
            _gReport = new Reportes.Gestion(_gFiltrar);
            _gestionRetIslrGenerar = new RetISLR.Generar.Gestion(_gListaProv);
            _gAdmDoc = new AdministradorDoc.Gestion(_gSeguridad, _gAnular, _gAuditoria, _gFiltrar, _gAdmLista);
            _gAdmDocCtaPagar = new CtasPagar.AdministradorDoc.Gestion(_gVisualizarDoc, _gCtaPagarAdmFiltro);
            _gAdmDocRetIslr = new RetISLR.AdministradorDoc.Gestion();
            _gToolPago = new ToolPago.Gestion(_gListaProv, _gPorPagar, _gGeneradorPago);
        }

        //INICIO DEL PROGRAMA
        Principal.MainFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                _gestionLogin.Inicializa();
                _gestionLogin.Inicia();
                if (_gestionLogin.LoginIsOk)
                {
                    if (frm == null)
                    {
                        frm = new MainFrm();
                        frm.setControlador(this);
                    }
                    frm.ShowDialog();
                }
            }
        }

        //CARGA DATOS INICIALES DEL PROCESO
        private bool CargarData()
        {
            var r01 = Helpers.XML.CargarXml();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            Sistema.MyData = new DataProvider.Data.Provider(Sistema.Instancia, Sistema.BaseDatos);
            Sistema.EquipoEstacion = Environment.MachineName;

            var r02 = Sistema.MyData.Empresa_GetFicha();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            Sistema.DatosEmpresa = r02.MiEntidad;

            return true;
        }

        public void ElaborarRetencionISLR()
        {
            var r01 = Sistema.MyData.Permiso_Solicitud_ElaborarRetencionISLR(Sistema.Usuario.idGrupo);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            _gSeguridad.Inicializa();
            _gSeguridad.Verifica(r01.MiEntidad);
            if (_gSeguridad.IsOk)
            {
                _gestionRetIslrGenerar.Inicializa();
                _gestionRetIslrGenerar.Inicia();
                if (_gestionRetIslrGenerar.ProcesarRetencionIsOK) 
                {
                    VisualizarPlanillaRetencion(_gestionRetIslrGenerar.AutoRetencionGenerada);
                }
            }
        }

        private void VisualizarPlanillaRetencion(string id)
        {
            var r01 = Sistema.MyData.RetISLR_GetById(id);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Helpers.Utils.VisualizarRetISLR(r01.MiEntidad);
        }

        public void AdministradorDocRetencionISLR()
        {
            var r01 = Sistema.MyData.Permiso_Solicitud_AdministradorRetencionISLR(Sistema.Usuario.idGrupo);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            _gSeguridad.Inicializa();
            _gSeguridad.Verifica(r01.MiEntidad);
            if (_gSeguridad.IsOk)
            {
                _gAdmDoc.setGestionAdmDoc(_gAdmDocRetIslr);
                _gAdmDoc.Inicializa();
                _gAdmDoc.Inicia();

            }
        }
 
        public void CtasPagar_AdministradorDoc()
        {
            var r01 = Sistema.MyData.Permiso_CtasPagar_Adminstrador(Sistema.Usuario.idGrupo);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            _gSeguridad.Inicializa();
            _gSeguridad.Verifica(r01.MiEntidad);
            if (_gSeguridad.IsOk)
            {
                _gAdmDoc.setGestionAdmDoc(_gAdmDocCtaPagar);
                _gAdmDoc.Inicializa();
                _gAdmDoc.Inicia();
            }
        }

        public void ReporteRetencionISLR()
        {
            var r01 = Sistema.MyData.Permiso_Solicitud_ReporteRetencionISLR(Sistema.Usuario.idGrupo);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            _gSeguridad.Inicializa();
            _gSeguridad.Verifica(r01.MiEntidad);
            if (_gSeguridad.IsOk)
            {
                Reporte(new Reportes.RetISLR.GeneralRet.Gestion());
            }
        }

        public void ReporteDocumentoPorPagarProveed()
        {
            var r00 = Sistema.MyData.Permiso_CtaPagar_Reporte_DocumentosPorPagar(Sistema.Usuario.idGrupo);
            if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            _gSeguridad.Inicializa();
            _gSeguridad.Verifica(r00.MiEntidad);
            if (_gSeguridad.IsOk)
            {
                Reporte(new Reportes.CtaPagar.DocumentosPorPagar.Gestion());
            }
        }

        public void ReportePagosEmitidosProveed()
        {
            var r00 = Sistema.MyData.Permiso_CtaPagar_Reporte_PagosEmitidos(Sistema.Usuario.idGrupo);
            if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            _gSeguridad.Inicializa();
            _gSeguridad.Verifica(r00.MiEntidad);
            if (_gSeguridad.IsOk)
            {
                Reporte(new Reportes.CtaPagar.PagosEmitidos.Gestion());
            }
        }

        public void ReporteRelacionPagoProveed()
        {
            var r00 = Sistema.MyData.Permiso_CtaPagar_Reporte_PagosEmitidos(Sistema.Usuario.idGrupo);
            if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            _gSeguridad.Inicializa();
            _gSeguridad.Verifica(r00.MiEntidad);
            if (_gSeguridad.IsOk)
            {
                Reporte(new Reportes.CtaPagar.RelacionPagoProveedor.Gestion());
            }
        }

        public void ReporteAnalisisVencimientoProveed()
        {
            var r00 = Sistema.MyData.Permiso_CtaPagar_Reporte_AnalisisVencimiento(Sistema.Usuario.idGrupo);
            if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            _gSeguridad.Inicializa();
            _gSeguridad.Verifica(r00.MiEntidad);
            if (_gSeguridad.IsOk)
            {
                Reporte(new Reportes.CtaPagar.AnalisisVencimiento.Gestion());
            }
        }

        private void Reporte(Reportes.IReportes ctr)
        {
            _gReport.setGestion(ctr);
            _gReport.Inicializa();
            _gReport.Inicia();
        }

        public void ToolPago()
        {
            _gToolPago.Inicializa();
            _gToolPago.Inicia();
        }

        public void MaestrosMedioPago()
        {
            _gMaestro.setGestion(_gMedioPago);
            _gMaestro.Inicializa();
            _gMaestro.Inicia();
        }

    }

}