using Service.ISERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.SERVICE
{

    public partial class DataService: IDataService
    {

        public DTO.Resutado.Entidad<int> RetISLR_ContadorUltimaRetencion()
        {
            return ServiceProv.RetISLR_ContadorUltimaRetencion();
        }

        public DTO.Resutado.Lista<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentosPendPorAplicar_GetLista(DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro filtro)
        {
            return ServiceProv.RetISLR_DocumentosPendPorAplicar_GetLista(filtro);
        }
        public DTO.Resutado.Entidad<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentoPendPorAplicar_GetByIdDoc(string idDoc)
        {
            return ServiceProv.RetISLR_DocumentoPendPorAplicar_GetByIdDoc(idDoc);
        }
        public DTO.Resutado.Entidad<string> RetISLR_DocumentoPendPorAplicar_CtaxPagar(DTO.RetISLR.DocumentoPendPorAplicar.CxPagar.Filtro filtro)
        {
            return ServiceProv.RetISLR_DocumentoPendPorAplicar_CtaxPagar(filtro);
        }

        public DTO.Resutado.AutoId RetISLR_GenerarRetencion(DTO.RetISLR.GenerarRetencion.Ficha ficha)
        {
            return ServiceProv.RetISLR_GenerarRetencion(ficha);
        }

    }

}