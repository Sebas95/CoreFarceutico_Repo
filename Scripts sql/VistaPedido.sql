USE FARMATICA;
SELECT P.NoFactura, C.Nombre as NombreCliente, C.Apellido,T.Telefono,S.Nombre AS SucursalDeRecojo ,P.HoraRecojo, p.Estado   FROM
((PEDIDO AS P JOIN CLIENTE AS C ON P.IdCliente = C.IdCliente) 
jOIN SUCURSAL AS S ON P.NoSucursal = S.NoSucursal) JOIN TELEFONOS_POR_CLIENTE AS T ON C.IdCliente = T.IdCliente 
WHERE T.Descripcion = 'Preferido'
ORDER BY (HoraRecojo)
; 
 