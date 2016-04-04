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
    public class SucursalController : ApiController
    {
        /// <summary>
        /// an boject that has acccess to tha Sucursal Table
        /// </summary>
        public SucursalAccess databaseAccess = new SucursalAccess();

        /// <summary>
        /// Gets all Sucursal objects
        /// </summary>
        /// <returns> List<Sucursal> </returns>
        public List<Sucursal> Get()
        {
            return databaseAccess.getAllSucursales();
        }
        /// <summary>
        /// Posts a new Sucursal object
        /// </summary>
        /// <param name="sucursal"> The new object to the posted </param>
        /// <returns> The new object to the posted  </returns>
        public Sucursal Post(Sucursal sucursal)
        {
            return databaseAccess.addScucursal(sucursal);
        }
        /// <summary>
        /// Puts a Sucursal object
        /// </summary>
        /// <param name="id"> The id of the Sucursal object </param>
        /// <param name="sucursal"> The object to be put </param>
        /// <returns> The object to be put  </returns>
        public Sucursal Put(int id, [FromBody]Sucursal sucursal)
        {
            return databaseAccess.updateSucursal(id, sucursal);
        }
        /// <summary>
        /// Deletes a Sucursal object
        /// </summary>
        /// <param name="id"> The id of the object to be deleted </param>
        public void Delete(int id)
        {
            databaseAccess.deleteSucursal(id);
        }
    }
}
