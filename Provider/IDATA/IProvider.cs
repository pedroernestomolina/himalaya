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

        DTO.Resutado.Lista<DTO.Proveedor.Lista.Ficha> Proveedor_GetLista(DTO.Proveedor.Lista.Filtro filtro);
        DTO.Resutado.Entidad<DTO.Proveedor.Entidad.Ficha> Proveedor_GetById(string idProv);

    }

}