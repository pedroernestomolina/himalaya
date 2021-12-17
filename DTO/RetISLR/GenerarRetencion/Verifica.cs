using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.RetISLR.GenerarRetencion
{
    
    public class Verifica
    {
        public List<DocAplicaRet> docAplicaRet { get; set; }
        public List<DocActualizarSaldoCxP> docActualizarSaldoCxP { get; set; }


        public Verifica() 
        {
            docAplicaRet = new List<DocAplicaRet>();
            docActualizarSaldoCxP = new List<DocActualizarSaldoCxP>();
        }

    }

}