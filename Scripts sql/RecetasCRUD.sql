
USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
INSERT INTO RECETA ( NoFactura , IdCliente , NoDoctor) 
VALUES ('','','');

/*------------------------------READ-------------------------------------------*/
SELECT NoReceta , NoFactura , IdCliente , NoDoctor FROM RECETA;

/*------------------------------UPDATE-------------------------------------------*/
UPDATE RECETA
SET  NoFactura='' , IdCliente='' , NoDoctor=''
WHERE NoReceta  = '1' ;

/*------------------------------Delete-------------------------------------------*/
DELETE FROM RECETA
WHERE NoReceta  = '1' ;

