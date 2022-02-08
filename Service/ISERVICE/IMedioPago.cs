using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.ISERVICE
{

    public interface IMedioPago
    {

        DTO.Resutado.Lista<DTO.MedioPago.Entidad.Ficha> MedioPago_GetLista();
        DTO.Resutado.Entidad<DTO.MedioPago.Entidad.Ficha> MedioPago_GetById(int id);
        DTO.Resutado.AutoId MedioPago_Agregar(DTO.MedioPago.Agregar.Ficha ficha);
        DTO.Resutado.Ficha MedioPago_Editar(DTO.MedioPago.Editar.Ficha ficha);
        DTO.Resutado.Ficha MedioPago_Eliminar(int id);

    }

}