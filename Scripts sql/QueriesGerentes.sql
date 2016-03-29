
/* Cantidad de ventas */
SELECT COUNT(NoFactura) FROM PEDIDO WHERE Estado='Completo'; /* AND EMPRESA=p; */

SELECT COUNT(NoFactura) FROM PEDIDO WHERE Estado='Completo';/* AND EMPRESA=F; */


/* Cantidad de ventas por compañía */
SELECT COUNT(NoFactura) FROM PEDIDO WHERE (Estado='Completo' AND EMPRESA='P');

SELECT COUNT(NoFactura) FROM PEDIDO WHERE (Estado='Completo' AND EMPRESA='F');

/* Productos más vendidos */
SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Código AND P.Estado='Completo';

/* Productos más vendidos por compañia */
SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Código AND P.Estado='Completo' AND P.Empresa='P';

SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Código AND P.Estado='Completo' AND P.Empresa='F';


/* Productos más vendidos por el nuevo software */
/**
SELECT SUM(cantidad), MEDICAMENTO.Nombre 
FROM 
	SELECT Mpp.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
	WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Código
		UNION
	SELECT Mppf.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO_FISICO AS Mppf, PEDIDO_FISICO AS Pf, MEDICAMENTO AS M
	WHERE Pf.NoFactura=Mppf.NoFactura AND Mppf.CodigoMedicamento=M.Código;


/* Productos más vendidos por el nuevo software por compañia*/
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, MEDICAMENTO AS M
FROM
	SELECT Mpp.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
	WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Código
		UNION
	SELECT Mppf.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO_FISICO AS Mppf, PEDIDO_FISICO AS Pf, MEDICAMENTO AS M
	WHERE Pf.NoFactura=Mppf.NoFactura AND Mppf.CodigoMedicamento=M.Código;

	FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, MEDICAMENTO AS M
FROM
	SELECT Mpp.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
	WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.Código
		UNION
	SELECT Mppf.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO_FISICO AS Mppf, PEDIDO_FISICO AS Pf, MEDICAMENTO AS M
	WHERE Pf.NoFactura=Mppf.NoFactura AND Mppf.CodigoMedicamento=M.Código;
**/

