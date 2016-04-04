using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{

    /// <summary>
    /// A class that represents The most sold product and the quantity of unities sold
    /// and will be serialized to json representation
    /// </summary>
    public class ProductosMasVendidos
    {
        public string NombreMedicamento;
        public string CantidadVendida;
    }
}