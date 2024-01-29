using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.VentaAdm.Reportes.Documentos
{
    public abstract class baseItem
    {
        public string idPrd { get; set; }
        public string codigoPrd { get; set; }
        public string descPrd { get; set; }
        public string idDepart { get; set; }
        public string nombreDepart { get; set; }
        public string idGrupo { get; set; }
        public string nombreGrupo { get; set; }
        public string idSubGrupo { get; set; }
        public string nombreSubGrupo { get; set; }
        public decimal cantidad { get; set; }
        public string descEmp { get; set; }
        public int contEmp { get; set; }
        public decimal precioNeto { get; set; }
        public decimal importeNeto { get; set; }
        public decimal tasaIva { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }
        public baseItem()
        {
        }
    }
}
