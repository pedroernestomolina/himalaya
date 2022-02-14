using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.CtaPagar.DocumentosPorPagar
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
            string _idProv="";
            DateTime? _desde=null;
            DateTime? _hasta=null;
            if (data.GetFechaDesde_Habilitar) 
            {
                _desde=data.GetDesde;
                filtrarPor += "Desde La Fecha: "+_desde.Value.ToShortDateString();
            }
            if (data.GetFechaHasta_Habilitar) 
            {
                _hasta=data.GetHasta;
                filtrarPor += ", Hasta La Fecha: " + _hasta.Value.ToShortDateString();
            }
            if (data.Proveedor!=null) 
            {
                _idProv=data.Proveedor.id;
                filtrarPor += ", Proveedor: " + data.Proveedor.desc;
            }
            var filtro = new OOB.Reportes.CtasPagar.DocumentosPorPagar.Filtro()
            {
                desde = _desde,
                hasta = _hasta,
                idProv = _idProv,
            };
            var r01 = Sistema.MyData.Reportes_CtaPagar_DocumentosPorPagar(filtro);
            if (r01.Result== OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Imprime(r01.ListaEntidad, filtrarPor);
        }

        private void Imprime(List<OOB.Reportes.CtasPagar.DocumentosPorPagar.Ficha> _lst, string _filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Source\Reportes\CtaPagar\DocPagar.rdlc";
            var ds = new DS_CTAPAGAR();

            foreach (var it in _lst.OrderBy(o => o.provNombre).ThenByDescending(o=>o.fechaEmision).ToList())
            {
                DataRow rt = ds.Tables["DocPagar"].NewRow();
                rt["proveedor"] = it.provCiRif+Environment.NewLine+it.provNombre;
                rt["tipoDoc"] = it.tipoDoc ;
                rt["numeroDoc"] = it.numeroDoc ;
                rt["fechaEmiDoc"] = it.fechaEmision;
                rt["fechaVenceDoc"] = it.fechaEmision;
                rt["detalle"] = it.detalleDoc;
                rt["importeDoc"] = it.importeDoc*it.signoDoc;
                rt["abonadoDoc"] = it.acumuladoDoc * it.signoDoc;
                rt["saldoDoc"] = it.restaDoc * it.signoDoc;
                rt["signoDoc"] = it.signoDoc;
                ds.Tables["DocPagar"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            pmt.Add(new ReportParameter("FILTRO", _filtro));
            Rds.Add(new ReportDataSource("DocPagar", ds.Tables["DocPagar"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}