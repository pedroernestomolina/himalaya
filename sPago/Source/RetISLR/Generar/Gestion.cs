using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.RetISLR.Generar
{
    
    public class Gestion
    {

        public enum enumPrefBusqueda { SinDefinir = -1, PorCiRif = 1, PorRazonSocial, PorCodigo };


        private string _prefBusPrv;
        private enumPrefBusqueda _prefBusqueda;
        private string _cadenaBuscar;
        private DateTime _fechaSistema;
        private int _ultRetISLR;
        private data _data;
        private Proveedor.Lista.Gestion _gestionListaProv;
        private List<data_1> _lst_1;
        private BindingList<data_1> _bl_1;
        private BindingSource _bs_1;
        //
        private List<data_2> _lst_ret;
        private BindingSource _bs_2;
        //
        private bool _abandonarIsOk;
        //
        private bool _activarBusquedaIsOk;


        public enumPrefBusqueda PrefBusqueda { get { return _prefBusqueda; } }
        public string DataProveedor { get { return _data.DataProveedor; } }
        public decimal DataProveedorRetISLR { get { return _data.DataProveedorRetISLR; } }
        public DateTime Fecha { get { return _fechaSistema; } }
        public int UltimaRetISLR { get { return (_ultRetISLR+1); } }
        public BindingSource SourceDocProv { get { return _bs_1; } }
        public int CntDocEncontrados { get { return _bs_1.Count; } }
        public BindingSource SourceDocRet { get { return _bs_2; } }
        public decimal Monto { get { return _lst_ret.Sum(s => s.MontoRetencion); } }
        public int Items { get { return _bs_2.Count; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }


        public Gestion() 
        {
            _activarBusquedaIsOk = true;
            _abandonarIsOk = false;
            _data = new data();
            _prefBusPrv = "";
            _prefBusqueda = enumPrefBusqueda.SinDefinir;
            _cadenaBuscar = "";
            _gestionListaProv = new Proveedor.Lista.Gestion();
            _lst_1 = new List<data_1>();
            _bl_1 = new BindingList<data_1>(_lst_1);
            _bs_1 = new BindingSource();
            _bs_1.DataSource = _bl_1;
            //
            _lst_ret = new List<data_2>();
            _bs_2 = new BindingSource();
            _bs_2.DataSource = _lst_ret;
        }


        public void Inicializa()
        {
            _activarBusquedaIsOk = true;
            _abandonarIsOk = false;
            //
            _data.Inicializa();
            //
            _prefBusPrv = "";
            _prefBusqueda = enumPrefBusqueda.SinDefinir;
            _cadenaBuscar = "";
            _gestionListaProv.Inicializa();
            //
            _bl_1.Clear();
            //
            _lst_ret.Clear();
        }

        GenerarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new GenerarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Configuracion_Proveedor_PreferenciaBusqueda();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _prefBusPrv = r01.MiEntidad;

            var r02 = Sistema.MyData.FechaSistema();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _fechaSistema = r02.MiEntidad.Date;

            var r03 = Sistema.MyData.RetISLR_ContadorUltimaRetencion();
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _ultRetISLR = r03.MiEntidad;

            switch (_prefBusPrv)
            {
                case "CI/RIF":
                    _prefBusqueda = enumPrefBusqueda.PorCiRif;
                    break;
                case "NOMBRE":
                    _prefBusqueda = enumPrefBusqueda.PorRazonSocial;
                    break;
                case "CODIGO":
                    _prefBusqueda = enumPrefBusqueda.PorCodigo;
                    break;
            }

            return true;
        }

        public void setCadenaBuscar(string p)
        {
            _cadenaBuscar = p;
        }

        public void Buscar()
        {
            if (!_activarBusquedaIsOk)
            {
                Helpers.Msg.Alerta("Para Hacer Una Nueva Busqueda, Debes Limpiar La Ficha Actual");
                return;
            }

            if (_cadenaBuscar=="")
            {
                return;
            }

            var metBusq= OOB.Proveedor.enumerados.metodosBusq.SinDefinir;
            switch(_prefBusqueda)
            {
                case enumPrefBusqueda.PorCiRif:
                    metBusq= OOB.Proveedor.enumerados.metodosBusq.PorCirif;
                    break;
                case enumPrefBusqueda.PorCodigo:
                    metBusq= OOB.Proveedor.enumerados.metodosBusq.PorCodigo;
                    break;
                case enumPrefBusqueda.PorRazonSocial:
                    metBusq= OOB.Proveedor.enumerados.metodosBusq.PorRazonSocial;
                    break;
            }
            var filtro = new OOB.Proveedor.Lista.Filtro()
            {
                cadena = _cadenaBuscar,
                metodoBusq = metBusq,
            };
            var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gestionListaProv.Inicializa();
            _gestionListaProv.setLista(r01.ListaEntidad);
            _gestionListaProv.Inicia();
            if (_gestionListaProv.ItemSeleccionadoIsOk)
            {
                CargarProveedor(_gestionListaProv.ItemSeleccionado.auto);
            }
        }

        private void CargarProveedor(string id)
        {
            _activarBusquedaIsOk = false;
            var r01 = Sistema.MyData.Proveedor_GetById(id);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _data.setProveedor(r01.MiEntidad);

            var filtro = new OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro()
            {
                idProv = r01.MiEntidad.id,
            };
            var r02 = Sistema.MyData.RetISLR_DocumentosPendPorAplicar_GetLista(filtro);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            _bl_1.Clear();
            foreach(var it in r02.ListaEntidad)
            {
                _bl_1.Add(new data_1(it));
            }
        }

        public void setPrefBusquedaPorCodigo()
        {
            _prefBusqueda = enumPrefBusqueda.PorCodigo;
        }

        public void setPrefBusquedaPorNombre()
        {
            _prefBusqueda = enumPrefBusqueda.PorRazonSocial;
        }

        public void setPrefBusquedaPorCiRif()
        {
            _prefBusqueda = enumPrefBusqueda.PorCiRif;
        }

        public void AplicarRetDocSeleccionados()
        {
            _lst_ret.Clear();
            foreach (var rt in _bl_1.Where(w => w.IsActivo).ToList())
            {
                var r01 = Sistema.MyData.RetISLR_DocumentoPendPorAplicar_GetByIdDoc(rt.AutoDoc);
                if (r01.Result != OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    _lst_ret.Add(new data_2(r01.MiEntidad, _data.DataProveedorRetISLR));
                }
            }
            _bs_2.DataSource = _lst_ret;
            _bs_2.CurrencyManager.Refresh();
        }
        
        public  void setTasaRetencion(decimal p)
        {
            _data.setTasaRetencion(p);
            foreach (var rt in _lst_ret.ToList())
            {
                rt.setTasaRet(p);
            }
        }

        public void Abandonar()
        {
            _abandonarIsOk = false;
            var msg = "Abandonar Proceso Actual y Perder Los Cambios ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) 
            {
                _abandonarIsOk = true;
            }
        }

        public void LimpiarFicha()
        {
            var msg = "Limpiar Datos de la Ficha ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                _activarBusquedaIsOk = true;
                _abandonarIsOk = false;
                _data.Inicializa();
                _cadenaBuscar = "";
                //
                _lst_ret.Clear();
                _bs_2.DataSource = _lst_ret;
                _bs_2.CurrencyManager.Refresh();
                //
                _bl_1.Clear();
            }
        }
        
        public void ProcesarFicha()
        {
            if (Items ==0)
            {
                return;
            }
            
            var msg = "Procesar Dicha Retención ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                Procesar();
            }
        }

        private void Procesar()
        {
            var mexento = _lst_ret.Sum(s=>s.Exento*s.Signo);
            var mbase = _lst_ret.Sum(s=>s.Base*s.Signo);
            var miva = _lst_ret.Sum(s=>s.Iva*s.Signo);
            var mtotal = _lst_ret.Sum(s=>s.Monto*s.Signo);

            var ficha = new OOB.RetISLR.GenerarRetencion.Ficha();
            ficha.retencion = new OOB.RetISLR.GenerarRetencion.Retencion()
            {
                autoProv = _data.Proveedor.id,
                ciRifProv = _data.Proveedor.ciRif,
                codigoProv = _data.Proveedor.codigo,
                dirFiscalProv = _data.Proveedor.dirFiscal,
                estatusAnulado = "0",
                montoBase = mbase,
                montoExento = mexento,
                montoIva = miva,
                total = mtotal,
                montoRetencion = Monto,
                nombreRazonSocialProv = _data.Proveedor.nombreRazonSocial,
                tasaRetencion = _data.DataProveedorRetISLR,
                tipoRetencion = "02",
            };
            ficha.retencionDet = _lst_ret.Select(s =>
            {
                var nr = new OOB.RetISLR.GenerarRetencion.RetencionDet()
                {
                    autoDoc = s.AutoDoc,
                    ciRifProv = _data.Proveedor.ciRif,
                    estatusAnulado = "0",
                    fechaDoc = s.Fecha,
                    montoBase = s.Base,
                    montoBase1 = s.Ficha.Base_1,
                    montoBase2 = s.Ficha.Base_2,
                    montoBase3 = s.Ficha.Base_3,
                    montoExento = s.Exento,
                    montoIva = s.Iva,
                    montoIva1 = s.Ficha.Iva_1,
                    montoIva2 = s.Ficha.Iva_2,
                    montoIva3 = s.Ficha.Iva_3,
                    montoRetencion = Monto,
                    montoTasa1 = s.Ficha.TasaIva_1,
                    montoTasa2 = s.Ficha.TasaIva_2,
                    montoTasa3 = s.Ficha.TasaIva_3,
                    numControlDoc = s.Control,
                    numDoc = s.Documento,
                    numDocAplica = s.Ficha.DocAplica,
                    signoDoc = s.Signo,
                    tasaRetencion = _data.DataProveedorRetISLR,
                    tipoDoc = s.Ficha.tipoDoc,
                    tipoRetencion = "02",
                    total = s.Monto,
                };
                return nr;
            }).ToList();
            ficha.docAplicaRet = _lst_ret.Select(s =>
            {
                var nr = new OOB.RetISLR.GenerarRetencion.DocAplicaRet()
                {
                    autoDoc = s.AutoDoc,
                    montoAplica = s.MontoRetencion,
                    tasaAplica = _data.DataProveedorRetISLR,
                };
                return nr;
            }).ToList();
            ficha.docActualizarSaldoCxP = _lst_ret.Select(s =>
            {
                var nr = new OOB.RetISLR.GenerarRetencion.DocActualizarSaldoCxP
                {
                    idDocCxP = s.Ficha.autoCxP,
                    montoAbonado = s.MontoRetencion,
                };
                return nr;
            }).ToList();
            ficha.cxp = new OOB.RetISLR.GenerarRetencion.CxP()
            {
                acumulado = Monto,
                autoProv = _data.Proveedor.id,
                ciRifProv = _data.Proveedor.ciRif,
                codigoProv = _data.Proveedor.codigo,
                detalle = "RETENCION ISLR",
                estatusAnulado = "0",
                estatusPagado = "1",
                importe = Monto,
                montoResta = 0M,
                nombreRazonSocialProv = _data.Proveedor.nombreRazonSocial,
                signo = -1,
                tipoDocGen = "IR",
                moduloOrigen = "05",
            };

            var r01 = Sistema.MyData.RetISLR_GenerarRetencion(ficha);
            if (r01.Result== OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
        }

    }

}