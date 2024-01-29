using Microsoft.Reporting.WinForms;
using sPago.Source.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.VentasAdm.Reportes.Formatos.HojaDetalleFact
{
    public class Imp: IDocumento
    {
        private string _idDoc;
        //
        public Imp()
        {
        }
        public void Generar()
        {
            cargarDoc();
        }
        public void setIdDocCargar(object idDoc)
        {
            _idDoc = (string)idDoc;
        }
        //
        private void cargarDoc()
        {
            try
            {
                var r01= Sistema.MyData.VentasAdm_Reportes_Documentos_Factura_GetById(_idDoc);
                imprimirDoc(r01.MiEntidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        private void imprimirDoc(OOB.VentaAdm.Reportes.Documentos.Factura.Ficha ficha)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Source\VentasAdm\Reportes\HojaDetalleFact.rdlc";
            var ds = new DS_VENTA();
            //
            DataRow rt1 = ds.Tables["docEnc"].NewRow();
            rt1["numeroDoc"] = ficha.documento.numeroDoc;
            rt1["entidad"] = ficha.documento.ciRifCliente+Environment.NewLine+
                ficha.documento.nombreCliente+Environment.NewLine+
                ficha.documento.dirFiscalCliente+ Environment.NewLine+
                ficha.documento.telefCliente;
            rt1["codCliente"] = "DATOS DEL CLIENTE: ("+ficha.documento.codCliente+")";
            rt1["dirDespCliente"] = "Direccion Despacho: "+ficha.documento.dirDespCliente;
            rt1["fechaEmision"] = ficha.documento.fechaEmDoc;
            rt1["ordenCompra"] = ficha.documento.numeroOrdenCompra;
            rt1["condicionPago"] = ficha.documento.condicionPagoDoc+" "+ficha.documento.diasCredito.ToString()+"Dias"+ Environment.NewLine+
                ficha.documento.fechaVencDoc.ToShortDateString();
            rt1["pedido"] = ficha.documento.numeroPedido+Environment.NewLine+
                ficha.documento.fechaPedido.ToShortDateString();
            rt1["vendedor"] = ficha.documento.codVendedor + Environment.NewLine +
                ficha.documento.nombreVendedor;
            rt1["sucursal"] = ficha.documento.codSucursal;
            rt1["atendidoPor"] = ficha.documento.codUsuario + Environment.NewLine +
                ficha.documento.nombreUsuario;
            ds.Tables["docEnc"].Rows.Add(rt1);
            //
            var _itNum = 0;
            var gr = ficha.items.OrderBy(o=> o.descPrd).ToList();
            foreach (var it in gr)
            {
                _itNum += 1;
                DataRow rt2 = ds.Tables["docCuerpo"].NewRow();
                rt2["itemNumero"] = _itNum;
                rt2["descItem"] = it.descPrd;
                rt2["cantidad"] = it.cantidad;
                rt2["precio"] = it.precioNeto;
                rt2["importe"] = it.importeNeto;
                rt2["codigoPrd"] = it.codigoPrd;
                rt2["tasaIvaPrd"] = it.tasaIva;
                ds.Tables["docCuerpo"].Rows.Add(rt2);
            }
            //
            DataRow rt3 = ds.Tables["docPie"].NewRow();
            rt3["subtotal"] = ficha.documento.subTotal;
            rt3["dsctDesc"] = "Descuento " + ficha.documento.dsctoPorct.ToString("n2") + "%:";
            rt3["dsctoMonto"] = ficha.documento.dsctoMonto;
            rt3["cargoDesc"] = "Cargo " + ficha.documento.cargoPorct.ToString("n2") + "%:"; 
            rt3["cargoMonto"] = ficha.documento.cargoMonto;
            rt3["impuesto"] = ficha.documento.impuesto;
            rt3["total"] = ficha.documento.total;
            rt3["notas"] = ficha.documento.notas;
            rt3["numeroItemsDesc"] = "Número Lineas: ";
            rt3["cntItemsDesc"] = "Total Items: ";
            rt3["numeroItems"] = gr.Count();
            rt3["cntItems"] = gr.Sum(s=>s.cantidad);
            ds.Tables["docPie"].Rows.Add(rt3);
            //
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.DatosEmpresa.ciRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.DatosEmpresa.nombreRazonSocial));
            //pmt.Add(new ReportParameter("FILTRO", _filtro));
            Rds.Add(new ReportDataSource("docEnc", ds.Tables["docEnc"]));
            Rds.Add(new ReportDataSource("docCuerpo", ds.Tables["docCuerpo"]));
            Rds.Add(new ReportDataSource("docPie", ds.Tables["docPie"]));
            //
            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}