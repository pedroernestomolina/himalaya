using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.RetISLR.Generar
{
    
    public class data
    {


        private OOB.Proveedor.Entidad.Ficha _proveedor;

        public decimal DataProveedorRetISLR 
        {
            get 
            {
                var rt = 0m;
                if (_proveedor != null) 
                {
                    rt = _proveedor.retISLR;
                }
                return rt;
            }
        }

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
            _proveedor = null;
        }

        public void setProveedor(OOB.Proveedor.Entidad.Ficha ficha)
        {
            _proveedor = ficha;
        }

    }

}