using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Maestro
{
    
    public class Gestion: IGestion
    {


        private IMaestro _gMaestro;
        private ILista _gLista  ;


        public string Maestro { get { return _gMaestro.Titulo; } }
        public int TotalItems { get { return _gLista.CntItems ; } }
        public BindingSource Source { get { return _gLista.Source; } }
        public data ItemActual { get { return _gLista.ItemActual; } }


        public Gestion(ILista ctrLista)
        {
            _gLista = ctrLista;
        }


        public void setGestion(IMaestro ctr)
        {
            _gMaestro = ctr;
        }

        public void Inicializa()
        {
            _gMaestro.Inicializa();
            _gLista.Inicializa();
        }

        MaestroFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new MaestroFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void AgregarItem()
        {
            _gMaestro.AgregarItem();
            if (_gMaestro.AgregarItemIsOk) 
            {
                _gLista.Agregar(_gMaestro.ItemAgregar);
            }
        }

        public void EditarItem()
        {
            if (ItemActual != null)
            {
                _gMaestro.EditarItem(ItemActual);
                if (_gMaestro.EditarIsOk)
                {
                    _gLista.Actualizar(_gMaestro.ItemAgregar);
                }
            }
        }

        public bool CargarData()
        {
            if (_gMaestro.CargarData())
            {
                _gLista.setLista(_gMaestro.ListData);
            }
            return true;
        }

        public void Eliminar()
        {
            if (ItemActual != null)
            {
                _gMaestro.EliminarItem(ItemActual);
                if (_gMaestro.EliminarIsOk) 
                {
                    _gLista.EliminarItemActual();
                } 
            }
        }

    }

}