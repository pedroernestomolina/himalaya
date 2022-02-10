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
        DTO.Resutado.Entidad <DTO.CtaPagar.Entidad.Ficha> CtaPagar_GetById(string idDoc);
        DTO.Resutado.AutoId CtaPagar_Agregar(DTO.CtaPagar.Agregar.Ficha ficha);
        DTO.Resutado.Ficha CtaPagar_AnularDoc(DTO.CtaPagar.AnularDoc.Ficha ficha);
        DTO.Resutado.Lista<DTO.CtaPagar.AnularPago.CtaPagarActualizar> CtaPagar_AnularPago_DocumentosInvolucrados(string  autoCxP);
        DTO.Resutado.Ficha CtaPagar_AnularPago(DTO.CtaPagar.AnularPago.Ficha ficha);

        //

        DTO.Resutado.Ficha CtaPagar_Agregar_Verficar(DTO.CtaPagar.Agregar.Ficha ficha);
        DTO.Resutado.Ficha CtaPagar_AnularDoc_Verficar(string autoDoc);

    }

}