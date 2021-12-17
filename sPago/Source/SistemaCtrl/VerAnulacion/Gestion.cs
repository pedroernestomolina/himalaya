using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.SistemaCtrl.VerAnulacion
{
    
    public class Gestion
    {

        private OOB.Sistema.DocAnulado.Entidad.Ficha _ficha;


        public string Motivo { get { return _ficha.detalleAnu; } }
        public DateTime Fecha { get { return _ficha.fechaAnu.Date; } }
        public string FechaHora { get { return Fecha.ToShortDateString() + ", " + _ficha.horaAnu; } }
        public string Usuario { get { return _ficha.usuCodigo + Environment.NewLine + _ficha.usuNombre; } }


        public Gestion()
        {
            _ficha = null;
        }


        VisualizarFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new VisualizarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void Inicializa()
        {
            _ficha = null;
        }

        public void setData(OOB.Sistema.DocAnulado.Entidad.Ficha ficha)
        {
            _ficha = ficha;
        }

    }

}