using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table Padecimiento and will be serialized to json representation
    /// </summary>
    public class Padecimiento
    {
        public int idCliente;
        public string descripcion;
    }
   
}