using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FarmaTicaWebService.Models;
using FarmaTicaWebService.DataBase;
using System.Collections.Generic;

namespace FarmaTicaWebService.Controllers
{
    public class TelefonosClientesController : ApiController
    {
        public ClientsAccess DataBaseAccess = new ClientsAccess();
        [Route("api/TelefonosClientes/{idCliente}")]
        public List<TelefonoCliente> getTelefonos(int idCliente)
        {
            return DataBaseAccess.getTelefonos(idCliente);
        }
        public TelefonoCliente Post(TelefonoCliente tel)
        {
            return DataBaseAccess.addTelefono(tel);
        }

    }
}
