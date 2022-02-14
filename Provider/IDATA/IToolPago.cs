using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{

    public interface IToolPago
    {

        DTO.Resutado.Lista<DTO.ToolPago.ResumenPendPagar.Ficha> ToolPago_ResumenPendPagar_GetLista();
        DTO.Resutado.Entidad<DTO.ToolPago.ResumenPendPagar.Ficha> ToolPago_ResumenPendPagar_GetByIdProveedor(string idProv);
        DTO.Resutado.Lista<DTO.ToolPago.PendPagar.Ficha> ToolPago_PendPagar_GetByIdProv(string idProv);
        DTO.Resutado.AutoId ToolPago_GenerarPago(DTO.ToolPago.GenerarPago.Ficha ficha);
        DTO.Resutado.Entidad<DTO.ToolPago.ReciboPago.Ficha> ToolPago_ReciboPago_GetByAutoRecibo(string autoRecibo);

    }

}