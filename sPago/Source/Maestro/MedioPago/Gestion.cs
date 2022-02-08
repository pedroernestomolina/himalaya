using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.Maestro.MedioPago
{

    public class Gestion : IMaestro
    {

        private data _itemAgregar;
        private List<data> _lst;
        private AgregarEditar.IAgregarEditar _gAgregarEditar;
        private bool _eliminarIsOk;


        public List<data> ListData { get { return _lst; } }
        public string Titulo { get { return "Medios De Pago"; } }
        public bool AgregarItemIsOk { get { return _gAgregarEditar.AgregarIsOk; } }
        public bool EditarIsOk { get { return _gAgregarEditar.EditarIsOk; } }
        public data ItemAgregar { get { return _itemAgregar; } }
        public bool EliminarIsOk { get { return _eliminarIsOk; } }


        public Gestion(AgregarEditar.IAgregarEditar ctr) 
        {
            _eliminarIsOk = false;
            _lst = new List<data>();
            _gAgregarEditar = ctr;
        }


        public void Inicializa()
        {
            _lst.Clear();
            _eliminarIsOk=false;
            _itemAgregar = null;
        }

        public bool CargarData()
        {
            var r01 = Sistema.MyData.MedioPago_GetLista();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _lst.Clear();
            foreach (var rg in r01.ListaEntidad.OrderBy(o => o.descripcion).ToList())
            {
                _lst.Add(new data(rg.id, rg.codigo, rg.descripcion));
            }

            return true;
        }

        public void AgregarItem()
        {
            _itemAgregar = null;
            _gAgregarEditar.setModoAgregar("Agregar: MEDIO PAGO");
            _gAgregarEditar.Inicializa();
            _gAgregarEditar.Inicia();
            if (_gAgregarEditar.AgregarIsOk) 
            {
                var r01 = Sistema.MyData.MedioPago_GetById(_gAgregarEditar.IdItemAgregado);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _itemAgregar = new data(r01.MiEntidad.id, r01.MiEntidad.codigo, r01.MiEntidad.descripcion);
            }
        }

        public void EditarItem(data item)
        {
            var r01 = Sistema.MyData.MedioPago_GetById(item.id);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var dt = new data(r01.MiEntidad.id, r01.MiEntidad.codigo, r01.MiEntidad.descripcion);
            _gAgregarEditar.setModoEditar("Actualizar/Editar: MEDIO PAGO", dt);
            _gAgregarEditar.Inicializa();
            _gAgregarEditar.Inicia();
            if (_gAgregarEditar.ProcesarIsOK)
            {
                var r02 = Sistema.MyData.MedioPago_GetById(item.id);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                _itemAgregar = new data(r02.MiEntidad.id, r02.MiEntidad.codigo, r02.MiEntidad.descripcion);
            }
        }

        public void EliminarItem(data ItemActual)
        {
            _eliminarIsOk = false;
            var xms = "Eliminar Ficha ?";
            var msg = MessageBox.Show(xms, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var r01 = Sistema.MyData.MedioPago_Eliminar(ItemActual.id);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _eliminarIsOk = true;
            }
        }
    }

}