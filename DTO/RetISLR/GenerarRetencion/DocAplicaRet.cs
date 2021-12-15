using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.RetISLR.GenerarRetencion
{
    
    public class DocAplicaRet
    {

        public string autoDoc { get; set; }
        public decimal tasaAplica { get; set; }
        public decimal montoAplica { get; set; }


        public DocAplicaRet() 
        {
            autoDoc = "";
            tasaAplica = 0m;
            montoAplica = 0m;
        }

    }

}