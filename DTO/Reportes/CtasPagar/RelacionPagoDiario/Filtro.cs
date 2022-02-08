using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.CtasPagar.RelacionPagoDiario
{
    
    public class Filtro: baseFiltro
    {

        public enumEstatus estatus { get; set; }


        public Filtro() 
        {
            desde = null;
            hasta = null;
            idProv = "";
            estatus = enumEstatus.SinDefinir;
        }

    }

}