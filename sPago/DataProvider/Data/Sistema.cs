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

        public OOB.Resultado.Entidad<OOB.Sistema.DocAnulado.Entidad.Ficha> Sistema_DocAnulado_Buscar(OOB.Sistema.DocAnulado.Buscar.Ficha ficha)
        {
            var rt = new OOB.Resultado.Entidad<OOB.Sistema.DocAnulado.Entidad.Ficha>();

            var fichaDTO = new DTO.Sistema.DocAnulado.Buscar.Ficha()
            {
                autoDoc = ficha.autoDoc,
                moduloOrigen = ficha.moduloOrigen,
            };
            var r01 = MyData.Sistema_DocAnulado_Buscar(fichaDTO);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var s= r01.MiEntidad;
            rt.MiEntidad = new OOB.Sistema.DocAnulado.Entidad.Ficha()
            {
                detalleAnu = s.detalleAnu.Trim(),
                estacion = s.estacion.Trim(),
                fechaAnu = s.fechaAnu,
                horaAnu = s.horaAnu.Trim(),
                usuCodigo = s.usuCodigo.Trim(),
                usuNombre = s.usuNombre.Trim(),
            };

            return rt;
        }

    }

}