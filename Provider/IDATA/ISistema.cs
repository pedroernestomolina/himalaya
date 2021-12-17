using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{

    public interface ISistema
    {

        DTO.Resutado.Entidad<DTO.Sistema.DocAnulado.Entidad.Ficha> Sistema_DocAnulado_Buscar(DTO.Sistema.DocAnulado.Buscar.Ficha ficha);

    }

}