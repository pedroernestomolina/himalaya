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

            //foreach (var it in _lst.ToList())
            //{
            //    DataRow rt = ds.Tables["documento"].NewRow();
            //    rt["fecha"] = it.deFecha;
            //    rt["numero"] = it.documento;
            //    rt["proveedor"] = it.nombreProv + Environment.NewLine + it.ciRifProv;
            //    rt["total"] = it.mTotal;
            //    rt["exento"] = it.mExento;
            //    rt["base"] = it.mBase;
            //    rt["impuesto"] = it.mIva;
            //    rt["tasaRet"] = it.tasaRet;
            //    rt["montoRet"] = it.montoRet;
            //    ds.Tables["documento"].Rows.Add(rt);
            //}

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            ////pmt.Add(new ReportParameter("Filtros", _filtros));
            Rds.Add(new ReportDataSource("Planilla", ds.Tables["Planilla"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}