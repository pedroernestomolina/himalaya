using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.VentaAdm.AdmDoc
{
    public class Filtro: __.baseFiltro
    {
        public __.enumerados.DescTipoDocumento PorTipoDocumento { get; set; }
        public Filtro()
            : base()
        {
        }
    }
}