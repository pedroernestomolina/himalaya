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

        public DTO.Resutado.Entidad<DTO.Sistema.DocAnulado.Entidad.Ficha> Sistema_DocAnulado_Buscar(DTO.Sistema.DocAnulado.Buscar.Ficha ficha)
        {
            return ServiceProv.Sistema_DocAnulado_Buscar(ficha);
        }

    }

}