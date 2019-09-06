create proc USP_Lab04_DetallesPorPedido
@idPedido INT
AS
select det.idpedido,prod.idproducto, det.preciounidad, det.cantidad, det.descuento
from detallesdepedidos det
inner join productos prod
on det.idproducto = prod.idproducto
where det.idpedido = @idPedido