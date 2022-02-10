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

        public DTO.Resutado.Lista<DTO.CtaPagar.Lista.Ficha> CtaPagar_GetLista(DTO.CtaPagar.Lista.Filtro filtro)
        {
            return ServiceProv.CtaPagar_GetLista(filtro);
        }
        public DTO.Resutado.Entidad<DTO.CtaPagar.Entidad.Ficha> CtaPagar_GetById(string idDoc)
        {
            return ServiceProv.CtaPagar_GetById(idDoc);
        }
        public DTO.Resutado.AutoId CtaPagar_Agregar(DTO.CtaPagar.Agregar.Ficha ficha)
        {
            var rt = new DTO.Resutado.AutoId();
            var r01 = ServiceProv.CtaPagar_Agregar_Verficar(ficha);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError) 
            {
                rt.Result = r01.Result;
                rt.Mensaje = r01.Mensaje;
                return rt;
            }

            var r02 = ServiceProv.FechaSistema();
            if (r02.Result == DTO.Resutado.Enumerados.EnumResult.isError) 
            {
                rt.Result = r02.Result;
                rt.Mensaje = r02.Mensaje;
                return rt;
            }
            if (ficha.fechaEmisionDoc > r02.MiEntidad)
            {
                rt.Result =  DTO.Resutado.Enumerados.EnumResult.isError;
                rt.Mensaje = "FECHA EMISION INCORRECTA";
                return rt;
            }

            return ServiceProv.CtaPagar_Agregar(ficha);
        }
        public DTO.Resutado.Ficha CtaPagar_AnularDoc(DTO.CtaPagar.AnularDoc.Ficha ficha)
        {
            var rt = new DTO.Resutado.Ficha();

            var r01 = ServiceProv.CtaPagar_AnularDoc_Verficar (ficha.autoDoc);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Result = r01.Result;
                rt.Mensaje = r01.Mensaje;
                return rt;
            }

            return ServiceProv.CtaPagar_AnularDoc(ficha);
        }
        public DTO.Resutado.Ficha CtaPagar_AnularPago(DTO.CtaPagar.AnularPago.Ficha ficha)
        {
            return ServiceProv.CtaPagar_AnularPago(ficha);
        }
        public DTO.Resutado.Lista<DTO.CtaPagar.AnularPago.CtaPagarActualizar> CtaPagar_AnularPago_DocumentosInvolucrados(string autoCxP)
        {
            return ServiceProv.CtaPagar_AnularPago_DocumentosInvolucrados(autoCxP);
        }

    }

}