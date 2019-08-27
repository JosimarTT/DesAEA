  CREATE PROC USP_Lab03_FECHAFECHA
  @FEC1 datetime,
  @FEC2 datetime
  AS
  SELECT *
  FROM Pedidos p
  WHERE p.FechaPedido BETWEEN @FEC1 AND @FEC2