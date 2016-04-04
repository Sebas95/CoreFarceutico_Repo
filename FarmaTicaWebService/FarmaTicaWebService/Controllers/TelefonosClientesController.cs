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
        /// <summary>
        /// An ojbject that has access to tha table TelefonosPorCliente
        /// </summary>
        public ClientsAccess DataBaseAccess = new ClientsAccess();

        /// <summary>
        /// Gets all the Telefono object of a certain cliente
        /// </summary>
        /// <param name="idCliente"> The owner id of the Telefono objects   </param>
        /// <returns> List<TelefonoCliente> </returns>
        [Route("api/TelefonosClientes/{idCliente}")]
        public List<TelefonoCliente> getTelefonos(int idCliente)
        {
            return DataBaseAccess.getTelefonos(idCliente);
        }
        /// <summary>
        /// Posts a new Telefono Object
        /// </summary>
        /// <param name="tel"> The new TelefonoCliente object </param>
        /// <returns> The new TelefonoCliente object </returns>
        public TelefonoCliente Post(TelefonoCliente tel)
        {
            return DataBaseAccess.addTelefono(tel);
        }

    }
}
