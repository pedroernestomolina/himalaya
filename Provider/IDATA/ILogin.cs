using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{
    
    public interface ILogin
    {

        DTO.Resutado.AutoId Login_Identificacion(DTO.Login.Identificacion.Ficha ficha);

    }

}