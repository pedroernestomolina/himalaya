using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.VentaAdm.AdmDoc
{
    public class Ficha
    {
        public string idDoc { get; set; }
        public string numeroDoc { get; set; }
        public DateTime fechaEmision { get; set; }
        public DateTime fechaVence { get; set; }
        public string nombreEnt { get; set; }
        public string ciRifEnt { get; set; }
        public decimal importeDoc { get; set; }
        public string estatusAnulado { get; set; }
        public string codTipoDoc { get; set; }
        public int diasCredito { get; set; }
    }
}