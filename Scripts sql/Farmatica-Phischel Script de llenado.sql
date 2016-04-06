USE FARMATICA;

INSERT INTO EMPRESA VALUES('F', 'FarmaTica S.A.');
INSERT INTO EMPRESA VALUES('P', 'Phischel');

INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (101130756, 'Uriel', 'Ventris', 'A', '05-06-1985', 'Cartago');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (205520827, 'Lazlo', 'Tiberius', 'A', '05-16-1978', 'Cartago');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (200780022, 'Almerz', 'Chanda', 'C', '05/16/1978', 'Alajuela');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (303310331, 'Miklas', 'Iacovone', 'C', '04-26-1981', 'Alajuela');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (205460748, 'Morten', 'Bauer', 'C', '03-14-1994', 'Alajuela');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (304890384, 'Isador', 'Akios', 'B', '06-25-1991', 'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (604960599, 'Mordecai', 'Toth', 'B', '08-30-1994',  'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (205910023, 'Davian', 'Thule', 'A', '09-05-1986', 'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (405280977, 'Indrick', 'Boreale', 'B', '10-06-1972', 'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (405800255, 'Firaveus', 'Carron', 'B', '11-13-1970', 'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (706880469, 'Vance', 'Stubbs', 'B', '06-12-1969', 'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (503250719, 'Doran', 'Farrier', 'D', '03-05-1991', 'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (400600391, 'Selena', 'Agna', 'A', '03-05-1991', 'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (206320726, 'Apollo', 'Diomedes', 'E', '02-14-1994', 'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (308640688, 'Elena', 'Derosa', 'C', '04-25-1986', 'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (501500551, 'Jonah', 'Orion', 'A', '02-29-1972', 'San José');
INSERT INTO Cliente (Cedula,Nombre,Apellido,Prioridad,FechaNacimiento,Residencia) VALUES (405340107, 'Shilo', 'Darksun', 'C', '11-01-1970','Heredia');

INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES (1, 'PADECIMIENTO2');
INSERT INTO PADECIMIENTOS_POR_CLIENTE VALUES (1, 'PADECIMIENTO1');

INSERT INTO TELEFONOS_POR_CLIENTE VALUES (1, '324434234','casa');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (1, '89985104','Preferido');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (2, '324434234','móvil');
INSERT INTO TELEFONOS_POR_CLIENTE VALUES (2, '89985104','Preferido');

INSERT INTO DOCTOR (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) VALUES ('323453234', 'Alfred', 'Cen', '1889-01-02', 'Colorado');
INSERT INTO DOCTOR (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) VALUES ('323453815', 'Kregor', 'Than', '1815-01-02', 'Jericho Reach');
INSERT INTO DOCTOR (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) VALUES ('323453816', 'Khiron', 'Ruberec', '1820-01-02', 'Karybdis');
INSERT INTO DOCTOR (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) VALUES ('323453817', 'Meric', 'Voyen', '1785-01-02', 'Barbarus');
INSERT INTO DOCTOR (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) VALUES ('323453652', 'Fabius', 'Bile', '1525-01-02', 'Chemos');
INSERT INTO DOCTOR (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) VALUES ('323453818', 'Corbulo', 'Sanguinary', '1230-01-02', 'Baal');
INSERT INTO DOCTOR (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) VALUES ('323453830', 'Ulrik', 'Lupus', '1026-01-02', 'Fenris');
INSERT INTO DOCTOR (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) VALUES ('323453832', 'Sternhammer', 'Stormfang', '1702-01-02', 'Fenris');
INSERT INTO DOCTOR (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) VALUES ('323453833', 'Fabrikus', 'Farbarius', '1562-01-02', 'Terra');
INSERT INTO DOCTOR (Cedula,Nombre,Apellido,FechaNacimiento,Residencia) VALUES ('323453834', 'Garreon', 'Abnett', '1468-01-02', 'Badab Primaris');

INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (11,'Heredia' , 'San Pablo' ,'22654356');
INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (22,'San Jose', 'San Jose Centro' ,'24346547');
INSERT INTO SUCURSAL (NoSucursal , Nombre , Direccion , Telefono) VALUES (33,'Alajuela', 'Poas' ,'9894774');

INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Halothano', 1, '111', 'AbbottLabs', 500);
INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Ketamina', 1, '112', 'AbbottLabs', 500);
INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Bupivicaína', 0, '121', 'Pfizer', 200);
INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Lidocaína', 0, '122', 'Bayer', 750);
INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Ibuprofeno', 0, '212', 'Bayer', 500);
INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Paracetamol', 0, '213', 'Bayer', 750);
INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Codeína', 1, '221', 'Pfizer', 1250);
INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Morfina', 1, '222', 'Pfizer', 2150);
INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Alopurinol', 0, '231', 'AbbottLabs', 500);
INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Clorfenamina', 0, '311', 'Bayer', 300);
INSERT INTO MEDICAMENTO (Nombre,Prescripcion,Codigo,CasaFarmaceutica,Costo) VALUES ('Dexametasona', 0, '312', 'Bayer', 200);

INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento,NoSucursal,Cantidad) VALUES ('111', 11 , 34); 
INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento,NoSucursal,Cantidad) VALUES ('111', 22 , 100); 
INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento,NoSucursal,Cantidad) VALUES ('112', 11 , 100);
INSERT INTO MEDICAMENTO_EN_SUCURSAL (CodigoMedicamento,NoSucursal,Cantidad) VALUES ('121', 22 , 300); 

INSERT INTO PEDIDO (FechaRecojo,NoSucursal,IdCliente,Estado,Empresa,TelefonoPreferido) VALUES ('2009-09-25 02:47:00.000' ,'22','2','Retirado','F','89985104');
INSERT INTO PEDIDO (FechaRecojo,NoSucursal,IdCliente,Estado,Empresa,TelefonoPreferido) VALUES ('2017-09-25 01:47:00.000','22','2','Nuevo','P','89985104');
INSERT INTO PEDIDO (FechaRecojo,NoSucursal,IdCliente,Estado,Empresa,TelefonoPreferido) VALUES ('2012-09-25 20:47:00.000','11','1','Preparado','F','89985104');
INSERT INTO PEDIDO (FechaRecojo,NoSucursal,IdCliente,Estado,Empresa,TelefonoPreferido) VALUES ('2013-09-25 21:47:00.000','11','1','Facturado','F','324434234');

INSERT INTO MEDICAMENTOS_POR_PEDIDO (NoFactura,CodigoMedicamento,Cantidad) VALUES ('1', '111', 23);
INSERT INTO MEDICAMENTOS_POR_PEDIDO (NoFactura,CodigoMedicamento,Cantidad) VALUES ('3', '121', 2 );
INSERT INTO MEDICAMENTOS_POR_PEDIDO (NoFactura,CodigoMedicamento,Cantidad) VALUES ('2', '111', 1 );

--INSERT INTO RECETA (NoFactura,IdCliente,NoDoctor,Imagen) SELECT '2', '1', '1', bulkcolumn from openrowset(bulk 'C:\Users\Vargam\Desktop\CoreFarceutico_Repo\Scripts sql\receta-WARHAMMER-1.jpg' ,single_blob) as BLOB;
--INSERT INTO RECETA (NoFactura,IdCliente,NoDoctor,Imagen) SELECT '3', '2', '1', bulkcolumn from openrowset(bulk 'C:\Users\Vargam\Desktop\CoreFarceutico_Repo\Scripts sql\receta-WARHAMMER-2.jpg' ,single_blob) as BLOB;

---INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento,NoReceta,Cantidad) VALUES('121', '1', 3);
--INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento,NoReceta,Cantidad) VALUES('121', '2', 2);
--INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento,NoReceta,Cantidad) VALUES('111', '2', 29);

INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Malcador',106300667, '12345678', 'G','F');
INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Horus', 102930586, '12345678','G', 'P');
INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Lion', 504340125, '12345678', 'D', 'F');
INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Jaghatai', 504400342, '12345678', 'D', 'F');
INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Leman', 603640714, '12345678', 'D', 'F');
INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Rogal', 500410698, '12345678', 'D', 'F');
INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Ferrus', 208370808, '12345678', 'D', 'F');
INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Roboute', 100160654, '12345678', 'D', 'F');
INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Fulgrim', 101370437, '12345678', 'D', 'P');
INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Alpharius', 304820114, '12345678', 'D', 'P');
INSERT INTO Empleado (Nombre, Cedula, Passwrd, Rol, Empresa) VALUES ('Konrad', 607020776, '12345678', 'D', 'P');

INSERT INTO PEDIDO_FISICO (NoSucursal,Estado,Empresa) VALUES ('22', 'Retirado', 'F');
INSERT INTO PEDIDO_FISICO (NoSucursal,Estado,Empresa) VALUES ('22', 'Nuevo', 'P');
INSERT INTO PEDIDO_FISICO (NoSucursal,Estado,Empresa) VALUES ('11', 'Preparado', 'F');
INSERT INTO PEDIDO_FISICO (NoSucursal,Estado,Empresa) VALUES ('11', 'Facturado', 'F');

INSERT INTO MEDICAMENTOS_POR_PEDIDO_FISICO (NoFactura,CodigoMedicamento,Cantidad) VALUES ('1', '121', 23);
INSERT INTO MEDICAMENTOS_POR_PEDIDO_FISICO (NoFactura,CodigoMedicamento,Cantidad) VALUES ('2', '111', 2 );
INSERT INTO MEDICAMENTOS_POR_PEDIDO_FISICO (NoFactura,CodigoMedicamento,Cantidad) VALUES ('3', '222', 1 );
