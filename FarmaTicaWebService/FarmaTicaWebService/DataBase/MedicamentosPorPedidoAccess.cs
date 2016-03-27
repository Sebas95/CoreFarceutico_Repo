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
        public List<MedicamentoPorPedido> getMedicamentosPorPedido()
        {
            List<MedicamentoPorPedido> listMedicamento_por_pedido = new List<MedicamentoPorPedido>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT NoFactura ,CodigoMedicamento FROM MEDICAMENTOS_POR_PEDIDO;", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    MedicamentoPorPedido medicamento_por_pedido = new MedicamentoPorPedido();
                    medicamento_por_pedido.NoFactura = rdr["NoFactura"].ToString();
                    medicamento_por_pedido.CodigoMedicamento = rdr["CodigoMedicamento"].ToString();
                    listMedicamento_por_pedido.Add(medicamento_por_pedido);
                }
            }
            return listMedicamento_por_pedido;

        }
        public List<MedicamentoPorPedido> getMedicamentosPorPedido(string NoFactura)
        {
            List<MedicamentoPorPedido> listMedicamento_por_pedido = new List<MedicamentoPorPedido>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT NoFactura ,CodigoMedicamento FROM MEDICAMENTOS_POR_PEDIDO WHERE NoFactura = '"+NoFactura+"';", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    MedicamentoPorPedido medicamento_por_pedido = new MedicamentoPorPedido();
                    medicamento_por_pedido.NoFactura = rdr["NoFactura"].ToString();
                    medicamento_por_pedido.CodigoMedicamento = rdr["CodigoMedicamento"].ToString();
                    listMedicamento_por_pedido.Add(medicamento_por_pedido);
                }
            }
            return listMedicamento_por_pedido;

        }
        public MedicamentoPorPedido addMedicamento_por_pedido(MedicamentoPorPedido medicamento_por_pedido)
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
    
        public void Delete_Medicamento_por_pedido(MedicamentoPorPedido medicamento_por_pedido)
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