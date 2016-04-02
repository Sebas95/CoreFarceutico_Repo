using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FarmaTicaWebService.Models;
using FarmaTicaWebService.DataBase;

namespace FarmaTicaWebService.Controllers
{
    public class ReportesController : ApiController
    {
        private ReportesAccess databaseAccess = new ReportesAccess();

        [Route("api/Reportes/ProductosMasVendidos")]
        public List<ProductosMasVendidos> GetProductosMasVendidos()
        {
            return databaseAccess.getAllProductosMasVendidos();
        }
        [Route("api/Reportes/ProductosMasVendidosPorNuevoSoftware")]
        public List<ProductosMasVendidos> GetProductosMasVendidosPorNuevoSoftware()
        {
            return databaseAccess.getAllProductosMasVendidosPorNuevoSoftware();
        }
        [Route("api/Reportes/CantidadDeVentasPorEmpresa/{Empresa}")]
        public List<Venta> GetCantidadDeVentasPorEmpresa(string Empresa)
        {
            return databaseAccess.getCantidadDeVentasPorEmpresa(Empresa);
        }
        [Route("api/Reportes/ProductosMasVendidosPorEmpresa/{Empresa}")]
        public List<ProductosMasVendidos> GetProductosMasVendidosPorEmpresa(string Empresa)
        {
            return databaseAccess.getProductosMasVendidosPorEmpresa(Empresa);
        }
        [Route("api/Reportes/TotalVendidoPorEmpresa/{Empresa}")]
        public TotalVendido GetTotalVendidoPorEmpresa(string Empresa)
        {
            return databaseAccess.getTotalVendidoPorEmpresa(Empresa);
        }

    }
}
