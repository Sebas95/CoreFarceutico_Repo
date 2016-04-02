using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaTicaWebService.Models;
using System.Configuration;
using System.Data.SqlClient;
namespace FarmaTicaWebService.DataBase
{
    public class ReportesAccess
    {
        public List<ProductosMasVendidos> getAllProductosMasVendidos()
        {
            List<ProductosMasVendidos> listProductos = new List<ProductosMasVendidos>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string statement =
                    "Select T.Nombre AS NOMBRE_DEL_MEDICAMENTO , SUM(T.Cantidad) AS TOTAL_VENDIDO"
                    +" FROM"
                    +" ("
                    +    "SELECT Nombre, Cantidad"
                    +    " FROM MEDICAMENTOS_POR_PEDIDO  JOIN MEDICAMENTO  ON Codigo = CodigoMedicamento"
                    +        " UNION ALL"
                    +    " SELECT Nombre, Cantidad"
                    +    " FROM MEDICAMENTOS_POR_RECETA JOIN MEDICAMENTO ON Codigo = CodigoMedicamento"
                    +        " UNION ALL"
                    +    " SELECT Nombre, Cantidad"
                    +    " FROM MEDICAMENTOS_POR_PEDIDO_FISICO JOIN MEDICAMENTO ON Codigo = CodigoMedicamento"
                    + " ) AS T"
                    + " GROUP BY (T.Nombre)"
                    +" ORDER BY(TOTAL_VENDIDO) DESC  " ;

                SqlCommand cmd = new SqlCommand(statement, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    ProductosMasVendidos producto = new ProductosMasVendidos();
                    producto.NombreMedicamento = rdr["NOMBRE_DEL_MEDICAMENTO"].ToString();
                    producto.CantidadVendida = rdr["TOTAL_VENDIDO"].ToString();
                    listProductos.Add(producto);
                }
            }
            return listProductos;
        }
        public List<ProductosMasVendidos> getAllProductosMasVendidosPorNuevoSoftware()
        {
            List<ProductosMasVendidos> listProductos = new List<ProductosMasVendidos>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string statement =
                            " Select T.Nombre AS NOMBRE_DEL_MEDICAMENTO , SUM(T.Cantidad) AS TOTAL_VENDIDO"
                            +    " FROM"
                            +    " ("
                            +        " SELECT Nombre, Cantidad"
                            +        " FROM MEDICAMENTOS_POR_PEDIDO  JOIN MEDICAMENTO  ON Codigo = CodigoMedicamento"
                            +            " UNION ALL"
                            +        " SELECT Nombre, Cantidad"
                            +        " FROM MEDICAMENTOS_POR_RECETA JOIN MEDICAMENTO ON Codigo = CodigoMedicamento"
                            +    " ) AS T"
                            +" GROUP BY (T.Nombre)"
                            +" ORDER BY(TOTAL_VENDIDO) DESC"
                            ;
                SqlCommand cmd = new SqlCommand(statement, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    ProductosMasVendidos producto = new ProductosMasVendidos();
                    producto.NombreMedicamento = rdr["NOMBRE_DEL_MEDICAMENTO"].ToString();
                    producto.CantidadVendida = rdr["TOTAL_VENDIDO"].ToString();
                    listProductos.Add(producto);
                }
            }
            return listProductos;
        }

        public List<Venta> getCantidadDeVentasPorEmpresa(string Empresa)
        {
            List<Venta> listventas = new List<Venta>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string statement =
                         "Select T.NoFactura , SUM(T.Cantidad * T.Costo) AS TOTAL_POR_FACTURA"
                        +    " FROM"
                        +    " ("
                        +        " SELECT P.NoFactura, Cantidad, M.Costo, Empresa FROM"
                        +            " PEDIDO AS P  JOIN MEDICAMENTOS_POR_PEDIDO AS MP ON MP.NoFactura = P.NoFactura"
                        +            " JOIN MEDICAMENTO AS M  ON M.Codigo = MP.CodigoMedicamento"
                        +        " UNION ALL"
                        +        " SELECT P.NoFactura, Cantidad, M.Costo, Empresa   FROM"
                        +            " PEDIDO AS P JOIN RECETA AS R ON P.NoFactura = R.NoFactura"
                        +            " JOIN  MEDICAMENTOS_POR_RECETA AS MP ON R.NoReceta = MP.NoReceta"
                        +            " JOIN MEDICAMENTO AS M ON M.Codigo = MP.CodigoMedicamento"
                        +        " UNION ALL"
                        +        " SELECT P.NoFactura, Cantidad, Costo, Empresa FROM"
                        +            " PEDIDO AS P JOIN MEDICAMENTOS_POR_PEDIDO_FISICO AS MPF ON P.NoFactura = MPF.NoFactura"
                        +            " JOIN MEDICAMENTO ON Codigo = CodigoMedicamento"
                        +    " ) AS T"
                        +    " WHERE EMPRESA = '"+Empresa+"'"
                        +    " GROUP BY (NoFactura)"
                            ;
                SqlCommand cmd = new SqlCommand(statement, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Venta venta = new Venta();
                    venta.NoFactura = rdr["NoFactura"].ToString();
                    venta.Total= rdr["TOTAL_POR_FACTURA"].ToString();
                    listventas.Add(venta);
                }
            }
            return listventas;
        }
        public List<ProductosMasVendidos> getProductosMasVendidosPorEmpresa(string Empresa)
        {
            List<ProductosMasVendidos> listProductos = new List<ProductosMasVendidos>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string statement =
                        "Select T.Nombre AS NOMBRE_DEL_MEDICAMENTO , SUM(T.Cantidad) AS TOTAL_VENDIDO"
                        +    " FROM"
                        +    " ("
                        +        " SELECT Nombre, Cantidad, Empresa FROM"
                        +            " PEDIDO AS P  JOIN MEDICAMENTOS_POR_PEDIDO AS MP ON MP.NoFactura = P.NoFactura"
                        +            " JOIN MEDICAMENTO AS M  ON M.Codigo = MP.CodigoMedicamento"
                        +        " UNION ALL"
                        +        " SELECT Nombre, Cantidad, Empresa FROM"
                        +            " PEDIDO AS P JOIN RECETA AS R ON P.NoFactura = R.NoFactura"
                        +           " JOIN  MEDICAMENTOS_POR_RECETA AS MP ON R.NoReceta = MP.NoReceta"
                        +            " JOIN MEDICAMENTO AS M ON M.Codigo = MP.CodigoMedicamento"
                        +        " UNION ALL"
                        +        " SELECT Nombre, Cantidad, Empresa FROM"
                        +            " PEDIDO AS P JOIN MEDICAMENTOS_POR_PEDIDO_FISICO AS MPF ON P.NoFactura = MPF.NoFactura"
                        +            " JOIN MEDICAMENTO ON Codigo = CodigoMedicamento"
                        +    " ) AS T"
                        +    " WHERE Empresa = '"+Empresa+"'"
                        +        " GROUP BY (T.Nombre)"
                        +        " ORDER BY(TOTAL_VENDIDO) DESC"
                            ;
                SqlCommand cmd = new SqlCommand(statement, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    ProductosMasVendidos producto = new ProductosMasVendidos();
                    producto.NombreMedicamento = rdr["NOMBRE_DEL_MEDICAMENTO"].ToString();
                    producto.CantidadVendida = rdr["TOTAL_VENDIDO"].ToString();
                    listProductos.Add(producto);
                }
            }
            return listProductos;
        }
        public String getTotalVendidoPorEmpresa(string Empresa)
        {
            String total_final = null;
            List<ProductosMasVendidos> listProductos = new List<ProductosMasVendidos>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string statement =
                        "Select SUM(T.Cantidad * t.Costo) AS TOTAL_DE_VENTAS"
                        + " FROM"
                        + " ("
                        + " SELECT P.NoFactura, Cantidad, M.Costo, Empresa FROM"
                        + "  PEDIDO AS P  JOIN MEDICAMENTOS_POR_PEDIDO AS MP ON MP.NoFactura = P.NoFactura"
                        + "  JOIN MEDICAMENTO AS M  ON M.Codigo = MP.CodigoMedicamento"
                        + " UNION ALL"
                        + "  SELECT P.NoFactura, Cantidad, M.Costo, Empresa   FROM"
                        + "  PEDIDO AS P JOIN RECETA AS R ON P.NoFactura = R.NoFactura"
                        + " JOIN  MEDICAMENTOS_POR_RECETA AS MP ON R.NoReceta = MP.NoReceta"
                        + " JOIN MEDICAMENTO AS M ON M.Codigo = MP.CodigoMedicamento"
                        + "  UNION ALL"
                        + " SELECT P.NoFactura, Cantidad, Costo, Empresa FROM"
                        + "  PEDIDO AS P JOIN MEDICAMENTOS_POR_PEDIDO_FISICO AS MPF ON P.NoFactura = MPF.NoFactura"
                        + " JOIN MEDICAMENTO ON Codigo = CodigoMedicamento"
                        + " ) AS T"
                        + " WHERE EMPRESA = '" + Empresa + "'"
                            ;
                SqlCommand cmd = new SqlCommand(statement, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) //si existe en la base de datos
                {
                    total_final = rdr["TOTAL_DE_VENTAS"].ToString();
                }
            }
            return total_final;
        }

    }
}