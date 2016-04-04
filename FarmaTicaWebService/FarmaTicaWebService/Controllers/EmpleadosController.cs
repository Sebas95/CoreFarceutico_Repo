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
    public class EmpleadosController : ApiController
    {
        /// <summary>
        /// The object which can do querys in the Empleado Table 
        /// </summary>
        private EmpleadosAccess databaseAccess = new EmpleadosAccess();

        /// <summary>
        /// Gets a list of Empleados 
        /// </summary>
        /// <returns>  List<Empleado></returns>
        public List<Empleado> Get()
        {
            return databaseAccess.getAllEmpleados();
        }
        /// <summary>
        /// Posts a new Empleado 
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns> The new Empleado posted </returns>
        public Empleado Post(Empleado empleado)
        {
            return databaseAccess.addEmpleado(empleado);
        }
        /// <summary>
        /// Puts an Empleado object identified by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="empleado"></param>
        /// <returns> The Empleado now updated </returns>
        public Empleado Put(string id, [FromBody]Empleado empleado)
        {
            return databaseAccess.updateEmpleado(id, empleado);
        }
        /// <summary>
        /// Deletes an Empleado object identified by its id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            databaseAccess.deleteEmpleado(id);
        }
        /// <summary>
        /// Searches for an Empleado by Cedula and password attributes
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="password"></param>
        /// <returns> Empleado who has both Cedula and password </returns>
        [Route("api/Empleados/{Cedula}/{password}")]
        public Empleado GetEmpleado(string Cedula, string password)
        {
            return databaseAccess.getEmpleado(Cedula, password);
        }

    }
}
