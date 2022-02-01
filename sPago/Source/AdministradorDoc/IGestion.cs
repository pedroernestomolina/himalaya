using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.AdministradorDoc
{
    
    public interface IGestion
    {

        string TituloAdministrador { get; }
        Filtrar.IFiltrar GestionFiltro { get; }
        Enumerados.EnumTipoAdministrador TipoAdminstrador { get; }
        bool AnularItemIsOk { get; }


        void setGestionSeguridad(Seguridad.IGestion _gSeguridad);
        void setGestionAnular(Anular.IGestion _gAnular);
        void setGestionAuditoria(SistemaCtrl.VerAnulacion.IGestion _gAuditoria);


        void Inicializa();
        bool CargarData();
        List<data> BuscarDocs(Filtrar.dataFiltrar filtro);
        void AnularItem(data ItemActual);
        void VisualizarDocumento(data ItemActual);
        void ReporteDocumentos(List<data> ListaItems);
        void VisualizarDocAnulado(data ItemActual);

    }

}