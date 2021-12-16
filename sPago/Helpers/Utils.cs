using Microsoft.Reporting.WinForms;
using sPago.Source.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Helpers
{
    
    public class Utils
    {

        public static void VisualizarRetISLR(OOB.RetISLR.Entidad.Ficha ficha)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Source\Reportes\RetISLR\Planilla.rdlc";
            var ds = new  DS_ISLR();

            DataRow rt = ds.Tables["Planilla"].NewRow();
            rt["documento"] = ficha.documento;
            ds.Tables["Planilla"].Rows.Add(rt);

            var op = 0;
            foreach (var it in ficha.Detalles)
            {
                var fac = "";
                var ncr= "";
                var ndb= "";
                switch (it.tipoDoc)
                {
                    case "01":
                        fac = it.numDoc;
                        break;
                    case "02":
                        ndb = it.numDoc;
                        break;
                    case "03":
                        ncr = it.numDoc;
                        break;
                }

                op += 1;
                DataRow rtDet = ds.Tables["PlanillaDet"].NewRow();
                rtDet["operacion"] = op;
                rtDet["docFecha"] = it.fechaDoc;
                rtDet["docNumero"] = fac ;
                rtDet["docControl"] = it.numControlDoc;
                rtDet["numNCr"] = ncr;
                rtDet["numNDb"] = ndb;
                rtDet["tipoTr"] = "01-reg";
                rtDet["aplica"] = it.numDocAplica;
                rtDet["total"] = it.total;
                rtDet["exento"] = it.montoExento;
                ds.Tables["PlanillaDet"].Rows.Add(rtDet);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            ////pmt.Add(new ReportParameter("Filtros", _filtros));
            Rds.Add(new ReportDataSource("Planilla", ds.Tables["Planilla"]));
            Rds.Add(new ReportDataSource("PlanillaDet", ds.Tables["PlanillaDet"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}