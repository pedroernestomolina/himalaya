using sPago.DataProvider.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.Data
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.Entidad<OOB.Empresa.Entidad.Ficha> Empresa_GetFicha()
        {
            var rt = new OOB.Resultado.Entidad<OOB.Empresa.Entidad.Ficha>();

            var r01 = MyData.Empresa_GetFicha ();
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var s= r01.MiEntidad;
            rt.MiEntidad = new OOB.Empresa.Entidad.Ficha()
            {
                ciRif = s.ciRif.Trim().ToUpper(),
                dirFiscal = s.dirFiscal.Trim(),
                nombreRazonSocial = s.nombreRazonSocial.Trim().ToUpper(),
                telefono_1 = s.telefono_1.Trim(),
                telefono_2 = s.telefono_2.Trim(),
                telefono_3 = s.telefono_3.Trim(),
                telefono_4 = s.telefono_4.Trim(),
            };

            return rt;
        }

    }

}