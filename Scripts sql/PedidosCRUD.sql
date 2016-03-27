
USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
INSERT INTO PEDIDO ( HoraRecojo , NoSucursal , IdCliente, Estado) 
VALUES ('','','','');

/*------------------------------READ-------------------------------------------*/
SELECT NoFactura , HoraRecojo , NoSucursal , IdCliente, Estado FROM PEDIDO;

/*------------------------------UPDATE-------------------------------------------*/
UPDATE PEDIDO
SET HoraRecojo = '' , NoSucursal='' , IdCliente='', Estado=''
WHERE NoFactura = '1' ;

/*------------------------------Delete-------------------------------------------*/
DELETE FROM PEDIDO
WHERE NoFactura = '';

