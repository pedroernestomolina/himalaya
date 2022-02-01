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


        public data(AdministradorDoc.data item)
        {
            Fecha = item.fechaEmiDoc;
            Documento = item.numDoc;
            Proveedor = item.provCiRif + Environment.NewLine + item.provNombre;
            Total = item.MontoTotalRet;
            Exento = item.MontoExentoRet;
            Base = item.MontoBaseRet;
            Impuesto = item.MontoIvaRet;
            TasaRetencion = item.TasaRetencion;
            MontoRetencion = item.MontoRetencion;
            IsAnulado = item.isAnulado;
        }

    }

}
