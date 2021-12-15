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

    }

}