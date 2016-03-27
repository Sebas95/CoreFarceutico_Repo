
/* Cantidad de ventas */
SELECT COUNT(NoFactura) FROM PEDIDO WHERE Estado='Completo'; /* AND EMPRESA=p; */

SELECT COUNT(NoFactura) FROM PEDIDO WHERE Estado='Completo';/* AND EMPRESA=F; */


/* Cantidad de ventas por compa��a */
SELECT COUNT(NoFactura) FROM PEDIDO WHERE (Estado='Completo' AND EMPRESA='P');

SELECT COUNT(NoFactura) FROM PEDIDO WHERE (Estado='Completo' AND EMPRESA='F');

/* Productos m�s vendidos por el nuevo software*/
SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Codigo AND P.Estado='Completo';

/* Productos m�s vendidos por el nuevo software por compa�ia*/
SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Codigo AND P.Estado='Completo' AND P.Empresa = 'P';

SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Codigo AND P.Estado='Completo' AND P.Empresa = 'F';
