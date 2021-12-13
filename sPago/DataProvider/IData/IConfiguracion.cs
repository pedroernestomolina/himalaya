using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{

    public interface IConfiguracion
    {

        OOB.Resultado.Entidad<string> Configuracion_Proveedor_PreferenciaBusqueda();

        OOB.Resultado.Entidad<String> Configuracion_Sistema_ClaveNivelMaximo();
        OOB.Resultado.Entidad<String> Configuracion_Sistema_ClaveNivelMedio();
        OOB.Resultado.Entidad<String> Configuracion_Sistema_ClaveNivelMinimo();

    }

}