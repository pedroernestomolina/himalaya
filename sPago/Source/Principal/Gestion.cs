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

        private Login.Gestion _gestionLogin;
        private RetISLR.Generar.Gestion _gestionRetIslrGenerar;
        private Seguridad.Gestion _gestionSeguridad;


        public string Host { get { return Sistema.Instancia + "/" + Sistema.BaseDatos; } }
        public string VersionSistema { get { return "Ver. " + Application.ProductVersion; } }
        public string UsuarioActivo { get {return Sistema.Usuario.codigoUsu + Environment.NewLine + Sistema.Usuario.nombreUsu; } }


        public Gestion() 
        {
            _gestionLogin = new Login.Gestion();
            _gestionRetIslrGenerar = new RetISLR.Generar.Gestion();
            _gestionSeguridad = new Seguridad.Gestion();
        }


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

            _gestionSeguridad.Inicializa();
            _gestionSeguridad.Verifica(r01.MiEntidad);
            if (_gestionSeguridad.IsOk)
            {
                _gestionRetIslrGenerar.Inicializa();
                _gestionRetIslrGenerar.Inicia();
            }
        }

    }

}