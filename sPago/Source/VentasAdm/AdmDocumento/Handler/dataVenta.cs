using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.VentasAdm.AdmDocumento.Handler
{
    public class dataVenta: __.Componente.AdmDoc.Vista.IdataItem
    {
        public OOB.VentaAdm.AdmDoc.Ficha Ficha { get; set; }
        public DateTime FechaEmisionDoc { get; set; }
        public string TipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        public DateTime FechaVenceDoc { get; set; }
        public int DiasCredito { get; set; }
        public string NombreEnt { get; set; }
        public string CiRifEnt{ get; set; }
        public decimal ImporteDoc { get; set; }
        public string EstatusAnuladoDoc { get; set; }
    }
}
