CREATE PROCEDURE [dbo].[USP_ListarClientePorIniciales]
@idCliente varchar(5) = ''
AS
SELECT *
FROM clientes c
WHERE c.idCliente LIKE @idCliente+'%' OR @idCliente = ''