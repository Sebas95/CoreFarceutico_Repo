using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaTicaWebService.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace FarmaTicaWebService.DataBase
{
    public class MedicamentosPorPedidoAccess
    {
        public List<Medicamento_por_pedido> getMedicamentosPorPedido()
        {
            List<Medicamento_por_pedido> listMedicamento_por_pedido = new List<Medicamento_por_pedido>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT NoFactura ,CodigoMedicamento FROM MEDICAMENTOS_POR_PEDIDO;", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Medicamento_por_pedido medicamento_por_pedido = new Medicamento_por_pedido();
                    medicamento_por_pedido.NoFactura = rdr["NoFactura"].ToString();
                    medicamento_por_pedido.CodigoMedicamento = rdr["CodigoMedicamento"].ToString();
                    listMedicamento_por_pedido.Add(medicamento_por_pedido);
                }
            }
            return listMedicamento_por_pedido;

        }
        public List<Medicamento_por_pedido> getMedicamentosPorPedido(string NoFactura)
        {
            List<Medicamento_por_pedido> listMedicamento_por_pedido = new List<Medicamento_por_pedido>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT NoFactura ,CodigoMedicamento FROM MEDICAMENTOS_POR_PEDIDO WHERE NoFactura = '"+NoFactura+"';", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Medicamento_por_pedido medicamento_por_pedido = new Medicamento_por_pedido();
                    medicamento_por_pedido.NoFactura = rdr["NoFactura"].ToString();
                    medicamento_por_pedido.CodigoMedicamento = rdr["CodigoMedicamento"].ToString();
                    listMedicamento_por_pedido.Add(medicamento_por_pedido);
                }
            }
            return listMedicamento_por_pedido;

        }
        public Medicamento_por_pedido addMedicamento_por_pedido(Medicamento_por_pedido medicamento_por_pedido)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento )" 
                    +" VALUES('"+ medicamento_por_pedido.NoFactura + "', '"+ medicamento_por_pedido .CodigoMedicamento+ "'); "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return medicamento_por_pedido;
        }
    
        public void Delete_Medicamento_por_pedido(Medicamento_por_pedido medicamento_por_pedido)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM MEDICAMENTOS_POR_PEDIDO"
                    +" WHERE NoFactura = '"+medicamento_por_pedido.NoFactura+"', CodigoMedicamento = '"+medicamento_por_pedido.CodigoMedicamento+"';"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}