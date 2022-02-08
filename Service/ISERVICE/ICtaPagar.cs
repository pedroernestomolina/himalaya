using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.ISERVICE
{
    
    public interface ICtaPagar
    {

        DTO.Resutado.Lista<DTO.CtaPagar.Lista.Ficha> CtaPagar_GetLista(DTO.CtaPagar.Lista.Filtro filtro);
        DTO.Resutado.Entidad<DTO.CtaPagar.Entidad.Ficha> CtaPagar_GetById(string idDoc);
        DTO.Resutado.AutoId CtaPagar_Agregar(DTO.CtaPagar.Agregar.Ficha ficha);
        DTO.Resutado.Ficha CtaPagar_AnularDoc(DTO.CtaPagar.AnularDoc.Ficha ficha);

    }

}