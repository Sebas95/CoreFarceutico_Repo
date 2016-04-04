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
    public class RecetasPorPedidoController : ApiController
    {
        /// <summary>
        /// An object that has a acces to the Table Receta
        /// </summary>
        private RecetasAccess recetasAccess = new RecetasAccess();

        /// <summary>
        /// Returns a list of VistaReceta object by its NoFactura
        /// </summary>
        /// <param name="NoFactura"> The filter </param>
        /// <returns> List<VistaReceta> </returns>
        [Route("api/RecetasPorPedido/{NoFactura}")]
        public List<VistaReceta> Get(string NoFactura)
        {
            return recetasAccess.getRecetasPorPedido(NoFactura);
        }
      
    }
}
