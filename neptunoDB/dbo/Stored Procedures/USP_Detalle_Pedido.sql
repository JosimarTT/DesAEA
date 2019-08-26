 create procedure USP_Detalle_Pedido
 @idpedido INT
 AS
 SELECT detallesdepedidos.idproducto, nombreProducto, detallesdepedidos.preciounidad, cantidad, detallesdepedidos.preciounidad*cantidad as Monto
 FROM detallesdepedidos INNER JOIN productos
 ON detallesdepedidos.idproducto = productos.idproducto
 WHERE idpedido = @idpedido