using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table Pedido 
    /// and will be serialized to json representation
    /// </summary>
    public class Pedido
    {
        public string NoFactura;
        public string FechaRecojo;
        public string NoSucursal;
        public string IdCliente;
        public string Estado;
        public string Empresa;
        public string TelefonoPreferido;
    }
}