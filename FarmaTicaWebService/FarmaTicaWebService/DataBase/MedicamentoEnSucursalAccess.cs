using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaTicaWebService.Models;
using System.Configuration;
using System.Data.SqlClient;


namespace FarmaTicaWebService.DataBase
{
    public class MedicamentoEnSucursalAccess
    {
        public List<SucursalPorMedicamento> getSucursalesPorMedicamento(string codigoMedicamento)
        {
            List<SucursalPorMedicamento> listSucursales = new List<SucursalPorMedicamento>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT  S.NoSucursal , S.Nombre  , S.Direccion , S.Telefono , MS.Cantidad"
                    + " FROM MEDICAMENTO_EN_SUCURSAL AS MS JOIN SUCURSAL AS S"
                    + " ON MS.NoSucursal = S.NoSucursal"
                    + " WHERE MS.CodigoMedicamento = '" + codigoMedicamento + "'; "
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    SucursalPorMedicamento sucursal = new SucursalPorMedicamento();
                    sucursal.NoSucursal = rdr["NoSucursal"].ToString();
                    sucursal.Nombre = rdr["Nombre"].ToString();
                    sucursal.Direccion = rdr["Direccion"].ToString();
                    sucursal.Telefono = rdr["Telefono"].ToString();
                    sucursal.Cantidad = rdr["Cantidad"].ToString();
                    listSucursales.Add(sucursal);
                }
            }
            return listSucursales;

        }
        public void addSucursalPorMedicamento(string CodigoMedicamento, string NoSucursal, string Cantidad)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento , NoSucursal, Cantidad) " +
                    " VALUES('" + CodigoMedicamento + "', '" + NoSucursal + "', '" + Cantidad + "'); "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
           

        }
        //
        public void deleteRemoveSucursalFromMedicamento(string codigoMedicamento, string NoSucursal)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM  MEDICAMENTO_EN_SUCURSAL WHERE CodigoMedicamento = '" + codigoMedicamento + "' and NoSucursal = '" + NoSucursal + "' ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}