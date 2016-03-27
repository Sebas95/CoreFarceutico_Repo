USE FARMATICA;

INSERT INTO CLIENTE ( Cedula, Nombre,Apellido,Prioridad, FechaNacimiento, Residencia) 
VALUES ('115090837','Sebastian','Gonzalez','B','1995-01-19','Tres Rios')
INSERT INTO CLIENTE ( Cedula, Nombre,Apellido,Prioridad, FechaNacimiento, Residencia) 
VALUES ('415090677','Cristian','Bolaños','B','1986-01-19','San jose')

INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES (1 , 'PADECIMIENTO2');
INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES (1 , 'PADECIMIENTO1');

INSERT INTO TELEFONOS_POR_CLIENTE VALUES (1 , '324434234','casa');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (1 , '89985104','cel');

insert into doctor (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) 
values('323453234','Alfred','Cen','1889-01-02','colorado');


INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (11,'Heredia' , 'San Pablo' ,'22654356');
INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (22,'San Jose', ' San jose Centro' ,'24346547');
INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (33,'ALajuela', 'Poas' ,'9894774');


INSERT INTO MEDICAMENTO (Nombre ,Prescripcion, Codigo , CasaFarmaceutica , Costo)
VALUES('Acetaminofem', 0, 'AC','Bayern' , 1500);
INSERT INTO MEDICAMENTO (Nombre ,Prescripcion, Codigo , CasaFarmaceutica , Costo)
VALUES(  'Cataflam',1, 'CF','Novartis', 3500);
INSERT INTO MEDICAMENTO (Nombre ,Prescripcion, Codigo , CasaFarmaceutica , Costo)
VALUES(  'Alcohol',0, 'AL','CCSS', 3500);



INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento , NoSucursal, Cantidad)
VALUES ('AC', 11 , 34); 
INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento , NoSucursal, Cantidad)
VALUES ('AL', 22 , 100); 
INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento , NoSucursal, Cantidad)
VALUES ('AL', 11 , 100);
INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento , NoSucursal, Cantidad)
VALUES ('CF', 22 , 300); 



INSERT INTO PEDIDO ( HoraRecojo , NoSucursal , IdCliente, Estado) 
VALUES (convert(varchar(10),getdate(),108),'22','2','R');
INSERT INTO PEDIDO ( HoraRecojo , NoSucursal , IdCliente, Estado) 
VALUES (convert(varchar(10),getdate(),108),'22','2','R');
INSERT INTO PEDIDO ( HoraRecojo , NoSucursal , IdCliente, Estado) 
VALUES ('20:18:01','11','1','P');
INSERT INTO PEDIDO ( HoraRecojo , NoSucursal , IdCliente, Estado) 
VALUES ('23:10:01','11','1','P');


INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento) 
VALUES ('3', 'CF' );
INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento ) 
VALUES ( '3' , 'AC' );
INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento ) 
VALUES ( '2' , 'AL' );


INSERT INTO RECETA ( NoFactura , IdCliente , NoDoctor) 
VALUES ('2','1','1');
INSERT INTO RECETA ( NoFactura , IdCliente , NoDoctor) 
VALUES ('3','2','1');


INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta) 
VALUES('CF','1') ;
INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta) 
VALUES('CF','2') ;
INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta) 
VALUES('AC','2') ;

SELECT * FROM CLIENTE;
select * from TELEFONOS_POR_CLIENTE; 
select * from PADECIMIENTOS_POR_CLIENTE; 
select * from DOCTOR;
select * from SUCURSAL; 
select * from MEDICAMENTO; 
select * from MEDICAMENTO_EN_SUCURSAL; 
select * from PEDIDO;
select * from MEDICAMENTOS_POR_PEDIDO; 
select * from RECETA; 
select * from MEDICAMENTOS_POR_RECETA; 

select * from USUARIOS;