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
        public SucursalAccess databaseAccess = new SucursalAccess();

        public List<Sucursal> Get()
        {
            return databaseAccess.getAllSucursales();
        }
        public Sucursal Post(Sucursal sucursal)
        {
            return databaseAccess.addScucursal(sucursal);
        }
        public Sucursal Put(int id, [FromBody]Sucursal sucursal)
        {
            return databaseAccess.updateSucursal(id, sucursal);
        }
        public void Delete(int id)
        {
            databaseAccess.deleteSucursal(id);
        }
    }
}
