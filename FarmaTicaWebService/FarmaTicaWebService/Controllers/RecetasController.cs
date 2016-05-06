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
    public class RecetasController : ApiController
    {
        /// <summary>
        /// The object that has acces to the Receta table
        /// </summary>
        private RecetasAccess databaseAccess = new RecetasAccess();

        /// <summary>
        /// Gets a list of all the VistaReceta objects
        /// </summary>
        /// <returns> List<VistaReceta> </returns>
        public List<VistaReceta> Get()
        {
            return databaseAccess.getAllRecetas();
        }
        /// <summary>
        /// Posts a new object Receta
        /// </summary>
        /// <param name="receta"> The new Receta object </param>
        /// <returns> The new Receta object </returns>
        public Receta Post(Receta receta)
        {
            return databaseAccess.addReceta(receta);
        }
        /// <summary>
        /// Puts a new object Receta
        /// </summary>
        /// <param name="id"> The id of the object </param>
        /// <param name="receta"> The receta object to be put </param>
        /// <returns>The receta object that has been put</returns>
        public Receta Put(string id, [FromBody]Receta receta)
        {
            return databaseAccess.updateReceta(id, receta);
        }
        /// <summary>
        /// Deletes a Receta object
        /// </summary>
        /// <param name="id"> The id of the object to be deleted </param>
        public void Delete(string id)
        {
            databaseAccess.deleteReceta(id);
        }


        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}
