using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Seguridad
{
    
    public class Gestion: IGestion
    {

        private string _clave;
        private Seguridad.Enumerados.Nivel _nivel;
        private bool _isClaveOk;


        public bool IsOk { get { return _isClaveOk; } }


        public Gestion() 
        {
            _clave = "";
            _nivel= Enumerados.Nivel.SinDefinir;
            _isClaveOk = false;
        }


        public void Inicializa()
        {
            _clave = "";
            _nivel= Enumerados.Nivel.SinDefinir;
            _isClaveOk = false;
        }

        public void Verifica(OOB.Permiso.Solictud.Ficha ficha)
        {
            SolicitarClave(ficha);
        }

        public void SolicitarClave(OOB.Permiso.Solictud.Ficha ficha)
        {
            if (ficha.IsEstatusActivo)
            {
                if (ficha.nivelSeguridad.ToUpper()!="NINGUNA")
                {
                    var nivel = Seguridad.Enumerados.Nivel.SinDefinir;
                    switch (ficha.nivelSeguridad.ToUpper())
                    {
                        case "MAXIMO":
                            nivel = Seguridad.Enumerados.Nivel.Maximo;
                            break;
                        case "MEDIO":
                            nivel = Seguridad.Enumerados.Nivel.Medio;
                            break;
                        case "MINIMO":
                            nivel = Seguridad.Enumerados.Nivel.Minimo;
                            break;
                    }
                    PedirClave(nivel);
                }
                else 
                {
                    _isClaveOk = true;
                }
            }
            else
            {
                Helpers.Msg.Error("ERROR... PERMISO DENEGADO");
            }
        }

        private SeguridadFrm frm;
        public void PedirClave(Seguridad.Enumerados.Nivel nivel)
        {
            _nivel=nivel;
            if (frm == null)
            {
                frm = new SeguridadFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }

        public void Aceptar()
        {
            var _claveSist = "";
            switch (_nivel)
            {
                case Enumerados.Nivel.Maximo:
                    var r01 = Sistema.MyData.Configuracion_Sistema_ClaveNivelMaximo();
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                    }
                    _claveSist = r01.MiEntidad;
                    break;
                case Enumerados.Nivel.Medio:
                    var r02 = Sistema.MyData.Configuracion_Sistema_ClaveNivelMedio();
                    if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                    }
                    _claveSist = r02.MiEntidad;
                    break;
                case Enumerados.Nivel.Minimo:
                    var r03 = Sistema.MyData.Configuracion_Sistema_ClaveNivelMinimo();
                    if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r03.Mensaje);
                    }
                    _claveSist = r03.MiEntidad;
                    break;
            }
            if (_clave == _claveSist)
            {
                _isClaveOk = true;
            }
            else
            {
                Helpers.Msg.Error("CLAVE INCORRECTA !!!");
            }

        }

        public void setClave(string p)
        {
            _clave = p;
        }

    }

}