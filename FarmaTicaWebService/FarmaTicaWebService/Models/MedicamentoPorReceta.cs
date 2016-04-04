using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table MedicamentoPorReceta and 
    /// will be serialized to json representation
    /// </summary>
    public class MedicamentoPorReceta
    {
        public string CodigoMedicamento;
        public string NoReceta;
        public string Cantidad;
    }
}