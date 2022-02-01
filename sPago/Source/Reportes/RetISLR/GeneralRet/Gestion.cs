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
    
    public class Gestion: IReportes
    {

        private Filtrar.IFiltrar _filtrar;


        public Filtrar.IFiltrar Filtrar { get { return _filtrar; } }


        public Gestion() 
        {
            _filtrar = new Source.Reportes.RetISLR.GeneralRet.Filtro();
        }


        public void Generar(Filtrar.dataFiltrar data)
        {
            var _filtros = "";
            DateTime? _desde = null;
            DateTime? _hasta = null;
            string _idProv = "";
            var _estatus = OOB.RetISLR.Lista.Filtro.enumEstatus.SinDefinir;
            if (data.GetFechaDesde_Habilitar)
            {
                _desde = data.GetDesde;
                _filtros+="Desde: "+_desde.Value.ToShortDateString();
            }
            if (data.GetFechaHasta_Habilitar)
            {
                _hasta = data.GetHasta;
                _filtros += ", Hasta: " + _hasta.Value.ToShortDateString();
            }
            if (data.Proveedor != null)
            {
                _idProv = data.Proveedor.id;
                _filtros += ", Proveedor: " + data.Proveedor.desc;
            }
            if (data.Esatus != null)
            {
                _estatus = OOB.RetISLR.Lista.Filtro.enumEstatus.Activo;
                if (data.Esatus.id == "02")
                {
                    _estatus = _estatus = OOB.RetISLR.Lista.Filtro.enumEstatus.Anulado;
                }
                _filtros += ", Estatus: " + data.Esatus.desc;
            }
            var filtroOOB = new OOB.RetISLR.Lista.Filtro()
            {
                desde = _desde,
                hasta = _hasta,
                tipoRetencion = "02",
                idProv = _idProv,
                estatus = _estatus,
            };
            var r01 = Sistema.MyData.RetISLR_GetLista(filtroOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Imprime(r01.ListaEntidad,_filtros);
        }

        private void Imprime(List<OOB.RetISLR.Entidad.Ficha> _lst, string _filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Source\Reportes\RetISLR\Retencion.rdlc";
            var ds = new DS_ISLR();

            foreach (var it in _lst.OrderByDescending(o=>o.documento).ToList())
            {
                DataRow rt = ds.Tables["documento"].NewRow();
                rt["fecha"] = it.deFecha;
                rt["numero"] = it.documento;
                rt["proveedor"] = it.nombreProv+Environment.NewLine+it.ciRifProv;
                rt["total"] = it.isAnulado ? 0m : it.mTotal;
                rt["exento"] = it.isAnulado ? 0m : it.mExento;
                rt["base"] = it.isAnulado ? 0m : it.mBase;
                rt["impuesto"] = it.isAnulado? 0m : it.mIva;
                rt["tasaRet"] = it.tasaRet;
                rt["montoRet"] = it.isAnulado ? 0m : it.montoRet;
                rt["estatus"] = it.isAnulado ? "ANULADO" : "";
                ds.Tables["documento"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            pmt.Add(new ReportParameter("FILTRO", _filtro));
            Rds.Add(new ReportDataSource("documento", ds.Tables["documento"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}