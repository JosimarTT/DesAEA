  CREATE PROCEDURE [dbo].[USP_ReportePedidosPorCliente]
  @idCliente VARCHAR(5) = ''
  AS
  SELECT p.IdPedido AS Codigo, cli.NombreCompañia AS Cliente, emp.Nombre+' '+emp.Apellidos AS Empleado, p.FechaPedido, p.Cargo
  FROM clientes AS c
  INNER JOIN Pedidos AS p 
  ON c.idCliente = p.IdCliente
  INNER JOIN clientes AS cli
  ON p.IdCliente = cli.idCliente
  INNER JOIN Empleados AS emp
  ON p.IdEmpleado = emp.IdEmpleado
  WHERE c.idCliente = @idCliente OR @idCliente = ''