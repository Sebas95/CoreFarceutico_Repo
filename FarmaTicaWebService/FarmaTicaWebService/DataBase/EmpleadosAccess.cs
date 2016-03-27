using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaTicaWebService.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace FarmaTicaWebService.DataBase
{
    public class EmpleadosAccess
    {
        public List<Empleado> getAllEmpleados()
        {
            List<Empleado> listEmpleados = new List<Empleado>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT IdEmpleado, Nombre, Cedula, Passwrd , Rol , Empresa FROM Empleado;", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = rdr["IdEmpleado"].ToString();
                    empleado.Nombre = rdr["Nombre"].ToString();
                    empleado.Cedula = rdr["Cedula"].ToString();
                    empleado.Passwrd = rdr["Passwrd"].ToString();
                    empleado.Rol = rdr["Rol"].ToString();
                    empleado.Empresa = rdr["Empresa"].ToString();
                    listEmpleados.Add(empleado);

                }
            }
            return listEmpleados;

        }
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
        public Empleado addEmpleado(Empleado empleado)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                   "INSERT INTO Empleado (Nombre,Cedula, Passwrd, Rol, Empresa)" 
                    +" VALUES('"+empleado.Nombre+"', '"+empleado.Cedula+"', '"+empleado.Passwrd+"', '"+empleado.Rol+"', '"+empleado.Empresa+"'); "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return empleado;
        }
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

            }
            return empleado;
        }
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