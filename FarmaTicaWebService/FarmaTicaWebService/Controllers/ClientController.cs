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
        public ClientsAccess DataBaseAccess = new ClientsAccess();

        public List<Client> getClients()
        {
            return DataBaseAccess.getClients();
        }

        public Client postClient(Client newClient)
        {
            DataBaseAccess.addClient(newClient);
            return newClient;
        }
        public Client updateClient(int ClientId, Client cliente)
        {
            
            return cliente;
        }

      
    }
}
