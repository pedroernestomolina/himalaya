using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.VentaAdm.__
{
    public static class enumerados
    {
        public class tipoDocumento
        {
            public enumerados.DescTipoDocumento tipo { get; set; }
            public string descripcion { get; set; }
        }
        public enum DescTipoDocumento { SinDefinir = -1, Factura = 1, NotaDebito, NotaCredito, NotaEntrega, Presupuesto };
        //
        public static tipoDocumento TipoDoc(string codDoc)
        {
            var rt = new tipoDocumento();
            switch (codDoc)
            {
                case "01":
                    rt.tipo = enumerados.DescTipoDocumento.Factura;
                    rt.descripcion = "FACTURA";
                    break;
                case "02":
                    rt.tipo = enumerados.DescTipoDocumento.NotaDebito;
                    rt.descripcion = "NOTA DEBITO";
                    break;
                case "03":
                    rt.tipo = enumerados.DescTipoDocumento.NotaCredito;
                    rt.descripcion = "NOTA CREDITO";
                    break;
                case "04":
                    rt.tipo = enumerados.DescTipoDocumento.NotaEntrega;
                    rt.descripcion = "NOTA ENTREGA";
                    break;
                case "05":
                    rt.tipo = enumerados.DescTipoDocumento.Presupuesto;
                    rt.descripcion = "PRESUPUESTO";
                    break;
                default:
                    rt.tipo = enumerados.DescTipoDocumento.SinDefinir;
                    rt.descripcion = "";
                    break;
            }
            return rt;
        }
    }
}
