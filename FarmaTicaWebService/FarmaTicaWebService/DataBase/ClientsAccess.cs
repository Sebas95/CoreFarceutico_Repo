using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                    "select  IdCliente, Cedula, Nombre , Apellido, Prioridad,CONVERT(VARCHAR(10),FechaNacimiento,120) as Fecha , Residencia from CLIENTE; ", con);
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
                    cliente.FechaNacimiento =rdr["Fecha"].ToString();
                    cliente.Residencia = rdr["Residencia"].ToString();
                    listClientes.Add(cliente);
                }
            }
            return listClientes;

        }
        public Client getClient(string cedula)
        {
            Client cliente = new Client();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "select  IdCliente, Cedula, Nombre , Apellido, Prioridad,CONVERT(VARCHAR(10),FechaNacimiento,120) as Fecha , Residencia"
                    +" from CLIENTE WHERE  Cedula = '"+cedula+"' ; "
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if(rdr.Read()) //si existe en la base de datos
                {
             
                    cliente.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                    cliente.Cedula = rdr["Cedula"].ToString();
                    cliente.Nombre = rdr["Nombre"].ToString();
                    cliente.Apellido = rdr["Apellido"].ToString();
                    cliente.Prioridad = rdr["Prioridad"].ToString();
                    cliente.FechaNacimiento = rdr["Fecha"].ToString();
                    cliente.Residencia = rdr["Residencia"].ToString();

                }
            }
            return cliente;

        }
        public Client addClient(Client client)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO CLIENTE (Cedula, Nombre,Apellido,Prioridad, FechaNacimiento, Residencia) " +
                    "VALUES('"+client.Cedula+"', '"+client.Nombre+"', '"+client.Apellido+"', '"
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
        public void deleteClient(int clientId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM CLIENTE WHERE IdCliente = "+ clientId+";"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            
        }
        public List<Padecimiento> getPadecimientos(int idCliente)
        {
            List<Padecimiento> listPadecimiento = new List<Padecimiento>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT  C.IdCliente ,  C.Nombre, P.Descripcion from CLIENTE AS C join PADECIMIENTOS_POR_CLIENTE AS P On C.IdCliente = P.IdCliente"
                    + " WHERE C.IdCliente = "+idCliente+";"
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Padecimiento padecimiento  = new Padecimiento();
                    padecimiento.idCliente = Convert.ToInt32(rdr["IdCliente"]);
                    padecimiento.descripcion = rdr["Descripcion"].ToString();
                    listPadecimiento.Add(padecimiento);
                }
            }
            return listPadecimiento;
        }
        public Padecimiento addPadecimiento(Padecimiento padecimiento)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES ("+padecimiento.idCliente+" , '"+padecimiento.descripcion+"');"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return padecimiento;
        }
        public List<TelefonoCliente> getTelefonos(int idCliente)
        {
            List<TelefonoCliente> listTelefonos = new List<TelefonoCliente>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT  C.IdCliente, C.Nombre , T.Telefono , T.Descripcion from CLIENTE AS C join TELEFONOS_POR_CLIENTE AS T "
                    + " On C.IdCliente = T.IdCliente WHERE C.IdCliente = "+idCliente+" ; "
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    TelefonoCliente tel = new TelefonoCliente();
                    tel.idCliente = Convert.ToInt32(rdr["IdCliente"]);
                    tel.descripcion = rdr["Descripcion"].ToString();
                    tel.Telefono = rdr["Telefono"].ToString();
                    listTelefonos.Add(tel);
                }
            }
            return listTelefonos;
        }
        public TelefonoCliente addTelefono(TelefonoCliente tel)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO TELEFONOS_POR_CLIENTE VALUES ("+tel.idCliente+" , '"+tel.Telefono+"','"+tel.descripcion+"');"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return tel;
        }
    }
}