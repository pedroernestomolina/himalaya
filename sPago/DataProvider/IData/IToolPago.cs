using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    
    public interface IToolPago
    {

        OOB.Resultado.Lista<OOB.ToolPago.ResumenPendPagar.Ficha> ToolPago_ResumenPendPagar_GetLista();
        OOB.Resultado.Entidad<OOB.ToolPago.ResumenPendPagar.Ficha> ToolPago_ResumenPendPagar_GetByIdProv(string idProv);
        OOB.Resultado.Lista<OOB.ToolPago.PendPagar.Ficha> ToolPago_PendPagar_GetByIdProv(string idProv);
        OOB.Resultado.AutoId ToolPago_GenerarPago(OOB.ToolPago.GenerarPago.Ficha ficha);
        OOB.Resultado.Entidad<OOB.ToolPago.ReciboPago.Ficha> ToolPago_ReciboPago_GetByAutoRecibo(string autoRecibo);

    }

}