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

        //
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

        //
        public DTO.Resutado.Lista<DTO.RetISLR.Lista.Ficha> RetISLR_GetLista(DTO.RetISLR.Lista.Filtro filtro)
        {
            return ServiceProv.RetISLR_GetLista(filtro);
        }
        public DTO.Resutado.Entidad<DTO.RetISLR.Entidad.Ficha> RetISLR_GetById(string id)
        {
            return ServiceProv.RetISLR_GetById(id);
        }

        //
        public DTO.Resutado.AutoId RetISLR_GenerarRetencion(DTO.RetISLR.GenerarRetencion.Ficha ficha)
        {
            return ServiceProv.RetISLR_GenerarRetencion(ficha);
        }
        public DTO.Resutado.Ficha RetISLR_AnularRetencion(DTO.RetISLR.AnularRetencion.Ficha ficha)
        {
            return ServiceProv.RetISLR_AnularRetencion(ficha);
        }
        public DTO.Resutado.Entidad<DTO.RetISLR.AnularRetencion.Ficha> RetISLR_AnularRetencion_GetData(string idRetencion)
        {
            return ServiceProv.RetISLR_AnularRetencion_GetData(idRetencion);
        }

    }

}