using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table MedicamentoPorPedido
    /// and will be serialized to json representation
    /// </summary>
    public class MedicamentoPorPedido
    {
        public string NoFactura;
        public string CodigoMedicamento;
        public string Cantidad;
    }
}