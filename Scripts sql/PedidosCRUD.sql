/*
Pedidos. Las operaciones que debe proveer este módulo son creación, actualización,
 eliminación de pedidos, los datos a almacenar de los pedidos son: sucursal de recojo, cliente,
  teléfono preferido, listado de medicamentos, hora de recojo. 
*/

USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
INSERT INTO PEDIDOS 

/*------------------------------READ-------------------------------------------*/
SELECT NoFactura, IdCliente, NoSucursal , HoraRecojo , Estado  FROM PEDIDO ; 

/*------------------------------UPDATE-------------------------------------------*/
UPDATE Doctor
SET Cedula = '' ,Nombre = '' ,Apellido = '',FechaNacimiento ='',Residencia = ''
WHERE NoDoctor= '1' ;


/*------------------------------Delete-------------------------------------------*/
DELETE FROM DOCTOR
WHERE NoDoctor='1';



