using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.GenerarPago.MetodosPago
{
    
    public class Gestion: IMetodosPago
    {


        private decimal _montoPagar;
        private bool _procesarIsOk;


        public decimal MontoPagar { get { return _montoPagar; } }
        public object ListaMetodosPago { get { throw new NotImplementedException(); } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        

        public Gestion() 
        {
        }


        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            _procesarIsOk = false;
            _montoPagar = 0m;
        }

        public void setMontoPagar(decimal monto)
        {
            _montoPagar = monto;
        }

        MetodosPagoFrm frm;
        public void Inicia()
        {
            if (CargarDta()) 
            {
                if (frm == null) 
                {
                    frm = new MetodosPagoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarDta()
        {
            return true;
        }

    }

}