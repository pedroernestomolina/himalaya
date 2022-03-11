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
        private bool _procesarPagoIsOk;
        private string _idReciboPagoGenerado; 
        private IListaDocPagar _gListaDocPagar;
        private IMetodosPago _gMetodosPago;
        private IDetalleMonto _gDetalleMonto;


        public BindingSource SourceDocPagar { get { return _gListaDocPagar.SourceDocPagar; } }
        public int CntDocPagar { get { return _gListaDocPagar.CntDocPagar; } }
        public string DataProveedor { get { return _data.DataProveedor; } }
        public decimal MontoPagar { get { return _gListaDocPagar.MontoPagar; } }
        public item ItemActual { get { return _gListaDocPagar.ItemActual; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool ProcesarPagoIsOk { get { return _procesarPagoIsOk; } }
        public bool GenerarPagIsOk { get { return _procesarPagoIsOk; } }
        public bool HayItemsMarcados { get { return _gListaDocPagar.HayItemsMarcados; } }
        public string IdReciboPago { get { return _idReciboPagoGenerado; } }
        

        public Gestion(IListaDocPagar ctrListDocPagar, IMetodosPago ctrMetodoPago, IDetalleMonto ctrDetalleMonto) 
        {
            _idReciboPagoGenerado = "";
            _gListaDocPagar = ctrListDocPagar;
            _gMetodosPago = ctrMetodoPago;
            _gDetalleMonto = ctrDetalleMonto;
            _abandonarIsOk = false;
            _procesarPagoIsOk = false;
            _data = new data();
        }


        public void setProveedor(string p)
        {
            _idProv = p;
        }

        public void Inicializa()
        {
            _idReciboPagoGenerado = "";
            _procesarPagoIsOk = false;
            _abandonarIsOk = false;
            _data.Inicializa();
            _gListaDocPagar.Inicializa();
            _gMetodosPago.Inicializa();
            _gDetalleMonto.Inicializa();
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
                _gDetalleMonto.Inicializa();
                _gDetalleMonto.setData(ItemActual.RestaDoc, ItemActual.MontoPagar, ItemActual.DetallePago);
                _gDetalleMonto.Inicia();
                if (_gDetalleMonto.DetalleMontoIsOk)
                {
                    _gListaDocPagar.setPagarActivar(_gDetalleMonto.MontoPagar, _gDetalleMonto.Detalle);
                }
            }
        }

        public void LimpiarItemPagar()
        {
            if (ItemActual != null)
            {
                _gListaDocPagar.setPagarActivar(0m, "");
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
            _idReciboPagoGenerado = "";
            _procesarPagoIsOk = false;
            var fichaOOB = new OOB.ToolPago.GenerarPago.Ficha();
            fichaOOB.docActualizarSaldoCxP = _data.DocumentosPagar.Select(s =>
            {
                var nr = new OOB.ToolPago.GenerarPago.DocActualizarSaldoCxP 
                {
                    idDocCxP = s.Ficha.autoDoc,
                    montoAbonado = s.MontoPagar,
                };
                return nr;
            }).ToList();
            fichaOOB.cxp = new OOB.ToolPago.GenerarPago.CxP()
            {
                acumulado = MontoPagar,
                autoProv = _data.Proveedor.id,
                ciRifProv = _data.Proveedor.ciRif,
                codigoProv = _data.Proveedor.codigo,
                detalle = "PAGO",
                estatusAnulado = "0",
                estatusPagado = "1",
                importe = MontoPagar,
                montoResta = 0M,
                nombreRazonSocialProv = _data.Proveedor.nombreRazonSocial,
                signo = -1,
                tipoDocGen = "PAG",
                moduloOrigen = "05",//A TRAVEZ DEL MODULO DE PAGO CXP 
            };
            fichaOOB.recibo = new OOB.ToolPago.GenerarPago.Recibo()
            {
                autoProv = _data.Proveedor.id,
                autoUsuario = Sistema.Usuario.id,
                cantDocInvolucrado = _data.DocumentosPagar.Count,
                ciRifProv = _data.Proveedor.ciRif,
                codigoProv = _data.Proveedor.codigo,
                dirFiscalProv = _data.Proveedor.dirFiscal,
                estatusAnulado = "0",
                importe = MontoPagar,
                montoCambio = 0m,
                montoRecibido = MontoPagar,
                nombreRazonSocialProv = _data.Proveedor.nombreRazonSocial,
                nombreUsuario = Sistema.Usuario.nombreUsu,
                detalle = "",
                notas = "",
                tipoPagoOrigen= "5", // MODULO PAGO CXP 
                telefonoProv = _data.Proveedor.telefonos,
            };
            var it = 0;
            fichaOOB.docInvRecibo = _data.DocumentosPagar.Select(s =>
            {
                it += 1;
                var nr = new OOB.ToolPago.GenerarPago.DocInvRecibo()
                {
                    autoCxPDocInv = s.Ficha.autoDoc,
                    detalle = s.DetallePago,
                    fechaDocInv = s.FechaDoc,
                    montoImporte = s.MontoPagar,
                    nItem = it,
                    numDocInv = s.NumeroDoc,
                    operacionEjecutar = "Abono",
                    tipoDocInv = s.Ficha.CodigoDoc,
                    nombreDocInv = s.Ficha.NombreDoc,
                };
                return nr;
            }).ToList();
            fichaOOB.formasPago = _data.MetodosPago.Select(s =>
            {
                var nr = new OOB.ToolPago.GenerarPago.FormaPago()
                {
                    codigoMedioPago = s.GetMedioPago.codigo,
                    descMedioPago = s.GetMedioPago.desc,
                    estatusAnulado = "0",
                    importe = s.Importe,
                    montoRecibido = s.GetMonto,
                    aplicaFactorCambio = s.GetAplicaFactorCambio ? "1" : "0",
                    banco = s.GetBanco,
                    detalleOperacion = s.GetDetalleOperacion,
                    factorCambio = s.GetFactorCambio,
                    fechaOperacion = s.GetFechaOperacion,
                    numeroChequeRef = s.GetNumeroChequeRef,
                    numeroCta = s.GetNumeroCta,
                };
                return nr;
            }).ToList();
            fichaOOB.proveedorAct = new OOB.ToolPago.GenerarPago.ProvActualizar()
            {
                autoProv = _data.Proveedor.id,
                credito = _data.DocumentosPagar.Where(s => s.Ficha.signoDoc == -1).Sum(ss => ss.MontoPagar),
                debito = _data.DocumentosPagar.Where(s => s.Ficha.signoDoc == 1).Sum(ss => ss.MontoPagar),
            };

            var r01 = Sistema.MyData.ToolPago_GenerarPago(fichaOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _idReciboPagoGenerado = r01.Auto;
            _procesarPagoIsOk = true;
        }

        public void MarcarDesmarcarDoc()
        {
            if (ItemActual != null) 
            {
                if (ItemActual.IsPagarActiva)
                {
                    LimpiarItemPagar();
                }
                else 
                {
                    MarcarItemPagar();
                }
            }
        }

    }

}