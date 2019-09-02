  CREATE PROCEDURE  [dbo].[USP_Lab03_ListaAnios]
  AS
  select distinct year(FechaPedido) AS Anios
  from Pedidos
  order by year(FechaPedido)