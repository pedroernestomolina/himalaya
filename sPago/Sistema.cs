using sPago.DataProvider.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago
{
    public class Sistema
    {
        static public IProvider MyData;
        static public string Instancia;
        static public string BaseDatos;
        public static OOB.Usuario.Entidad.Ficha Usuario;
        public static OOB.Empresa.Entidad.Ficha DatosEmpresa;
        public static string EquipoEstacion;
        public static string IdEquipo;
    }
}