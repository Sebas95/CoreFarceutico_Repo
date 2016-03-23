using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

public class DataBaseAccess
{
    public DataBaseAccess()
    {
    }

    public User getUserAuthentication(string userName, string password)    
    {
        User user = new User();
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand(
                "use FARMATICA; Select Tipo from USUARIOS where NombreUsuario ='" + userName + "' and Passwrd = '" + password + "';", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read()) //si existe en la base de datos
            {
                user.username = userName;
                user.password = password;
                user.type = (Convert.ToInt32(rdr[" Tipo"]));
            }  
           else // si no existe que lo cree
            {
                user.username = userName;
                user.password = password;
                using (SqlConnection con2 = new SqlConnection(cs))
                {
                    SqlCommand insert = new SqlCommand(
                   "use FARMATICA; INSERT INTO USUARIOS VALUES('" + user.username + "','" + user.password + "','" + user.type + "');", con2);
                    con2.Open();
                    insert.ExecuteNonQuery();
                }
            }
        }
        return user;
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
                cliente.IdCliente= Convert.ToInt32(rdr["IdCliente"]);
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
    /* public List<Employee> getEmployees()
     {
         List<Employee> listEmployees = new List<Employee>();
         string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
         using (SqlConnection con = new SqlConnection(cs))
         {
             SqlCommand cmd = new SqlCommand("Select * from tblEmployees", con);
             con.Open();
             SqlDataReader rdr = cmd.ExecuteReader();
             while (rdr.Read())
             {
                 Employee employee = new Employee();
                 employee.id = Convert.ToInt32(rdr["Id"]);
                 employee.name = rdr["Name"].ToString();
                 employee.gender = rdr["Gender"].ToString();
                 employee.salary = Convert.ToInt32(rdr["Salary"]);
                 listEmployees.Add(employee);
             }
         }
         return listEmployees;
     }*/


}