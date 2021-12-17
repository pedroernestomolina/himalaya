﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.OOB.RetISLR.AnularRetencion.CapturarData
{
    
    public class DocCompraAplicaRetencion
    {

        public string autoDocCompra { get; set; }
        public string autoCxP { get; set; }
        public decimal montoAplica { get; set; }


        public DocCompraAplicaRetencion()
        {
            autoDocCompra = "";
            autoCxP = "";
            montoAplica = 0m;
        }

    }

}