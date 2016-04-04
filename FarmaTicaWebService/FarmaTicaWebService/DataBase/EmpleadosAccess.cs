
using System.Collections.Generic;
using FarmaTicaWebService.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace FarmaTicaWebService.DataBase
{
    public class EmpleadosAccess
    {
        /// <summary>
        /// Selects all the rows of the table Empleados, maps it into Empleado objects and returns it as a list
        /// </summary>
        /// <returns> List<Empleado> </returns>
        public List<Empleado> getAllEmpleados()
        {
            List<Empleado> listEmpleados = new List<Empleado>(); //the list of object Empleados that will be returned
            //get the configuration string for SQL server connection
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                //the sql command (SELECT)
                SqlCommand cmd = new SqlCommand(
                    "SELECT IdEmpleado, Nombre, Cedula, Passwrd , Rol , Empresa FROM Empleado;", con);
                con.Open();
                //the dataset object or resultset
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //if there is a row retuned
                {
                    Empleado empleado = new Empleado(); //new model object Empleado
                    //setting of all its attributes from retrieved data from the database
                    empleado.IdEmpleado = rdr["IdEmpleado"].ToString();
                    empleado.Nombre = rdr["Nombre"].ToString();
                    empleado.Cedula = rdr["Cedula"].ToString();
                    empleado.Passwrd = rdr["Passwrd"].ToString();
                    empleado.Rol = rdr["Rol"].ToString();
                    empleado.Empresa = rdr["Empresa"].ToString();
                    listEmpleados.Add(empleado); //add the new object to the list

                }
            }
            return listEmpleados; //returns the list of mapped objects

        }
        /// <summary>
        /// Selects an specific row of the table Empleados searched by the aatirbutes cedula adn password,
        /// maps it into Empleado objects and returns 
        /// </summary>
        /// <param name="cedula"> attribute cedula</param>
        /// <param name="password">attribute password</param>
        /// <returns></returns>
        public Empleado getEmpleado(string cedula, string password)
        {
            Empleado empleado = new Empleado();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT IdEmpleado, Nombre, Cedula, Passwrd , Rol , Empresa FROM Empleado WHERE cedula = '"+cedula+"' AND Passwrd = '"+password+"' ;"
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) //si existe en la base de datos
                {
                    empleado.IdEmpleado = rdr["IdEmpleado"].ToString();
                    empleado.Nombre = rdr["Nombre"].ToString();
                    empleado.Cedula = rdr["Cedula"].ToString();
                    empleado.Passwrd = rdr["Passwrd"].ToString();
                    empleado.Rol = rdr["Rol"].ToString();
                    empleado.Empresa = rdr["Empresa"].ToString();
                }
            }
            return empleado;

        }
        /// <summary>
        /// Inserts a row in the table Empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns> The new Empleado object </returns>
        public Empleado addEmpleado(Empleado empleado)
        {

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                   "INSERT INTO Empleado (Nombre,Cedula, Passwrd, Rol, Empresa)" 
                    +" VALUES('"+empleado.Nombre+"', '"+empleado.Cedula+"', '"+empleado.Passwrd+"', '"+empleado.Rol+"', '"+empleado.Empresa+"'); "
                    + "  Select SCOPE_IDENTITY();  "
                    , con);
                con.Open();
                empleado.IdEmpleado =cmd.ExecuteScalar().ToString(); //execute query
            }
            return empleado;
        }
        /// <summary>
        /// Updates a row of Empleado table
        /// </summary>
        /// <param name="idEmpleado"> The primary key of the row </param>
        /// <param name="empleado"> The mapped object that reprsents a row of Empleado table</param>
        /// <returns></returns>
        public Empleado updateEmpleado(string idEmpleado, Empleado empleado)
        {
           
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Empleado "
                    +" SET Nombre = '"+empleado.Nombre+"', Cedula = '"+empleado.Cedula+"', Passwrd = '"+empleado.Passwrd+"', Rol = '"+empleado.Rol+"', Empresa = '"+empleado.Empresa+"' "
                    +" WHERE IdEmpleado = '"+idEmpleado+"' ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
                empleado.IdEmpleado = idEmpleado;
            }
            return empleado;
        }
        /// <summary>
        /// Deletes a row in the Empleado table
        /// </summary>
        /// <param name="idEmpleado"> The primary key ofthe Empleado needed to be deleted </param>
        public void deleteEmpleado(string idEmpleado)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM EMPLEADO WHERE IdEmpleado = '"+idEmpleado+"' ;"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}