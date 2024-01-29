using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.VentaAdm.__
{
    public static class enumerados
    {
        public enum TipoDocumento { SinDefinir = -1, Factura = 1, NotaDebito, NotaCredito, NotaEntrega, Presupuesto };
        //
        public static string Get_TipoDocumento(TipoDocumento tipo) 
        {
            var rt = "";
            switch (tipo) 
            {
                case TipoDocumento.Factura:
                    return "01";
                case TipoDocumento.NotaDebito:
                    return "02";
                case TipoDocumento.NotaCredito:
                    return "03";
                case TipoDocumento.NotaEntrega:
                    return "04";
                case TipoDocumento.Presupuesto:
                    return "05";
            }
            return rt;
        }
    }
}