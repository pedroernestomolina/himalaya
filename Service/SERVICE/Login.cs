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

        public DTO.Resutado.AutoId Login_Identificacion(DTO.Login.Identificacion.Ficha ficha)
        {
            return ServiceProv.Login_Identificacion(ficha);
        }

    }

}