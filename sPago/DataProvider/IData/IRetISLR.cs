using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    
    public interface IRetISLR
    {

        OOB.Resultado.Entidad<int> RetISLR_ContadorUltimaRetencion();

        //

        OOB.Resultado.Lista<OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentosPendPorAplicar_GetLista(OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro filtro);
        OOB.Resultado.Entidad<OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentoPendPorAplicar_GetByIdDoc(string idDoc);

        //

        OOB.Resultado.AutoId RetISLR_GenerarRetencion(OOB.RetISLR.GenerarRetencion.Ficha ficha);
        OOB.Resultado.Ficha RetISLR_AnularRetencion(OOB.RetISLR.AnularRetencion.Ficha ficha);
        OOB.Resultado.Entidad<OOB.RetISLR.AnularRetencion.Ficha> RetISLR_AnularRetencion_GetData(string idRetencion);

        //
        OOB.Resultado.Lista<OOB.RetISLR.Entidad.Ficha> RetISLR_GetLista(OOB.RetISLR.Lista.Filtro filtro);
        OOB.Resultado.Entidad<OOB.RetISLR.Entidad.Ficha> RetISLR_GetById(string id);

    }

}