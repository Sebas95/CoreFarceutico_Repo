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
        public List<VistaReceta> getAllRecetas()
        {
            List<VistaReceta> listRecetas = new List<VistaReceta>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT R.NoFactura , R.NoReceta , C.Nombre AS NombreCliente ,"
                    +" C.Apellido as Apellidos, c.Cedula as CedulaCliente, D.Nombre AS NombreDoctor, D.NoDoctor"
                    +" FROM"
                    +" (RECETA AS R JOIN DOCTOR AS D ON R.NoDoctor = D.NoDoctor) JOIN CLIENTE AS C ON R.IdCliente = C.IdCliente ;"           
                    ,con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    VistaReceta vista_receta = new VistaReceta();
                    vista_receta.NoFactura = rdr["NoFactura"].ToString();
                    vista_receta.NoReceta = rdr["NoReceta"].ToString();
                    vista_receta.NombreCliente = rdr["NombreCliente"].ToString();
                    vista_receta.Apellidos = rdr["Apellidos"].ToString();
                    vista_receta.CedulaCliente = rdr["CedulaCliente"].ToString();
                    vista_receta.NombreDoctor = rdr["NombreDoctor"].ToString();
                    vista_receta.NoDoctor = rdr["NoDoctor"].ToString();
                    listRecetas.Add(vista_receta);
                }
            }
            return listRecetas;

        }
        public List<VistaReceta> getRecetasPorPedido(string NoFactura)
        {
            List<VistaReceta> listRecetas = new List<VistaReceta>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT R.NoFactura , R.NoReceta , C.Nombre AS NombreCliente ,"
                    + " C.Apellido as Apellidos, c.Cedula as CedulaCliente, D.Nombre AS NombreDoctor, D.NoDoctor"
                    + " FROM"
                    + " (RECETA AS R JOIN DOCTOR AS D ON R.NoDoctor = D.NoDoctor) JOIN CLIENTE AS C ON R.IdCliente = C.IdCliente"
                    + " WHERE R.NoFactura = '"+NoFactura+"'  ;"
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    VistaReceta vista_receta = new VistaReceta();
                    vista_receta.NoFactura = rdr["NoFactura"].ToString();
                    vista_receta.NoReceta = rdr["NoReceta"].ToString();
                    vista_receta.NombreCliente = rdr["NombreCliente"].ToString();
                    vista_receta.Apellidos = rdr["Apellidos"].ToString();
                    vista_receta.CedulaCliente = rdr["CedulaCliente"].ToString();
                    vista_receta.NombreDoctor = rdr["NombreDoctor"].ToString();
                    vista_receta.NoDoctor = rdr["NoDoctor"].ToString();
                    listRecetas.Add(vista_receta);
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