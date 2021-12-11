using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.ISERVICE
{
    
    public interface IPermiso
    {

        DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloPago(string idGrupo);

        //
        DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ElaborarRetencionISLR(string idGrupo);

    }

}