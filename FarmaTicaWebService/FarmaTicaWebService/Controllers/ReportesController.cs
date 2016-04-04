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
        /// <summary>
        /// Anobject with access to the database
        /// </summary>
        private ReportesAccess databaseAccess = new ReportesAccess();

        /// <summary>
        ///  Returns the name and quantity of products that are more often saled
        /// </summary>
        /// <returns> List<ProductosMasVendidos> </returns>
        [Route("api/Reportes/ProductosMasVendidos")]
        public List<ProductosMasVendidos> GetProductosMasVendidos()
        {
            return databaseAccess.getAllProductosMasVendidos();
        }
        /// <summary>
        ///  Returns the name and quantity of products that are more often saled by the new software
        /// </summary>
        /// <returns> List<ProductosMasVendidos> </returns>
        [Route("api/Reportes/ProductosMasVendidosPorNuevoSoftware")]
        public List<ProductosMasVendidos> GetProductosMasVendidosPorNuevoSoftware()
        {
            return databaseAccess.getAllProductosMasVendidosPorNuevoSoftware();
        }
        /// <summary>
        /// Gets a list of Venta objects that has the NoFactura attributte and total cost
        /// </summary>
        /// <param name="Empresa"> The company where "Pedido" was done </param>
        /// <returns>  List<Venta>  </returns>
        [Route("api/Reportes/CantidadDeVentasPorEmpresa/{Empresa}")]
        public List<Venta> GetCantidadDeVentasPorEmpresa(string Empresa)
        {
            return databaseAccess.getCantidadDeVentasPorEmpresa(Empresa);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Empresa"></param>
        /// <returns></returns>
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
