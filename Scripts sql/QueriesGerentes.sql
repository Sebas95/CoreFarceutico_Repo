
/* Cantidad de ventas */
SELECT COUNT(NoFactura) FROM PEDIDO WHERE Estado='Completo'; /* AND EMPRESA=p; */

SELECT COUNT(NoFactura) FROM PEDIDO WHERE Estado='Completo';/* AND EMPRESA=F; */


/* Cantidad de ventas por compañía */
SELECT COUNT(NoFactura) FROM PEDIDO WHERE (Estado='Completo' AND EMPRESA='P');

SELECT COUNT(NoFactura) FROM PEDIDO WHERE (Estado='Completo' AND EMPRESA='F');

/* Productos más vendidos */
SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Codigo AND P.Estado='Completo' AND ;

/* Productos más vendidos por compañia */
SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Codigo AND P.Estado='Completo' AND P.Empresa='P';

SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Codigo AND P.Estado='Completo' AND P.Empresa='F';

/**
/* Productos más vendidos por el nuevo software */
SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Codigo AND P.Estado='Completo' AND P.Orden='W'; /*Orden Web*/

/* Productos más vendidos por el nuevo software por compañia*/
SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Codigo AND P.Estado='Completo' AND P.Empresa='P' AND P.Orden='W'; /*Orden Web*/

SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Codigo AND P.Estado='Completo' AND P.Empresa='F' AND P.Orden='W'; /*Orden Web*/

**/

