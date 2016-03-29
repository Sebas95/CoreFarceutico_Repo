USE FARMATICA;
SELECT M.Codigo , M.Nombre , MR.Cantidad , M.Costo AS CostoUnitario , M.CasaFarmaceutica   FROM 
(RECETA AS R  JOIN MEDICAMENTOS_POR_RECETA AS MR ON R.NoReceta = MR.NoReceta ) 
JOIN MEDICAMENTO AS M ON MR.CodigoMedicamento = M.Codigo
WHERE R.NoReceta = '2'  ;