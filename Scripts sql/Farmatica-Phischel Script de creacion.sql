
CREATE TABLE EMPRESA(
	Codigo CHAR(1),
	Descrpcion VARCHAR(15),

	CONSTRAINT PK_CodigoEmpresa
		PRIMARY KEY (Codigo),
	CONSTRAINT Check_Empresa CHECK (Codigo = 'P' OR Codigo = 'F')
)

CREATE TABLE EMPLEADO(
	IdEmpleado INT IDENTITY(1,1),
	Nombre CHAR(15),
	Cedula CHAR(11),
	Passwrd Char(8) DEFAULT '12345768',
	Rol CHAR(1) DEFAULT 'D',
	Empresa CHAR(1),

	CONSTRAINT PK_EMPLEADO
		PRIMARY KEY (IdEmpleado),
	CONSTRAINT UK_CEDULA_EMPLEADO UNIQUE(Cedula),
	CONSTRAINT FK_EmpresaCliente
		FOREIGN KEY (Empresa) REFERENCES Empresa(Codigo) ON DELETE CASCADE ON UPDATE CASCADE 
)

CREATE TABLE CLIENTE(
	IdCliente INT IDENTITY(1,1),				 
	Cedula CHAR(11),
	Nombre CHAR (15),
	Apellido CHAR(15),
	Prioridad CHAR(1) DEFAULT 'A',
	FechaNacimiento DATE,
	Residencia CHAR(45),

	CONSTRAINT PK_CLIENTE
		PRIMARY KEY (IdCliente),
	CONSTRAINT UK_CEDULA_CLIENTE UNIQUE(Cedula)
)

CREATE TABLE PADECIMIENTOS_POR_CLIENTE(
	IdCliente INT,
	Descripcion CHAR (100),
	
	CONSTRAINT FK_PADECIMIENTOS_POR_CLIENTE_IdCliente
		FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente) ON DELETE CASCADE ON UPDATE CASCADE 
)

CREATE TABLE TELEFONOS_POR_CLIENTE(
	IdCliente INT,
	Telefono CHAR (11),
	Descripcion CHAR (20),

	CONSTRAINT PK_TELEFONOS_POR_CLIENTE
		PRIMARY KEY (IdCliente, Telefono),
	CONSTRAINT FK_TELEFONOS_POR_CLIENTE_IdCliente
		FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente) ON DELETE CASCADE ON UPDATE CASCADE 
	 
)

CREATE TABLE DOCTOR(
	NoDoctor INT IDENTITY(1,1),
	Cedula CHAR(15),
	Nombre CHAR(15),
	Apellido CHAR(15),
	FechaNacimiento DATE,
	Residencia CHAR(100),

	CONSTRAINT PK_DOCTOR 
		PRIMARY KEY (NoDoctor)	
)

CREATE TABLE MEDICAMENTO(
	Nombre CHAR (15),
	Prescripcion BIT,
	Codigo VARCHAR(10),
	CasaFarmaceutica CHAR(15),
	Costo FLOAT,
	CONSTRAINT PK_MEDICAMENTO
		PRIMARY KEY (Codigo)
)

CREATE TABLE SUCURSAL (
	NoSucursal INT,
	Nombre CHAR (15),
	Direccion CHAR (100),
	Telefono CHAR(10),

	CONSTRAINT PK_SUCURSAL
		PRIMARY KEY (NoSucursal)
)



CREATE TABLE PEDIDO (
	NoFactura INT IDENTITY(1,1),
	FechaRecojo DATETIME,
	NoSucursal INT,
	IdCliente INT,	
	Estado CHAR(9) DEFAULT 'Nuevo',
	Empresa CHAR(1),
	TelefonoPreferido CHAR (11),

	CONSTRAINT PK_PEDIDO
		PRIMARY KEY (NoFactura),
	CONSTRAINT FK_PEDIDO_SE_RECOGE_EN_SUCURSAL_NoSucursal
		FOREIGN KEY (NoSucursal) REFERENCES SUCURSAL(NoSucursal) ON DELETE CASCADE ON UPDATE CASCADE ,
	CONSTRAINT FK_PEDIDOS_POR_CLIENTE_IdCliente
		FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_Empresa
		FOREIGN KEY (Empresa) REFERENCES EMPRESA(Codigo) ON DELETE SET NULL ON UPDATE NO ACTION,
	CONSTRAINT Check_Estado CHECK (Estado = 'Nuevo' OR Estado = 'Preparado' OR Estado = 'Facturado' OR Estado = 'Retirado'),
	
)

CREATE TABLE RECETA(
	NoReceta INT IDENTITY(1,1),
	NoFactura INT,
	IdCliente INT,
	NoDoctor INT,
	Imagen IMAGE,

	CONSTRAINT PK_RECETA
		PRIMARY KEY (NoReceta),
	CONSTRAINT FK_RECETAS_POR_PEDIDO
		FOREIGN KEY (NoFactura) REFERENCES PEDIDO (NoFactura) ON DELETE CASCADE ON UPDATE CASCADE ,
	CONSTRAINT FK_RECETAS_POR_CLIENTE_IdCliente
		FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente) ON DELETE NO ACTION ON UPDATE NO ACTION ,
	CONSTRAINT FK_RECETAS_POR_DOCTOR_NoDoctor
		FOREIGN KEY (NoDoctor) REFERENCES DOCTOR(NoDoctor) ON DELETE CASCADE ON UPDATE CASCADE 
)

