using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Login
{

    public class Gestion
    {


        private bool _loginIsOk;
        private string _codigoUsu;
        private string _claveUsu;


        public bool LoginIsOk { get { return _loginIsOk; } }


        public Gestion()
        {
            Inicializa();
        }


        LoginFrm frm;
        public void Inicia()
        {
            frm = new LoginFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void Inicializa()
        {
            _loginIsOk = false;
            _codigoUsu = "";
            _claveUsu = "";
        }

        public void SetCodigo(string p)
        {
            _codigoUsu = p.Trim().ToUpper();
        }

        public void SetClave(string p)
        {
            _claveUsu = p.Trim().ToUpper();
        }

        public void Aceptar()
        {
            _loginIsOk = VerificarUsuario();
        }

        public bool VerificarUsuario()
        {
            var rt = true;

            var ficha = new OOB.Login.Identificacion.Ficha()
            {
                codigo = _codigoUsu,
                clave = _claveUsu,
            };
            var r01 = Sistema.MyData.Login_Identificacion(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var r02 = Sistema.MyData.Usuario_GetById(r01.Auto);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            if (!r02.MiEntidad.IsUsuarioActivo)
            {
                Helpers.Msg.Error("USUARIO INACTIVO, VERIFIQUE POR FAVOR");
                return false;
            }
            var r03 = Sistema.MyData.Permiso_Solicitud_ModuloPago(r02.MiEntidad.idGrupo);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            if (!r03.MiEntidad.IsEstatusActivo)
            {
                Helpers.Msg.Error("MODULO NO PERMITDO PARA ESTE USUARIO, VERIFIQUE POR FAVOR");
                return false;
            }

            Sistema.Usuario = r02.MiEntidad;
            return rt;
        }

    }

}