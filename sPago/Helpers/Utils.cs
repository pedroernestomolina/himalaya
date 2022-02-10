using Microsoft.Reporting.WinForms;
using sPago.Source.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            rt["ciRifProv"] = ficha.ciRifProv;
            rt["nombreProv"] = ficha.nombreProv;
            rt["dirFiscalProv"] = "";
            rt["tasaRetencion"] = ficha.tasaRet;
            rt["fechaRet"] = ficha.deFecha;
            rt["periodoRet"] = ficha.anoRelacion+"-"+ficha.mesRelacion;
            ds.Tables["Planilla"].Rows.Add(rt);

            DataRow rt2 = ds.Tables["Empresa"].NewRow();
            rt2["nombre"] = Sistema.DatosEmpresa.nombreRazonSocial;
            rt2["ciRif"] = Sistema.DatosEmpresa.ciRif;
            rt2["dirFiscal"] = Sistema.DatosEmpresa.dirFiscal;
            ds.Tables["Empresa"].Rows.Add(rt2);

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
                rtDet["base"] = it.montoBase;
                rtDet["impuesto"] = it.montoIva;
                rtDet["retencion"] = it.montoRetencion;
                ds.Tables["PlanillaDet"].Rows.Add(rtDet);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            ////pmt.Add(new ReportParameter("Filtros", _filtros));
            Rds.Add(new ReportDataSource("Planilla", ds.Tables["Planilla"]));
            Rds.Add(new ReportDataSource("PlanillaDet", ds.Tables["PlanillaDet"]));
            Rds.Add(new ReportDataSource("Empresa", ds.Tables["Empresa"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

        public static void VisualizarReciboPago(OOB.ToolPago.ReciboPago.Ficha ficha)
        {
            MessageBox.Show("VISUALIZANDO PAGO");
        }

    }

}