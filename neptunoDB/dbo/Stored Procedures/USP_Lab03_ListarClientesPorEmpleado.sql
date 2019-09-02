
create procedure USP_Lab03_ListarClientesPorEmpleado
@Anios as INT,
@Meses AS INT,
@idEmpleado as INT
AS
  select c.idCliente AS id, c.NombreCompañia AS Nombre
  from Pedidos p
  inner join clientes c
  on p.IdCliente = c.idCliente
  where year(p.FechaPedido) = @Anios and month(p.fechapedido) = @Meses and p.IdEmpleado = @idEmpleado