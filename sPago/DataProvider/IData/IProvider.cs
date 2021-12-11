using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{

    public interface IProvider: ILogin, IUsuario, IPermiso
    {
    }

}