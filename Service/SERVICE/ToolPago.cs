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
        public DTO.Resutado.AutoId ToolsPago_GenerarPago(DTO.ToolPago.GenerarPago.Ficha ficha)
        {
            return ServiceProv.ToolPago_GenerarPago(ficha);
        }
        public DTO.Resutado.Entidad<DTO.ToolPago.ReciboPago.Ficha> ToolPago_ReciboPago_GetByAutoRecibo(string autoRecibo)
        {
            return ServiceProv.ToolPago_ReciboPago_GetByAutoRecibo(autoRecibo);
        }

    }

}