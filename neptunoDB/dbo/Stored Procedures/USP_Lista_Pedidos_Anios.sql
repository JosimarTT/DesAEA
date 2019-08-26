  CREATE PROCEDURE USP_Lista_Pedidos_Anios
  @anio INT
  AS
  SELECT IdPedido, NombreCompañia, Apellidos+' '+Nombre AS Empleado, FechaPedido, FechaEntrega
  FROM clientes INNER JOIN Pedidos
  ON clientes.idCliente = Pedidos.IdCliente
  INNER JOIN Empleados
  ON Pedidos.IdEmpleado = Empleados.IdEmpleado
  WHERE YEAR (FechaPedido) = @anio