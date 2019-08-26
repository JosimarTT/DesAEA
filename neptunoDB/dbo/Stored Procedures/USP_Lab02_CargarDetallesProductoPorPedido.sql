CREATE PROCEDURE USP_Lab02_CargarDetallesProductoPorPedido
@idPedido INT = 0
AS
SELECT p.IdPedido, prod.nombreProducto, prod.cantidadPorUnidad, prod.categoriaProducto
FROM Pedidos p
INNER JOIN detallesdepedidos det
ON p.IdPedido = det.idpedido
INNER JOIN productos prod
ON det.idproducto = prod.idproducto
WHERE p.IdPedido = @idPedido