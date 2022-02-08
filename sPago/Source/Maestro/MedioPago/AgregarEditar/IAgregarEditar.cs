using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.Maestro.MedioPago.AgregarEditar
{
    
    public interface IAgregarEditar
    {

        bool AgregarIsOk { get; }
        int IdItemAgregado { get; }
        bool EditarIsOk { get; }
        bool ProcesarIsOK { get; }


        void Inicializa();
        void Inicia();
        void setModoAgregar(string p);
        void setModoEditar(string p, Maestro.data dt);
    }

}