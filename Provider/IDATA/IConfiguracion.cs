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

    }

}