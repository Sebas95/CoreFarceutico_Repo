using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents The sum of total cost of each order (Pedido) that belongs to a specific company (Empresa)
    /// and will be serialized to json representation
    /// </summary>
    public class TotalVendido
    {
        public string Empresa;
        public string totalVendido;
    }
}