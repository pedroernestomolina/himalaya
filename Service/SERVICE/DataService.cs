using Service.ISERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.SERVICE
{
    
    public partial class DataService: IDataService
    {
        
        public static Provider.IDATA.IProvider ServiceProv;


        public DataService(string instancia, string bd)
        {
            ServiceProv = new Provider.DATASQL.Provider(instancia, bd);
        }

    }

}