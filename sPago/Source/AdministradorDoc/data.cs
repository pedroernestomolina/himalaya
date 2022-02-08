using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.AdministradorDoc
{
    
    public class data
    {

        private decimal _montoDebe;
        private decimal _montoHaber;


        public string autoDoc { get; set; }
        public string numDoc { get; set; }
        public DateTime fechaEmiDoc { get; set; }
        public DateTime fechaVtoDoc { get; set; }
        public string tipoDoc { get; set; }
        public string detalleDoc { get; set; }
        public decimal importeDoc { get; set; }
        public decimal restaDoc { get; set; }
        public int signoDoc { get; set; }
        public string provCiRif { get; set; }
        public string provNombre { get; set; }
        public string estatusDoc { get; set; }
        public decimal abonadoDoc { get; set; }
        public int diasTransc 
        {
            get 
            {
                var rt = 0;
                rt = DateTime.Now.Date.Subtract(fechaVtoDoc).Days;
                if (rt <= 0)
                    rt = 0;
                return rt;
            } 
        }
        public int diasPend 
        {
            get 
            {
                var rt = 0;
                rt = DateTime.Now.Date.Subtract(fechaVtoDoc).Days;
                if (rt > 0)
                    rt = 0;
                return Math.Abs(rt);
            } 
        }
        public bool isAnulado { get { return estatusDoc == "1" ? true : false; } }
        public string EstatusDocDesc { get { return estatusDoc == "1" ? "ANULADO" : ""; } }
        public decimal montoDebe { get { return _montoDebe; } }
        public decimal montoHaber { get { return _montoHaber; } }
        //
        public decimal TasaRetencion { get; set; }
        public decimal MontoRetencion { get; set; }
        public decimal MontoExentoRet { get; set; }
        public decimal MontoBaseRet { get; set; }
        public decimal MontoIvaRet { get; set; }
        public decimal MontoTotalRet { get; set; }


        public data(
            string _autoDoc, 
            string _numDoc, 
            DateTime _fechaEmision, 
            string _tipoDoc, 
            string _detalleDoc,
            decimal _importeDoc,
            decimal _abonadoDoc,
            decimal _restaDoc,
            int _signoDoc,
            string _provCiRif,
            string _provNombre,
            string _estatusDoc,
            DateTime _fechaVto,
            decimal _tasaRetencion,
            decimal _montoRetencion,
            decimal _montoExentoRet,
            decimal _montoBaseRet,
            decimal _montoIvaRet,
            decimal _montoTotalRet
            )
        {
            autoDoc = _autoDoc;
            numDoc = _numDoc;
            fechaEmiDoc = _fechaEmision;
            tipoDoc = _tipoDoc;
            detalleDoc = _detalleDoc;
            importeDoc = _importeDoc;
            abonadoDoc = _abonadoDoc;
            restaDoc = _restaDoc;
            signoDoc = _signoDoc;
            provCiRif = _provCiRif;
            provNombre = _provNombre;
            estatusDoc = _estatusDoc;
            fechaVtoDoc = _fechaVto;
            //
            TasaRetencion = _tasaRetencion;
            MontoRetencion = _montoRetencion;
            MontoExentoRet = _montoExentoRet;
            MontoBaseRet = _montoBaseRet;
            MontoIvaRet = _montoIvaRet;
            MontoTotalRet = _montoTotalRet;
        }

        public data(data _ficha)
        {
            this.autoDoc = _ficha.autoDoc;
            this.numDoc = _ficha.numDoc;
            this.fechaEmiDoc = _ficha.fechaEmiDoc;
            this.tipoDoc = _ficha.tipoDoc;
            this.detalleDoc = _ficha.detalleDoc;
            this.importeDoc = _ficha.importeDoc;
            this.abonadoDoc = _ficha.abonadoDoc;
            this.restaDoc = _ficha.restaDoc;
            this.signoDoc = _ficha.signoDoc;
            this.provCiRif = _ficha.provCiRif;
            this.provNombre = _ficha.provNombre;
            this.estatusDoc = _ficha.estatusDoc;
            this.fechaVtoDoc = _ficha.fechaVtoDoc;
            if (signoDoc == 1)
            {
                _montoDebe = importeDoc;
                _montoHaber = 0m;
            }
            else
            {
                _montoDebe = 0m;
                _montoHaber = importeDoc;
            }
            //
            this.TasaRetencion = _ficha.TasaRetencion;
            this.MontoRetencion =_ficha.MontoRetencion;
            this.MontoExentoRet= _ficha.MontoExentoRet;
            this.MontoBaseRet= _ficha.MontoBaseRet;
            this.MontoIvaRet=_ficha.MontoIvaRet;
            this.MontoTotalRet= _ficha.MontoTotalRet;
        }


        public void setEstatusAnulado()
        {
            estatusDoc = "1";
        }

    }

}