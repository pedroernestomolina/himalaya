using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Reportes.CtaPagar.RelacionPagoProveedor
{
    
    public class Filtro: Filtrar.IFiltrar
    {

        private List<Filtrar.ficha> _lstTipoDoc;
        private List<Filtrar.ficha> _lstEstatus;


        public List<Filtrar.ficha> ListTipoDoc { get { return _lstTipoDoc; } }
        public List<Filtrar.ficha> ListEstatus { get { return _lstEstatus; } }


        public Filtro() 
        {
            _lstTipoDoc = new List<Filtrar.ficha>();
            _lstEstatus = new List<Filtrar.ficha>();
        }


        public bool CargarData()
        {
            var rt = true;

            _lstTipoDoc.Clear();
            _lstEstatus.Clear();

            return rt; ;
        }

    }

}