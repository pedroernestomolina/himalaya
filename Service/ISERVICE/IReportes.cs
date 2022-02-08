using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ISERVICE
{

    public interface IReportes
    {

        //
        DTO.Resutado.Lista<DTO.Reportes.CtasPagar.DocumentosPorPagar.Ficha> Reportes_CtaPagar_DocumentosPorPagar(DTO.Reportes.CtasPagar.DocumentosPorPagar.Filtro filtro);
        DTO.Resutado.Lista<DTO.Reportes.CtasPagar.PagosEmitidos.Ficha> Reportes_CtaPagar_PagosEmitidos(DTO.Reportes.CtasPagar.PagosEmitidos.Filtro filtro);
        DTO.Resutado.Lista<DTO.Reportes.CtasPagar.RelacionPagoDiario.Ficha> Reportes_CtaPagar_RelacionPagoDiario(DTO.Reportes.CtasPagar.RelacionPagoDiario.Filtro filtro);

    }

}