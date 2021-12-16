using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{

    public interface IRetISLR
    {

        DTO.Resutado.Entidad<int> RetISLR_ContadorUltimaRetencion();

        // DOCUMENTOS PENDIENTENTE POR APLICAR RETENCION
        DTO.Resutado.Lista<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentosPendPorAplicar_GetLista(DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro filtro);
        DTO.Resutado.Entidad<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentoPendPorAplicar_GetByIdDoc(string idDoc);
        DTO.Resutado.Entidad<string> RetISLR_DocumentoPendPorAplicar_CtaxPagar(DTO.RetISLR.DocumentoPendPorAplicar.CxPagar.Filtro filtro);

        //
        DTO.Resutado.AutoId RetISLR_GenerarRetencion(DTO.RetISLR.GenerarRetencion.Ficha ficha);
        DTO.Resutado.Ficha RetISLR_AnularRetencion(DTO.RetISLR.AnularRetencion.Ficha ficha);
        DTO.Resutado.Entidad<DTO.RetISLR.AnularRetencion.Ficha > RetISLR_AnularRetencion_GetData(string idRetencion);
        //

        DTO.Resutado.Lista<DTO.RetISLR.Lista.Ficha> RetISLR_GetLista(DTO.RetISLR.Lista.Filtro filtro);
        DTO.Resutado.Entidad<DTO.RetISLR.Entidad.Ficha> RetISLR_GetById(string id);

    }

}