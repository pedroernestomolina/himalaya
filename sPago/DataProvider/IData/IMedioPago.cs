using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    
    public interface IMedioPago
    {

        OOB.Resultado.Lista<OOB.MedioPago.Entidad.Ficha> MedioPago_GetLista();
        OOB.Resultado.Entidad<OOB.MedioPago.Entidad.Ficha> MedioPago_GetById(int id);
        OOB.Resultado.AutoId MedioPago_Agregar(OOB.MedioPago.Agregar.Ficha ficha);
        OOB.Resultado.Ficha MedioPago_Editar(OOB.MedioPago.Editar.Ficha ficha);
        OOB.Resultado.Ficha MedioPago_Eliminar(int id);

    }

}