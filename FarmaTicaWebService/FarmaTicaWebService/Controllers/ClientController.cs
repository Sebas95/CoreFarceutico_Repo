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
        //member object that belongs to the data access layer that perfoms database operations
        private ClientsAccess DataBaseAccess = new ClientsAccess();

        // GET api/Client
        public List<Client> Get()
        {
            //returns the list of objects Clients (from Cliente table)
            return DataBaseAccess.getClients();
        }
        // POST api/Client
        public Client Post(Client newClient)
        {
            //posts a new Client into the database (inserts into the table Cliente a new Client) and returns it
            return DataBaseAccess.addClient(newClient);
            
        }
        // PUT api/Client/5
        public Client Put(int id, [FromBody]Client cliente)
        {
            //updates a client in the database (in the table Cliente) and returns it
            return DataBaseAccess.updateClient(id,cliente);   
        }
        // DELETE api/Client/5
        public void Delete(int id)
        {
            //deletes a client in the database (in the table Cliente)
            DataBaseAccess.deleteClient(id);
        }
        //search a client by cedula attribute (unique)
        [Route("api/Client/login/{cedula}")]
        public Client GetClient (string cedula)
        {
            return DataBaseAccess.getClient(cedula);
        }

        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }



    }
}
