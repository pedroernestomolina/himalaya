using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{
    
    public interface IConfiguracion
    {

        DTO.Resutado.Entidad<string> Configuracion_Proveedor_PreferenciaBusqueda();

        DTO.Resutado.Entidad<string> Configuracion_Sistema_ClaveNivelMaximo();
        DTO.Resutado.Entidad<string> Configuracion_Sistema_ClaveNivelMedio();
        DTO.Resutado.Entidad<string> Configuracion_Sistema_ClaveNivelMinimo();

    }

}