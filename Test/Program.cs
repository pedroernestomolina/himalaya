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

             var ficha = new DTO.Login.Identificacion.Ficha()
             {
                 clave = "ALEJANDRO73",
                 codigo = "003",
             };
             var r01 = dataProv.Login_Identificacion(ficha);
             var r02 = dataProv.Usuario_GetById(r01.Auto);
             var r03 = dataProv.Permiso_Solicitud_ModuloPago(r02.MiEntidad.idGrupo);
             var r04 = dataProv.Permiso_Solicitud_ElaborarRetencionISLR(r02.MiEntidad.idGrupo);

             var filtro5 = new DTO.Proveedor.Lista.Filtro()
             {
                 cadena = "*MULTI",
                 metodoBusq = DTO.Proveedor.enumerados.metodosBusq.PorRazaonSocial,
             };
             var r05 = dataProv.Proveedor_GetLista(filtro5);
             var r06 = dataProv.Configuracion_Proveedor_PreferenciaBusqueda();
             var r07 = dataProv.Proveedor_GetById("0000001008");
        }
    }

}