USE FARMATICA;

SELECT M.Codigo , M.Nombre , MP.Cantidad , M.Costo AS CostoUnitario , m.CasaFarmaceutica FROM 
(PEDIDO AS P JOIN MEDICAMENTOS_POR_PEDIDO AS MP ON P.NoFactura = MP.NoFactura)
JOIN MEDICAMENTO AS M ON MP.CodigoMedicamento = M.Codigo
WHERE P.NoFactura = '3' ;