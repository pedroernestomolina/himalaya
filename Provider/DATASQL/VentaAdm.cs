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
        public DTO.Resutado.Entidad<DTO.VentaAdm.Reportes.Documentos.Factura.Ficha>
            VentasAdm_Reportes_Documentos_Factura_GetById(string idDoc)
        {
            var rt = new DTO.Resutado.Entidad<DTO.VentaAdm.Reportes.Documentos.Factura.Ficha>();
            //
            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var sql = @"select 
                            		vta.documento as numeroDoc,
		                            vta.fecha as fechaEmDoc,
		                            vta.fecha_vencimiento as fechaVencDoc,
		                            vta.condicion_pago as condicionPagoDoc,
		                            vta.dias as diasCredito,
		                            vta.orden_compra as numeroOrdenCompra,
		                            vta.pedido as numeroPedido,
		                            vta.fecha_pedido as fechaPedido,
		                            vta.codigo_vendedor as codVendedor,
		                            vta.vendedor as nombreVendedor,
		                            vta.codigo_usuario as codUsuario,
		                            vta.usuario as nombreUsuario,
		                            vta.codigo_sucursal as codSucursal,
		                            vta.nombre as nombreCliente,
		                            vta.ci_rif as ciRifCliente,
		                            vta.dir_fiscal as dirFiscalCliente,
		                            vta.codigo_entidad as codCliente,
		                            vta.telefono as telefCliente,
		                            vta.dir_despacho as dirDespCliente,
		                            vta.subtotal,
		                            vta.exento as exento,
		                            vta.base1 as base1,
		                            vta.base2 as base2,
		                            vta.base3 as base3,
		                            vta.impuesto1 as iva1,
		                            vta.impuesto2 as iva2,
		                            vta.impuesto3 as iva3,
		                            vta.tasa1 as tasa1,
		                            vta.tasa2 as tasa2,
		                            vta.tasa3 as tasa3,
		                            vta.impuesto as impuesto,
		                            vta.descuento1 as dsctoMonto,
		                            vta.cargos as cargoMonto,
		                            vta.descuento1_porcentaje as dsctoPorc,
		                            vta.cargos_porcentaje as cargoPorct,
		                            vta.total as total,
		                            vta.nota as notas
                                FROM ventas as vta
                                where auto=@idDoc";
                    var p1 = new SqlParameter("@idDoc", idDoc);
                    var ent = cn.Database.SqlQuery<DTO.VentaAdm.Reportes.Documentos.Factura.Doc>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        rt.Mensaje = "DOCUMENTO NO ENCONTRADO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    //
                    sql = @"select 
                                vd.auto_productos as idPrd,
                                vd.codigo as codigoPrd,
                                vd.nombre as descPrd,
                                vd.cantidad as cantidad,
                                vd.empaque as descEmp,
                                vd.contenido_empaque as contEmp,
                                vd.precio_neto as precioNeto,
                                vd.total_neto as importeNeto,
                                vd.tasa as tasaIva,
                                vd.impuesto as impuesto,
                                vd.total as total,
                                prdDepart.auto as idDepart,
                                prdDepart.nombre as nombreDepart,
                                prdGrupo.auto as idGrupo,
                                prdGrupo.nombre as nombreGrupo,
                                prdSubGrupo.auto as idSubGrupo,
                                prdSubGrupo.nombre as nombreSubGrupo
                            FROM ventas_detalle as vd
                            join productos_departamento as prdDepart on vd.auto_departamento=prdDepart.auto
                            join productos_grupo as prdGrupo on vd.auto_grupo=prdGrupo.auto
                            join productos_subgrupo as prdSubGrupo on vd.auto_subgrupo=prdSubGrupo.auto
                            where auto_documento=@idDoc";
                    p1 = new SqlParameter("@idDoc", idDoc);
                    var det = cn.Database.SqlQuery<DTO.VentaAdm.Reportes.Documentos.Factura.Item>(sql, p1).ToList();
                    //
                    rt.MiEntidad = new DTO.VentaAdm.Reportes.Documentos.Factura.Ficha()
                    {
                        documento = ent,
                        items = det,
                    };
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        //
        public DTO.Resutado.Lista<DTO.VentaAdm.AdmDoc.Ficha> 
            VentasAdm_AdmDocumento_GetLista(DTO.VentaAdm.AdmDoc.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.VentaAdm.AdmDoc.Ficha>();
            //
            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("", "");
                    var p2 = new SqlParameter("", "");
                    var p3 = new SqlParameter("", "");
                    var sql_1 = @"select 
		                                vta.auto as idDoc,
		                                vta.documento as numeroDoc,
		                                vta.fecha as fechaEmision,
		                                vta.fecha_vencimiento as fechaVence,
		                                vta.nombre as nombreEnt,
		                                vta.ci_rif as ciRifEnt,
		                                vta.total as importeDoc,
		                                vta.estatus as estatusAnulado,
		                                vta.tipo as codTipoDoc,
                                        vta.dias as diasCredito
                                FROM ventas as vta ";
                    var sql_2 = @" where 1=1 ";
                    if (filtro != null) 
                    {
                        if (filtro.desde.HasValue) 
                        {
                            sql_2 += " and vta.fecha>=@desde ";
                            p1.ParameterName = "@desde";
                            p1.Value = filtro.desde.Value;
                        }
                        if (filtro.hasta.HasValue)
                        {
                            sql_2 += " and vta.fecha<=@hasta ";
                            p2.ParameterName = "@hasta";
                            p2.Value = filtro.hasta.Value;
                        }
                        if (filtro.PorTipoDocumento != DTO.VentaAdm.__.enumerados.TipoDocumento.SinDefinir)
                        {
                            sql_2 += " and vta.tipo=@tipoDoc ";
                            p3.ParameterName = "@tipoDoc";
                            p3.Value = DTO.VentaAdm.__.enumerados.Get_TipoDocumento(filtro.PorTipoDocumento);
                        }
                    }
                    var sql = sql_1 + sql_2;
                    rt.ListaEntidad = cn.Database.SqlQuery<DTO.VentaAdm.AdmDoc.Ficha>(sql, p1, p2, p3).ToList();
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
    }
}