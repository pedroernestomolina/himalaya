using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.CtaPagar.RelacionPagoProveedor
{
    
    public class Gestion: IReportes
    {


        private Filtrar.IFiltrar _gFiltrar;



        public Filtrar.IFiltrar Filtrar { get { return _gFiltrar; } }


        public Gestion()
        {
            _gFiltrar = new Filtro();
        }


        public void Generar(Filtrar.dataFiltrar data)
        {
            var filtrarPor = "Filtrado Por: ";
            string _idProv = "";
            DateTime? _desde = null;
            DateTime? _hasta = null;
            OOB.Reportes.CtasPagar.PagosEmitidos.Filtro.enumEstatus _estatus = OOB.Reportes.CtasPagar.baseFiltro.enumEstatus.SinDefinir;

            if (data.GetFechaDesde_Habilitar)
            {
                _desde = data.GetDesde;
                filtrarPor += "Desde La Fecha: " + _desde.Value.ToShortDateString();
            }
            if (data.GetFechaHasta_Habilitar)
            {
                _hasta = data.GetHasta;
                filtrarPor += ", Hasta La Fecha: " + _hasta.Value.ToShortDateString();
            }
            if (data.Proveedor != null)
            {
                _idProv = data.Proveedor.id;
                filtrarPor += ", Proveedor: " + data.Proveedor.desc;
            }
            if (data.Esatus != null)
            {
                _estatus = OOB.Reportes.CtasPagar.baseFiltro.enumEstatus.Activo;
                if (data.Esatus.id == "02")
                {
                    _estatus = OOB.Reportes.CtasPagar.baseFiltro.enumEstatus.Anulado;
                }
                filtrarPor += ", Estatus : " + data.Esatus.desc;
            }
            var filtro = new OOB.Reportes.CtasPagar.RelacionPagoDiario.Filtro()
            {
                desde = _desde,
                hasta = _hasta,
                idProv = _idProv,
                estatus = _estatus,
            };
            var r01 = Sistema.MyData.Reportes_CtaPagar_RelacionPagoDiario(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Imprime(r01.ListaEntidad, filtrarPor);
        }

        private void Imprime(List<OOB.Reportes.CtasPagar.RelacionPagoDiario.Ficha> _lst, string _filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Source\Reportes\CtaPagar\RelPago.rdlc";
            var ds = new DS_CTAPAGAR();

            foreach (var it in _lst.OrderByDescending(o => o.fechaRecibo).ThenByDescending(o=>o.numeroRecibo).ToList())
            {
                var importe = it.importeRecibo;
                if (it.estatusRecibo == "1")
                {
                    importe = 0m;
                }
                DataRow rt = ds.Tables["RelPago"].NewRow();
                rt["fechaRec"] = it.fechaRecibo ;
                rt["proveedor"] = it.provCiRif + Environment.NewLine + it.provNombre;
                rt["numeroRec"] = it.numeroRecibo;
                rt["importeRec"] = importe;
                rt["detalleREc"] = it.detalleRecibo;
                rt["estatusRec"] = it.estatusRecibo == "1" ? "ANULADO" : "";
                ds.Tables["RelPago"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            pmt.Add(new ReportParameter("FILTRO", _filtro));
            Rds.Add(new ReportDataSource("RelPago", ds.Tables["RelPago"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}