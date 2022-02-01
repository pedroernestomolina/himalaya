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
        //
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ElaborarRetencionISLR(string idGrupo)
        {
            return ServiceProv.Permiso_Solicitud_ElaborarRetencionISLR(idGrupo);
        }
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloRetencionISLR(string idGrupo)
        {
            return ServiceProv.Permiso_Solicitud_ModuloRetencionISLR(idGrupo);
        }
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_AdministradorRetencionISLR(string idGrupo)
        {
            return ServiceProv.Permiso_Solicitud_AdministradorRetencionISLR(idGrupo);
        }
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_AnularRetencionISLR(string idGrupo)
        {
            return ServiceProv.Permiso_Solicitud_AnularRetencionISLR(idGrupo);
        }
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_Solicitud_ReporteRetencionISLR(string idGrupo)
        {
            return ServiceProv.Permiso_Solicitud_ReportesRetencionISLR(idGrupo);
        }
        //
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_CtasPagar_ToolPago(string idGrupo)
        {
            return ServiceProv.Permiso_CtasPagar_ToolPago(idGrupo);
        }
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_CtasPagar_Adminstrador(string idGrupo)
        {
            return ServiceProv.Permiso_CtasPagar_Adminstrador(idGrupo);
        }
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_CtasPagar_Adminstrador_AnularPago(string idGrupo)
        {
            return ServiceProv.Permiso_CtasPagar_Adminstrador_AnularPago(idGrupo);
        }
        //
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_CtaPagar_Reporte_DocumentosPorPagar(string idGrupo)
        {
            return ServiceProv.Permiso_CtaPagar_Reporte_DocumentosPorPagar(idGrupo);
        }
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_CtaPagar_Reporte_PagosEmitidos(string idGrupo)
        {
            return ServiceProv.Permiso_CtaPagar_Reporte_PagosEmitidos(idGrupo);
        }
        public DTO.Resutado.Entidad<DTO.Permiso.Solictud.Ficha> Permiso_CtaPagar_Reporte_AnalisisVencimiento(string idGrupo)
        {
            return ServiceProv.Permiso_CtaPagar_Reporte_AnalisisVencimiento(idGrupo);
        }

    }

}