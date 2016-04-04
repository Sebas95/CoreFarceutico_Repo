using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table Emplado
    /// and will be serialized to json representation
    /// </summary>
    public class Empleado
    {
        public string IdEmpleado;
        public string Nombre;
        public string Cedula;
        public string Passwrd;
        public string Rol;
        public string Empresa;
    }
}