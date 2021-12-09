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

        public DTO.Resutado.Lista<DTO.Proveedor.Lista.Ficha> Proveedor_GetLista(DTO.Proveedor.Lista.Filtro filtro)
        {
            var rt = new DTO.Resutado.Lista<DTO.Proveedor.Lista.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var p1 = new SqlParameter("","");
                    var sql = @"select p.auto as id, p.codigo, p.nombre as nombreRazonSocial, p.ci_rif as ciRif, 
                        p.dir_fiscal as dirFiscal, p.estatus 
                        FROM proveedores as p 
                        where 1=1 ";
                    var valor = "";
                    if (filtro.cadena != "")
                    {
                        if (filtro.metodoBusq== DTO.Proveedor.enumerados.metodosBusq.PorCodigo)
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                sql += " and p.codigo like @p";
                                valor = "%" + cad + "%";
                            }
                            else
                            {
                                sql += " and p.codigo like @p";
                                valor = cad + "%";
                            }
                        }
                        if (filtro.metodoBusq == DTO.Proveedor.enumerados.metodosBusq.PorRazaonSocial)
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                sql += " and p.nombre like @p";
                                valor = "%" + cad + "%";
                            }
                            else
                            {
                                sql += " and p.nombre like @p";
                                valor = cad + "%";
                            }
                        }
                        if (filtro.metodoBusq ==  DTO.Proveedor.enumerados.metodosBusq.PorCirif)
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                sql += " and p.ci_rif like @p";
                                valor = "%" + cad + "%";
                            }
                            else
                            {
                                sql += " and p.ci_rif like @p";
                                valor = cad + "%";
                            }
                        }
                        p1.ParameterName = "@p";
                        p1.Value = valor;
                    }
                    var list = cn.Database.SqlQuery<DTO.Proveedor.Lista.Ficha>(sql, p1).ToList();
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

        public DTO.Resutado.Entidad<DTO.Proveedor.Entidad.Ficha> Proveedor_GetById(string idProv)
        {
            var rt = new DTO.Resutado.Entidad<DTO.Proveedor.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var ent = cn.proveedores.Find(idProv);
                    if (ent == null)
                    {
                        rt.Mensaje = "ID PROVEEDOR NO ENCONTRADO";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        return rt;
                    }

                    var nr = new DTO.Proveedor.Entidad.Ficha()
                    {
                        celular1 = ent.Celular_1,
                        celular2 = ent.Celular_2,
                        ciRif = ent.ci_rif,
                        codigo = ent.codigo,
                        contacto = ent.contacto,
                        dirFiscal = ent.dir_fiscal,
                        email = ent.email,
                        estatus = ent.estatus,
                        fechaAlta = ent.fecha_alta,
                        id = ent.auto,
                        nombreRazonSocial = ent.nombre,
                        retISLR = ent.retencion_islr,
                        retIVA = ent.retencion_iva,
                        telefono1 = ent.Telefono_1,
                        telefono2 = ent.Telefono_2,
                        telefono3 = ent.Telefono_3,
                        telefono4 = ent.Telefono_4,
                    };
                    rt.MiEntidad = nr;
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