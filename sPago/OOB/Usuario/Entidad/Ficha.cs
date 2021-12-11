using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.Usuario.Entidad
{
    
    public class Ficha
    {

        public string id { get; set; }
        public string idGrupo { get; set; }
        public string codigoUsu { get; set; }
        public string nombreUsu { get; set; }
        public string estatusUsu { get; set; }
        public string nombreGrup { get; set; }
        public bool IsUsuarioActivo { get { return estatusUsu.Trim().ToUpper() == "ACTIVO"; } }


        public Ficha() 
        {
            id = "";
            idGrupo = "";
            codigoUsu = "";
            nombreUsu = "";
            estatusUsu = "";
            nombreGrup = "";
        }

    }

}