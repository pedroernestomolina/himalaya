using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    
    public interface ICtaPagar
    {

        OOB.Resultado.Lista<OOB.CtaPagar.Lista.Ficha> CtaPagar_GetLista(OOB.CtaPagar.Lista.Filtro filtro);

    }

}