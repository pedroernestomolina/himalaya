using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Principal
{

    public class Gestion
    {

        private Login.Gestion _gestionLogin;


        public Gestion() 
        {
            _gestionLogin = new Login.Gestion(); 
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

    }

}