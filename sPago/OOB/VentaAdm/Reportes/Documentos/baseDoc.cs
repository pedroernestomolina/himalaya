using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.VentaAdm.Reportes.Documentos
{
    public abstract class baseDoc
    {
        public string numeroDoc { get; set; }
        public DateTime fechaEmDoc { get; set; }
        public DateTime fechaVencDoc { get; set; }
        public string condicionPagoDoc { get; set; }
        public int diasCredito { get; set; }
        public string numeroOrdenCompra { get; set; }
        public string numeroPedido { get; set; }
        public DateTime fechaPedido { get; set; }
        public string codVendedor { get; set; }
        public string nombreVendedor { get; set; }
        public string codUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string codSucursal { get; set; }
        public string nombreCliente { get; set; }
        public string ciRifCliente { get; set; }
        public string dirFiscalCliente { get; set; }
        public string codCliente { get; set; }
        public string telefCliente { get; set; }
        public string dirDespCliente { get; set; }
        //
        public decimal subTotal { get; set; }
        public decimal exento { get; set; }
        public decimal base1 { get; set; }
        public decimal base2 { get; set; }
        public decimal base3 { get; set; }
        public decimal iva1 { get; set; }
        public decimal iva2 { get; set; }
        public decimal iva3 { get; set; }
        public decimal tasa1 { get; set; }
        public decimal tasa2 { get; set; }
        public decimal tasa3 { get; set; }
        public decimal impuesto { get; set; }
        public decimal dsctoMonto { get; set; }
        public decimal cargoMonto { get; set; }
        public decimal dsctoPorct { get; set; }
        public decimal cargoPorct { get; set; }
        public decimal total { get; set; }
        public string notas { get; set; }
        public baseDoc()
        {
        }
    }
}