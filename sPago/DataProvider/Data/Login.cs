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

        public OOB.Resultado.AutoId Login_Identificacion(OOB.Login.Identificacion.Ficha ficha)
        {
            var rt= new OOB.Resultado.AutoId ();

            var fichaDTO = new DTO.Login.Identificacion.Ficha()
            {
                clave = ficha.clave,
                codigo = ficha.codigo,
            };
            var r01= MyData.Login_Identificacion(fichaDTO);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError) 
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;
            rt.Id = r01.Id;

            return rt;
        }

    }

}