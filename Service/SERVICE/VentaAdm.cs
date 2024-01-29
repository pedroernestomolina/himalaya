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
        public DTO.Resutado.Entidad<DTO.VentaAdm.Reportes.Documentos.Factura.Ficha> 
            VentasAdm_Reportes_Documentos_Factura_GetById(string idDoc)
        {
            return ServiceProv.VentasAdm_Reportes_Documentos_Factura_GetById(idDoc);
        }
        //
        public DTO.Resutado.Lista<DTO.VentaAdm.AdmDoc.Ficha> 
            VentasAdm_AdmDocumento_GetLista(DTO.VentaAdm.AdmDoc.Filtro filtro)
        {
            return ServiceProv.VentasAdm_AdmDocumento_GetLista(filtro);
        }
    }
}