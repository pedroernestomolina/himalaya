using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    
    class Program
    {
        static void Main(string[] args)
        {
             Provider.IDATA.IProvider dataProv = new Provider.DATASQL.Provider(@"localhost\mssql14", "00000001");

             //var ficha = new DTO.Login.Identificacion.Ficha()
             //{
             //    clave = "ALEJANDRO73",
             //    codigo = "003",
             //};
             //var r01 = dataProv.Login_Identificacion(ficha);
             //var r02 = dataProv.Usuario_GetById(r01.Auto);
             //var r03 = dataProv.Permiso_Solicitud_ModuloPago(r02.MiEntidad.idGrupo);
             //var r04 = dataProv.Permiso_Solicitud_ElaborarRetencionISLR(r02.MiEntidad.idGrupo);

             //var filtro5 = new DTO.Proveedor.Lista.Filtro()
             //{
             //    cadena = "*MULTI",
             //    metodoBusq = DTO.Proveedor.enumerados.metodosBusq.PorRazaonSocial,
             //};
             //var r05 = dataProv.Proveedor_GetLista(filtro5);
             //var r06 = dataProv.Configuracion_Proveedor_PreferenciaBusqueda();
             //var r07 = dataProv.Proveedor_GetById("0000001014");

             //var filtro8 = new DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro()
             //{
             //    idProv = "0000001014",
             //};
             //var r08 = dataProv.RetISLR_DocumentosPendPorAplicar_GetLista(filtro8);

             //var r09 = dataProv.RetISLR_DocumentoPendPorAplicar_GetByIdDoc("0000000010");

             //var filtro10 = new DTO.RetISLR.DocumentoPendPorAplicar.CxPagar.Filtro()
             //{
             //    idDoc = "0000000016",
             //    tipoDoc = "FAC",
             //};
             //var r10 = dataProv.RetISLR_DocumentoPendPorAplicar_CtaxPagar(filtro10);

             //var r11 = dataProv.Configuracion_Sistema_ClaveNivelMaximo();

             //var r12 = dataProv.FechaSistema();
             //var r13 = dataProv.RetISLR_ContadorUltimaRetencion();

             //var filtro14 = new DTO.RetISLR.Lista.Filtro()
             // {
             //     tipoRetencion = "02",
             // };
             //var r14 = dataProv.RetISLR_GetLista(filtro14);

             //var r15 = dataProv.Empresa_GetFicha();

            //var r16 = dataProv.RetISLR_AnularRetencion_GetData("0000000015");
            //var r17 = dataProv.RetISLR_AnularRetencion(r16.MiEntidad);

        }

    }

}