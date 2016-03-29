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
        private PedidoAccess databaseAccess = new PedidoAccess();

        public List<VistaPedido> Get()
        {
            return databaseAccess.getAllVistasPedidos();
        }
      /*  public List<Pedido> Get()
        {
            return databaseAccess.getAllPedidos();
        }*/
        public Pedido Post(Pedido pedido)
        {
            return databaseAccess.addPedido(pedido);
        }
        public Pedido Put(string id, [FromBody]Pedido pedido)
        {
            return databaseAccess.updatePedido(id, pedido);
        }
        public void Delete(string id)
        {
            databaseAccess.deletePedido(id);
        }
    }
}
