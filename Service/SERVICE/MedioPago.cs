using Service.ISERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.SERVICE
{

    public partial class DataService: IDataService
    {

        public DTO.Resutado.Lista<DTO.MedioPago.Entidad.Ficha> MedioPago_GetLista()
        {
            return ServiceProv.MedioPago_GetLista();
        }
        public DTO.Resutado.Entidad<DTO.MedioPago.Entidad.Ficha> MedioPago_GetById(int id)
        {
            return ServiceProv.MedioPago_GetById(id);
        }
        public DTO.Resutado.AutoId MedioPago_Agregar(DTO.MedioPago.Agregar.Ficha ficha)
        {
            return ServiceProv.MedioPago_Agregar(ficha);
        }
        public DTO.Resutado.Ficha MedioPago_Editar(DTO.MedioPago.Editar.Ficha ficha)
        {
            return ServiceProv.MedioPago_Editar(ficha);
        }
        public DTO.Resutado.Ficha MedioPago_Eliminar(int id)
        {
            return ServiceProv.MedioPago_Eliminar(id);
        }

    }

}