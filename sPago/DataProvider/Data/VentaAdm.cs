using sPago.DataProvider.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.DataProvider.Data
{
    public partial class Provider: IProvider
    {
        //REPORTES
        public OOB.Resultado.Entidad<OOB.VentaAdm.Reportes.Documentos.Factura.Ficha> 
            VentasAdm_Reportes_Documentos_Factura_GetById(string idDoc)
        {
            var rt = new OOB.Resultado.Entidad<OOB.VentaAdm.Reportes.Documentos.Factura.Ficha>();
            //
            var r01 = MyData.VentasAdm_Reportes_Documentos_Factura_GetById(idDoc);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            //
            if (r01.MiEntidad ==null)
            {
                throw new Exception("FICHA NO FUE CARGADA CORRECTAMENTE");
            }
            //
            if (r01.MiEntidad.documento ==null)
            {
                throw new Exception("DATOS DEL ENCABEZADO NO FUERON CARGADOS CORRECTAMENTE");
            }
            //
            if (r01.MiEntidad.items ==null)
            {
                throw new Exception("ITEMS NO FUERON CARGADOS CORRECTAMENTE");
            }
            if (r01.MiEntidad.items.Count<=0)
            {
                throw new Exception("LISTA DE ITEMS ESTA VACIA");
            }
            //
            var doc= r01.MiEntidad.documento;
            var enc = new OOB.VentaAdm.Reportes.Documentos.Factura.Doc()
            {
                ciRifCliente = doc.ciRifCliente.Trim(),
                codCliente = doc.codCliente.Trim(),
                codVendedor = doc.codVendedor.Trim(),
                codSucursal = doc.codSucursal.Trim(),
                codUsuario = doc.codUsuario.Trim(),
                condicionPagoDoc = doc.condicionPagoDoc.Trim(),
                diasCredito = doc.diasCredito,
                dirDespCliente = doc.dirDespCliente.Trim(),
                dirFiscalCliente = doc.dirFiscalCliente.Trim(),
                fechaEmDoc = doc.fechaEmDoc,
                fechaPedido = doc.fechaPedido,
                fechaVencDoc = doc.fechaVencDoc,
                nombreCliente = doc.nombreCliente.Trim(),
                nombreUsuario = doc.nombreUsuario.Trim(),
                nombreVendedor = doc.nombreVendedor.Trim(),
                numeroDoc = doc.numeroDoc.Trim(),
                numeroOrdenCompra = doc.numeroOrdenCompra.Trim(),
                numeroPedido = doc.numeroPedido.Trim(),
                telefCliente = doc.telefCliente.Trim(),
                //
                base1 = doc.base1,
                base2 = doc.base2,
                base3 = doc.base3,
                cargoMonto = doc.cargoMonto,
                cargoPorct = doc.cargoPorct,
                dsctoMonto = doc.dsctoMonto,
                dsctoPorct = doc.dsctoPorct,
                exento = doc.exento,
                impuesto = doc.impuesto,
                iva1 = doc.iva1,
                iva2 = doc.iva2,
                iva3 = doc.iva3,
                notas = doc.notas,
                subTotal = doc.subTotal,
                tasa1 = doc.tasa1,
                tasa2 = doc.tasa2,
                tasa3 = doc.tasa3,
                total = doc.total,
            };
            var det= new List<OOB.VentaAdm.Reportes.Documentos.Factura.Item>();
            det = r01.MiEntidad.items.Select(s =>
            {
                var rg = new OOB.VentaAdm.Reportes.Documentos.Factura.Item()
                {
                    idPrd = s.idPrd.Trim(),
                    idDepart = s.idDepart.Trim(),
                    idGrupo = s.idGrupo.Trim(),
                    idSubGrupo = s.idSubGrupo.Trim(),
                    codigoPrd = s.codigoPrd.Trim(),
                    descPrd = s.descPrd.Trim(),
                    nombreDepart = s.nombreDepart.Trim(),
                    nombreGrupo = s.nombreGrupo.Trim(),
                    nombreSubGrupo = s.nombreSubGrupo.Trim(),
                    cantidad = s.cantidad,
                    contEmp = s.contEmp,
                    descEmp = s.descEmp,
                    importeNeto = s.importeNeto,
                    precioNeto = s.precioNeto,
                    impuesto = s.impuesto,
                    tasaIva = s.tasaIva,
                    total = s.total,
                };
                return rg;
            }).ToList();
            //
            rt.MiEntidad = new OOB.VentaAdm.Reportes.Documentos.Factura.Ficha()
            {
                documento = enc,
                items = det,
            };
            //
            return rt;
        }
        //
        public OOB.Resultado.Lista<OOB.VentaAdm.AdmDoc.Ficha> 
            VentasAdm_AdmDocumento_GetLista(OOB.VentaAdm.AdmDoc.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.VentaAdm.AdmDoc.Ficha>();
            //
            var filtroDTO = new DTO.VentaAdm.AdmDoc.Filtro()
            {
                desde = filtro.desde,
                hasta = filtro.hasta,
                PorTipoDocumento = (DTO.VentaAdm.__.enumerados.TipoDocumento)filtro.PorTipoDocumento,
            };
            var r01 = MyData.VentasAdm_AdmDocumento_GetLista(filtroDTO);
            if (r01.Result == DTO.Resutado.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            //
            if (r01.ListaEntidad == null)
            {
                throw new Exception("ITEMS NO FUERON CARGADOS CORRECTAMENTE");
            }
            //
            var _lst = new List<OOB.VentaAdm.AdmDoc.Ficha>();
            if (r01.ListaEntidad.Count > 0)
            {
                rt.ListaEntidad = r01.ListaEntidad.Select(s =>
                {
                    var nr = new OOB.VentaAdm.AdmDoc.Ficha()
                    {
                        ciRifEnt = s.ciRifEnt.Trim(),
                        codTipoDoc = s.codTipoDoc.Trim(),
                        estatusAnulado = s.estatusAnulado.Trim(),
                        fechaEmision = s.fechaEmision,
                        fechaVence = s.fechaVence,
                        idDoc = s.idDoc.Trim(),
                        importeDoc = s.importeDoc,
                        nombreEnt = s.nombreEnt.Trim(),
                        numeroDoc = s.numeroDoc.Trim(),
                        diasCredito= s.diasCredito,
                    };
                    return nr;
                }).ToList();
            }
            else 
            {
                rt.ListaEntidad = new List<OOB.VentaAdm.AdmDoc.Ficha>();
            }
            //
            return rt;
        }
    }
}