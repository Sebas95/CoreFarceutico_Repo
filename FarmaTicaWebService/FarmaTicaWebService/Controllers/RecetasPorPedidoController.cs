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
        private RecetasAccess recetasAccess = new RecetasAccess();

        public List<VistaReceta> Get(string id)
        {
            return recetasAccess.getRecetasPorPedido(id);
        }
      
    }
}
