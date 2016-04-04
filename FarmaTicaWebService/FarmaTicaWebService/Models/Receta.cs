using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table Receta 
    /// and will be serialized to json representation
    /// </summary>
    public class Receta
    {
        public string NoReceta;
        public string NoFactura;
        public string IdCliente;
        public string NoDoctor;

    }
}