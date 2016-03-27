
USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
INSERT INTO MEDICAMENTOS_POR_RECETA (CodigoMedicamento , NoReceta) 
VALUES('','') ;

/*------------------------------READ-------------------------------------------*/
SELECT CodigoMedicamento , NoReceta FROM MEDICAMENTOS_POR_RECETA ; 

/*------------------------------UPDATE-------------------------------------------*/


/*------------------------------Delete-------------------------------------------*/
DELETE FROM MEDICAMENTOS_POR_RECETA
WHERE  CodigoMedicamento='' AND NoReceta='' ;
