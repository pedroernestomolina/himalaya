using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{

    public interface IRetISLR
    {

        DTO.Resutado.Lista<DTO.RetISLR.DocumentoPendPorAplicar.Ficha> RetISLR_DocumentosPendPorAplicar_GetLista(DTO.RetISLR.DocumentoPendPorAplicar.Filtro filtro);

    }

}