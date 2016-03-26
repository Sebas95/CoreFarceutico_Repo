 /*
 número de receta 
 doctor que emitió la receta
 medicamentos prescritos
 */
USE FARMATICA;
/*------------------------------------CREATE-------------------------------------------*/
INSERT INTO RECETA (NoReceta, NoFactura, IdCliente , NoDoctor)
VALUES (1,2,3,4);

/*------------------------------------READ--------------------------------------------*/
SELECT NoReceta , NoFactura , IdCliente , D.Nombre 
FROM RECETA AS R JOIN DOCTOR AS D
ON R.NoDoctor = D.NoDoctor ;
/*------------------------------------UPDATE--------------------------------------------*/

/*------------------------------------DELETE--------------------------------------------*/