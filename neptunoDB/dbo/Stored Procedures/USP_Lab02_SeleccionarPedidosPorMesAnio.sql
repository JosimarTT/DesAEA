CREATE procedure [dbo].[USP_Lab02_SeleccionarPedidosPorMesAnio]
@anio int,
@mes int
AS
select p.IdPedido,IdCliente,Destinatario,DireccionDestinatario AS Mes
from pedidos p
WHERE year(FechaPedido)=@anio AND MONTH(FechaPedido) = @mes