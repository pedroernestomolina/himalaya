using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.NuevoDcoumento
{
    
    public class data
    {

        private ficha _condPago;
        private ficha _tipoDoc;
        private DateTime _fechaEmision;
        private int _diasCredito;
        private string _numDocumento;
        private decimal _importe;
        private string _detalle;
        private OOB.Proveedor.Entidad.Ficha _proveedor;


        public DateTime FechaEmision { get { return _fechaEmision; } }
        public DateTime FechaVencimiento { get { return _fechaEmision.AddDays(_diasCredito); } }
        public ficha CondicionPago { get { return _condPago; } }
        public ficha TipoDocumento { get { return _tipoDoc; } }
        public int DiasCredito { get { return _diasCredito; } }
        public string DocumentoNro { get { return _numDocumento; } }
        public decimal Importe { get { return _importe; } }
        public string Detalle { get { return _detalle; } }
        public OOB.Proveedor.Entidad.Ficha Proveedor { get { return _proveedor; } }
        public string GetProveedor 
        {
            get 
            {
                var rt = "";
                if (_proveedor != null) 
                {
                    rt += _proveedor.ciRif + Environment.NewLine + _proveedor.nombreRazonSocial + Environment.NewLine + _proveedor.dirFiscal;
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
            _condPago = null;
            _tipoDoc = null;
            _fechaEmision = DateTime.Now.Date;
            _diasCredito = 0;
            _numDocumento = "";
            _importe = 0m;
            _detalle = "";
            _proveedor = null;
        }

        public void setCondPago(ficha data) 
        {
            _condPago = data;
        }

        public void setTipoDoc (ficha data)
        {
            _tipoDoc= data;
        }

        public void setFechaEmision(DateTime fecha)
        {
            _fechaEmision = fecha;
        }

        public void setDiasCredito(int dias)
        {
            _diasCredito = dias;
        }

        public void setDocumentoNumero(string p)
        {
            _numDocumento = p;
        }

        public void setImporte(decimal p)
        {
            _importe = p;
        }

        public void setDetalle(string p)
        {
            _detalle = p;
        }

        public void setProveedor(OOB.Proveedor.Entidad.Ficha ficha)
        {
            _proveedor = ficha;
        }

        public bool ValidarDatos()
        {
            if (_proveedor == null)
            {
                Helpers.Msg.Error("Campo Proveedor No Seleccionado");
                return false;
            }
            if (_condPago == null)
            {
                Helpers.Msg.Error("Campo Condición de Pago Incorrecto");
                return false;
            }
            if (_tipoDoc == null)
            {
                Helpers.Msg.Error("Campo Tipo Documento Incorrecto");
                return false;
            }
            if (_numDocumento.Trim() == "")
            {
                Helpers.Msg.Error("Campo Número Documento Incorrecto");
                return false;
            }
            if (_importe <= 0m)
            {
                Helpers.Msg.Error("Campo Importe Del Documento Incorrecto");
                return false;
            }
            if (_detalle.Trim()=="")
            {
                Helpers.Msg.Error("Campo Detalle Del Documento Incorrecto");
                return false;
            }

            return true;
        }

    }

}