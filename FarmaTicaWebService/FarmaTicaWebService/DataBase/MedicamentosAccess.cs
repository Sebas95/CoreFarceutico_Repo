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
        /// <summary>
        /// Selects all the rows of Meidcamento table, maps to Medicamento objects and returns it
        /// </summary>
        /// <returns> List<Medicamento> </returns>
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
        /// <summary>
        /// Selects all the rows of Meidcamento table filtered by Prescripcion attribute, maps to Medicamento objects and returns it
        /// </summary>
        /// <param name="Prescripcion"> Tha attribute Prescripcion (0 or 1) </param>
        /// <returns> List<Medicamento></returns>
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
        public List<Medicamento> getAllMedicamentosPorSucursal(string Prescripcion,string Nosucursal)
        {
            List<Medicamento> listMedicamentos = new List<Medicamento>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT M.Nombre, M.Codigo , M.Prescripcion , M.CasaFarmaceutica , M.Costo  FROM MEDICAMENTO AS M JOIN MEDICAMENTO_EN_SUCURSAL AS MS" 
                    +" ON M.Codigo = MS.CodigoMedicamento " 
                    +" WHERE M.Prescripcion = '" + Prescripcion + "'  AND MS.NoSucursal = '"+ Nosucursal +"' AND MS.Cantidad > 0  ; "
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
        /// <summary>
        /// Selects a specific row of Medicamento table and maps into an object Medicamento 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
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
        /// <summary>
        /// INserts a row in the table Medicamento
        /// </summary>
        /// <param name="medicamento"> The object tobe mapped and inserted </param>
        /// <returns> The new object Medicamento inserted </returns>
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
        /// <summary>
        /// Updates an specific Medicamento row
        /// </summary>
        /// <param name="Codigo"> The id of the row or primary key </param>
        /// <param name="medicamento"> The medicamento object modified fr updating </param>
        /// <returns> The Medicamento object inserted </returns>
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
        /// <summary>
        /// Deletes a row i the tabe Medicamento
        /// </summary>
        /// <param name="Codigo"> The id of the Medicamento object to be deleted </param>
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