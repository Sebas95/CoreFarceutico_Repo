
/* Cantidad de ventas */
SELECT COUNT(NoFactura) FROM PEDIDO WHERE Estado='Completo'; /* AND EMPRESA=p; */

SELECT COUNT(NoFactura) FROM PEDIDO WHERE Estado='Completo';/* AND EMPRESA=F; */


/* Cantidad de ventas por compa��a */
SELECT COUNT(NoFactura) FROM PEDIDO WHERE (Estado='Completo' AND EMPRESA='P');

SELECT COUNT(NoFactura) FROM PEDIDO WHERE (Estado='Completo' AND EMPRESA='F');

/* Productos m�s vendidos */
SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.C�digo AND P.Estado='Completo';

/* Productos m�s vendidos por compa�ia */
SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.C�digo AND P.Estado='Completo' AND P.Empresa='P';

SELECT SUM(Mpp.Cantidad), M.Nombre
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.C�digo AND P.Estado='Completo' AND P.Empresa='F';


/* Productos m�s vendidos por el nuevo software */
/**
SELECT SUM(cantidad), MEDICAMENTO.Nombre 
FROM 
	SELECT Mpp.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
	WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.C�digo
		UNION
	SELECT Mppf.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO_FISICO AS Mppf, PEDIDO_FISICO AS Pf, MEDICAMENTO AS M
	WHERE Pf.NoFactura=Mppf.NoFactura AND Mppf.CodigoMedicamento=M.C�digo;


/* Productos m�s vendidos por el nuevo software por compa�ia*/
FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, MEDICAMENTO AS M
FROM
	SELECT Mpp.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
	WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.C�digo
		UNION
	SELECT Mppf.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO_FISICO AS Mppf, PEDIDO_FISICO AS Pf, MEDICAMENTO AS M
	WHERE Pf.NoFactura=Mppf.NoFactura AND Mppf.CodigoMedicamento=M.C�digo;

	FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, MEDICAMENTO AS M
FROM
	SELECT Mpp.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO AS Mpp, PEDIDO AS P, MEDICAMENTO AS M
	WHERE P.NoFactura=Mpp.NoFactura AND Mpp.CodigoMedicamento=M.C�digo
		UNION
	SELECT Mppf.Cantidad, M.Nombre
	FROM MEDICAMENTOS_POR_PEDIDO_FISICO AS Mppf, PEDIDO_FISICO AS Pf, MEDICAMENTO AS M
	WHERE Pf.NoFactura=Mppf.NoFactura AND Mppf.CodigoMedicamento=M.C�digo;
**/

