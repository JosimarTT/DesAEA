create proc USP_Lab03_Total
@idpedido INT,
@Total MONEY OUTPUT
AS
SET @Total=(
SELECT SUM(preciounidad*cantidad)
FROM detallesdepedidos
WHERE idpedido=@idpedido
)