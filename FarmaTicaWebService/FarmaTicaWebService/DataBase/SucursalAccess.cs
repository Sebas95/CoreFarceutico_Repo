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
        /// <summary>
        /// Gets all the rows of the table Sucursal
        /// </summary>
        /// <returns>  List<Sucursal> </returns>
        public List<Sucursal> getAllSucursales()
        {
            List<Sucursal> listSucursales = new List<Sucursal>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                //the select command
                SqlCommand cmd = new SqlCommand(
                    "SELECT NoSucursal , Nombre , Direccion , Telefono FROM SUCURSAL; ", con); 
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    //a new instance of Sucursal per row
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
        /// <summary>
        /// Inserts a new row in the Sucursal table
        /// </summary>
        /// <param name="sucursal"> An object that represents a row </param>
        /// <returns> The new sucursal added </returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NoSucursal"></param>
        /// <param name="sucursal"></param>
        /// <returns></returns>
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
                sucursal.NoSucursal = NoSucursal.ToString();

            }
            return sucursal;
        }
        /// <summary>
        /// Deletes a row in the table Sucursal
        /// </summary>
        /// <param name="NoSucursal"> the id of Sucursal </param>
        public void deleteSucursal(int NoSucursal)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM SUCURSAL WHERE NoSucursal = '"+ NoSucursal +"'; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}