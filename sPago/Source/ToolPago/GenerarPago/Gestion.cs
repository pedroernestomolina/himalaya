using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.GenerarPago
{
    
    public class Gestion : IGestion
    {


        private string _idProv;
        private data _data;
        private bool _abandonarIsOk;
        private IListaDocPagar _gListaDocPagar;
        private IMetodosPago _gMetodosPago;


        public BindingSource SourceDocPagar { get { return _gListaDocPagar.SourceDocPagar; } }
        public int CntDocPagar { get { return _gListaDocPagar.CntDocPagar; } }
        public string DataProveedor { get { return _data.DataProveedor; } }
        public bool GenerarPagIsOk { get { return false; } }
        public decimal MontoPagar { get { return _gListaDocPagar.MontoPagar; } }
        public item ItemActual { get { return _gListaDocPagar.ItemActual; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool HayItemsMarcados { get { return _gListaDocPagar.HayItemsMarcados; } }
        

        public Gestion(IListaDocPagar ctrListDocPagar, IMetodosPago ctrMetodoPago) 
        {
            _gListaDocPagar = ctrListDocPagar;
            _gMetodosPago = ctrMetodoPago;
            _abandonarIsOk = false;
            _data = new data();
        }


        public void setProveedor(string p)
        {
            _idProv = p;
        }

        public void Inicializa()
        {
            _abandonarIsOk = false;
            _data.Inicializa();
            _gListaDocPagar.Inicializa();
        }

        GenerarPagoFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new GenerarPagoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Proveedor_GetById(_idProv);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _data.setProveedor(r01.MiEntidad);

            var r02 = Sistema.MyData.ToolPago_PendPagar_GetByIdProv(_idProv);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _gListaDocPagar.setLista(r02.ListaEntidad);

            return true;
        }

        public void MarcarItemPagar()
        {
            if (ItemActual != null)
            {
                var _xmonto = 1000;
                _gListaDocPagar.setPagarActivar(_xmonto);
            }
        }

        public void LimpiarItemPagar()
        {
            if (ItemActual != null)
            {
                _gListaDocPagar.setPagarActivar(0m);
            }
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

        public void ProcesarPago()
        {
            if (!HayItemsMarcados)
            {
                Helpers.Msg.Error("No Hay Documentos Seleccionados Para Realizar Pago");
                return;
            }
            if (MontoPagar < 0)
            {
                Helpers.Msg.Error("Monto Incorrecto Para Realizar Pago");
                return;
            }
            _data.setItemsPagar(_gListaDocPagar.ListaDocPagar);
            MetodosPagos();
        }

        private void MetodosPagos()
        {
            _gMetodosPago.Inicializa();
            _gMetodosPago.setMontoPagar(MontoPagar);
            _gMetodosPago.Inicia();
            if (_gMetodosPago.ProcesarIsOk) 
            {
                _data.setMetodoPago(_gMetodosPago.ListaMetodosPago);
                GenerarPago();
            }
        }

        private void GenerarPago()
        {
        }

    }

}