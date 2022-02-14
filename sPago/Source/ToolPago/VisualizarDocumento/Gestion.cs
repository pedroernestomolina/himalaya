using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.VisualizarDocumento
{
    
    public class Gestion: CtasPagar.AdministradorDoc.IVerDocumento
    {


        private OOB.CtaPagar.Entidad.Ficha _ficha;


        public string Proveedor { get { return _ficha.provCiRif + Environment.NewLine + _ficha.provNombre; } }
        public DateTime FechaEmision { get { return _ficha.fechaEmisionDoc;} }
        public int DiasCredito { get { return _ficha.fechaVenceDoc.Subtract(_ficha.fechaEmisionDoc).Days; } }
        public string CondPago { get { return DiasCredito > 0 ? "CREDITO" : "CONTADO"; } }
        public DateTime FechaVence { get { return _ficha.fechaVenceDoc; } }
        public string NumeroDocumento { get { return _ficha.numeroDoc; } }
        public string TipoDocumento { get { return _ficha.tipoDoc; } }
        public string DetalleDocumento { get { return _ficha.detalleDoc; } }
        public decimal ImporteDocumento { get { return _ficha.importeDoc; } }


        public Gestion() 
        {
            _ficha = null;
        }


        public void Inicializa()
        {
            _ficha = null;
        }

        public void setData(OOB.CtaPagar.Entidad.Ficha ficha)
        {
            this._ficha = ficha;
        }

        VerDocumentoFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new VerDocumentoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

    }

}