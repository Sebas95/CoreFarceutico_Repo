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
        public EmpleadosAccess databaseAccess = new EmpleadosAccess();

        public List<Empleado> Get()
        {
            return databaseAccess.getAllEmpleados();
        }
        public Empleado Post(Empleado empleado)
        {
            return databaseAccess.addEmpleado(empleado);
        }
        public Empleado Put(string id, [FromBody]Empleado empleado)
        {
            return databaseAccess.updateEmpleado(id, empleado);
        }
        public void Delete(string id)
        {
            databaseAccess.deleteEmpleado(id);
        }
        public Empleado GetEmpleado(string Cedula, string password)
        {
            return new Empleado();
        }

    }
}
