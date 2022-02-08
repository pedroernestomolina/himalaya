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

        public DTO.Resutado.Lista<DTO.ToolPago.ResumenPendPagar.Ficha> ToolsPago_ResumenPendPagar_GetLista()
        {
            return ServiceProv.ToolPago_ResumenPendPagar_GetLista();
        }
        public DTO.Resutado.Entidad<DTO.ToolPago.ResumenPendPagar.Ficha> ToolsPago_ResumenPendPagar_GetByIdProveedor(string idProv)
        {
            return ServiceProv.ToolPago_ResumenPendPagar_GetByIdProveedor(idProv);
        }
        public DTO.Resutado.Lista<DTO.ToolPago.PendPagar.Ficha> ToolsPago_PendPagar_GetByIdProv(string idProv)
        {
            return ServiceProv.ToolPago_PendPagar_GetByIdProv(idProv);
        }

    }

}