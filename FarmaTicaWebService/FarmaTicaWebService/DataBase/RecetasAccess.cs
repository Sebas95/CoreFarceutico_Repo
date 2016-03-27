using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaTicaWebService.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace FarmaTicaWebService.DataBase
{
    public class RecetasAccess
    {
        public List<Receta> getAllRecetas()
        {
            List<Receta> listRecetas = new List<Receta>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT NoReceta , NoFactura , IdCliente , NoDoctor FROM RECETA", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Receta receta = new Receta();
                    receta.NoReceta = rdr["NoReceta"].ToString();
                    receta.NoFactura = rdr["NoFactura"].ToString(); ;
                    receta.IdCliente = rdr["IdCliente"].ToString(); ;
                    receta.NoDoctor = rdr["NoDoctor"].ToString(); 
                    listRecetas.Add(receta);
                }
            }
            return listRecetas;

        }
        public Receta addReceta(Receta receta)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO RECETA ( NoFactura , IdCliente , NoDoctor)"
                    +" VALUES('"+receta.NoFactura+"', '"+receta.IdCliente+"', '"+receta.NoDoctor+"'); "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return receta;
        }
        public Receta updateReceta(string NoReceta, Receta receta)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE RECETA SET  NoFactura = '"+receta.NoFactura+"', IdCliente = '"+receta.IdCliente+"', NoDoctor = '"+receta.NoDoctor+"'"
                    +" WHERE NoReceta = '"+NoReceta+"' ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return receta;
        }
        public void deleteReceta(string NoReceta)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM RECETA WHERE NoReceta = '"+NoReceta+"' ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}