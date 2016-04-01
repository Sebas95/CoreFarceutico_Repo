USE FARMATICA;

INSERT INTO CLIENTE ( Cedula, Nombre,Apellido,Prioridad, FechaNacimiento, Residencia) 
VALUES ('115090837','Sebastian','Gonzalez','B','1995-01-19','Tres Rios')
INSERT INTO CLIENTE ( Cedula, Nombre,Apellido,Prioridad, FechaNacimiento, Residencia) 
VALUES ('41501177','Celso','Borges','B','1986-01-19','San jose')


INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES (1 , 'PADECIMIENTO2');
INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES (1 , 'PADECIMIENTO1');

INSERT INTO TELEFONOS_POR_CLIENTE VALUES (1 , '324434234','casa');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (1 , '89985104','Preferido');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (2 , '324434234','móvil');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (2 , '89985104','Preferido');

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



INSERT INTO PEDIDO ( FechaRecojo , NoSucursal , IdCliente, Estado, Empresa , TelefonoPreferido) 
VALUES ('2009-09-25 02:47:00.000' ,'22','2','Retirado','F','89985104');
INSERT INTO PEDIDO (FechaRecojo , NoSucursal , IdCliente, Estado, Empresa , TelefonoPreferido) 
VALUES ('2017-09-25 01:47:00.000','22','2','Nuevo','P','89985104');
INSERT INTO PEDIDO ( FechaRecojo , NoSucursal , IdCliente, Estado, Empresa , TelefonoPreferido) 
VALUES ('2012-09-25 20:47:00.000','11','1','Preparado','F','89985104');
INSERT INTO PEDIDO ( FechaRecojo , NoSucursal , IdCliente, Estado, Empresa , TelefonoPreferido) 
VALUES ('2013-09-25 21:47:00.000','11','1','Facturado','F','324434234');


INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento , Cantidad) 
VALUES ('1', 'CF' ,23);
INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento , Cantidad) 
VALUES ( '3' , 'AC',2 );
INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento , Cantidad) 
VALUES ( '2' , 'AL',1 );


INSERT INTO RECETA ( NoFactura , IdCliente , NoDoctor) 
VALUES ('2','1','1');
INSERT INTO RECETA ( NoFactura , IdCliente , NoDoctor) 
VALUES ('3','2','1');


INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta , Cantidad) 
VALUES('CF','1',3) ;
INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta , Cantidad) 
VALUES('CF','2',2) ;
INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta, Cantidad) 
VALUES('AC','2',29) ;


INSERT INTO Empleado (Nombre,Cedula, Passwrd, Rol, Empresa) 
VALUES ('gerado','34453435','1234','G','F');
INSERT INTO Empleado (Nombre,Cedula, Passwrd, Rol, Empresa) 
VALUES ('Lucia','34451115','1234','G','P');
INSERT INTO Empleado (Nombre,Cedula, Passwrd, Rol, Empresa) 
VALUES ('Maria','34453321','1234','D','F');
INSERT INTO Empleado (Nombre,Cedula, Passwrd, Rol, Empresa) 
VALUES ('Cristian','3745199','1222','D','P');
INSERT INTO Empleado (Nombre,Cedula, Passwrd, Rol, Empresa) 
VALUES ('Daniel','3045555','asas','D','P');



INSERT INTO PEDIDO_FISICO ( NoSucursal , Estado, Empresa) 
VALUES ('22','Retirado','F');
INSERT INTO PEDIDO_FISICO ( NoSucursal , Estado, Empresa) 
VALUES ('22','Nuevo','P');
INSERT INTO PEDIDO_FISICO ( NoSucursal , Estado, Empresa) 
VALUES ('11','Preparado','F');
INSERT INTO PEDIDO_FISICO  ( NoSucursal , Estado, Empresa) 
VALUES ('11','Facturado','F');

INSERT INTO MEDICAMENTOS_POR_PEDIDO_FISICO ( NoFactura , CodigoMedicamento , Cantidad) 
VALUES ('5', 'CF' ,23);
INSERT INTO MEDICAMENTOS_POR_PEDIDO_FISICO ( NoFactura , CodigoMedicamento , Cantidad) 
VALUES ( '7' , 'AC',2 );
INSERT INTO MEDICAMENTOS_POR_PEDIDO_FISICO ( NoFactura , CodigoMedicamento , Cantidad) 
VALUES ( '6' , 'AL',1 );
INSERT INTO MEDICAMENTOS_POR_PEDIDO_FISICO ( NoFactura , CodigoMedicamento , Cantidad) 
VALUES ('8', 'CF' ,23);
INSERT INTO MEDICAMENTOS_POR_PEDIDO_FISICO ( NoFactura , CodigoMedicamento , Cantidad) 
VALUES ( '8' , 'AC',2 );
INSERT INTO MEDICAMENTOS_POR_PEDIDO_FISICO ( NoFactura , CodigoMedicamento , Cantidad) 
VALUES ( '7' , 'AL',1 );




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
select * from EMPLEADO;
select * from EMPRESA;
Select * from PEDIDO_FISICO;
select * from MEDICAMENTOS_POR_PEDIDO_FISICO; 

