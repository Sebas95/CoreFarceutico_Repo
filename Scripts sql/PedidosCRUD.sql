
USE FARMATICA;


/*------------------------------CREATE-------------------------------------------*/
INSERT INTO PEDIDO ( HoraRecojo , NoSucursal , IdCliente, Estado, Empresa) 
VALUES ('','','','','');

/*------------------------------READ-------------------------------------------*/
SELECT NoFactura , HoraRecojo , NoSucursal , IdCliente, Estado , Empresa FROM PEDIDO;

/*------------------------------UPDATE-------------------------------------------*/
UPDATE PEDIDO
SET HoraRecojo = '' , NoSucursal='' , IdCliente='', Estado='' , Empresa = ''
WHERE NoFactura = '1' ;

/*------------------------------Delete-------------------------------------------*/
DELETE FROM PEDIDO
WHERE NoFactura = '';

