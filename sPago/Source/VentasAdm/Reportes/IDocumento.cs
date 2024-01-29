using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.VentasAdm.Reportes
{
    public interface IDocumento: IReporte
    {
        void setIdDocCargar(object idDoc);
    }
}
