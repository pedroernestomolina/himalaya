using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.RetISLR.Administrador
{

    public class Gestion
    {

        private Filtro.Gestion _gFiltro;
        private Items.Gestion _gItem;
        private Seguridad.Gestion _gSeguridad;
        private Anular.Gestion _gAnular;
        private SistemaCtrl.VerAnulacion.Gestion _gAuditoria;


        public int CntItems { get { return _gItem.CntItem; } }
        public DateTime Desde { get { return _gFiltro.GetDesde; } }
        public DateTime Hasta { get { return _gFiltro.GetHasta; } }
        public object ItemSource { get { return _gItem.ItemSource; } }


        public Gestion()
        {
            _gFiltro = new Filtro.Gestion();
            _gItem = new Items.Gestion();
            _gAnular = new Anular.Gestion();
            _gAuditoria = new  SistemaCtrl.VerAnulacion.Gestion();
        }


        public void Inicializa()
        {
            _gFiltro.Inicializa();
            _gItem.Inicializa();
            _gAnular.Inicializa();
            _gAuditoria.Inicializa();
        }

        AdmDocFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AdmDocFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setFechaDesde(DateTime fecha)
        {
            _gFiltro.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _gFiltro.setFechaHasta(fecha);
        }

        public void Buscar()
        {
            GenerarBusqueda();
        }

        private void GenerarBusqueda()
        {
            _gItem.Limpiar();
            var filtro = new OOB.RetISLR.Lista.Filtro()
            {
                desde = _gFiltro.GetDesde,
                hasta = _gFiltro.GetHasta,
                tipoRetencion = "02",
            };
            var r01 = Sistema.MyData.RetISLR_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gItem.setLista(r01.ListaEntidad);
        }

        public void LimpiarFiltros()
        {
            _gFiltro.Inicializa();
        }

        public void LimpiarItems()
        {
            _gItem.Limpiar();
        }

        public void Imprimir()
        {
            var rp = new Reportes.RetISLR.AdmLista.Gestion();
            rp.setLista(_gItem.ListaItems);
            rp.setFiltro(_gFiltro.Filtros);
            rp.Generar();
        }

        public void VisualizarDocumento()
        {
            if (_gItem.ItemActual != null)
            {
                var r01 = Sistema.MyData.RetISLR_GetById(_gItem.ItemActual.Id);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Helpers.Utils.VisualizarRetISLR(r01.MiEntidad);
            }
        }

        public void AnularItem()
        {
            if (_gItem.ItemActual == null)
            {
                return;
            }
            if (_gItem.ItemActual.IsAnulado) 
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
                AnularDoc(_gItem.ItemActual.Id);
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
                    _gItem.setEstatusAnuladoItemActual();
                    Helpers.Msg.EliminarOk();
                }
            }
        }

        public void setGSeguridad(Seguridad.Gestion gSeguridad)
        {
            _gSeguridad = gSeguridad;
        }

        public void VisualizarDocAnulado()
        {
            if (_gItem.ItemActual == null)
            {
                return;
            }
            if (!_gItem.ItemActual.IsAnulado)
            {
                return;
            }

            var ficha = new OOB.Sistema.DocAnulado.Buscar.Ficha()
            {
                autoDoc = _gItem.ItemActual.Id,
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