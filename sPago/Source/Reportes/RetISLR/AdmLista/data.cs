using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.RetISLR.AdmLista
{
    
    public class data
    {

        public DateTime Fecha{ get; set; }
        public string Documento { get; set; }
        public string Proveedor { get; set; }
        public decimal Total { get; set; }
        public decimal Exento { get; set; }
        public decimal Base { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TasaRetencion { get; set; }
        public decimal MontoRetencion { get; set; }
        public bool IsAnulado { get; set; }


        public data(Source.RetISLR.Administrador.Items.data item)
        {
            Fecha = item.Fecha;
            Documento = item.Documento;
            Proveedor = item.CiRifProv + Environment.NewLine + item.Proveedor;
            Total = item.MontoTotal;
            Exento = item.MontoExento;
            Base = item.MontoBase;
            Impuesto = item.MontoIva;
            TasaRetencion = item.TasaRetencion;
            MontoRetencion = item.MontoRetencion;
            IsAnulado= item.IsAnulado;
        }

    }

}
