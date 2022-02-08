using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    
    public interface IReportes
    {

        OOB.Resultado.Lista<OOB.Reportes.CtasPagar.DocumentosPorPagar.Ficha> Reportes_CtaPagar_DocumentosPorPagar(OOB.Reportes.CtasPagar.DocumentosPorPagar.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.CtasPagar.PagosEmitidos.Ficha> Reportes_CtaPagar_PagosEmitidos(OOB.Reportes.CtasPagar.PagosEmitidos.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.CtasPagar.RelacionPagoDiario.Ficha> Reportes_CtaPagar_RelacionPagoDiario(OOB.Reportes.CtasPagar.RelacionPagoDiario.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.CtasPagar.AnalisisVencimiento.Ficha> Reportes_CtaPagar_AnalisisVencimiento(OOB.Reportes.CtasPagar.DocumentosPorPagar.Filtro filtro);

    }

}