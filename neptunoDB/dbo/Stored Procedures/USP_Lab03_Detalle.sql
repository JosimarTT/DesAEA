  CREATE PROC USP_Lab03_Detalle
  @idPedido INT
  AS
  select det.idpedido, prod.nombreProducto, prod.precioUnidad,prod.cantidadPorUnidad
  from detallesdepedidos det
  INNER JOIN productos prod
  ON det.idproducto = prod.idproducto
  where det.idpedido = @idPedido