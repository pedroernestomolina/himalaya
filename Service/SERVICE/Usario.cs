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

        public DTO.Resutado.Entidad<DTO.Usuario.Entidad.Ficha> Usuario_GetById(string id)
        {
            return ServiceProv.Usuario_GetById(id);
        }

    }

}