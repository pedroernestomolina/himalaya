﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.RetISLR.Lista
{
    
    public class Ficha
    {

        public string id { get; set; }
        public string tipoRetencion { get; set; }
        public string documento { get; set; }
        public DateTime deFecha { get; set; }
        public string nombreProv { get; set; }
        public string ciRifProv { get; set; }
        public decimal tasaRet { get; set; }
        public decimal montoRet { get; set; }
        public string estatus { get; set; }
        public decimal mExento { get; set; }
        public decimal mBase { get; set; }
        public decimal mIva { get; set; }
        public decimal mTotal { get; set; }


        public Ficha() 
        {
            id = "";
            tipoRetencion = "";
            documento = "";
            deFecha = DateTime.Now.Date;
            nombreProv = "";
            ciRifProv = "";
            tasaRet = 0m;
            montoRet = 0m;
            estatus = "";
            mExento = 0m;
            mBase = 0m;
            mIva = 0m;
            mTotal = 0m;
        }

    }

}