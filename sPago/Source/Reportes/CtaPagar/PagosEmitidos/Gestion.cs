using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.CtaPagar.PagosEmitidos
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
            OOB.Reportes.CtasPagar.PagosEmitidos.Filtro.enumEstatus _estatus=  OOB.Reportes.CtasPagar.baseFiltro.enumEstatus.SinDefinir;


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

            var filtro = new OOB.Reportes.CtasPagar.PagosEmitidos.Filtro()
            {
                desde = _desde,
                hasta = _hasta,
                idProv = _idProv,
                estatus=_estatus,
            };
            var r01 = Sistema.MyData.Reportes_CtaPagar_PagosEmitidos(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Imprime(r01.ListaEntidad, filtrarPor);
        }

        private void Imprime(List<OOB.Reportes.CtasPagar.PagosEmitidos.Ficha> _lst, string _filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Source\Reportes\CtaPagar\PagoProveedor.rdlc";
            var ds = new DS_CTAPAGAR();

            var prv="";
            var rec="";
            foreach (var it in _lst.OrderBy(o=>o.provNombre).ThenByDescending(o => o.fechaRecibo).ThenByDescending(o=>o.numeroRecibo).ToList())
            {
                DataRow rt = ds.Tables["PagoProv"].NewRow();
                if (it.estatusRecibo == "1") 
                {
                    continue;
                }

                rt["importe"] = it.importeRecibo;
                rt["cntDocRel"] = it.cntDocRel;
                if (it.provNombre == prv && it.numeroRecibo == rec)
                {
                    rt["importe"] = 0m;
                    rt["cntDocRel"] = 0;
                }
                prv = it.provNombre;
                rec = it.numeroRecibo;

                rt["proveedor"] = it.provCiRif + Environment.NewLine + it.provNombre;
                rt["recibo"] = it.numeroRecibo;
                rt["fecha"] = it.fechaRecibo;
                rt["medioPago"] = it.codMedioPago + Environment.NewLine + it.descMedioPago;
                rt["importePago"] =it.importePago;
                ds.Tables["PagoProv"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            pmt.Add(new ReportParameter("FILTRO", _filtro));
            Rds.Add(new ReportDataSource("PagoProv", ds.Tables["PagoProv"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}