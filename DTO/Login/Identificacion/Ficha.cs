﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Login.Identificacion
{
    
    public class Ficha
    {

        public string codigo { get; set; }
        public string clave { get; set; }


        public Ficha()
        {
            codigo = "";
            clave = "";
        }

    }

}