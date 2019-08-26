CREATE procedure [dbo].[USP_Lab02_SeleccionarMesPorAnio]
@anio INT
as
select distinct MONTH(FechaPedido) AS Mes
from Pedidos
where year(Pedidos.FechaPedido) = @anio