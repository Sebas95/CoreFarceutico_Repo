select  IdCliente, Cedula, Nombre , Apellido, Prioridad, FechaNacimiento , Residencia 
from CLIENTE; 

SELECT C.Nombre , T.Telefono , T.Descripcion
from CLIENTE AS C join TELEFONOS_POR_CLIENTE AS T
On C.IdCliente = T.IdCliente
--WHERE C.IdCliente = ''
;

SELECT C.Nombre , P.Descripcion  
from CLIENTE AS C join PADECIMIENTOS_POR_CLIENTE AS P
On C.IdCliente = P.IdCliente
--WHERE C.IdCliente = ''
;
/*---------------PARA updades------------------------------------------------*/
UPDATE CLIENTE 
SET Cedula='' , Nombre='' , Apellido='', FechaNacimiento= '', Residencia='' , Prioridad = ''
WHERE IdCliente= '' ;


/*---------------PARA INSERCIONES------------------------------------------------*/
INSERT INTO CLIENTE (IdCliente, Cedula, Nombre,Apellido,Prioridad, FechaNacimiento, Residencia) 
VALUES ('id','ced','nomb','apellido','A','date','residencia')
INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES ('IDCLIENTE' , 'PADECIMIENTO');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES ('IDCLIENTE' , 'TELEFONO','desc');

/*---------------PARA ELIMINACIONES------------------------------------------------*/
DELETE FROM CLIENTE
WHERE IdCliente='';

/*-----------------------------------Prueba---------------------------------------------------*/
INSERT INTO CLIENTE (IdCliente, Cedula, Nombre,Apellido, FechaNacimiento, Residencia)  
VALUES (32,'115090837','Sebastian','Gonzalez','1995-01-19','Tres Rios')
INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES (32 , 'PADECIMIENTO1');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (32 , '89985104','cel');
INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES (32 , 'PADECIMIENTO2');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (32 , '324434234','casa');

UPDATE CLIENTE 
SET Cedula='115090837' , Nombre='Sebastian' , Apellido='Gonzales', FechaNacimiento= '1995-01-19', Residencia='Tres Rios' 
WHERE IdCliente= '32' ;

DELETE FROM CLIENTE
WHERE IdCliente='11';

SELECT * FROM  PADECIMIENTOS_POR_CLIENTE ;
SELECT * FROM  TELEFONOS_POR_CLIENTE ;
Use FARMATICA;
SELECT * FROM  CLIENTE ;

DELETE FROM PADECIMIENTOS_POR_CLIENTE
WHERE IdCliente='32';




