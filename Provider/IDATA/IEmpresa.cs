using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{
    
    public interface IEmpresa
    {

        DTO.Resutado.Entidad<DTO.Empresa.Entidad.Ficha> Empresa_GetFicha();

    }

}