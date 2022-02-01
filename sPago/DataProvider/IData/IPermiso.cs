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
        //
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_ElaborarRetencionISLR(string idGrupo);
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloRetencionISLR(string idGrupo);
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_AdministradorRetencionISLR(string idGrupo);
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_AnularRetencionISLR(string idGrupo);
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_ReporteRetencionISLR(string idGrupo);
        //
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_CtasPagar_ToolPago(string idGrupo);
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_CtasPagar_Adminstrador(string idGrupo);
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_CtasPagar_Adminstrador_AnularPago(string idGrupo);
        //
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_CtaPagar_Reporte_DocumentosPorPagar(string idGrupo);
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_CtaPagar_Reporte_PagosEmitidos(string idGrupo);
        OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_CtaPagar_Reporte_AnalisisVencimiento(string idGrupo);

    }

}