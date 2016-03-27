
USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento, Cantidad  ) 
VALUES ('','','');

/*------------------------------READ-------------------------------------------*/
SELECT NoFactura ,CodigoMedicamento, Cantidad FROM MEDICAMENTOS_POR_PEDIDO;

/*------------------------------UPDATE-------------------------------------------*/

/*------------------------------Delete-------------------------------------------*/
DELETE FROM MEDICAMENTOS_POR_PEDIDO
WHERE NoFactura = ''  AND CodigoMedicamento = '';
