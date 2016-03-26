/*
 sucursal donde se crea, nombre, casa farmacéutica, requiere prescripción (Si/No), cantidad disponible.
*/

USE FARMATICA;
/*---------------------------------------CREATE-----------------------------------------------------*/

INSERT INTO MEDICAMENTO (Nombre ,Prescripcion, Codigo , CasaFarmaceutica , Costo)
VALUES('Acetaminofem', 0, 'AC','Bayern' , 1500);
INSERT INTO MEDICAMENTO (Nombre ,Prescripcion, Codigo , CasaFarmaceutica , Costo)
VALUES(  'Cataflam',1, 'CF','Novartis', 3500);
INSERT INTO MEDICAMENTO (Nombre ,Prescripcion, Codigo , CasaFarmaceutica , Costo)
VALUES(  'Alcohol',0, 'AL','CCSS', 3500);


INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (11,'Heredia' , 'San Pablo' ,'22654356');
INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (22,'San Jose', ' San jose Centro' ,'24346547');

INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento , NoSucursal, Cantidad)
VALUES ('AC', 11 , 34); 
INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento , NoSucursal, Cantidad)
VALUES ('AL', 22 , 100); 
INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento , NoSucursal, Cantidad)
VALUES ('CF', 22 , 300); 

/*-----------------------------------------READ-----------------------------------------------------*/
/*
 sucursal donde se crea, nombre, casa farmacéutica, requiere prescripción (Si/No), cantidad disponible.
*/
SELECT MEDICAMENTO.Nombre as Nombre , Codigo , Prescripcion 
FROM MEDICAMENTO ; 

SELECT  MS.Cantidad , S.NoSucursal , S.Nombre AS NombreSucursal , S.Direccion , S.Telefono
FROM MEDICAMENTO_EN_SUCURSAL AS MS JOIN SUCURSAL AS S
ON MS.NoSucursal = S.NoSucursal 
WHERE MS.CodigoMedicamento = 'AL';
/*-----------------------------------------UPDATE-----------------------------------------------------*/

UPDATE MEDICAMENTO
SET Nombre ='' ,Prescripcion = '', CasaFarmaceutica = '', Costo = '' 
WHERE Codigo= '' ;


/*-----------------------------------------DELETE-----------------------------------------------------*/
DELETE  FROM MEDICAMENTO WHERE Codigo = 'CF';



Select * from MEDICAMENTO;