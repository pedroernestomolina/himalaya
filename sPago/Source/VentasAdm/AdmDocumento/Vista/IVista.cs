using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.VentasAdm.AdmDocumento.Vista
{
    public interface IVista: __.Componente.AdmDoc.Vista.IbaseVista
    {
        AdmFiltro.Vista.IFiltroAdm Filtro { get; }
    }
}