using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FarmaTicaWebService.Models
{
    public class Client
    {
        public Client()
        {
        }
        public int IdCliente;
        public string Cedula;
        public string Nombre;
        public string Apellido;
        public string Prioridad;
        public DateTime FechaNacimiento;
        public string Residencia;

    }
}