using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the table Medicamento
    /// and will be serialized to json representation
    /// </summary>
    public class Medicamento
    {
        public string Nombre;
        public string codigo;
        public string Prescripcion;
        public string CasaFarmaceutica;
        public string Costo;

    }
}