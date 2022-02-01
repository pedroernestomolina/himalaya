using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaPagar.Lista
{
    
    public class Filtro
    {

        public enum enumEstatus { SinDefinir = -1, Activo = 1, Anulado };
        public enum enumTipoDoc { SinDefinir = -1, Factura = 1, NtaCredito, DocPorLiquidar, Pago, Retencion };
        public DateTime? desde { get; set; }
        public DateTime? hasta { get; set; }
        public enumEstatus estatus { get; set; }
        public enumTipoDoc tipoDoc { get; set; }
        public string autoProv { get; set; }


        public Filtro() 
        {
            desde = null;
            hasta = null;
            estatus = enumEstatus.SinDefinir;
            tipoDoc = enumTipoDoc.SinDefinir;
            autoProv = "";
        }

    }

}