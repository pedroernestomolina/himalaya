using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.RetISLR.Generar
{
    
    public class data
    {


        private decimal _tasaRet;
        private OOB.Proveedor.Entidad.Ficha _proveedor;


        public decimal DataProveedorRetISLR { get { return _tasaRet; } }
        public OOB.Proveedor.Entidad.Ficha Proveedor { get { return _proveedor; } }
        public string DataProveedor 
        {
            get 
            {
                var rt = "";
                if (_proveedor!=null)
                {
                    rt = "(" + _proveedor.codigo + ")" + Environment.NewLine + _proveedor.ciRif + Environment.NewLine + _proveedor.nombreRazonSocial + Environment.NewLine + _proveedor.dirFiscal;
                }
                return rt;
            }
        }


        public data() 
        {
            limpiar();
        }


        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            _tasaRet = 0m;
            _proveedor = null;
        }

        public void setProveedor(OOB.Proveedor.Entidad.Ficha ficha)
        {
            this._proveedor = ficha;
            _tasaRet = ficha.retISLR;
        }

        public void setTasaRetencion(decimal p)
        {
            this._tasaRet = p;
        }

    }

}