using Service.ISERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.SERVICE
{

    public partial class DataService: IDataService
    {

        public DTO.Resutado.Entidad<string> Configuracion_Proveedor_PreferenciaBusqueda()
        {
            return ServiceProv.Configuracion_Proveedor_PreferenciaBusqueda();
        }

    }

}