CREATE TABLE MEDICAMENTOS_POR_RECETA(
	CodigoMedicamento VARCHAR(10),
	NoReceta INT,
	Cantidad SMALLINT,

	CONSTRAINT PK_MEDICAMENTOS_POR_RECETA
		PRIMARY KEY (CodigoMedicamento, NoReceta),
	CONSTRAINT FK_MEDICAMENTOS_POR_RECETA_CodigoMedicamento 
		FOREIGN KEY (CodigoMedicamento) REFERENCES MEDICAMENTO(Codigo) ON DELETE CASCADE ON UPDATE CASCADE ,
	CONSTRAINT FK_MEDICAMENTOS_POR_RECETA_NoReceta
		FOREIGN KEY (NoReceta) REFERENCES RECETA(NoReceta) ON DELETE CASCADE ON UPDATE CASCADE 
)


CREATE TABLE MEDICAMENTO_EN_SUCURSAL(
		CodigoMedicamento VARCHAR(10),
		NoSucursal INT,
		Cantidad INT,
		
		CONSTRAINT PK_MEDICAMENTOS_SE_ENCUENTRA_EN_SUCURAL
			PRIMARY KEY (CodigoMedicamento, NoSucursal),

		CONSTRAINT FK_MEDICAMENTOS_SE_ENCUENTRA_EN_SUCURAL_CodigoMedicamento
			FOREIGN KEY (CodigoMedicamento) REFERENCES MEDICAMENTO(Codigo) ON DELETE CASCADE ON UPDATE CASCADE ,

		CONSTRAINT FK_MEDICAMENTOS_SE_ENCUENTRA_EN_SUCURAL_NoSucursal
			FOREIGN KEY (NoSucursal) REFERENCES SUCURSAL(NoSucursal) ON DELETE CASCADE ON UPDATE CASCADE 
)

CREATE TABLE MEDICAMENTOS_POR_PEDIDO (
	NoFactura INT,
	CodigoMedicamento VARCHAR(10),
	Cantidad SMALLINT,

	CONSTRAINT PK_MEDICAMENTOS_POR_PEDIDO
		PRIMARY KEY (NoFactura, CodigoMedicamento),
	CONSTRAINT FK_MEDICAMENTOS_POR_PEDIDO_CodigoMedicamento
		FOREIGN KEY (CodigoMedicamento) REFERENCES MEDICAMENTO(Codigo) ON DELETE CASCADE ON UPDATE CASCADE ,
 	CONSTRAINT FK_MEDICAMENTOS_POR_PEDIDO_PEDIDO
		FOREIGN KEY (NoFactura) REFERENCES PEDIDO(NoFactura) ON DELETE CASCADE ON UPDATE CASCADE 
)


CREATE TABLE PEDIDO_FISICO (
	NoFactura INT IDENTITY(1,1),
	NoSucursal INT,
	Estado CHAR(9),
	Empresa CHAR(1),

	CONSTRAINT PK_PEDIDO_FISICO
		PRIMARY KEY (NoFactura),
	CONSTRAINT FK_PEDIDO_FISICO_SE_RECOGE_EN_SUCURSAL_NoSucursal
		FOREIGN KEY (NoSucursal) REFERENCES SUCURSAL(NoSucursal) ON DELETE CASCADE ON UPDATE CASCADE ,
	CONSTRAINT FK_Empresa_FISICA
		FOREIGN KEY (Empresa) REFERENCES EMPRESA(Codigo) ON DELETE SET NULL ON UPDATE NO ACTION,
	CONSTRAINT Check_Estado_FISICO CHECK (Estado = 'Nuevo' OR Estado = 'Preparado' OR Estado = 'Facturado' OR Estado = 'Retirado'),
	
)

CREATE TABLE MEDICAMENTOS_POR_PEDIDO_FISICO (
	NoFactura INT,
	CodigoMedicamento VARCHAR(10),
	Cantidad SMALLINT,

	CONSTRAINT PK_MEDICAMENTOS_POR_PEDIDO_FISICO
		PRIMARY KEY (NoFactura, CodigoMedicamento),
	
	CONSTRAINT FK_MEDICAMENTOS_POR_PEDIDO_FISICO_CodigoMedicamento
		FOREIGN KEY (CodigoMedicamento) REFERENCES MEDICAMENTO(Codigo) ON DELETE CASCADE ON UPDATE CASCADE ,

 	CONSTRAINT FK_MEDICAMENTOS_POR_PEDIDO_FISICO
		FOREIGN KEY (NoFactura) REFERENCES PEDIDO_FISICO(NoFactura) ON DELETE CASCADE ON UPDATE CASCADE 
)