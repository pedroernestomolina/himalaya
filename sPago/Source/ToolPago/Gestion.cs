using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.ToolPago
{
    
    public class Gestion
    {


        private Lista.Gestion _gLista;
        private PorPagar.IGestion _gPorPagar;
        private NuevoDcoumento.IGestion _gAgregarDoc;
        private GenerarPago.IGestion _gGenerarPago;


        public Lista.data ItemActual { get { return _gLista.ItemActual; } }
        public BindingSource SourceItems { get { return _gLista.SourceItems; } }
        public decimal Acumulado { get { return _gLista.Acumulado; } }
        public decimal Resta { get { return _gLista.Resta; } }
        public decimal Importe { get { return _gLista.Importe; } }
        public int CntItem { get { return _gLista.CntItems; } }
        public bool AgregarDocumentoIsOk { get { return _gAgregarDoc.AgregarDocIsOk; } }
        public bool GenerarPagIsOk { get { return _gGenerarPago.GenerarPagIsOk; } }


        public Gestion(Filtrar.IListaProv ctrProv, 
            PorPagar.IGestion ctrPorPagar, 
            GenerarPago.IGestion ctrGenerarPago) 
        {
            _gPorPagar = ctrPorPagar;
            _gGenerarPago = ctrGenerarPago;
            _gLista = new Lista.Gestion();
            _gAgregarDoc = new NuevoDcoumento.Gestion(ctrProv);
        }


        public void Inicializa() 
        {
            _gLista.Inicializa();
        }

        PrincipalFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new PrincipalFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.ToolPago_ResumenPendPagar_GetLista();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var lst = new List<Lista.data>();
            foreach (var rg in r01.ListaEntidad.OrderBy(o => o.provNombre).ToList()) 
            {
                lst.Add(new Lista.data(rg.provId, rg.provNombre, rg.provCiRif, rg.importe, rg.resta, rg.acumulado, rg.cntDoc));
            }
            _gLista.setLista(lst);

            return true;
        }

        public void VisualizarProveedor()
        {
            if (ItemActual != null)
            {
                CtasPorPagarProveedor(ItemActual);
            }
        }

        private void CtasPorPagarProveedor(Lista.data ItemActual)
        {
            var filtro = new OOB.Reportes.CtasPagar.DocumentosPorPagar.Filtro() { idProv = ItemActual.provId, };
            var r01 = Sistema.MyData.Reportes_CtaPagar_DocumentosPorPagar(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var r02 = Sistema.MyData.Proveedor_GetById (ItemActual.provId);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            var lst = new List<PorPagar.data>();
            foreach (var rg in r01.ListaEntidad.OrderByDescending(o => o.fechaEmision).ToList())
            {
                var nr = new PorPagar.data(rg.fechaEmision, rg.tipoDoc, rg.numeroDoc,
                    rg.fechaVence, rg.detalleDoc, rg.importeDoc, rg.acumuladoDoc, rg.restaDoc, rg.signoDoc);
                lst.Add(nr);
            }
            _gPorPagar.Inicializa();
            _gPorPagar.setLista(lst);
            _gPorPagar.setProveedor(r02.MiEntidad);
            _gPorPagar.Inicia();
        }

        public void VisualizarDocumentosPendientes()
        {
            if (ItemActual != null)
            {
                CtasPorPagarProveedor(ItemActual);
            }
        }

        public void AgregarDocumento()
        {
            _gAgregarDoc.Inicializa();
            _gAgregarDoc.Inicia();
            if (_gAgregarDoc.AgregarDocIsOk)
            {
                var id = _gAgregarDoc.DocumentoAgregadoGetId;
                var r01 = Sistema.MyData.CtaPagar_GetById(id);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _gLista.AgregarDoc(r01.MiEntidad);
            }
        }

        public void GenerarPago()
        {
            if (ItemActual != null)
            {
                var idProv = ItemActual.provId;
                _gGenerarPago.setProveedor(idProv);
                _gGenerarPago.Inicializa();
                _gGenerarPago.Inicia();
                if (_gGenerarPago.GenerarPagIsOk) 
                {
                    ActualizarData(idProv);
                }
            }
        }
        
        private void ActualizarData(string idProv)
        {
            var r01 = Sistema.MyData.ToolPago_ResumenPendPagar_GetByIdProv(idProv);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var rg = r01.MiEntidad;
            _gLista.ActualizarItem(new Lista.data(rg.provId, rg.provNombre, rg.provCiRif, rg.importe, rg.resta, rg.acumulado, rg.cntDoc));
        }

    }

}