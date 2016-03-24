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
    public class ClientController : ApiController
    {
        public ClientsAccess ca = new ClientsAccess();

        public List<Client> getClients()
        {
            return ca.getClients();
        }
        public Client postClient(Client newClient)
        {
            ca.postClient(newClient);
            return newClient;
        }
      
    }
}
