using Provider.IDATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.DATASQL
{

    public partial class Provider: IProvider
    {

        public DTO.Resutado.Lista<DTO.RetISLR.DocumentoPendPorAplicar.Ficha> RetISLR_DocumentosPendPorAplicar_GetLista(DTO.RetISLR.DocumentoPendPorAplicar.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.RetISLR.DocumentoPendPorAplicar.Ficha>();
            return rt;
        }

    }

}