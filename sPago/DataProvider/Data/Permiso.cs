﻿using sPago.DataProvider.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.Data
{

    public partial class Provider: IProvider
    {

        public OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloPago(string idGrupo)
        {
            var rt = new OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha>();

            var r01 = MyData.Permiso_Solicitud_ModuloPago(idGrupo);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var ent = r01.MiEntidad;
            rt.MiEntidad = new OOB.Permiso.Solictud.Ficha()
            {
                estatus = ent.estatus.Trim(),
                nivelSeguridad = ent.nivelSeguridad.Trim(),
            };

            return rt;
        }

        public OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_ElaborarRetencionISLR(string idGrupo)
        {
            var rt = new OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha>();

            var r01 = MyData.Permiso_Solicitud_ElaborarRetencionISLR(idGrupo);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var ent = r01.MiEntidad;
            rt.MiEntidad = new OOB.Permiso.Solictud.Ficha()
            {
                estatus = ent.estatus.Trim(),
                nivelSeguridad = ent.nivelSeguridad.Trim(),
            };

            return rt;
        }
        public OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_ModuloRetencionISLR(string idGrupo)
        {
            var rt = new OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha>();

            var r01 = MyData.Permiso_Solicitud_ModuloRetencionISLR(idGrupo);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var ent = r01.MiEntidad;
            rt.MiEntidad = new OOB.Permiso.Solictud.Ficha()
            {
                estatus = ent.estatus.Trim(),
                nivelSeguridad = ent.nivelSeguridad.Trim(),
            };

            return rt;
        }
        public OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_AdministradorRetencionISLR(string idGrupo)
        {
            var rt = new OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha>();

            var r01 = MyData.Permiso_Solicitud_AdministradorRetencionISLR(idGrupo);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var ent = r01.MiEntidad;
            rt.MiEntidad = new OOB.Permiso.Solictud.Ficha()
            {
                estatus = ent.estatus.Trim(),
                nivelSeguridad = ent.nivelSeguridad.Trim(),
            };

            return rt;
        }
        public OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_AnularRetencionISLR(string idGrupo)
        {
            var rt = new OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha>();

            var r01 = MyData.Permiso_Solicitud_AnularRetencionISLR(idGrupo);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var ent = r01.MiEntidad;
            rt.MiEntidad = new OOB.Permiso.Solictud.Ficha()
            {
                estatus = ent.estatus.Trim(),
                nivelSeguridad = ent.nivelSeguridad.Trim(),
            };

            return rt;
        }
        public OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha> Permiso_Solicitud_ReporteRetencionISLR(string idGrupo)
        {
            var rt = new OOB.Resultado.Entidad<OOB.Permiso.Solictud.Ficha>();

            var r01 = MyData.Permiso_Solicitud_ReporteRetencionISLR(idGrupo);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }
            var ent = r01.MiEntidad;
            rt.MiEntidad = new OOB.Permiso.Solictud.Ficha()
            {
                estatus = ent.estatus.Trim(),
                nivelSeguridad = ent.nivelSeguridad.Trim(),
            };

            return rt;
        }

    }

}