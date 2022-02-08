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

        public DTO.Resutado.Lista<DTO.Reportes.CtasPagar.DocumentosPorPagar.Ficha> Reportes_CtaPagar_DocumentosPorPagar(DTO.Reportes.CtasPagar.DocumentosPorPagar.Filtro filtro)
        {
            return ServiceProv.Reportes_CtaPagar_DocumentosPorPagar(filtro);
        }
        public DTO.Resutado.Lista<DTO.Reportes.CtasPagar.PagosEmitidos.Ficha> Reportes_CtaPagar_PagosEmitidos(DTO.Reportes.CtasPagar.PagosEmitidos.Filtro filtro)
        {
            return ServiceProv.Reportes_CtaPagar_PagosEmitidos(filtro);
        }
        public DTO.Resutado.Lista<DTO.Reportes.CtasPagar.RelacionPagoDiario.Ficha> Reportes_CtaPagar_RelacionPagoDiario(DTO.Reportes.CtasPagar.RelacionPagoDiario.Filtro filtro)
        {
            return ServiceProv.Reportes_CtaPagar_RelacionPagoDiario(filtro);
        }

    }

}