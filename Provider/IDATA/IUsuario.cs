using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{
    
    public interface IUsuario
    {

        DTO.Resutado.Entidad<DTO.Usuario.Entidad.Ficha> Usuario_GetById(string id);

    }

}