  CREATE PROC [dbo].[USP_Lab03_FECHAFECHA]
  @FEC1 datetime,
  @FEC2 datetime
  AS
  SELECT IdPedido, IdCliente, IdEmpleado, FechaPedido, FechaEntrega, FechaEnvio, FormaEnvio,Cargo, Destinatario, DireccionDestinatario, RegionDestinatario,CodPostalDestinatario,PaisDestinatario
  FROM Pedidos p
  WHERE p.FechaPedido BETWEEN @FEC1 AND @FEC2