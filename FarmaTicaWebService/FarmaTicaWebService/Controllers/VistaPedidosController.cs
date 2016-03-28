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
    public class VistaPedidosController : ApiController
    {
        private PedidoAccess databaseAccess = new PedidoAccess();
        public List<VistaPedido> Get()
        {
            return databaseAccess.getAllVistasPedidos();
        }
    }
}
