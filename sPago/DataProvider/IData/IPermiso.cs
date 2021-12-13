using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    
    public interface IPermiso
    {

        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloPago(string idGrupo);
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_ElaborarRetencionISLR(string idGrupo);

    }

}
