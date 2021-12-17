using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.RetISLR.AdmLista
{
    
    public class Gestion
    {

        private List<data> _lst;
        private string _filtros;


        public Gestion() 
        {
            _lst = new List<data>();
            _filtros = "";
        }


        public void setFiltro(string p)
        {
            _filtros = p;
        }

        public void setLista(List<Source.RetISLR.Administrador.Items.data> lst)
        {
            _lst.Clear();
            foreach(var r in lst)
            {
                _lst.Add(new data(r));
            }
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Source\Reportes\RetISLR\Retencion.rdlc";
            var ds = new DS_ISLR();

            foreach (var it in _lst.ToList())
            {
                DataRow rt = ds.Tables["documento"].NewRow();
                rt["fecha"] = it.Fecha;
                rt["numero"] = it.Documento;
                rt["proveedor"] = it.Proveedor;
                rt["total"] = it.IsAnulado ? 0m : it.Total;
                rt["exento"] = it.IsAnulado ? 0m : it.Exento;
                rt["base"] = it.IsAnulado ? 0m : it.Base;
                rt["impuesto"] = it.IsAnulado ? 0m : it.Impuesto;
                rt["tasaRet"] = it.TasaRetencion;
                rt["montoRet"] = it.IsAnulado ? 0m : it.MontoRetencion;
                rt["estatus"] = it.IsAnulado ? "ANULADO": "";
                ds.Tables["documento"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            pmt.Add(new ReportParameter("FILTRO", _filtros));
            Rds.Add(new ReportDataSource("documento", ds.Tables["documento"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}