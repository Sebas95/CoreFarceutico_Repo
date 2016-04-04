using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{

    /// <summary>
    /// A class that represents The total cost of each order (Pedido)
    /// and will be serialized to json representation
    /// </summary>
    public class Venta
    {
        public string NoFactura;
        public string Total;
    }
}