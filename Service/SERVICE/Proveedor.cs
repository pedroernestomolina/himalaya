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

        public DTO.Resutado.Lista<DTO.Proveedor.Lista.Ficha> Proveedor_GetLista(DTO.Proveedor.Lista.Filtro filtro)
        {
            return ServiceProv.Proveedor_GetLista(filtro);
        }

        public DTO.Resutado.Entidad<DTO.Proveedor.Entidad.Ficha> Proveedor_GetById(string idProv)
        {
            return ServiceProv.Proveedor_GetById(idProv);
        }

    }

}