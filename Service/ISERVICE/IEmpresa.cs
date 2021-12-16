using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.ISERVICE
{

    public interface IEmpresa
    {

        DTO.Resutado.Entidad<DTO.Empresa.Entidad.Ficha> Empresa_GetFicha();

    }

}