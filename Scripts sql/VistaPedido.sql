USE FARMATICA;
SELECT P.NoFactura, C.Nombre as NombreCliente, C.Apellido,P.TelefonoPreferido ,S.Nombre AS SucursalDeRecojo ,P.FechaRecojo, p.Estado   FROM
((PEDIDO AS P JOIN CLIENTE AS C ON P.IdCliente = C.IdCliente) 
jOIN SUCURSAL AS S ON P.NoSucursal = S.NoSucursal)  
ORDER BY (FechaRecojo); 
 