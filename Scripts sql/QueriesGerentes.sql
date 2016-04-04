
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






USE FARMATICA;

/* productos más vendidos */

Select T.Nombre AS NOMBRE_DEL_MEDICAMENTO , SUM(T.Cantidad) AS TOTAL_VENDIDO
	FROM
	(
		SELECT Nombre ,  Cantidad 
		FROM MEDICAMENTOS_POR_PEDIDO  JOIN MEDICAMENTO  ON Codigo = CodigoMedicamento
			UNION ALL
		SELECT Nombre ,  Cantidad 
		FROM MEDICAMENTOS_POR_RECETA JOIN MEDICAMENTO ON Codigo =CodigoMedicamento
			UNION ALL
		SELECT Nombre ,  Cantidad 
		FROM MEDICAMENTOS_POR_PEDIDO_FISICO JOIN MEDICAMENTO ON Codigo =CodigoMedicamento

	) AS T
GROUP BY ( T.Nombre )
ORDER BY (TOTAL_VENDIDO) DESC
 


 
/*productos más vendidos por el nuevo software,*/


Select T.Nombre AS NOMBRE_DEL_MEDICAMENTO , SUM(T.Cantidad) AS TOTAL_VENDIDO
	FROM
	(
		SELECT Nombre ,  Cantidad 
		FROM MEDICAMENTOS_POR_PEDIDO  JOIN MEDICAMENTO  ON Codigo = CodigoMedicamento
			UNION ALL
		SELECT Nombre ,  Cantidad 
		FROM MEDICAMENTOS_POR_RECETA JOIN MEDICAMENTO ON Codigo =CodigoMedicamento
	) AS T
GROUP BY ( T.Nombre )
ORDER BY (TOTAL_VENDIDO) DESC

/*cantidad de ventas por compañía,*/

 Select T.NoFactura , SUM(T.Cantidad*t.Costo) AS TOTAL_POR_FACTURA 
	FROM
	(
		SELECT P.NoFactura ,  Cantidad , M.Costo , Empresa FROM 
			PEDIDO AS P  JOIN MEDICAMENTOS_POR_PEDIDO AS MP ON MP.NoFactura =  P.NoFactura 
			JOIN MEDICAMENTO AS M  ON M.Codigo = MP.CodigoMedicamento
		UNION ALL
		SELECT P.NoFactura ,  Cantidad ,M.Costo , Empresa	FROM
			PEDIDO AS P JOIN RECETA AS R ON P.NoFactura = R.NoFactura 
			JOIN  MEDICAMENTOS_POR_RECETA AS MP ON R.NoReceta = MP.NoReceta
			JOIN MEDICAMENTO AS M ON M.Codigo = MP.CodigoMedicamento
		UNION ALL
		SELECT P.NoFactura ,  Cantidad , Costo ,Empresa FROM 
			PEDIDO AS P JOIN MEDICAMENTOS_POR_PEDIDO_FISICO AS MPF ON P.NoFactura = MPF.NoFactura  
			JOIN MEDICAMENTO ON Codigo =CodigoMedicamento
	) AS T
	WHERE EMPRESA = 'F'
	GROUP BY (NoFactura)

--suma de totales	 
 Select SUM(T.Cantidad*t.Costo) AS TOTAL_DE_VENTAS 
	FROM
	(
		SELECT P.NoFactura ,  Cantidad , M.Costo , Empresa FROM 
			PEDIDO AS P  JOIN MEDICAMENTOS_POR_PEDIDO AS MP ON MP.NoFactura =  P.NoFactura 
			JOIN MEDICAMENTO AS M  ON M.Codigo = MP.CodigoMedicamento
		UNION ALL
		SELECT P.NoFactura ,  Cantidad ,M.Costo , Empresa	FROM
			PEDIDO AS P JOIN RECETA AS R ON P.NoFactura = R.NoFactura 
			JOIN  MEDICAMENTOS_POR_RECETA AS MP ON R.NoReceta = MP.NoReceta
			JOIN MEDICAMENTO AS M ON M.Codigo = MP.CodigoMedicamento
		UNION ALL
		SELECT P.NoFactura ,  Cantidad , Costo ,Empresa FROM 
			PEDIDO AS P JOIN MEDICAMENTOS_POR_PEDIDO_FISICO AS MPF ON P.NoFactura = MPF.NoFactura  
			JOIN MEDICAMENTO ON Codigo =CodigoMedicamento
	) AS T
	WHERE EMPRESA = 'f'
		
 

/*productos más vendidos por compañía.*/

 Select T.Nombre AS NOMBRE_DEL_MEDICAMENTO , SUM(T.Cantidad) AS TOTAL_VENDIDO 
	FROM
	(
		SELECT Nombre ,  Cantidad , Empresa FROM 
			PEDIDO AS P  JOIN MEDICAMENTOS_POR_PEDIDO AS MP ON MP.NoFactura =  P.NoFactura 
			JOIN MEDICAMENTO AS M  ON M.Codigo = MP.CodigoMedicamento

		UNION ALL

		SELECT Nombre ,  Cantidad , Empresa	FROM
			PEDIDO AS P JOIN RECETA AS R ON P.NoFactura = R.NoFactura 
			JOIN  MEDICAMENTOS_POR_RECETA AS MP ON R.NoReceta = MP.NoReceta
			JOIN MEDICAMENTO AS M ON M.Codigo = MP.CodigoMedicamento

		UNION ALL

		SELECT Nombre ,  Cantidad  ,Empresa FROM 
			PEDIDO AS P JOIN MEDICAMENTOS_POR_PEDIDO_FISICO AS MPF ON P.NoFactura = MPF.NoFactura  
			JOIN MEDICAMENTO ON Codigo =CodigoMedicamento

	) AS T
	WHERE Empresa = 'P'
		GROUP BY ( T.Nombre  )
		ORDER BY (TOTAL_VENDIDO) DESC