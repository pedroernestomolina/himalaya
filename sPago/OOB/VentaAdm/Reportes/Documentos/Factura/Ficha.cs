using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.VentaAdm.Reportes.Documentos.Factura
{
    public class Ficha
    {
        public Doc documento { get; set; }
        public List<Item> items { get; set; }
    }
}