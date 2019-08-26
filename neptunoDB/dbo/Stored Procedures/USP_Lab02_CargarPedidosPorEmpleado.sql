CREATE PROCEDURE USP_Lab02_CargarPedidosPorEmpleado
@idEmpleado INT = 0
AS
select p.IdPedido AS PEDIDO, cli.NombreCompañia AS CLIENTE, e.Nombre+' '+e.Apellidos AS EMPLEADO from Pedidos p
INNER JOIN Empleados e
ON p.IdEmpleado = e.IdEmpleado
INNER JOIN clientes cli
ON p.IdCliente = cli.idCliente
WHERE p.IdEmpleado = @idEmpleado