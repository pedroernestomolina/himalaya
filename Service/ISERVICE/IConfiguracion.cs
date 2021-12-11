using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.ISERVICE
{
    
    public interface IConfiguracion
    {

        DTO.Resutado.Entidad<string> Configuracion_Proveedor_PreferenciaBusqueda();

    }

}