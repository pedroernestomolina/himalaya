using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.ISERVICE
{
    
    public interface IRetISLR
    {

        // DOCUMENTOS PENDIENTENTE POR APLICAR RETENCION
        DTO.Resutado.Lista<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentosPendPorAplicar_GetLista(DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro filtro);
        DTO.Resutado.Entidad<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentoPendPorAplicar_GetByIdDoc(string idDoc);
        DTO.Resutado.Entidad<string> RetISLR_DocumentoPendPorAplicar_CtaxPagar(DTO.RetISLR.DocumentoPendPorAplicar.CxPagar.Filtro filtro);

        //
        DTO.Resutado.AutoId RetISLR_GenerarRetencion(DTO.RetISLR.GenerarRetencion.Ficha ficha);

    }

}