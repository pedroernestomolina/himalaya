using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{

    public interface IProvider : ILogin , IUsuario, IPermiso, IProveedor, IConfiguracion, 
        IRetISLR
    {

        DTO.Resutado.Entidad<DateTime> FechaSistema();

    }

}