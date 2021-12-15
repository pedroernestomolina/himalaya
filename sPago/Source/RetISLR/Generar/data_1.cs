using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.RetISLR.Generar
{
    
    public class data_1
    {

        private OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha _it;


        public string AutoDoc { get { return _it.autoDoc; } }
        public string Origen { get { return _it.TipoDocumento; } }
        public string Documento{ get { return _it.numDoc; } }
        public string Control { get { return _it.numControlDoc; } }
        public string Serie { get { return _it.serieDoc; } }
        public DateTime Fecha { get { return _it.fechaDoc; } }
        public decimal Monto { get { return _it.total; } }
        public bool IsActivo { get; set; }


        public data_1(OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha it)
        {
            this._it = it;
        }

    }

}