USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/

INSERT INTO Empleado (Nombre,Cedula, Passwrd, Rol, Empresa) 
VALUES ('Malcador',106300667,'12345678','G','P');
/*------------------------------READ-------------------------------------------*/

SELECT IdEmpleado, Nombre, Cedula, Passwrd, Rol , Empresa FROM Empleado;
/*------------------------------UPDATE-------------------------------------------*/
UPDATE Empleado
SET Nombre = '' , Cedula = '' , Passwrd = '' , Rol='' , Empresa =''
WHERE IdEmpleado= '' ;


/*------------------------------Delete-------------------------------------------*/
DELETE FROM EMPLEADO
WHERE IdEmpleado= '' ;
