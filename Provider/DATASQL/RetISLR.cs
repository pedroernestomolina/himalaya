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

        public DTO.Resutado.Lista<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentosPendPorAplicar_GetLista(DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("", "");
                    var sql_1 = @"select 
                        c.auto as autoDoc,
                        c.documento as numDoc,
                        c.control as numControlDoc,
                        c.n_serie as serieDoc,
                        c.fecha as fechaDoc,
                        c.tipo as tipoDoc,
                        c.base  as montoBase,
                        c.exento as montoExento,
                        c.impuesto as montoIva,
                        c.total as total,
                        c.estatus as estatus
                        FROM compras as c ";
                    var sql_2= " where 1=1 and comprobante_retencion_islr='' ";
                    if (filtro.idProv!= "")
                    {
                        p1.ParameterName = "idProv";
                        p1.Value = filtro.idProv;
                        sql_2 += " and c.auto_entidad=@idProv ";
                    }
                    var sql = sql_1 + sql_2;
                    var lst = cn.Database.SqlQuery<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>(sql, p1).ToList();
                    rt.ListaEntidad = lst;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }

        public DTO.Resutado.Entidad<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha> RetISLR_DocumentoPendPorAplicar_GetByIdDoc(string idDoc)
        {
            var rt = new DTO.Resutado.Entidad<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("idDoc", idDoc);
                    var sql_1 = @"select 
                        c.auto as autoDoc,
                        c.documento as numDoc,
                        c.control as numControlDoc,
                        c.n_serie as serieDoc,
                        c.fecha as fechaDoc,
                        c.tipo as tipoDoc,
                        c.base  as montoBase,
                        c.exento as montoExento,
                        c.impuesto as montoIva,
                        c.total as total,
                        c.estatus as estatus
                        FROM compras as c ";
                    var sql_2 = " where c.auto=@idDoc ";
                    var sql = sql_1 + sql_2;
                    var ent = cn.Database.SqlQuery<DTO.RetISLR.DocumentoPendPorAplicar.Entidad.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        rt.Mensaje = "ID DOCUMENTO NO ENCONTRADO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                    }
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

        public DTO.Resutado.Entidad<string> RetISLR_DocumentoPendPorAplicar_CtaxPagar(DTO.RetISLR.DocumentoPendPorAplicar.CxPagar.Filtro filtro)
        {
            var rt = new DTO.Resutado.Entidad<string>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("idDoc", filtro.idDoc);
                    var p2 = new SqlParameter("tipoDoc", filtro.tipoDoc);
                    var sql_1 = @"select 
                        auto as autoDoc
                        FROM cxp ";
                    var sql_2 = " where 1=1 and auto_documento=@idDoc and tipo_documento=@tipoDoc ";
                    var sql = sql_1 + sql_2;
                    var ent = cn.Database.SqlQuery<string>(sql, p1, p2).FirstOrDefault();
                    if (ent == null)
                    {
                        rt.Mensaje = "DOCUMENTO POR PAGAR NO ENCONTRADO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }

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

        public DTO.Resutado.AutoId RetISLR_GenerarRetencion(DTO.RetISLR.GenerarRetencion.Ficha ficha)
        {
            throw new NotImplementedException();
        }

    }

}