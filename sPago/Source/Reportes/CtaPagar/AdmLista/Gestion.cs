using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.CtaPagar.AdmLista
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

        public void setLista(List<AdministradorDoc.data> lst)
        {
            _lst.Clear();
            foreach(var r in lst)
            {
                _lst.Add(new data(r));
            }
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Source\Reportes\CtaPagar\ListaDoc.rdlc";
            var ds = new DS_CTAPAGAR();

            foreach (var it in _lst.ToList())
            {
                DataRow rt = ds.Tables["Documento"].NewRow();
                rt["fechaEmision"] = it.Ficha.fechaEmiDoc;
                ds.Tables["Documento"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            /*
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            pmt.Add(new ReportParameter("FILTRO", _filtros));
             * */
            Rds.Add(new ReportDataSource("Documento", ds.Tables["Documento"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}