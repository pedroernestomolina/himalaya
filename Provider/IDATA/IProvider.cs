using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.IDATA
{
    public interface IProvider : ILogin , IUsuario, IPermiso, 
        IProveedor, IConfiguracion, IRetISLR, IEmpresa, ISistema, 
        ICtaPagar, IReportes, IToolPago, IMedioPago, IVentaAdm
    {
        DTO.Resutado.Entidad<DateTime> FechaSistema();
    }
}