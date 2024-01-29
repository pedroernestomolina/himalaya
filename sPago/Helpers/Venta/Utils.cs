using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Helpers.Venta
{
    public static class Utils
    {
        internal static void Visualiza(OOB.VentaAdm.__.enumerados.DescTipoDocumento tipoDoc, string idDoc)
        {
            switch (tipoDoc)
            { 
                case OOB.VentaAdm.__.enumerados.DescTipoDocumento.Factura:
                    VisualizaFactura(idDoc);
                    break;
            }
        }
        static sPago.Source.VentasAdm.Reportes.IDocumento _doc;
        private static void VisualizaFactura(string idDoc) 
        {
            var _idDoc = idDoc;
            if (_doc == null)
            {
                _doc = new sPago.Source.VentasAdm.Reportes.Formatos.Factura.Imp();
            }
            _doc.setIdDocCargar(_idDoc);
            _doc.Generar();
            //
            _doc = new sPago.Source.VentasAdm.Reportes.Formatos.HojaDetalleFact.Imp();
            _doc.setIdDocCargar(_idDoc);
            _doc.Generar();
        }
    }
}
