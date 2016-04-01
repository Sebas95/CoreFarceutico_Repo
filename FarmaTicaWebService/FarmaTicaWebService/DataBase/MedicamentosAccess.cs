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
        public List<Medicamento> getAllMedicamentos(string Prescripcion)
        {
            List<Medicamento> listMedicamentos = new List<Medicamento>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Nombre, Codigo , Prescripcion , CasaFarmaceutica, Costo  FROM MEDICAMENTO WHERE Prescripcion = '"+Prescripcion+"' ; "
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
        public Medicamento getMedicamento(string codigo)
        {
            Medicamento medicamento = new Medicamento();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Nombre, Codigo , Prescripcion , CasaFarmaceutica, Costo FROM MEDICAMENTO WHERE Codigo = '"+codigo+"' ; "
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                
                if (rdr.Read()) //si existe en la base de datos
                {
                   
                    medicamento.Nombre = rdr["Nombre"].ToString();
                    medicamento.codigo = rdr["Codigo"].ToString();
                    medicamento.Prescripcion = rdr["Prescripcion"].ToString();
                    if (medicamento.Prescripcion == "True") { medicamento.Prescripcion = "1"; }
                    if (medicamento.Prescripcion == "False") { medicamento.Prescripcion = "0"; }
                    medicamento.CasaFarmaceutica = rdr["CasaFarmaceutica"].ToString();
                    medicamento.Costo = rdr["Costo"].ToString();
            
                }
            }
            return medicamento;
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
                con.Open();
                cmd.ExecuteNonQuery();
                medicamento.codigo = Codigo;
            }
            return medicamento;
        }

        public void deleteMedicamento(string Codigo)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE  FROM MEDICAMENTO WHERE Codigo = '"+Codigo+"';"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }



    }
}