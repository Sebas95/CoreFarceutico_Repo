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
                    "SELECT CodigoMedicamento , NoReceta , Cantidad FROM MEDICAMENTOS_POR_RECETA ; ", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    MedicamentoPorReceta medicamento_por_receta = new MedicamentoPorReceta();
                    medicamento_por_receta.CodigoMedicamento = rdr["CodigoMedicamento"].ToString();
                    medicamento_por_receta.NoReceta = rdr["NoReceta"].ToString();
                    medicamento_por_receta.Cantidad = rdr["Cantidad"].ToString();
                    listMedicamento_por_receta.Add(medicamento_por_receta);
                }
            }
            return listMedicamento_por_receta;

        }
        public List<VistaMedicamentosPorReceta> getMedicamentosPorReceta(string NoReceta)
        {
            List<VistaMedicamentosPorReceta> listMedicamento_por_receta = new List<VistaMedicamentosPorReceta>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT M.Codigo , M.Nombre , MR.Cantidad , M.Costo AS CostoUnitario , M.CasaFarmaceutica   FROM" 
                    +" (RECETA AS R  JOIN MEDICAMENTOS_POR_RECETA AS MR ON R.NoReceta = MR.NoReceta)"
                    +" JOIN MEDICAMENTO AS M ON MR.CodigoMedicamento = M.Codigo"
                    +" WHERE R.NoReceta = '"+NoReceta+"'  ; "
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    VistaMedicamentosPorReceta medicamento_por_receta = new VistaMedicamentosPorReceta();
                    medicamento_por_receta.Codigo = rdr["Codigo"].ToString();
                    medicamento_por_receta.Nombre = rdr["Nombre"].ToString();
                    medicamento_por_receta.Cantidad = rdr["Cantidad"].ToString();
                    medicamento_por_receta.CostoUnitario = rdr["CostoUnitario"].ToString();
                    medicamento_por_receta.CasaFarmaceutica = rdr["CasaFarmaceutica"].ToString();
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
                    "INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta , Cantidad)"
                    + " VALUES('"+medicamento_por_receta.CodigoMedicamento+"', '"+medicamento_por_receta.NoReceta+"','"+medicamento_por_receta.Cantidad +"' ) ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return medicamento_por_receta;
        }



        public void DeleteMedicamento_por_receta(MedicamentoPorReceta medicamento_por_receta)
        {
            Console.WriteLine(medicamento_por_receta);
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