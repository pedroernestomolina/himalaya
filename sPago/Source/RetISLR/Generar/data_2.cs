using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.RetISLR.Generar
{
    
    public class data_2
    {

        private OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha _ficha;
        private decimal _tasaRet;


        public OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha Ficha { get { return _ficha; } }
        public string AutoDoc { get { return _ficha.autoDoc; } }
        public string Origen { get { return _ficha.TipoDocumento; } }
        public string Documento { get { return _ficha.numDoc; } }
        public string Control { get { return _ficha.numControlDoc; } }
        public string Serie { get { return _ficha.serieDoc; } }
        public DateTime Fecha { get { return _ficha.fechaDoc; } }
        public decimal Monto { get { return _ficha.total; } }
        public decimal Exento { get { return _ficha.montoExento; } }
        public decimal Base { get { return _ficha.montoBase; } }
        public decimal Iva { get { return _ficha.montoIva; } }
        public int Signo { get { return _ficha.signo; } }
        public decimal MontoRetencion { get { return ((Exento + Base) * _tasaRet / 100) * Signo; } }


        public data_2(OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha ficha, decimal tasaRet)
        {
            this._ficha = ficha;
            setTasaRet(tasaRet);
        }

        public void setTasaRet(decimal tasa)
        {
            _tasaRet = tasa;
        }

    }

}