using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.VentasAdm.AdmFiltro.Handler
{
    public class ImpFiltro: __.Componente.Filtro.Handler.baseImp, Vista.IFiltroAdm
    {
        public ImpFiltro()
            :base()
        {
        }
        public override void Inicializa()
        {
            Desde.Inicializa();
            Hasta.Inicializa();
        }
        public override void Inicia()
        {
        }
        public override bool ValidacionIsOk()
        {
            var rt = true;
            if (Desde.IsActiva) 
            {
                if (Hasta.IsActiva) 
                {
                    if (Desde.Fecha > Hasta.Fecha)
                    {
                        Helpers.Msg.Alerta("FECHAS INCORRECTAS");
                        rt = false;
                    }
                }
            } 
            return rt;
        }
        public override object ObtenerFiltros()
        {
            Vista.Idata _data = new data()
            {
                desde = Desde.IsActiva ? Desde.Fecha : (DateTime?)null,
                hasta = Hasta.IsActiva ? Hasta.Fecha : (DateTime?)null,
            };
            return _data;
        }
        public override void Limpiar()
        {
            Desde.Limpiar();
            Hasta.Limpiar();
        }
    }
}