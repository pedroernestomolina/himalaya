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

        public DTO.Resutado.Lista<DTO.ToolPago.ResumenPendPagar.Ficha> ToolPago_ResumenPendPagar_GetLista()
        {
            var rt = new DTO.Resutado.Lista<DTO.ToolPago.ResumenPendPagar.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("", "");
                    var p2 = new SqlParameter("", "");
                    var p3 = new SqlParameter("", "");
                    var p4 = new SqlParameter("", "");
                    var p5 = new SqlParameter("", "");
                    var sql_1 = @"SELECT 
                                    sum([importe]) as importe,
                                    sUM([acumulado]) as acumulado,
                                    [auto_proveedor] as provId,
                                    [proveedor] as provNombre,
                                    [ci_rif] as provCiRif,
                                    sum([resta]) as resta,
                                    count(*) as cntDoc
                                    FROM [cxp]
                                    where estatus='0' and cancelado='0'
                                    group by auto_proveedor, proveedor, ci_rif";
                    var sql = sql_1;
                    var list = cn.Database.SqlQuery<DTO.ToolPago.ResumenPendPagar.Ficha>(sql, p1, p2, p3, p4, p5).ToList();
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
        public DTO.Resutado.Entidad<DTO.ToolPago.ResumenPendPagar.Ficha> ToolPago_ResumenPendPagar_GetByIdProveedor(string idProv)
        {
            var rt = new DTO.Resutado.Entidad<DTO.ToolPago.ResumenPendPagar.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("@p1", idProv);
                    var sql_1 = @"SELECT 
                                    sum([importe]) as importe,
                                    sUM([acumulado]) as acumulado,
                                    [auto_proveedor] as provId,
                                    [proveedor] as provNombre,
                                    [ci_rif] as provCiRif,
                                    sum([resta]) as resta,
                                    count(*) as cntDoc
                                    FROM [cxp]
                                    where estatus='0' and cancelado='0' and auto_proveedor=@p1
                                    group by auto_proveedor, proveedor, ci_rif";
                    var sql = sql_1;
                    var ent = cn.Database.SqlQuery<DTO.ToolPago.ResumenPendPagar.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                        rt.MiEntidad = new DTO.ToolPago.ResumenPendPagar.Ficha();
                    else
                        rt.MiEntidad = ent;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.Lista<DTO.ToolPago.PendPagar.Ficha> ToolPago_PendPagar_GetByIdProv(string idProv)
        {
            var rt = new DTO.Resutado.Lista<DTO.ToolPago.PendPagar.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("@p1", idProv);
                    var sql_1 = @"SELECT 
                                    auto as autoDoc,
                                    [fecha] as fechaEmision
                                    ,[tipo_documento] as tipoDoc
                                    ,[documento] as numeroDoc
                                    ,[fecha_vencimiento] as fechaVence
                                    ,[detalle] as detalleDoc
                                    ,[importe] as importeDoc
                                    ,[acumulado] as acumuladoDoc
                                    ,[resta] as restaDoc
                                    ,[signo] as signoDoc
                                    FROM cxp ";
                    var sql_2 = "where estatus='0' and cancelado='0' and auto_proveedor = @p1 ";
                    var sql = sql_1 + sql_2;
                    var list = cn.Database.SqlQuery<DTO.ToolPago.PendPagar.Ficha>(sql, p1).ToList();
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