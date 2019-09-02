CREATE procedure [dbo].[USP_Lab03_SeleccionarPedidoPorCliente]
@Anio INT,
@Mes INT,
@idEmpleado INT,
@idCliente varchar(5) = ''
AS
select p.IdPedido, p.FechaEntrega AS 'Fecha de Entrega', Destinatario
from pedidos p
inner join clientes c
on p.IdCliente = c.idCliente
where year(p.FechaPedido) = @Anio and month(p.fechapedido) = @Mes and p.IdEmpleado = @idEmpleado and p.IdCliente = @idCliente