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

        public DTO.Resutado.Entidad<DTO.Empresa.Entidad.Ficha> Empresa_GetFicha()
        {
            return ServiceProv.Empresa_GetFicha();
        }

    }

}