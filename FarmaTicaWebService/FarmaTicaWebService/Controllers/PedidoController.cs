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
    public class PedidoController : ApiController
    {
        /// <summary>
        /// Object that has acces to the Pedido Table
        /// </summary>
        private PedidoAccess databaseAccess = new PedidoAccess();

        /// <summary>
        /// Gets a list of VistaPedido Objects
        /// </summary>
        /// <returns> List<VistaPedido> </returns>
        public List<VistaPedido> Get()
        {
            return databaseAccess.getAllVistasPedidos();
        }
        /// <summary>
        /// Posts a pedido Object 
        /// </summary>
        /// <param name="pedido">The new object to tbe posted</param>
        /// <returns> The new object to be posted </returns>
        public Pedido Post(Pedido pedido)
        {
            return databaseAccess.addPedido(pedido);
        }
        /// <summary>
        /// Puts an existing Pedido object 
        /// </summary>
        /// <param name="id">The id of the object</param>
        /// <param name="pedido">The new object to tbe posted</param></param>
        /// <returns>The new object to tbe posted</param></returns>
        public Pedido Put(string id, [FromBody]Pedido pedido)
        {
            return databaseAccess.updatePedido(id, pedido);
        }
        /// <summary>
        /// Deletes an Pedido object
        /// </summary>
        /// <param name="id"> The id of the object </param>
        public void Delete(string id)
        {
            databaseAccess.deletePedido(id);
        }

        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}
