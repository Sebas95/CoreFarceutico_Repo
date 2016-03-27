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
        public RecetasAccess databaseAccess = new RecetasAccess();

        public List<Receta> Get()
        {
            return databaseAccess.getAllRecetas();
        }
        public Receta Post(Receta receta)
        {
            return databaseAccess.addReceta(receta);
        }
        public Receta Put(string id, [FromBody]Receta receta)
        {
            return databaseAccess.updateReceta(id, receta);
        }
        public void Delete(string id)
        {
            databaseAccess.deleteReceta(id);
        }
    }
}
