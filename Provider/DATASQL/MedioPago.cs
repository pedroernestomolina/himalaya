using Provider.IDATA;
using SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace Provider.DATASQL
{

    public partial class Provider: IProvider
    {

        public DTO.Resutado.Lista<DTO.MedioPago.Entidad.Ficha> MedioPago_GetLista()
        {
            var rt = new DTO.Resutado.Lista<DTO.MedioPago.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var sql_1 = @"select id, codigo, descripcion 
                                from medios_pago_cxp";
                    var sql_2 = " where 1=1 ";
                    var sql = sql_1 + sql_2;
                    var list = cn.Database.SqlQuery<DTO.MedioPago.Entidad.Ficha>(sql).ToList();
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
        public DTO.Resutado.Entidad<DTO.MedioPago.Entidad.Ficha> MedioPago_GetById(int id)
        {
            var rt = new DTO.Resutado.Entidad<DTO.MedioPago.Entidad.Ficha>();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    var ent = cn.medios_pago_cxp.Find(id);
                    if (ent == null) 
                    {
                        rt.Mensaje = "[ ID ] ENTIDAD NO ENCONTRADA";
                        rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                    };
                    var mp = new DTO.MedioPago.Entidad.Ficha()
                    {
                        id = ent.id,
                        codigo = ent.codigo,
                        descripcion = ent.descripcion,
                    };
                    rt.MiEntidad=mp;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.AutoId MedioPago_Agregar(DTO.MedioPago.Agregar.Ficha ficha)
        {
            var rt = new DTO.Resutado.AutoId();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = new medios_pago_cxp()
                        {
                            codigo = ficha.codigo,
                            descripcion = ficha.descripcion
                        };
                        cn.medios_pago_cxp.Add(ent);
                        cn.SaveChanges();

                        ts.Complete();
                        rt.Id = ent.id;
                        rt.Auto = "";
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                var dbUpdateEx = ex as System.Data.Entity.Infrastructure.DbUpdateException;
                var sqlEx = dbUpdateEx.InnerException;
                if (sqlEx != null)
                {
                    var exx = (SqlException)sqlEx.InnerException;
                    if (exx != null)
                    {
                        if (exx.Number == 1452)
                        {
                            rt.Mensaje = "PROBLEMA DE CLAVE FORANEA" + Environment.NewLine + exx.Message;
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        else if (exx.Number == 2601)
                        {
                            rt.Mensaje = "CODIGO YA REGISTRADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        else
                        {
                            rt.Mensaje = exx.Message;
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                    }
                }
                rt.Mensaje = ex.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.Ficha MedioPago_Editar(DTO.MedioPago.Editar.Ficha ficha)
        {
            var rt = new DTO.Resutado.AutoId();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = cn.medios_pago_cxp.Find(ficha.id);
                        if (ent == null)
                        {
                            rt.Mensaje = "[ ID ] ENTIDAD NO ENCONTRADA";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        };
                        ent.codigo = ficha.codigo;
                        ent.descripcion = ficha.descripcion;
                        cn.SaveChanges();

                        ts.Complete();
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                var dbUpdateEx = ex as System.Data.Entity.Infrastructure.DbUpdateException;
                var sqlEx = dbUpdateEx.InnerException;
                if (sqlEx != null)
                {
                    var exx = (SqlException)sqlEx.InnerException;
                    if (exx != null)
                    {
                        if (exx.Number == 1452)
                        {
                            rt.Mensaje = "PROBLEMA DE CLAVE FORANEA" + Environment.NewLine + exx.Message;
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        else if (exx.Number == 2601)
                        {
                            rt.Mensaje = "CODIGO YA REGISTRADO";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        else
                        {
                            rt.Mensaje = exx.Message;
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                    }
                }
                rt.Mensaje = ex.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DTO.Resutado.Ficha MedioPago_Eliminar(int id)
        {
            var rt = new DTO.Resutado.AutoId();

            try
            {
                using (var cn = new EPago(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = cn.medios_pago_cxp.Find(id);
                        if (ent == null)
                        {
                            rt.Mensaje = "[ ID ] ENTIDAD NO ENCONTRADA";
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                        };
                        cn.medios_pago_cxp.Remove(ent);
                        cn.SaveChanges();

                        ts.Complete();
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                var dbUpdateEx = ex as System.Data.Entity.Infrastructure.DbUpdateException;
                var sqlEx = dbUpdateEx.InnerException;
                if (sqlEx != null)
                {
                    var exx = (SqlException)sqlEx.InnerException;
                    if (exx != null)
                    {
                        if (exx.Number == 1452)
                        {
                            rt.Mensaje = "PROBLEMA DE CLAVE FORANEA" + Environment.NewLine + exx.Message;
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        else
                        {
                            rt.Mensaje = exx.Message;
                            rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
                            return rt;
                        }
                    }
                }
                rt.Mensaje = ex.Message;
                rt.Result = DTO.Resutado.Enumerados.EnumResult.isError;
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