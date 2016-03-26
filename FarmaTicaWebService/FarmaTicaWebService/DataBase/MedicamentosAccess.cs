using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaTicaWebService.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace FarmaTicaWebService.DataBase
{
    public class MedicamentosAccess
    {
        public List<Medicamento> getAllMedicamentos()
        {
            List < Medicamento > listMedicamentos  = new List<Medicamento>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Nombre, Codigo , Prescripcion , CasaFarmaceutica, Costo    FROM MEDICAMENTO ; "
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Medicamento medicamento = new Medicamento();
                    medicamento.Nombre = rdr["Nombre"].ToString();
                    medicamento.codigo = rdr["Codigo"].ToString();
                    medicamento.Prescripcion = rdr["Prescripcion"].ToString();
                    if (medicamento.Prescripcion == "True") { medicamento.Prescripcion = "1"; }
                    if (medicamento.Prescripcion == "False") { medicamento.Prescripcion = "0"; }
                    medicamento.CasaFarmaceutica = rdr["CasaFarmaceutica"].ToString();
                    medicamento.Costo = rdr["Costo"].ToString();
                    listMedicamentos.Add(medicamento);
                }
            }
            return listMedicamentos;
        }
        public Medicamento addMedicamento(Medicamento medicamento)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO MEDICAMENTO (Nombre ,Prescripcion, Codigo , CasaFarmaceutica , Costo) " +
                    "VALUES('"+medicamento.Nombre+"', "+medicamento.Prescripcion+", '"+medicamento.codigo+"', '"+medicamento.CasaFarmaceutica+"', "+medicamento.Costo+"); "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return medicamento;
        }

        public Medicamento updateMedicamento(string Codigo, Medicamento medicamento)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE MEDICAMENTO SET Nombre = '"+medicamento.Nombre+"', Prescripcion = "+medicamento.Prescripcion+", CasaFarmaceutica = '"+medicamento.CasaFarmaceutica+"', Costo = "+ medicamento.Costo+
                    " WHERE Codigo = '"+Codigo+"' ; "
                    , con);
                medicamento.codigo = Codigo;
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return medicamento;
        }

        public void deleteMedicamento(string Codigo)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE  FROM MEDICAMENTO WHERE Codigo = "+Codigo+";"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public List<SucursalPorMedicamento> getSucursales(string codigoMedicamento)
        {
            List <SucursalPorMedicamento > listSucursales = new List<SucursalPorMedicamento > ();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT  S.NoSucursal , S.Nombre  , S.Direccion , S.Telefono , MS.Cantidad"
                    +" FROM MEDICAMENTO_EN_SUCURSAL AS MS JOIN SUCURSAL AS S"
                    +" ON MS.NoSucursal = S.NoSucursal"
                    +" WHERE MS.CodigoMedicamento = '"+codigoMedicamento+"'; "
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    SucursalPorMedicamento  sucursal = new SucursalPorMedicamento();
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
         public SucursalPorMedicamento addSucursalPorMedicamento(string codigoMedicamento, SucursalPorMedicamento sucursal_por_medicamento)
         {
             string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
             using (SqlConnection con = new SqlConnection(cs))
             {
                 SqlCommand cmd = new SqlCommand(
                     "INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento , NoSucursal, Cantidad) "+
                     " VALUES('"+ codigoMedicamento+"', '"+sucursal_por_medicamento.NoSucursal+"', '"+sucursal_por_medicamento.Cantidad+"'); "
                     , con);
                 con.Open();
                 cmd.ExecuteNonQuery();

             }
             return sucursal_por_medicamento;


         }
        //
        public void deleteRemoveSucursalFromMedicamento(string codigoMedicamento, string NoSucursal)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM  MEDICAMENTO_EN_SUCURSAL WHERE CodigoMedicamento = '"+codigoMedicamento+"' and NoSucursal = '"+NoSucursal+"' ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

    }
}