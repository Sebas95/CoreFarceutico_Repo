USE FARMATICA;

SELECT R.NoFactura , R.NoReceta , C.Nombre AS NombreCliente ,
 C.Apellido as Apellidos , c.Cedula as CedulaCliente, D. Nombre AS NombreDoctor , D.NoDoctor 
 FROM
(RECETA AS R JOIN DOCTOR AS D ON R.NoDoctor = D.NoDoctor) JOIN CLIENTE AS C ON R.IdCliente = C.IdCliente ; 


   