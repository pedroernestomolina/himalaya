using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{
    
    public interface ICtaPagar
    {

        DTO.Resutado.Lista<DTO.CtaPagar.Lista.Ficha> CtaPagar_GetLista(DTO.CtaPagar.Lista.Filtro filtro);

    }

}