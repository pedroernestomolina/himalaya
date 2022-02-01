using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Filtrar
{
    
    public interface IFiltrar
    {

        List<ficha> ListTipoDoc { get; }
        List<ficha> ListEstatus { get; }


        bool CargarData();

    }

}