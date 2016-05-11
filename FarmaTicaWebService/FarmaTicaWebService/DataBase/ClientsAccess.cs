using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using FarmaTicaWebService.Models;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace FarmaTicaWebService.DataBase
{ 
    public class ClientsAccess
    {
        public ClientsAccess()
        {
        }
        /// <summary>
        /// Selects all the rows of Client table, maps it into objects Client and returns it as a list
        /// </summary>
        /// <returns>List<Client></returns>
        public List<Client> getClients()
        {
            List<Client> listClientes = new List<Client>(); //the list of object Client that will be returned
            //get the configuration string for SQL server connection
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                //the sql command (SELECT)
                SqlCommand cmd = new SqlCommand(
                    "select  IdCliente, Cedula, Nombre , Apellido, Prioridad,CONVERT(VARCHAR(10),FechaNacimiento,120) as Fecha ,"
                    +" Residencia from CLIENTE; "
                    , con);
                con.Open();
                //the dataset object or resultset
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //if there is a row retuned
                {
                    Client cliente = new Client(); //new model object Client (for each row returned)
                    //setting of all its attributes from retrieved data from the database
                    cliente.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                    cliente.Cedula = rdr["Cedula"].ToString();
                    cliente.Nombre = rdr["Nombre"].ToString();
                    cliente.Apellido = rdr["Apellido"].ToString();
                    cliente.Prioridad = rdr["Prioridad"].ToString();
                    cliente.FechaNacimiento =rdr["Fecha"].ToString();
                    cliente.Residencia = rdr["Residencia"].ToString();
                    listClientes.Add(cliente); //add the new object to the list
                }
            }
            return listClientes;  //returns the list of mapped objects

        }
        /// <summary>
        /// Selects a client row by cedula attribute and returns a mapped Client object
        /// </summary>
        /// <param name="cedula"> Atribute cedula of the table Client</param>
        /// <returns> Client</returns>
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
        /// <summary>
        /// inserts a row into the client table, 
        /// </summary>
        /// <param name="client"> An mapped object of client row </param>
        /// <returns>Client</returns>
        public Client addClient(Client client)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO CLIENTE (Cedula, Nombre,Apellido, FechaNacimiento, Residencia) " +
                    "VALUES('"+client.Cedula+"', '"+client.Nombre+"', '"+client.Apellido+"',"
                    +" '"+client.FechaNacimiento+"', '"+client.Residencia+ "');  Select SCOPE_IDENTITY();  "
                    , con);
                con.Open();
                client.IdCliente = Convert.ToInt32(cmd.ExecuteScalar()); //execute query
            }
            return client;
        }
        /// <summary>
        /// updates a row into the client table
        /// </summary>
        /// <param name="clientId"> the primary key of the row</param>
        /// <param name="client">An mapped object of client row</param>
        /// <returns>updated  Client  object</returns>
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
                client.IdCliente = clientId;
            }
            return client;
        }
        /// <summary>
        /// delestes a row in cliente table
        /// </summary>
        /// <param name="clientId"> The if of the row that will be deleted  </param>
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
        /// <summary>
        /// selects the rows of the table PAdecimientos specifiyng the Client id that belongs to, maps into objects Padecimiento and
        /// returns it as a list
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns> List<Padecimiento> </returns>
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
        /// <summary>
        /// inserts a row into Padecimiento table
        /// </summary>
        /// <param name="padecimiento"> The mapped Padecimiento object that will be use for insertion </param>
        /// <returns> Padecimiento </returns>
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
        /// <summary>
        /// selects the rows of the table Telefonos specifiyng the Client id that belongs to, maps into objects Telefonos and
        /// returns it as a list
        /// </summary>
        /// <param name="idCliente">primary key of cliente</param>
        /// <returns> List<TelefonoCliente></returns>
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
        /// <summary>
        ///  inserts a row into TelefonosCliente table
        /// </summary>
        /// <param name="tel">The mapped Padecimiento object that will be use for insertion </param>
        /// <returns> The new  TelefonoCliente  </returns>
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
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}