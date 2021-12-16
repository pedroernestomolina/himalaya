using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Reportes.RetISLR.GeneralRet
{
    
    public class Gestion: RetISLR.Reportes.IGestion
    {

        public void Generar(Filtro.data filtros)
        {
            var filtro = new OOB.RetISLR.Lista.Filtro()
            {
                estatus = filtros.GetEstatus,
                desde = filtros.GetDesde,
                hasta = filtros.GetHasta,
                tipoRetencion = "02",
            };
            var r01 = Sistema.MyData.RetISLR_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Imprime(r01.ListaEntidad);
        }

        private void Imprime(List<OOB.RetISLR.Entidad.Ficha> _lst)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Source\Reportes\RetISLR\Retencion.rdlc";
            var ds = new DS_ISLR();

            foreach (var it in _lst.ToList())
            {
                DataRow rt = ds.Tables["documento"].NewRow();
                rt["fecha"] = it.deFecha;
                rt["numero"] = it.documento;
                rt["proveedor"] = it.nombreProv+Environment.NewLine+it.ciRifProv;
                rt["total"] = it.mTotal;
                rt["exento"] = it.mExento;
                rt["base"] = it.mBase;
                rt["impuesto"] = it.mIva;
                rt["tasaRet"] = it.tasaRet;
                rt["montoRet"] = it.montoRet;
                ds.Tables["documento"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            //pmt.Add(new ReportParameter("Filtros", _filtros));
            Rds.Add(new ReportDataSource("documento", ds.Tables["documento"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}