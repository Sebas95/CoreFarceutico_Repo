using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table Doctor
    /// and will be serialized to json representation
    /// </summary>
    public class Doctor
    {
        public int NoDoctor;
        public string Cedula;
        public string Nombre;
        public string Apellido;
        public string FechaNacimiento;
        public string Residencia;
    }
}