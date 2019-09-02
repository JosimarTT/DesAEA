  CREATE PROCEDURE [dbo].[USP_Lab03_ListarMeses]
  AS
  select distinct month(FechaPedido) as Meses
  from Pedidos
  order by month(FechaPedido)