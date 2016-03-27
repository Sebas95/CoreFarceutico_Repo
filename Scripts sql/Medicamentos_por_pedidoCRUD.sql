
USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
INSERT INTO MEDICAMENTOS_POR_PEDIDO ( NoFactura , CodigoMedicamento  ) 
VALUES ('','');

/*------------------------------READ-------------------------------------------*/
SELECT NoFactura ,CodigoMedicamento FROM MEDICAMENTOS_POR_PEDIDO;

/*------------------------------UPDATE-------------------------------------------*/
UPDATE MEDICAMENTOS_POR_PEDIDO
SET HoraRecojo = '' , NoSucursal='' , IdCliente='', Estado=''
WHERE NoFactura = '1' ;

/*------------------------------Delete-------------------------------------------*/
DELETE FROM PEDIDO
WHERE NoFactura = '';
