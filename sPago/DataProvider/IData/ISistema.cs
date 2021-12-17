using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    
    public interface ISistema
    {

        OOB.Resultado.Entidad<OOB.Sistema.DocAnulado.Entidad.Ficha> Sistema_DocAnulado_Buscar(OOB.Sistema.DocAnulado.Buscar.Ficha ficha);

    }

}