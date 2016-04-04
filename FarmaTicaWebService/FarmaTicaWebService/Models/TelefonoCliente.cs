using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table TelefonoCliente 
    /// and will be serialized to json representation
    /// </summary>
    public class TelefonoCliente
    {
        public int idCliente;
        public string Telefono;
        public string descripcion;
    }
}