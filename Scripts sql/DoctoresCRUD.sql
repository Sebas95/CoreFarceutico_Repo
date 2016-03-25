USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
insert into doctor (NoDoctor,Cedula,Nombre,Apellido,FechaNacimiento,Residencia) 
values(1,'323453234','Alfred','Cen','1889-01-02','colorado');

/*------------------------------READ-------------------------------------------*/
select NoDoctor,Cedula,Nombre,Apellido,FechaNacimiento,Residencia from doctor  ;

/*------------------------------UPDATE-------------------------------------------*/
UPDATE Doctor
SET Cedula = '' ,Nombre = '' ,Apellido = '',FechaNacimiento ='',Residencia = ''
WHERE NoDoctor= '1' ;


/*------------------------------Delete-------------------------------------------*/
DELETE FROM DOCTOR
WHERE NoDoctor='1';

