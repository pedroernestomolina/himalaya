using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.RetISLR.Administrador.Items
{
    
    public class data
    {

        private OOB.RetISLR.Entidad.Ficha _ficha;


        public string Id { get { return _ficha.id; } }
        public DateTime Fecha { get { return _ficha.deFecha; } }
        public string Documento { get { return _ficha.documento; } }
        public string Proveedor { get { return _ficha.nombreProv; } }
        public string CiRifProv { get { return _ficha.ciRifProv; } }
        public decimal TasaRetencion { get { return _ficha.tasaRet; } }
        public decimal MontoRetencion { get { return _ficha.montoRet; } }
        public decimal MontoExento { get { return _ficha.mExento; } }
        public decimal MontoBase{ get { return _ficha.mBase; } }
        public decimal MontoIva{ get { return _ficha.mIva ; } }
        public decimal MontoTotal { get { return _ficha.mTotal; } }
        public string IsActivo { get { return _ficha.estatus == "1" ? "ANULADO" : ""; } }
        public bool IsAnulado { get { return _ficha.estatus == "1" ? true : false; } }


        public data(OOB.RetISLR.Entidad.Ficha ficha)
        {
            this._ficha = ficha;
        }


        public void setEstatusAnulado()
        {
            _ficha.estatus = "1";
        }

    }

}