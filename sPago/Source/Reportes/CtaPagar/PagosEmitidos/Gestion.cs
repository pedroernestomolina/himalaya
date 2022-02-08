using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.CtaPagar.PagosEmitidos
{
    
    public class Gestion: IReportes
    {


        private Filtrar.IFiltrar _gFiltrar;



        public Filtrar.IFiltrar Filtrar { get { return _gFiltrar; } }


        public Gestion()
        {
            _gFiltrar = new Filtro();
        }


        public void Generar(Filtrar.dataFiltrar data)
        {
            string _idProv = "";
            DateTime? _desde = null;
            DateTime? _hasta = null;
            OOB.Reportes.CtasPagar.PagosEmitidos.Filtro.enumEstatus _estatus=  OOB.Reportes.CtasPagar.baseFiltro.enumEstatus.SinDefinir;


            if (data.GetFechaDesde_Habilitar)
            {
                _desde = data.GetDesde;
            }
            if (data.GetFechaHasta_Habilitar)
            {
                _hasta = data.GetHasta;
            }
            if (data.Proveedor != null)
            {
                _idProv = data.Proveedor.id;
            }
            if (data.Esatus != null)
            {
                _estatus = OOB.Reportes.CtasPagar.baseFiltro.enumEstatus.Activo;
                if (data.Esatus.id == "02")
                {
                    _estatus = OOB.Reportes.CtasPagar.baseFiltro.enumEstatus.Anulado;
                }
            }

            var filtro = new OOB.Reportes.CtasPagar.PagosEmitidos.Filtro()
            {
                desde = _desde,
                hasta = _hasta,
                idProv = _idProv,
                estatus=_estatus,
            };
            var r01 = Sistema.MyData.Reportes_CtaPagar_PagosEmitidos(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
        }

    }

}