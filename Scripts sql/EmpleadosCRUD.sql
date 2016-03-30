USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/

INSERT INTO Empleado (Nombre,Cedula, Passwrd, Rol, Empresa) 
VALUES ('','','','','');
/*------------------------------READ-------------------------------------------*/

SELECT IdEmpleado, Nombre, Cedula, Passwrd, Rol , Empresa FROM Empleado;
/*------------------------------UPDATE-------------------------------------------*/
UPDATE Empleado
SET Nombre = '' , Cedula = '' , Passwrd = '' , Rol='' , Empresa =''
WHERE IdEmpleado= '' ;


/*------------------------------Delete-------------------------------------------*/
DELETE FROM EMPLEADO
WHERE IdEmpleado= '' ;


/*
	Malcador Sigillite, G, F
	Horus Lupercal, G, P

		Lion ElJonson, D
		Jaghatai Khan, D
		Leman Russ, D
		Rogal Dorn, D
		Ferrus Manus, D
		Roboute Gulliman, D
		Corvus Corax, D
		Alpharius Omegon, D
		Konrad Curze, D
		*/