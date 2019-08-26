  CREATE PROCEDURE USP_ListaAnios
  AS
  SELECT DISTINCT YEAR(fechapedido) AS Anios FROM Pedidos