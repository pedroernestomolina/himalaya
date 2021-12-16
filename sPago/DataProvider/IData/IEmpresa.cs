using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    
    public interface IEmpresa
    {

        OOB.Resultado.Entidad<OOB.Empresa.Entidad.Ficha> Empresa_GetFicha();

    }

}