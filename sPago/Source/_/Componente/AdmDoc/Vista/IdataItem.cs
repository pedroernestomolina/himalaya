using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.__.Componente.AdmDoc.Vista
{
    public interface IdataItem
    {
        DateTime FechaEmisionDoc { get; set; }
        string TipoDoc { get; set; }
        string NumeroDoc { get; set; }
        DateTime FechaVenceDoc { get; set; }
        int DiasCredito { get; set; }
        string NombreEnt { get; set; }
        string CiRifEnt { get; set; }
        decimal ImporteDoc { get; set; }
        string EstatusAnuladoDoc { get; set; }
    }
}