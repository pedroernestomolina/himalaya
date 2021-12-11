using sPago.DataProvider.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.Data
{
    
    public partial class Provider: IProvider
    {


        public static Service.ISERVICE.IDataService MyData;


        public Provider(string instancia, string bd)
        {
            MyData = new Service.SERVICE.DataService(instancia, bd);
        }

    }

}