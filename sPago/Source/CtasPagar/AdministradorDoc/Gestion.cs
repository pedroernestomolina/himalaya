using sPago.Source.AdministradorDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.CtasPagar.AdministradorDoc
{
    
    public class Gestion: IGestion
    {

        private bool _anularItemIsOk;
        private Filtrar.IFiltrar _gFiltro;
        private Seguridad.IGestion _gSeguridad;
        private Anular.IGestion _gAnular;
        private SistemaCtrl.VerAnulacion.IGestion _gAuditoria;


        public string TituloAdministrador { get { return "Administrador de Documentos: Ctas por Pagar"; } }
        public Enumerados.EnumTipoAdministrador TipoAdminstrador { get { return Enumerados.EnumTipoAdministrador.CtasxPagar; } }
        public Filtrar.IFiltrar GestionFiltro { get { return _gFiltro; } }
        public bool AnularItemIsOk { get { return _anularItemIsOk; } }


        public Gestion() 
        {
            _anularItemIsOk = false;
            _gFiltro = new GestionFiltro();
        }


        public void setGestionSeguridad(Seguridad.IGestion ctrSeguridad)
        {
            _gSeguridad = ctrSeguridad;
        }

        public void setGestionAnular(Anular.IGestion ctrAnular)
        {
            _gAnular = ctrAnular;
        }

        public void setGestionAuditoria(SistemaCtrl.VerAnulacion.IGestion ctrAuditoria)
        {
            _gAuditoria = ctrAuditoria;
        }


        public void Inicializa()
        {
            _anularItemIsOk = false;
        }

        public bool CargarData()
        {
            return true;
        }

        public List<data> BuscarDocs(Filtrar.dataFiltrar filtro)
        {
            var rt = new List<data>();

            var _estatus = OOB.CtaPagar.Lista.Filtro.enumEstatus.SinDefinir;
            if (filtro.Esatus !=null)
            {
                _estatus = OOB.CtaPagar.Lista.Filtro.enumEstatus.Activo;
                if (filtro.Esatus.id == "02")
                {
                    _estatus = OOB.CtaPagar.Lista.Filtro.enumEstatus.Anulado;
                }
            }
            var _tipoDoc = OOB.CtaPagar.Lista.Filtro.enumTipoDoc.SinDefinir;
            if (filtro.TipoDoc != null) 
            {
                switch (filtro.TipoDoc.id) 
                {
                    case "01":
                        _tipoDoc = OOB.CtaPagar.Lista.Filtro.enumTipoDoc.Factura;
                        break;
                    case "02":
                        _tipoDoc = OOB.CtaPagar.Lista.Filtro.enumTipoDoc.NtaCredito;
                        break;
                    case "03":
                        _tipoDoc = OOB.CtaPagar.Lista.Filtro.enumTipoDoc.Pago;
                        break;
                    case "04":
                        _tipoDoc = OOB.CtaPagar.Lista.Filtro.enumTipoDoc.Retencion;
                        break;
                    case "05":
                        _tipoDoc = OOB.CtaPagar.Lista.Filtro.enumTipoDoc.DocPorLiquidar;
                        break;
                }
            }
            DateTime? _desde = null;
            DateTime? _hasta= null;
            if (filtro.GetFechaDesde_Habilitar)
            {
                _desde = filtro.GetDesde;
            }
            if (filtro.GetFechaHasta_Habilitar)
            {
                _hasta= filtro.GetHasta;
            }
            var filt = new OOB.CtaPagar.Lista.Filtro()
            {
                desde = _desde,
                hasta = _hasta,
                autoProv = filtro.Proveedor != null ? filtro.Proveedor.id : "",
                estatus = _estatus,
                tipoDoc= _tipoDoc,
            };
            var r01 = Sistema.MyData.CtaPagar_GetLista(filt);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return rt;
            }

            foreach (var rg in r01.ListaEntidad.OrderByDescending(o=>o.fechaEmisionDoc).ThenBy(o=>o.tipoDoc).ThenByDescending(o=>o.numDoc).ToList())
            {
                rt.Add(new data(rg.autoDoc, 
                    rg.numDoc, 
                    rg.fechaEmisionDoc, 
                    rg.tipoDoc, 
                    rg.detalleDoc, 
                    rg.importeDoc, 
                    rg.abonadoDoc,
                    rg.restaDoc,
                    rg.signoDoc,
                    rg.provCiRif,
                    rg.provNombre,
                    rg.estatusDoc, 
                    rg.fechaVenceDoc,
                    0m,
                    0m,
                    0m,
                    0m,
                    0m,
                    0m));
            }

            return rt;
        }

        public void AnularItem(data ItemActual)
        {
            _anularItemIsOk = false;
            var r00 = Sistema.MyData.Permiso_CtasPagar_Adminstrador_AnularPago(Sistema.Usuario.idGrupo);
            if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            var r01 = Sistema.MyData.CtaPagar_GetById(ItemActual.autoDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            if (r01.MiEntidad.codigoModuloOrigen != "05")
            {
                Helpers.Msg.Error("DOCUMENTO A ANULAR NO APLICA PARA ESTE MODULO");
                return;
            }
            if (r01.MiEntidad.isAnulado)
            {
                Helpers.Msg.Error("DOCUMENTO YA ANULADO");
                return;
            }

            _gSeguridad.Inicializa();
            _gSeguridad.Verifica(r00.MiEntidad);
            if (_gSeguridad.IsOk)
            {
                _gAnular.Inicializa();
                _gAnular.Inicia();
                if (_gAnular.ProcesarIsOK)
                {
                    if (ItemActual.tipoDoc != "PAG")
                    {
                        AnularDoc(ItemActual.autoDoc, _gAnular.Motivo);
                    }
                    else
                    {
                        Helpers.Msg.Alerta("ANULANDO DOCUMENTO");
                        _anularItemIsOk = true;
                    }
                }
            }
        }

        private void AnularDoc(string aDoc, string mot)
        {
            var xms = "Anular Documento ?";
            var msg = MessageBox.Show(xms, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No)
            {
                return;
            }

            var ficha = new OOB.CtaPagar.AnularDoc.Ficha()
            {
                autoDoc = aDoc,
                regAuditoria = new OOB.CtaPagar.AnularDoc.Auditoria()
                {
                    autoDoc = aDoc,
                    detalle = mot,
                    equipoEstacion = Sistema.EquipoEstacion,
                    moduloOrigen = "05",
                    usuCodigo = Sistema.Usuario.codigoUsu,
                    usuNombre = Sistema.Usuario.nombreUsu,
                },
            };
            var r01 = Sistema.MyData.CtaPagar_AnularDoc(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _anularItemIsOk = true;
            Helpers.Msg.EliminarOk();
        }

        public void VisualizarDocumento(data ItemActual)
        {
            if (ItemActual.tipoDoc == "PAG")
            {
                Helpers.Msg.Alerta("VISUALIZANDO DOCUMENTO");
            }
        }

        public void ReporteDocumentos(List<data> lst)
        {
            var rp = new Reportes.CtaPagar.AdmLista.Gestion();
            rp.setLista(lst);
            rp.setFiltro("");
            rp.Generar();
        }

        public void VisualizarDocAnulado(data ItemActual)
        {
            Helpers.Msg.Alerta("VISUALIZANDO DOCUMENTO ANULADO");
        }

    }

}