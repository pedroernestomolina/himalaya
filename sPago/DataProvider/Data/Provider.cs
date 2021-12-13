using sPago.DataProvider.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.Data
{
    
    public partial class Provider: IProvider
    {


        public static Service.ISERVICE.IDataService MyData;


        public Provider(string instancia, string bd)
        {
            MyData = new Service.SERVICE.DataService(instancia, bd);
        }


        public OOB.Resultado.Entidad<DateTime> FechaSistema()
        {
            var rt = new OOB.Resultado.Entidad<DateTime>();

            var r01 = MyData.FechaSistema();
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.MiEntidad  = r01.MiEntidad;

            return rt;
        }

    }

}