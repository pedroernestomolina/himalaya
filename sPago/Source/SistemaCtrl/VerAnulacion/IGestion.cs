using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.SistemaCtrl.VerAnulacion
{
    
    public interface IGestion
    {

        void Inicializa();
        void Inicia();
        void setData(OOB.Sistema.DocAnulado.Entidad.Ficha ficha);

    }

}