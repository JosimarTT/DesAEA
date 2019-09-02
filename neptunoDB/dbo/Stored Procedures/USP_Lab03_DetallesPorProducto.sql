CREATE procedure [dbo].[USP_Lab03_DetallesPorProducto]
@idPedido INT
AS
select prod.idproducto, prod.nombreProducto, det.preciounidad, det.cantidad, det.preciounidad*det.cantidad AS Monto
from detallesdepedidos det
inner join productos prod
on det.idproducto = prod.idproducto
where det.idpedido = @idPedido