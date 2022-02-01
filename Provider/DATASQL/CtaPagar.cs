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

        public DTO.Resutado.Lista<DTO.CtaPagar.Lista.Ficha> CtaPagar_GetLista(DTO.CtaPagar.Lista.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.CtaPagar.Lista.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("","");
                    var p2 = new SqlParameter("","");
                    var p3 = new SqlParameter("","");
                    var p4 = new SqlParameter("","");
                    var p5 = new SqlParameter("","");
                    var sql_1 = @"select auto as autoDoc, auto_proveedor as autoProveedor, documento as numDoc, 
                                fecha as fechaEmisionDoc, fecha_vencimiento as fechaVenceDoc, importe as importeDoc,
                                resta as restaDoc, proveedor as provNombre, ci_rif as provCiRif, estatus as estatusDoc, 
                                signo as signoDoc, acumulado as abonadoDoc, tipo_documento as tipoDoc, detalle as detalleDoc
                                from cxp";
                    var sql_2=" where 1=1 ";
                    if (filtro.desde .HasValue)
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
                    if (filtro.autoProv != "")
                    {
                        p3.Value = filtro.autoProv;
                        p3.ParameterName = "@autoProv";
                        sql_2 += " and auto_proveedor=@autoProv ";
                    }
                    if (filtro.estatus !=  DTO.CtaPagar.Lista.Filtro.enumEstatus.SinDefinir)
                    {
                        p4.Value = filtro.estatus == DTO.CtaPagar.Lista.Filtro.enumEstatus.Activo ? "0" : "1";
                        p4.ParameterName = "@estatus";
                        sql_2 += " and estatus=@estatus ";
                    }
                    if (filtro.tipoDoc != DTO.CtaPagar.Lista.Filtro.enumTipoDoc.SinDefinir)
                    {
                        var tipo = "";
                        switch (filtro.tipoDoc) 
                        {
                            case DTO.CtaPagar.Lista.Filtro.enumTipoDoc.Factura:
                                tipo = "FAC";
                                break;
                            case DTO.CtaPagar.Lista.Filtro.enumTipoDoc.NtaCredito:
                                tipo = "NCF";
                                break;
                            case DTO.CtaPagar.Lista.Filtro.enumTipoDoc.Pago:
                                tipo = "PAG";
                                break;
                            case DTO.CtaPagar.Lista.Filtro.enumTipoDoc.Retencion:
                                tipo = "IR";
                                break;
                            case DTO.CtaPagar.Lista.Filtro.enumTipoDoc.DocPorLiquidar:
                                sql_2 += " and cancelado='0' ";
                                break;
                        }
                        if (tipo != "") 
                        {
                            p5.Value = tipo;
                            p5.ParameterName = "@tipo";
                            sql_2 += " and tipo_documento=@tipo ";
                        }
                    }
                    var sql = sql_1 + sql_2;
                    var list = cn.Database.SqlQuery<DTO.CtaPagar.Lista.Ficha>(sql, p1, p2, p3, p4, p5).ToList();
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