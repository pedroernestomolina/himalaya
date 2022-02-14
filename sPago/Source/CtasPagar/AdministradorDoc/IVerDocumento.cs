using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.CtasPagar.AdministradorDoc
{

    public interface IVerDocumento
    {

        void Inicializa();
        void setData(OOB.CtaPagar.Entidad.Ficha ficha);
        void Inicia();

    }

}