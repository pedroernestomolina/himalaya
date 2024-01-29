using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{
    public interface IVentaAdm
    {
        OOB.Resultado.Entidad<OOB.VentaAdm.Reportes.Documentos.Factura.Ficha>
            VentasAdm_Reportes_Documentos_Factura_GetById(string idDoc);
        //
        OOB.Resultado.Lista<OOB.VentaAdm.AdmDoc.Ficha>
            VentasAdm_AdmDocumento_GetLista(OOB.VentaAdm.AdmDoc.Filtro filtro);
    }
}