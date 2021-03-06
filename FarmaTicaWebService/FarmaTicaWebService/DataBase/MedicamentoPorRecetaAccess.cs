﻿using System;
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
        /// <summary>
        /// Selects all the MedicamentosPorReceta objects mapping each one
        /// </summary>
        /// <returns>  List<MedicamentoPorReceta>  </returns>
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
        /// <summary>
        /// Selects a all The Medicmanento rows related with Single Receta row and maps to VistaMedicmanetosPorReceta objects
        /// </summary>
        /// <param name="NoReceta"> The id of an specific Receta row</param>
        /// <returns> List<VistaMedicamentosPorReceta> </returns>
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
        /// <summary>
        /// Inserts a row in MedicamnetoPorReceta table, represented as MedicamentoPorReceta object
        /// </summary>
        /// <param name="medicamento_por_receta"> The new The MedicamentoPorReceta object </param>
        /// <returns>The MedicamentoPorReceta object inserted</returns>
        public MedicamentoPorReceta addMedicamento_por_receta(MedicamentoPorReceta medicamento_por_receta)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            MedicamentoEnSucursalAccess medicamentoEnSucursalAccess = new MedicamentoEnSucursalAccess();
            int cantidad_disponible = medicamentoEnSucursalAccess.getCantidadDisponible(medicamento_por_receta.CodigoMedicamento, medicamento_por_receta.NoSucursal);

            //si hay cantidad disponible
            if (Convert.ToInt32(medicamento_por_receta.Cantidad) < cantidad_disponible)
            {
                int cantidad_nueva = cantidad_disponible - Convert.ToInt32(medicamento_por_receta.Cantidad);
                //update Cantdad of MedicamentoEnSucursal
                medicamentoEnSucursalAccess.setCantidadDisponible(medicamento_por_receta.CodigoMedicamento, medicamento_por_receta.NoSucursal, cantidad_nueva);
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta , Cantidad)"
                        + " VALUES('" + medicamento_por_receta.CodigoMedicamento + "', '" + medicamento_por_receta.NoReceta + "','" + medicamento_por_receta.Cantidad + "' ) ; "
                        , con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                //update Cantdad of MedicamentoEnSucursal
                medicamentoEnSucursalAccess.setCantidadDisponible(medicamento_por_receta.CodigoMedicamento, medicamento_por_receta.NoSucursal, 0);
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta , Cantidad)"
                        + " VALUES('" + medicamento_por_receta.CodigoMedicamento + "', '" + medicamento_por_receta.NoReceta + "','" + cantidad_disponible + "' ) ; "
                        , con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                medicamento_por_receta.Cantidad = cantidad_disponible.ToString();
            }


            return medicamento_por_receta;
        }


        /// <summary>
        /// Deletes a row if MedicamentoPorReceta table
        /// </summary>
        /// <param name="CodigoMedicamento"></param>
        /// <param name="NoReceta"></param>
        public void DeleteMedicamento_por_receta(string CodigoMedicamento, string NoReceta)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM MEDICAMENTOS_POR_RECETA WHERE  "
                    +" CodigoMedicamento = '"+CodigoMedicamento+ "' AND NoReceta = '"+NoReceta+"' ;"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
       
        
}