using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Maestro.MedioPago.AgregarEditar
{
    
    public class data
    {

        private int _id;
        private string _codigo;
        private string _descripcion;


        public int Id { get { return _id; } }
        public string Codigo { get { return _codigo; } }
        public string Descripcion { get { return _descripcion; } }


        public data()
        {
            limpiar();
        }


        private void limpiar()
        {
            _id = -1;
            _codigo = "";
            _descripcion = "";
        }

        public void setCodigo(string p)
        {
            _codigo = p;
        }

        public void setId(int p)
        {
            _id = p;
        }

        public void setDescripcion(string p)
        {
            _descripcion = p;
        }

        public bool VerificarIsOk()
        {
            if (Codigo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Código ] No Puede Estar Vacio");
                return false;
            }
            if (Descripcion.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Descripción ] No Puede Estar Vacio");
                return false;
            }

            return true;
        }

        public void Inicializar()
        {
            limpiar();
        }

    }

}