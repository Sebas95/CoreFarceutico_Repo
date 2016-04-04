using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table Sucursal 
    /// and will be serialized to json representation
    /// </summary>
    public class Sucursal
    {
        public string NoSucursal;
        public string Nombre;
        public string Direccion;
        public string Telefono;
    }
}