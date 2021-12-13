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

        public DTO.Resutado.Entidad<string> Configuracion_Sistema_ClaveNivelMaximo()
        {
            return ServiceProv.Configuracion_Sistema_ClaveNivelMaximo();
        }
        public DTO.Resutado.Entidad<string> Configuracion_Sistema_ClaveNivelMedio()
        {
            return ServiceProv.Configuracion_Sistema_ClaveNivelMedio();
        }
        public DTO.Resutado.Entidad<string> Configuracion_Sistema_ClaveNivelMinimo()
        {
            return ServiceProv.Configuracion_Sistema_ClaveNivelMinimo();
        }

    }

}