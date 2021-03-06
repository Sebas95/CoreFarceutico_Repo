﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaTicaWebService.Models
{
    /// <summary>
    /// A class that represents a row in the result set table of a select 
    /// of the table Pedido,  Medicmaneto , Cliente and Sucursal
    /// and will be serialized to json representation
    /// </summary>
    public class VistaPedido
    {
        public string NoFactura;
        public string NombreCliente ;
        public string Apellidos;
        public string Telefono ;
        public string SucursalDeRecojo;
        public string FechaRecojo;
        public string Estado;
        public string Prioridad;
        public string Empresa;
        public string IdCliente;
        public string NoSucursal;
    }
}