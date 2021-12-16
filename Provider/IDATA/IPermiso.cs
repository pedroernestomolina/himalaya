﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{
    
    public interface IPermiso
    {

        DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloPago(string idGrupo);

        //
        DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloRetencionISLR(string idGrupo);
        DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ElaborarRetencionISLR(string idGrupo);
        DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_AdministradorRetencionISLR(string idGrupo);
        DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_AnularRetencionISLR(string idGrupo);
        DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ReportesRetencionISLR(string idGrupo);

    }

}