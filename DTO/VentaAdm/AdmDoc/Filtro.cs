using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.VentaAdm.AdmDoc
{
    public class Filtro: __.baseFiltro
    {
        public __.enumerados.TipoDocumento PorTipoDocumento { get; set; }
        public Filtro()
            : base()
        {
        }
    }
}