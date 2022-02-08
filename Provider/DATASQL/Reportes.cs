using Provider.IDATA;
using SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.DATASQL
{

    public partial class Provider: IProvider
    {

        public DTO.Resutado.Lista<DTO.Reportes.CtasPagar.DocumentosPorPagar.Ficha> Reportes_CtaPagar_DocumentosPorPagar(DTO.Reportes.CtasPagar.DocumentosPorPagar.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.Reportes.CtasPagar.DocumentosPorPagar.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("", "");
                    var p2 = new SqlParameter("", "");
                    var p3 = new SqlParameter("", "");
                    var sql_1 = @"SELECT 
                                    [fecha] as fechaEmision
                                    ,[tipo_documento] as tipoDoc
                                    ,[documento] as numeroDoc
                                    ,[fecha_vencimiento] as fechaVence
                                    ,[detalle] as detalleDoc
                                    ,[importe] as importeDoc
                                    ,[acumulado] as acumuladoDoc
                                    ,[proveedor] as provNombre
                                    ,[ci_rif] as provCiRif
                                    ,[codigo_proveedor] as provCodigo
                                    ,[resta] as restaDoc
                                    ,[signo] as signoDoc
                                    FROM cxp ";
                    var sql_2 = "where estatus='0' and cancelado='0' ";
                    if (filtro.desde.HasValue)
                    {
                        p1.Value = filtro.desde.Value;
                        p1.ParameterName = "@desde";
                        sql_2 += " and fecha>=@desde ";
                    }
                    if (filtro.hasta.HasValue)
                    {
                        p2.Value = filtro.hasta.Value;
                        p2.ParameterName = "@hasta";
                        sql_2 += " and fecha<=@hasta ";
                    }
                    if (filtro.idProv!= "")
                    {
                        p3.Value = filtro.idProv;
                        p3.ParameterName = "@autoProv";
                        sql_2 += " and auto_proveedor=@autoProv ";
                    }
                    var sql = sql_1 + sql_2;
                    var list = cn.Database.SqlQuery<DTO.Reportes.CtasPagar.DocumentosPorPagar.Ficha>(sql, p1, p2, p3).ToList();
                    rt.ListaEntidad = list;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.Lista<DTO.Reportes.CtasPagar.PagosEmitidos.Ficha> Reportes_CtaPagar_PagosEmitidos(DTO.Reportes.CtasPagar.PagosEmitidos.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.Reportes.CtasPagar.PagosEmitidos.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("", "");
                    var p2 = new SqlParameter("", "");
                    var p3 = new SqlParameter("", "");
                    var p4 = new SqlParameter("", "");
                    var sql_1 = @"SELECT 
                                    c.[numero] as numeroRecibo
                                    ,c.[fecha] as fechaRecibo
                                    ,c.[importe] as importeRecibo
                                    ,c.[detalle] as detalleRecibo
                                    ,c.[nombre_proveedor] as provNombre
                                    ,c.[ci_rif_proveedor] as provCiRif
                                    ,c.[codigo_proveedor] as provCodigo
                                    ,c.[estatus] as estatusRecibo
                                    ,c.[cant_doc_rel] as cntDocRel
                                    ,c.[monto_recibido] as montoRecibido
                                    ,c.[monto_cambio] as cambioDar
                                    ,c.[dirFiscal_proveedor] as provDir
                                    ,c.[telefono_proveedor] as provTel
                                    ,c.[nota] as nota,
	                                c1.importe as importePago, 
                                    c1.codigo_medio_pago as codMedioPago, 
                                    c1.desc_medio_pago as descMedioPago
                                    FROM [cxp_recibos] as c
                                    join cxp_modo_pago as c1 on c1.auto_recibo = c.auto";
                    var sql_2 = " where 1=1 ";
                    if (filtro.desde.HasValue)
                    {
                        p1.Value = filtro.desde.Value;
                        p1.ParameterName = "@desde";
                        sql_2 += " and c.fecha>=@desde ";
                    }
                    if (filtro.hasta.HasValue)
                    {
                        p2.Value = filtro.hasta.Value;
                        p2.ParameterName = "@hasta";
                        sql_2 += " and c.fecha<=@hasta ";
                    }
                    if (filtro.idProv != "")
                    {
                        p3.Value = filtro.idProv;
                        p3.ParameterName = "@autoProv";
                        sql_2 += " and c.auto_proveedor=@autoProv ";
                    }
                    if (filtro.estatus!= DTO.Reportes.CtasPagar.baseFiltro.enumEstatus.SinDefinir)
                    {
                        var _estatus = "0";
                        if (filtro.estatus == DTO.Reportes.CtasPagar.baseFiltro.enumEstatus.Anulado)
                        {
                            _estatus = "1";
                        }
                        p4.Value = _estatus;
                        p4.ParameterName = "@estatus";
                        sql_2 += " and c.estatus=@estatus ";
                    }

                    var sql = sql_1 + sql_2;
                    var list = cn.Database.SqlQuery<DTO.Reportes.CtasPagar.PagosEmitidos.Ficha>(sql, p1, p2, p3, p4).ToList();
                    rt.ListaEntidad = list;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.Lista<DTO.Reportes.CtasPagar.RelacionPagoDiario.Ficha> Reportes_CtaPagar_RelacionPagoDiario(DTO.Reportes.CtasPagar.RelacionPagoDiario.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.Reportes.CtasPagar.RelacionPagoDiario.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("", "");
                    var p2 = new SqlParameter("", "");
                    var p3 = new SqlParameter("", "");
                    var p4 = new SqlParameter("", "");
                    var sql_1 = @"SELECT 
                                    c.[numero] as numeroRecibo
                                    ,c.[fecha] as fechaRecibo
                                    ,c.[importe] as importeRecibo
                                    ,c.[detalle] as detalleRecibo
                                    ,c.[nombre_proveedor] as provNombre
                                    ,c.[ci_rif_proveedor] as provCiRif
                                    ,c.[codigo_proveedor] as provCodigo
                                    ,c.[estatus] as estatusRecibo
                                    ,c.[cant_doc_rel] as cntDocRel
                                    ,c.[monto_recibido] as montoRecibido
                                    ,c.[monto_cambio] as cambioDar
                                    ,c.[dirFiscal_proveedor] as provDir
                                    ,c.[telefono_proveedor] as provTel
                                    ,c.[nota] as nota
                                    FROM [cxp_recibos] as c ";
                    var sql_2 = " where 1=1  ";
                    if (filtro.desde.HasValue)
                    {
                        p1.Value = filtro.desde.Value;
                        p1.ParameterName = "@desde";
                        sql_2 += " and c.fecha>=@desde ";
                    }
                    if (filtro.hasta.HasValue)
                    {
                        p2.Value = filtro.hasta.Value;
                        p2.ParameterName = "@hasta";
                        sql_2 += " and c.fecha<=@hasta ";
                    }
                    if (filtro.idProv != "")
                    {
                        p3.Value = filtro.idProv;
                        p3.ParameterName = "@autoProv";
                        sql_2 += " and c.auto_proveedor=@autoProv ";
                    }
                    if (filtro.estatus != DTO.Reportes.CtasPagar.baseFiltro.enumEstatus.SinDefinir)
                    {
                        var _estatus = "0";
                        if (filtro.estatus == DTO.Reportes.CtasPagar.baseFiltro.enumEstatus.Anulado)
                        {
                            _estatus = "1";
                        }
                        p4.Value = _estatus;
                        p4.ParameterName = "@estatus";
                        sql_2 += " and c.estatus=@estatus ";
                    }

                    var sql = sql_1 + sql_2;
                    var list = cn.Database.SqlQuery<DTO.Reportes.CtasPagar.RelacionPagoDiario.Ficha>(sql, p1, p2, p3, p4).ToList();
                    rt.ListaEntidad = list;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }

    }

}