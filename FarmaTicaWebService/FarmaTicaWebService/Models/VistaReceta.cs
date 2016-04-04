using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the result set table of a select 
    /// of the table Receta,  Medicmaneto , Cliente and Sucursal
    /// and will be serialized to json representation
    /// </summary>
    public class VistaReceta
    {
        public string NoFactura;
        public string NoReceta;
        public string NombreCliente;
        public string Apellidos;
        public string CedulaCliente;
        public string NoDoctor;
        public string NombreDoctor;
        public string Imagen;
    }
}