using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes
{
    
    public interface IReportes
    {

        Filtrar.IFiltrar Filtrar { get; }


        void Generar(Filtrar.dataFiltrar data);

    }

}