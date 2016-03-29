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

        // GET api/Client
        public List<Client> Get()
        {
            return DataBaseAccess.getClients();
        }
        // POST api/Client
        public Client Post(Client newClient)
        {
            return DataBaseAccess.addClient(newClient);
            
        }
        // PUT api/Client/5
        public Client Put(int id, [FromBody]Client cliente)
        {
            return DataBaseAccess.updateClient(id,cliente);   
        }
        // DELETE api/Client/5
        public void Delete(int id)
        {
            DataBaseAccess.deleteClient(id);
        }
        [Route("api/Client/{cedula}")]
        public Client GetClient (string cedula)
        {
            return DataBaseAccess.getClient(cedula);
        }

        


    }
}
