using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaTicaWebService.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace FarmaTicaWebService.DataBase
{
    public class SucursalAccess
    {
        public List<Sucursal> getAllSucursales()
        {
            List<Sucursal> listSucursales = new List<Sucursal>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT NoSucursal , Nombre , Direccion , Telefono FROM SUCURSAL; ", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Sucursal sucursal = new Sucursal();
                    sucursal.NoSucursal = rdr["NoSucursal"].ToString();
                    sucursal.Nombre = rdr["Nombre"].ToString();
                    sucursal.Direccion = rdr["Direccion"].ToString();
                    sucursal.Telefono = rdr["Telefono"].ToString();
                    listSucursales.Add(sucursal);
                   
                }
            }
            return listSucursales;

        }
        public Sucursal addScucursal(Sucursal sucursal)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                   "INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono)"
                   +" VALUES ("+sucursal.NoSucursal+",'"+sucursal.Nombre+"' , '"+sucursal.Direccion+"' ,'"+sucursal.Telefono+"');"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return sucursal;
        }
        public Sucursal updateSucursal(int NoSucursal, Sucursal sucursal)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    " UPDATE SUCURSAL SET Nombre = '"+sucursal.Nombre+"', Direccion = '"+sucursal.Direccion+"', Telefono = '"+sucursal.Telefono+"'"
                    +" WHERE NoSucursal = '"+NoSucursal+"' ;" 
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return sucursal;
        }
        public void deleteSucursal(int NoSucursal)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM DOCTOR WHERE NoDoctor = " + NoSucursal + " ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}