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
                    "SELECT NoFactura , FechaRecojo , NoSucursal , IdCliente, Estado , Empresa , TelefonoPreferido  FROM PEDIDO;", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Pedido pedido = new Pedido();
                    pedido.NoFactura = rdr["NoFactura"].ToString();
                    pedido.FechaRecojo = rdr["FechaRecojo"].ToString();
                    pedido.NoSucursal = rdr["NoSucursal"].ToString();
                    pedido.IdCliente = rdr["IdCliente"].ToString();
                    pedido.Estado = rdr["Estado"].ToString();
                    pedido.Empresa = rdr["Empresa"].ToString();
                    pedido.TelefonoPreferido = rdr["TelefonoPreferido"].ToString();
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
                    "INSERT INTO PEDIDO ( FechaRecojo , NoSucursal , IdCliente, Estado , Empresa , TelefonoPreferido )"
                    + " VALUES('" + pedido.FechaRecojo + "', '" + pedido.NoSucursal + "', '" + pedido.IdCliente + "', '" + pedido.Estado + "','" + pedido.Empresa + "' , '"+pedido.TelefonoPreferido+"'); "
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
                    "UPDATE PEDIDO  SET FechaRecojo = '" + pedido.FechaRecojo + "', NoSucursal = '" + pedido.NoSucursal + "', "
                    + " IdCliente = '" + pedido.IdCliente + "', Estado = '" + pedido.Estado + "' , Empresa = '" + pedido.Empresa + "' , TelefonoPreferido = '"+pedido.TelefonoPreferido+"'"
                    + " WHERE NoFactura = '" + NoFactura + "' ; "
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
                    "DELETE FROM PEDIDO WHERE NoFactura = '" + NoFactura + "'; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public List<VistaPedido> getAllVistasPedidos()
        {
            List<VistaPedido> listPedidos = new List<VistaPedido>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                   "SELECT P.NoFactura, C.Nombre as NombreCliente, C.Apellido, P.TelefonoPreferido, S.Nombre AS SucursalDeRecojo,"
                   +" CONVERT(VARCHAR(10), P.FechaRecojo, 120) as Fecha, CONVERT(VARCHAR(10), FechaRecojo, 108) as Hora, p.Estado, C.Prioridad"
                   +" FROM((PEDIDO AS P JOIN CLIENTE AS C ON P.IdCliente = C.IdCliente)"
                   +" jOIN SUCURSAL AS S ON P.NoSucursal = S.NoSucursal)"
                   +" ORDER BY (FechaRecojo);" 
                    , con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    VistaPedido pedido = new VistaPedido();
                    pedido.NoFactura = rdr["NoFactura"].ToString();
                    pedido.NombreCliente = rdr["NombreCliente"].ToString();
                    pedido.Apellidos = rdr["Apellido"].ToString();
                    pedido.Telefono = rdr["TelefonoPreferido"].ToString();
                    pedido.SucursalDeRecojo = rdr["SucursalDeRecojo"].ToString();
                    pedido.FechaRecojo = rdr["Fecha"] + " " + rdr["Hora"].ToString();
                    pedido.Estado = rdr["Estado"].ToString();
                    pedido.Prioridad = rdr["Prioridad"].ToString();
                    listPedidos.Add(pedido);
                }
            }
            return listPedidos;

        }
    }
}