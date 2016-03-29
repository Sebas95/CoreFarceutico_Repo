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
                    "SELECT NoFactura ,CodigoMedicamento, Cantidad FROM MEDICAMENTOS_POR_PEDIDO;", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    MedicamentoPorPedido medicamento_por_pedido = new MedicamentoPorPedido();
                    medicamento_por_pedido.NoFactura = rdr["NoFactura"].ToString();
                    medicamento_por_pedido.CodigoMedicamento = rdr["CodigoMedicamento"].ToString();
                    medicamento_por_pedido.Cantidad = rdr["Cantidad"].ToString();
                    listMedicamento_por_pedido.Add(medicamento_por_pedido);
                }
            }
            return listMedicamento_por_pedido;

        }
        public List<VistaMedicamentosPorPedido> getMedicamentosPorPedido(string NoFactura)
        {
            List<VistaMedicamentosPorPedido> listMedicamento_por_pedido = new List<VistaMedicamentosPorPedido>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT M.Codigo , M.Nombre , MP.Cantidad , M.Costo AS CostoUnitario , m.CasaFarmaceutica , M.Prescripcion FROM"
                    + " (PEDIDO AS P JOIN MEDICAMENTOS_POR_PEDIDO AS MP ON P.NoFactura = MP.NoFactura)"
                    + " JOIN MEDICAMENTO AS M ON MP.CodigoMedicamento = M.Codigo"
                    + " WHERE P.NoFactura = '" + NoFactura + "' ; "
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    VistaMedicamentosPorPedido medicamento_por_pedido = new VistaMedicamentosPorPedido();
                    medicamento_por_pedido.Codigo = rdr["Codigo"].ToString();
                    medicamento_por_pedido.Nombre = rdr["Nombre"].ToString();
                    medicamento_por_pedido.Cantidad = rdr["Cantidad"].ToString();
                    medicamento_por_pedido.CostoUnitario = rdr["CostoUnitario"].ToString();
                    medicamento_por_pedido.CasaFarmaceutica = rdr["CasaFarmaceutica"].ToString();
                    medicamento_por_pedido.Prescripcion = rdr["Prescripcion"].ToString();
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
                    "INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento, Cantidad  )"
                    + " VALUES('" + medicamento_por_pedido.NoFactura + "', '" + medicamento_por_pedido.CodigoMedicamento + "','" + medicamento_por_pedido.Cantidad + "'); "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return medicamento_por_pedido;
        }

        public void Delete_Medicamento_por_pedido(string NoFactura, string CodigoMedicamento)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM MEDICAMENTOS_POR_PEDIDO"
                    +" WHERE NoFactura = '"+NoFactura+"' AND CodigoMedicamento = '"+CodigoMedicamento+"';"
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}