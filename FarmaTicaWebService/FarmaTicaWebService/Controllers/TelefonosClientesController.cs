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

        public List<TelefonoCliente> getTelefonos(int id)
        {
            return DataBaseAccess.getTelefonos(id);
        }
        public TelefonoCliente Post(TelefonoCliente tel)
        {
            return DataBaseAccess.addTelefono(tel);
        }

    }
}
