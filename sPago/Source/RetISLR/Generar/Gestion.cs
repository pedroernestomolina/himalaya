using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sPago.Source.RetISLR.Generar
{
    
    public class Gestion
    {

        public enum enumPrefBusqueda { SinDefinir = -1, PorCiRif = 1, PorRazonSocial, PorCodigo };


        private string _prefBusPrv;
        private enumPrefBusqueda _prefBusqueda;
        private string _cadenaBuscar;
        private DateTime _fechaSistema;
        private int _ultRetISLR;
        private data _data;
        private Proveedor.Lista.Gestion _gestionListaProv;
        private List<data_1> _lst_1;
        private BindingList<data_1> _bl_1;
        private BindingSource _bs_1;


        public enumPrefBusqueda PrefBusqueda { get { return _prefBusqueda; } }
        public string DataProveedor { get { return _data.DataProveedor; } }
        public decimal DataProveedorRetISLR { get { return _data.DataProveedorRetISLR; } }
        public DateTime Fecha { get { return _fechaSistema; } }
        public int UltimaRetISLR { get { return (_ultRetISLR+1); } }
        public BindingSource SourceDoc { get { return _bs_1; } }


        public Gestion() 
        {
            _data = new data();
            _prefBusPrv = "";
            _prefBusqueda = enumPrefBusqueda.SinDefinir;
            _cadenaBuscar = "";
            _gestionListaProv = new Proveedor.Lista.Gestion();
            _lst_1 = new List<data_1>();
            _bl_1 = new BindingList<data_1>(_lst_1);
            _bs_1 = new BindingSource();
            _bs_1.DataSource = _bl_1;
        }


        public void Inicializa()
        {
            _data.Inicializa();
            _prefBusPrv = "";
            _prefBusqueda = enumPrefBusqueda.SinDefinir;
            _cadenaBuscar = "";
            _gestionListaProv.Inicializa();
        }

        GenerarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new GenerarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Configuracion_Proveedor_PreferenciaBusqueda();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _prefBusPrv = r01.MiEntidad;

            var r02 = Sistema.MyData.FechaSistema();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _fechaSistema = r02.MiEntidad.Date;

            var r03 = Sistema.MyData.RetISLR_ContadorUltimaRetencion();
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _ultRetISLR = r03.MiEntidad;

            switch (_prefBusPrv)
            {
                case "CI/RIF":
                    _prefBusqueda = enumPrefBusqueda.PorCiRif;
                    break;
                case "NOMBRE":
                    _prefBusqueda = enumPrefBusqueda.PorRazonSocial;
                    break;
                case "CODIGO":
                    _prefBusqueda = enumPrefBusqueda.PorCodigo;
                    break;
            }

            return true;
        }

        public void setCadenaBuscar(string p)
        {
            _cadenaBuscar = p;
        }

        public void Buscar()
        {
            if (_cadenaBuscar=="")
            {
                return;
            }

            var metBusq= OOB.Proveedor.enumerados.metodosBusq.SinDefinir;
            switch(_prefBusqueda)
            {
                case enumPrefBusqueda.PorCiRif:
                    metBusq= OOB.Proveedor.enumerados.metodosBusq.PorCirif;
                    break;
                case enumPrefBusqueda.PorCodigo:
                    metBusq= OOB.Proveedor.enumerados.metodosBusq.PorCodigo;
                    break;
                case enumPrefBusqueda.PorRazonSocial:
                    metBusq= OOB.Proveedor.enumerados.metodosBusq.PorRazonSocial;
                    break;
            }
            var filtro = new OOB.Proveedor.Lista.Filtro()
            {
                cadena = _cadenaBuscar,
                metodoBusq = metBusq,
            };
            var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gestionListaProv.Inicializa();
            _gestionListaProv.setLista(r01.ListaEntidad);
            _gestionListaProv.Inicia();
            if (_gestionListaProv.ItemSeleccionadoIsOk)
            {
                CargarProveedor(_gestionListaProv.ItemSeleccionado.auto);
            }
        }

        private void CargarProveedor(string id)
        {
            var r01 = Sistema.MyData.Proveedor_GetById(id);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _data.setProveedor(r01.MiEntidad);

            var filtro = new OOB.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro()
            {
                idProv = r01.MiEntidad.id,
            };
            var r02 = Sistema.MyData.RetISLR_DocumentosPendPorAplicar_GetLista(filtro);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            _bl_1.Clear();
            foreach(var it in r02.ListaEntidad)
            {
                _bl_1.Add(new data_1(it));
            }
        }

        public void setPrefBusquedaPorCodigo()
        {
            _prefBusqueda = enumPrefBusqueda.PorCodigo;
        }

        public void setPrefBusquedaPorNombre()
        {
            _prefBusqueda = enumPrefBusqueda.PorRazonSocial;
        }

        public void setPrefBusquedaPorCiRif()
        {
            _prefBusqueda = enumPrefBusqueda.PorCiRif;
        }

    }

}