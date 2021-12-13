using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    
    public interface IProveedor
    {

        OOB.Resultado.Lista<OOB.Proveedor.Entidad.Ficha> Proveedor_GetLista(OOB.Proveedor.Lista.Filtro filtro);
        OOB.Resultado.Entidad<OOB.Proveedor.Entidad.Ficha> Proveedor_GetById(string idProv);

    }

}