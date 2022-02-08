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
        OOB.Resultado.Entidad<OOB.CtaPagar.Entidad.Ficha> CtaPagar_GetById(string id);
        OOB.Resultado.AutoId CtaPagar_Agregar(OOB.CtaPagar.Agregar.Ficha ficha);
        OOB.Resultado.Ficha CtaPagar_AnularDoc(OOB.CtaPagar.AnularDoc.Ficha ficha);

    }

}