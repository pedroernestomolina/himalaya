using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago.NuevoDcoumento
{
    
    public class Gestion: IGestion
    {


        private string _cadenaBusProv;
        private data _data;
        private List<ficha> _lCondPago;
        private List<ficha> _lTipoDoc;
        private BindingSource _bsCondPago;
        private BindingSource _bsTipoDoc;
        private bool _agregarDocIsOk;
        private string _documentoAgregadoGetId;
        private bool _abandonarIsOk;
        private Filtrar.IListaProv _gProv;


        public DateTime FechaEmision { get { return _data.FechaEmision; } }
        public DateTime FechaVencimiento { get { return _data.FechaVencimiento; } }
        public int DiasCredito { get { return _data.DiasCredito; } }
        public string NumeroDoc { get { return _data.DocumentoNro; } }
        public decimal Importe { get { return _data.Importe; } }
        public string Detalle { get { return _data.Detalle; } }
        public string Proveedor { get { return _data.GetProveedor; } }
        public BindingSource SourceCondPago { get { return _bsCondPago; } }
        public BindingSource SourceTipoDoc { get { return _bsTipoDoc; } }
        public bool AgregarDocIsOk { get { return _agregarDocIsOk; } }
        public string DocumentoAgregadoGetId { get { return _documentoAgregadoGetId; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }


        public Gestion(Filtrar.IListaProv ctrProv) 
        {
            _gProv = ctrProv;
            _data = new data();
            _lCondPago = new List<ficha>();
            _lTipoDoc = new List<ficha>();
            _bsCondPago = new BindingSource();
            _bsTipoDoc = new BindingSource();
            _bsCondPago.DataSource = _lCondPago;
            _bsTipoDoc.DataSource = _lTipoDoc;
            _abandonarIsOk = false;
            _agregarDocIsOk = false;
            _documentoAgregadoGetId = "";
        }


        public void Inicializa() 
        {
            _data.Inicializa();
            _lCondPago.Clear();
            _lTipoDoc.Clear();
            _abandonarIsOk = false;
            _agregarDocIsOk = false;
            _documentoAgregadoGetId = "";
        }

        AgregarDocFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AgregarDocFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            _lTipoDoc.Clear();
            _lTipoDoc.Add(new ficha("01", "FACTURA"));
            _lTipoDoc.Add(new ficha("02", "NOTA DEBITO"));
            _lTipoDoc.Add(new ficha("03", "NOTA CREDITO"));
            _bsTipoDoc.DataSource = _lTipoDoc;

            _lCondPago.Clear();
            _lCondPago.Add(new ficha("01", "CONTADO"));
            _lCondPago.Add(new ficha("02", "CREDITO"));
            _bsCondPago.DataSource = _lCondPago;

            return true;
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

        public void setCondPago(string id)
        {
            _data.setCondPago(_lCondPago.FirstOrDefault(f => f.id == id));
        }

        public void setTipoDoc(string id)
        {
            _data.setTipoDoc(_lTipoDoc.FirstOrDefault(f => f.id == id));
        }

        public void setFechaEmision(DateTime fecha)
        {
            _data.setFechaEmision(fecha);
        }

        public void setDiasCredito(int dias)
        {
            _data.setDiasCredito(dias);
        }

        public void setDocumentoNumero(string p)
        {
            _data.setDocumentoNumero(p);
        }

        public void setImporte(decimal p)
        {
            _data.setImporte(p);
        }

        public void setDetalle(string p)
        {
            _data.setDetalle(p);
        }

        public void setCadenaBuscarProv(string p)
        {
            _cadenaBusProv = p;
        }

        public void BuscarProveedor()
        {
            if (_cadenaBusProv.Trim().ToUpper() == "")
                return;

            var filtro = new OOB.Proveedor.Lista.Filtro() { cadena = _cadenaBusProv, metodoBusq = OOB.Proveedor.enumerados.metodosBusq.PorRazonSocial };
            var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return ;
            }

            _gProv.Inicializa();
            _gProv.setLista(r01.ListaEntidad);
            _gProv.Inicia();
            if (_gProv.ItemSeleccionadoIsOk)
            {
                _data.setProveedor(_gProv.ProveedorSeleccionado);
            }
        }

        public void Procesar()
        {
            if (!ValidarDatos())
                return;

            _agregarDocIsOk = false;
            var msg = "Procesar Documento ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                GuardarDatos();
            }
        }

        private bool ValidarDatos()
        {
            return _data.ValidarDatos();
        }

        private void GuardarDatos()
        {
            var mdebito=0m;
            var mcredito=0m;
            var signoDocumento=1;
            var tipoDocumento="";
            switch (_data.TipoDocumento.id) 
            {
                case "01":
                    tipoDocumento = "FAC";
                    mdebito= _data.Importe;
                    break;
                case "02":
                    tipoDocumento = "NDF";
                    mdebito= _data.Importe;
                    break;
                case "03":
                    signoDocumento = -1;
                    tipoDocumento = "NCF";
                    mcredito= _data.Importe*signoDocumento;
                    break;
            }
            var ficha = new OOB.CtaPagar.Agregar.Ficha()
            {
                abonadoDoc = 0m,
                autoProv = _data.Proveedor.id,
                codigoModuloOrigen = "05",
                detalleDoc = _data.Detalle,
                estatusCanceladoDoc = "0",
                estatusDoc = "0",
                fechaEmisionDoc = _data.FechaEmision,
                fechaVenceDoc = _data.FechaVencimiento,
                importeDoc = _data.Importe * signoDocumento,
                numeroDoc = _data.DocumentoNro,
                provCiRif = _data.Proveedor.ciRif,
                provCodigo = _data.Proveedor.codigo,
                provNombre = _data.Proveedor.nombreRazonSocial,
                restaDoc = _data.Importe * signoDocumento,
                signoDoc = signoDocumento,
                tipoDoc = tipoDocumento,
                proveedorAct = new OOB.CtaPagar.Agregar.ProvActualizar()
                {
                    autoProv = _data.Proveedor.id,
                    credito = mcredito,
                    debito = mdebito,
                },
            };
            var r01 = Sistema.MyData.CtaPagar_Agregar(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _agregarDocIsOk = true;
            _documentoAgregadoGetId = r01.Auto;
            Helpers.Msg.AgregarOk();
        }

    }

}