using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Maestro.MedioPago.AgregarEditar
{

    public class AgregarEditar: IAgregarEditar
    {

        enum enumModo { SinDefinir=-1, Agregar=1, Editar };


        private enumModo _modoFicha;
        private data _data;
        private string _titulo;
        private bool _agregarIsOk;
        private int _idItemAgregado;
        private bool _editarIsOk;
        private bool _procesarIsOK;
        private bool _abandonarIsOk;


        public bool AgregarIsOk { get { return _agregarIsOk; } }
        public int IdItemAgregado { get { return _idItemAgregado; } }
        public bool EditarIsOk { get { return _editarIsOk; } }
        public string Codigo { get { return _data.Codigo; } }
        public string Nombre { get { return _data.Descripcion; } }
        public string TituloVentana { get { return _titulo; } }
        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }

        
        public AgregarEditar()
        {
            _data = new data();
            _modoFicha = enumModo.SinDefinir;
            _titulo = "";
            _agregarIsOk = false;
            _idItemAgregado = -1;
            _editarIsOk = false;
            _abandonarIsOk = false;
            _procesarIsOK = false;
        }


        public bool AbandonarDocumento()
        {
            var msg = MessageBox.Show("Abandonar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return (msg == DialogResult.Yes);
        }

        public void Inicializa()
        {
            if (_modoFicha != enumModo.Editar)
            {
                _data.Inicializar();
            }
            _agregarIsOk = false;
            _editarIsOk = false;
            _idItemAgregado = -1;
        }

        AgregarEditarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setModoAgregar(string p)
        {
            _titulo = p;
            _modoFicha = enumModo.Agregar;
        }

        public void setDescripcion(string p)
            {
            _data.setDescripcion(p);
        }

        public void setCodigo(string p)
        {
            _data.setCodigo(p);
        }

        public void Abandonar()
        {
            _abandonarIsOk = false;
            var msg = "Abandonar y Perder Los Cambios ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

        public void Procesar()
        {
            _procesarIsOK = false;
            if (_data.VerificarIsOk())
            {
                if (_modoFicha == enumModo.Agregar)
                {
                    _agregarIsOk = false;
                    AgregarRegistro();
                }
                else 
                {
                    _editarIsOk = false;
                    EditarRegistro();
                }
            }
        }

        private void AgregarRegistro()
        {
            var xms = "Guardar Ficha ?";
            var msg = MessageBox.Show(xms, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var xficha = new OOB.MedioPago.Agregar.Ficha()
                {
                    descripcion = Nombre,
                    codigo = Codigo,
                };
                var r01 = Sistema.MyData.MedioPago_Agregar(xficha);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _idItemAgregado = r01.Id;
                _procesarIsOK = true;
                _agregarIsOk = true;
            }
        }

        public void setModoEditar(string p, Maestro.data dt)
        {
            _titulo = p;
            _modoFicha = enumModo.Editar;
            _data.Inicializar();
            _data.setId(dt.id);
            _data.setCodigo(dt.codigo);
            _data.setDescripcion(dt.descripcion);
        }

        private void EditarRegistro()
        {
            var xms = "Actualizar Datos Ficha ?";
            var msg = MessageBox.Show(xms, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var xficha = new OOB.MedioPago.Editar.Ficha()
                {
                    id = _data.Id,
                    descripcion = Nombre,
                    codigo = Codigo,
                };
                var r01 = Sistema.MyData.MedioPago_Editar(xficha);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOK = true;
                _editarIsOk = true;
            }
        }

    }

}