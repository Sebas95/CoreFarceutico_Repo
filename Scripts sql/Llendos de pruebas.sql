USE FARMATICA;

INSERT INTO CLIENTE (IdCliente, Cedula, Nombre,Apellido,Prioridad, FechaNacimiento, Residencia) 
VALUES (32,'115090837','Sebastian','Gonzalez','B','1995-01-19','Tres Rios')

INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES (32 , 'PADECIMIENTO1');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (32 , '89985104','cel');
INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES (32 , 'PADECIMIENTO2');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (32 , '324434234','casa');


INSERT INTO CLIENTE (IdCliente, Cedula, Nombre,Apellido,Prioridad, FechaNacimiento, Residencia) 
VALUES (99,'415090677','Cristian','Bolaños','B','1986-01-19','San jose')


insert into doctor (NoDoctor,Cedula,Nombre,Apellido,FechaNacimiento,Residencia) 
values(1,'323453234','Alfred','Cen','1889-01-02','colorado');

select* from DOCTOR;