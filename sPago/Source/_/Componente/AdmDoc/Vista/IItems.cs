using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.__.Componente.AdmDoc.Vista
{
    public interface IItems: ILista
    {
        void setDataCargar(IEnumerable<IdataItem> list);
    }
}
