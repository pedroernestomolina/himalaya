using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.ISERVICE
{
    public interface IVentaAdm
    {
        DTO.Resutado.Entidad<DTO.VentaAdm.Reportes.Documentos.Factura.Ficha>
            VentasAdm_Reportes_Documentos_Factura_GetById(string idDoc);
        //
        DTO.Resutado.Lista<DTO.VentaAdm.AdmDoc.Ficha>
            VentasAdm_AdmDocumento_GetLista(DTO.VentaAdm.AdmDoc.Filtro filtro);
    }
}
