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

        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloPago(string idGrupo)
        {
            return ServiceProv.Permiso_Solicitud_ModuloPago(idGrupo);
        }

        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ElaborarRetencionISLR(string idGrupo)
        {
            return ServiceProv.Permiso_Solicitud_ElaborarRetencionISLR(idGrupo);
        }

    }

}