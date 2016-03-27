using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaTicaWebService.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace FarmaTicaWebService.DataBase
{
    public class PedidoAccess
    {
        public List<Pedido> getAllPedidos()
        {
            List<Pedido> listPedidos = new List<Pedido>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT NoFactura , HoraRecojo , NoSucursal , IdCliente, Estado , Empresa  FROM PEDIDO;", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Pedido pedido = new Pedido();
                    pedido.NoFactura = rdr["NoFactura"].ToString();
                    pedido.HoraRecojo = rdr["HoraRecojo"].ToString();
                    pedido.NoSucursal = rdr["NoSucursal"].ToString();
                    pedido.IdCliente = rdr["IdCliente"].ToString();
                    pedido.Estado = rdr["Estado"].ToString();
                    pedido.Estado = rdr["Empresa"].ToString();
                    listPedidos.Add(pedido);
                }
            }
            return listPedidos;

        }
        public Pedido addPedido(Pedido pedido)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO PEDIDO ( HoraRecojo , NoSucursal , IdCliente, Estado , Empresa)" 
                    +" VALUES('"+pedido.HoraRecojo+"', '"+pedido.NoSucursal+"', '"+pedido.IdCliente+"', '"+pedido.Estado+"','"+pedido.Empresa+"'); "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return pedido;
        }
        public Pedido updatePedido(string NoFactura, Pedido pedido)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE PEDIDO  SET HoraRecojo = '"+pedido.HoraRecojo+"', NoSucursal = '"+pedido.NoSucursal+"', "
                    +" IdCliente = '"+pedido.IdCliente+"', Estado = '"+pedido.Estado+"' , Empresa = '"+pedido.Empresa +"'" 
                    +" WHERE NoFactura = '"+NoFactura+"' ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return pedido;
        }
        public void deletePedido(string NoFactura)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM PEDIDO WHERE NoFactura = '"+NoFactura+"'; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}