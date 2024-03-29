﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.ISERVICE
{
    
    public interface IToolPago
    {

        DTO.Resutado.Lista<DTO.ToolPago.ResumenPendPagar.Ficha> ToolsPago_ResumenPendPagar_GetLista();
        DTO.Resutado.Entidad<DTO.ToolPago.ResumenPendPagar.Ficha> ToolsPago_ResumenPendPagar_GetByIdProveedor(string idProv);
        DTO.Resutado.Lista<DTO.ToolPago.PendPagar.Ficha> ToolsPago_PendPagar_GetByIdProv(string idProv);
        DTO.Resutado.AutoId ToolsPago_GenerarPago(DTO.ToolPago.GenerarPago.Ficha ficha);
        DTO.Resutado.Entidad<DTO.ToolPago.ReciboPago.Ficha> ToolPago_ReciboPago_GetByAutoRecibo(string autoRecibo);

    }

}