using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    
    public interface IUsuario
    {

        OOB.Resultado.Entidad<OOB.Usuario.Entidad.Ficha> Usuario_GetById(string id);

    }

}