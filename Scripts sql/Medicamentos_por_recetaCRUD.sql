
USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta , Cantidad) 
VALUES('','','') ;

/*------------------------------READ-------------------------------------------*/
SELECT CodigoMedicamento , NoReceta , Cantidad FROM MEDICAMENTOS_POR_RECETA ; 

/*------------------------------UPDATE-------------------------------------------*/


/*------------------------------Delete-------------------------------------------*/
DELETE FROM MEDICAMENTOS_POR_RECETA
WHERE  CodigoMedicamento='' AND NoReceta='' ;
