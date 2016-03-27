using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaTicaWebService.Models;
using System.Configuration;
using System.Data.SqlClient;


namespace FarmaTicaWebService.DataBase
{
    public class MedicamentoPorRecetaAccess
    {
        public List<MedicamentoPorReceta> getMedicamentosPorReceta()
        {
            List<MedicamentoPorReceta> listMedicamento_por_receta = new List<MedicamentoPorReceta>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT CodigoMedicamento , NoReceta FROM MEDICAMENTOS_POR_RECETA ;", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    MedicamentoPorReceta medicamento_por_receta = new MedicamentoPorReceta();
                    medicamento_por_receta.CodigoMedicamento = rdr["CodigoMedicamento"].ToString();
                    medicamento_por_receta.NoReceta = rdr["NoReceta"].ToString();
                    listMedicamento_por_receta.Add(medicamento_por_receta);
                }
            }
            return listMedicamento_por_receta;

        }
        public List<MedicamentoPorReceta> getMedicamentosPorReceta(string NoReceta)
        {
            List<MedicamentoPorReceta> listMedicamento_por_receta = new List<MedicamentoPorReceta>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT CodigoMedicamento , NoReceta FROM MEDICAMENTOS_POR_RECETA WHERE NoReceta = '"+NoReceta+"' ;", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    MedicamentoPorReceta medicamento_por_receta = new MedicamentoPorReceta();
                    medicamento_por_receta.CodigoMedicamento = rdr["CodigoMedicamento"].ToString();
                    medicamento_por_receta.NoReceta = rdr["NoReceta"].ToString();
                    listMedicamento_por_receta.Add(medicamento_por_receta);
                }
            }
            return listMedicamento_por_receta;

        }
        public MedicamentoPorReceta addMedicamento_por_receta(MedicamentoPorReceta medicamento_por_receta)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta)"
                    + " VALUES('"+medicamento_por_receta.CodigoMedicamento+"', '"+medicamento_por_receta.NoReceta+"') ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return medicamento_por_receta;
        }

        public void DeleteMedicamento_por_receta(MedicamentoPorReceta medicamento_por_receta)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM MEDICAMENTOS_POR_RECETA WHERE  "
                    +" CodigoMedicamento = '"+medicamento_por_receta.CodigoMedicamento+ "' AND NoReceta = '"+medicamento_por_receta.NoReceta+"' ;"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
       
        
}