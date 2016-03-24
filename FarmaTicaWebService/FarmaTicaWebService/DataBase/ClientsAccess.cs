using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using FarmaTicaWebService.Models;

namespace FarmaTicaWebService.DataBase
{ 
    public class ClientsAccess
    {
        public ClientsAccess()
        {
        }
        public List<Client> getClients()
        {
            List<Client> listClientes = new List<Client>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "select  IdCliente, Cedula, Nombre , Apellido, Prioridad, FechaNacimiento , Residencia from CLIENTE; ", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Client cliente = new Client();
                    cliente.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                    cliente.Cedula = rdr["Cedula"].ToString();
                    cliente.Nombre = rdr["Nombre"].ToString();
                    cliente.Apellido = rdr["Apellido"].ToString();
                    cliente.Prioridad = rdr["Prioridad"].ToString();
                    cliente.FechaNacimiento =rdr["FechaNacimiento"].ToString();
                    cliente.Residencia = rdr["Residencia"].ToString();
                    listClientes.Add(cliente);
                }
            }
            return listClientes;

        }
        public Client addClient(Client client)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO CLIENTE (IdCliente, Cedula, Nombre,Apellido,Prioridad, FechaNacimiento, Residencia) " +
                    "VALUES("+client.IdCliente+", '"+client.Cedula+"', '"+client.Nombre+"', '"+client.Apellido+"', '"
                    +client.Prioridad+"', '"+client.FechaNacimiento+"', '"+client.Residencia+"');"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
            return client;
        }
        public Client updateClient(int clientId, Client client)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    " UPDATE CLIENTE SET Cedula = '"+client.Cedula+"', Nombre = '"+client.Nombre+"', Apellido = '"+client.Apellido+"'," 
                    +" FechaNacimiento = '"+client.FechaNacimiento+"', Residencia = '"+client.Residencia+"',"
                    +" Prioridad = '"+client.Prioridad+"' WHERE IdCliente = "+ clientId +" ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return client;
        }
    }
}