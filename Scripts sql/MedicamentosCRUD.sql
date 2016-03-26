/*
 sucursal donde se crea, nombre, casa farmacéutica, requiere prescripción (Si/No), cantidad disponible.
*/

USE FARMATICA;
/*---------------------------------------CREATE-----------------------------------------------------*/
INSERT INTO CASA_FARMACEUTICA (Identificador , Nombre) VALUES(1 ,'Bayern');
INSERT INTO CASA_FARMACEUTICA (Identificador , Nombre) VALUES(2 ,'CCSS');
INSERT INTO CASA_FARMACEUTICA (Identificador , Nombre) VALUES(3 ,'Novartis');

INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (11,'Heredia' , 'San Pablo' ,'22654356');
INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (22,'San Jose', ' San jose Centro' ,'24346547');

INSERT INTO MEDICAMENTO (Prescripcion, Codigo , Nombre , Costo)
VALUES( 0, 'AC', 'Acetaminofem', 1500);
INSERT INTO MEDICAMENTO (Prescripcion, Codigo , Nombre , Costo)
VALUES( 1, 'CF', 'Cataflam', 3500);

INSERT INTO MEDICAMENTOS_POR_CASA_FARMACEUTICA (CodigoMedicamento , Identificador_Casa) 
VALUES ('AC' , 1); 
INSERT INTO MEDICAMENTOS_POR_CASA_FARMACEUTICA (CodigoMedicamento , Identificador_Casa) 
VALUES ('CF' , 3); 

INSERT INTO MEDICAMENTO_EN_SUCURAL (CodigoMedicamento , NoSucursal, Cantidad)
VALUES ('AC', 11 , 34); 

INSERT INTO MEDICAMENTO_EN_SUCURAL (CodigoMedicamento , NoSucursal, Cantidad)
VALUES ('CF', 22 , 300); 

/*-----------------------------------------READ-----------------------------------------------------*/
/*
 sucursal donde se crea, nombre, casa farmacéutica, requiere prescripción (Si/No), cantidad disponible.
*/
SELECT *
FROM 
((((MEDICAMENTO JOIN MEDICAMENTO_EN_SUCURAL ON MEDICAMENTO.Codigo = MEDICAMENTO_EN_SUCURAL.CodigoMedicamento )
JOIN SUCURSAL ON MEDICAMENTO_EN_SUCURAL.NoSucursal = SUCURSAL.NoSucursal ) 
JOIN MEDICAMENTOS_POR_CASA_FARMACEUTICA ON MEDICAMENTO.Codigo = MEDICAMENTOS_POR_CASA_FARMACEUTICA.CodigoMedicamento )
JOIN CASA_FARMACEUTICA ON MEDICAMENTOS_POR_CASA_FARMACEUTICA.Identificador_Casa = CASA_FARMACEUTICA.Identificador )


-- SUCURSAL, MEDICAMENTOS_POR_CASA_FARMACEUTICA , CASA_FARMACEUTICA;