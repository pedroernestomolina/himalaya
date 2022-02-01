﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.IData
{

    public interface IProvider: ILogin, IUsuario, IPermiso, IConfiguracion,
        IProveedor, IRetISLR, IEmpresa, ISistema, ICtaPagar
    {

        OOB.Resultado.Entidad<DateTime> FechaSistema();

    }

}