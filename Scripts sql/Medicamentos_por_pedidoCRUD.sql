
USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento  ) 
VALUES ('','');

/*------------------------------READ-------------------------------------------*/
SELECT NoFactura ,CodigoMedicamento FROM MEDICAMENTOS_POR_PEDIDO;

/*------------------------------UPDATE-------------------------------------------*/

/*------------------------------Delete-------------------------------------------*/
DELETE FROM MEDICAMENTOS_POR_PEDIDO
WHERE NoFactura = '' ,CodigoMedicamento = '';
