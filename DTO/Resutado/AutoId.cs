using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Resutado
{

    public class AutoId : Ficha
    {

        public string Auto { get; set; }
        public int Id  {get;set;}

        public AutoId()
            : base()
        {
            Auto = "";
            Id = -1;
        }

    }

}