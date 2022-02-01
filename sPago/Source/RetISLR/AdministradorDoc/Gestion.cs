using sPago.Source.AdministradorDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.RetISLR.AdministradorDoc
{
    
    public class Gestion: IGestion
    {

        private bool _anularItemIsOk;
        private Filtrar.IFiltrar _gFiltro;
        private Seguridad.IGestion _gSeguridad;
        private Anular.IGestion _gAnular;
        private SistemaCtrl.VerAnulacion.IGestion _gAuditoria;


        public string TituloAdministrador { get { return "Administrador de Documentos: Retención ISLR"; } }
        public Enumerados.EnumTipoAdministrador TipoAdminstrador { get { return Enumerados.EnumTipoAdministrador.RetencionISLR; } }
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
            _gAnular= ctrAnular;
        }

        public void setGestionAuditoria(SistemaCtrl.VerAnulacion.IGestion ctrAuditoria)
        {
            _gAuditoria= ctrAuditoria;
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

            DateTime? _desde = null;
            DateTime? _hasta = null;
            string _idProv = "";
            var _estatus = OOB.RetISLR.Lista.Filtro.enumEstatus.SinDefinir;
            if (filtro.GetFechaDesde_Habilitar)
            {
                _desde = filtro.GetDesde;
            }
            if (filtro.GetFechaHasta_Habilitar)
            {
                _hasta = filtro.GetHasta;
            }
            if (filtro.Proveedor !=null)
            {
                _idProv = filtro.Proveedor.id;
            }
            if (filtro.Esatus != null)
            {
                _estatus = OOB.RetISLR.Lista.Filtro.enumEstatus.Activo;
                if (filtro.Esatus.id == "02")
                {
                    _estatus = _estatus = OOB.RetISLR.Lista.Filtro.enumEstatus.Anulado;
                }
            }
            var filtroOOB = new OOB.RetISLR.Lista.Filtro()
            {
                desde = _desde,
                hasta = _hasta,
                tipoRetencion = "02",
                idProv = _idProv,
                estatus=_estatus,
            };
            var r01 = Sistema.MyData.RetISLR_GetLista(filtroOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return rt;
            }

            foreach (var rg in r01.ListaEntidad.OrderByDescending(o => o.deFecha).ThenByDescending(o=>o.documento).ToList())
            {
                var nw = new data(
                    rg.id,
                    rg.documento,
                    rg.deFecha,
                    "", 
                    "", 
                    0m,
                    0m, 
                    0m, 
                    1, 
                    rg.ciRifProv,
                    rg.nombreProv,
                    rg.estatus,
                    DateTime.Now.Date, 
                    rg.tasaRet,
                    rg.montoRet,
                    rg.mExento,
                    rg.mBase,
                    rg.mIva,
                    rg.mTotal);
                rt.Add(nw);
            }

            return rt;
        }

        public void AnularItem(data ItemActual)
        {
            _anularItemIsOk = false;

            if (ItemActual.isAnulado)
            {
                Helpers.Msg.Error("DOCUMENTO YA ANULADO");
                return;
            }

            var r01 = Sistema.MyData.Permiso_Solicitud_AnularRetencionISLR(Sistema.Usuario.idGrupo);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gSeguridad.Inicializa();
            _gSeguridad.Verifica(r01.MiEntidad);
            if (_gSeguridad.IsOk)
            {
                AnularDoc(ItemActual.autoDoc);
            }
        }

        private void AnularDoc(string idDoc)
        {
            _gAnular.Inicializa();
            _gAnular.Inicia();
            if (_gAnular.ProcesarIsOK)
            {
                var msg = "Seguro de Anular Documento ?";
                var mr = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (mr == DialogResult.Yes)
                {
                    var r01 = Sistema.MyData.RetISLR_AnularRetencion_CapturarData(idDoc);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }

                    var s = r01.MiEntidad;
                    var ficha = new OOB.RetISLR.AnularRetencion.Anular.Ficha()
                    {
                        autoDocRetencion = s.autoDocRetencion,
                        autoPago = s.autoPago,
                        autoRecibo = s.autoRecibo,
                        docCompraAplicaRetencion = s.docCompraAplicaRetencion.Select(ss =>
                        {
                            var nr = new OOB.RetISLR.AnularRetencion.Anular.DocCompraAplicaRetencion()
                            {
                                autoCxP = ss.autoCxP,
                                autoDocCompra = ss.autoDocCompra,
                                montoAplica = ss.montoAplica,
                            };
                            return nr;
                        }).ToList(),
                    };
                    ficha.docRegistrAnulacion = new OOB.RetISLR.AnularRetencion.Anular.DocRegistro()
                    {
                        autoDoc = idDoc,
                        detalle = _gAnular.Motivo,
                        equipoEstacion = Sistema.EquipoEstacion,
                        moduloOrigen = "07R2",
                        usuCodigo = Sistema.Usuario.codigoUsu,
                        usuNombre = Sistema.Usuario.nombreUsu,
                    };
                    var r02 = Sistema.MyData.RetISLR_AnularRetencion(ficha);
                    if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }
                    Helpers.Msg.EliminarOk();
                    _anularItemIsOk = true;
                }
            }
        }

        public void VisualizarDocumento(data ItemActual)
        {
            var r01 = Sistema.MyData.RetISLR_GetById(ItemActual.autoDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Helpers.Utils.VisualizarRetISLR(r01.MiEntidad);
        }

        public void ReporteDocumentos(List<data> lst)
        {
            var rp = new Reportes.RetISLR.AdmLista.Gestion();
            rp.setLista(lst);
            rp.setFiltro("");
            rp.Generar();
        }

        public void VisualizarDocAnulado(data ItemActual)
        {
            var ficha = new OOB.Sistema.DocAnulado.Buscar.Ficha()
            {
                autoDoc = ItemActual.autoDoc,
                moduloOrigen = "07R2",
            };
            var r01 = sPago.Sistema.MyData.Sistema_DocAnulado_Buscar(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            _gAuditoria.Inicializa();
            _gAuditoria.setData(r01.MiEntidad);
            _gAuditoria.Inicia();
        }

    }

}