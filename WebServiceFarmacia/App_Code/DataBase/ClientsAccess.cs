using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

public class ClientesAccess
{
    public ClientesAccess()
    {
    }
    public List<Cliente> getClients()
    {
        List<Cliente> listClientes = new List<Cliente>();
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand(
                "select  IdCliente, Cedula, Nombre , Apellido, Prioridad, FechaNacimiento , Residencia from CLIENTE; ", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read()) //si existe en la base de datos
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                cliente.Cedula = rdr["Cedula"].ToString();
                cliente.Nombre = rdr["Nombre"].ToString();
                cliente.Apellido = rdr["Apellido"].ToString();
                cliente.Prioridad = rdr["Prioridad"].ToString();
                cliente.FechaNacimiento = rdr["FechaNacimiento"].ToString();
                cliente.Residencia = rdr["Residencia"].ToString();
                listClientes.Add(cliente);
            }
        }
        return listClientes;

    }
}