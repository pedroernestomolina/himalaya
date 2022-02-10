using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.GenerarPago
{
    
    public class data
    {

        private OOB.Proveedor.Entidad.Ficha _proveedor;
        private List<item> _listaDocPagar;
        private List<MetodosPago.data> _listMetodosPago;


        public OOB.Proveedor.Entidad.Ficha Proveedor { get { return _proveedor; } }
        public List<item> DocumentosPagar { get { return _listaDocPagar; } }
        public List<MetodosPago.data> MetodosPago { get { return _listMetodosPago; } }
        public string DataProveedor 
        {
            get 
            {
                var rt = "";
                if (_proveedor != null)
                {
                    rt = _proveedor.ciRif + Environment.NewLine + _proveedor.nombreRazonSocial + Environment.NewLine + _proveedor.dirFiscal;
                }
                return rt;
            }
        }


        public data() 
        {
            _proveedor = null;
            _listaDocPagar = null;
            _listMetodosPago = null;
        }


        public void setProveedor(OOB.Proveedor.Entidad.Ficha ficha) 
        {
            _proveedor = ficha;
        }

        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            _proveedor = null;
            _listaDocPagar = null;
            _listMetodosPago = null;
        }

        public void setItemsPagar(List<item> list)
        {
            _listaDocPagar = list;
        }

        public void setMetodoPago(List<MetodosPago.data> list)
        {
            _listMetodosPago = list;
        }

    }

}