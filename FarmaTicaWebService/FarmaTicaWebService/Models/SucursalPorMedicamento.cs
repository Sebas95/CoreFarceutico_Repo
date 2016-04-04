using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table SucursalPorMedicamento 
    /// and will be serialized to json representation
    /// </summary>
    public class SucursalPorMedicamento
    {
        public string Nombre;
        public string Telefono;
        public string NoSucursal;
        public string Cantidad;
        public string Direccion;

    }
}