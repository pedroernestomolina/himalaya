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

        public OOB.Resultado.Entidad<OOB.Usuario.Entidad.Ficha> Usuario_GetById(string id)
        {
            var rt = new OOB.Resultado.Entidad<OOB.Usuario.Entidad.Ficha>();

            var r01 = MyData.Usuario_GetById(id);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var ent = r01.MiEntidad;
            rt.MiEntidad = new OOB.Usuario.Entidad.Ficha()
            {
                codigoUsu = ent.codigoUsu.Trim(),
                estatusUsu = ent.estatusUsu.Trim(),
                id = ent.id.Trim(),
                idGrupo = ent.idGrupo.Trim(),
                nombreGrup = ent.nombreGrup.Trim(),
                nombreUsu = ent.nombreUsu.Trim(),
            };

            return rt;
        }

    }

}