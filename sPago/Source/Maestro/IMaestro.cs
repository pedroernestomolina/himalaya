using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Maestro
{
    
    public interface IMaestro
    {

        string Titulo { get; }
        List<data> ListData { get; }
        bool AgregarItemIsOk { get; }
        bool EditarIsOk { get; }
        bool EliminarIsOk { get; }
        data ItemAgregar { get; }


        bool CargarData();
        void AgregarItem();
        void EditarItem(data ItemActual);
        void Inicializa();
        void EliminarItem(data ItemActual);
    }

}