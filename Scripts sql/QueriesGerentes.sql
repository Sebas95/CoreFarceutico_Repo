
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






USE FARMATICA;

/* productos m�s vendidos */

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
 


 
/*productos m�s vendidos por el nuevo software,*/


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

/*cantidad de ventas por compa��a,*/

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
		
 

/*productos m�s vendidos por compa��a.*/

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