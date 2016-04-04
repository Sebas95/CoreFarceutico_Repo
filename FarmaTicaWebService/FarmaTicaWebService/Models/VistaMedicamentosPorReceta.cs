using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the result set table of a select for Medicamento for each Receta  
    /// and will be serialized to json representation
    /// </summary>
    public class VistaMedicamentosPorReceta
    {
        public string Codigo;
        public string Nombre;
        public string Cantidad;
        public string CostoUnitario;
        public string CasaFarmaceutica;
    }
}