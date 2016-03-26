USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (11,'Heredia' , 'San Pablo' ,'22654356');
INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (22,'San Jose', ' San jose Centro' ,'24346547');

/*------------------------------READ-------------------------------------------*/
SELECT NoSucursal , Nombre , Direccion , Telefono FROM SUCURSAL;

/*------------------------------UPDATE-------------------------------------------*/
UPDATE SUCURSAL
SET Nombre = 'San jose' ,Direccion = ' sn jose centro',Telefono = '8888888'
WHERE NoSucursal = '11' ;


/*------------------------------Delete-------------------------------------------*/
DELETE FROM SUCURSAL
WHERE NoSucursal='11';

