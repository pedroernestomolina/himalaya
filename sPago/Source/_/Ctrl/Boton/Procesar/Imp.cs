using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.__.Ctrl.Boton.Procesar
{
    public class Imp: baseImp, IProcesar
    {
        public Imp()
            :base()
        {
        }
        public override void Opcion()
        {
            _opcion = Helpers.Msg.Procesar();
        }
        public void setOpcion(bool p)
        {
            _opcion = p;
        }
    }
}
