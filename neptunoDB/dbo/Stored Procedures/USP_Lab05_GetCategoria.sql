CREATE PROC USP_Lab05_GetCategoria
@idcategoria INT=0
AS
BEGIN
SELECT idcategoria,nombrecategoria,descripcion
FROM categorias
WHERE idcategoria=@idcategoria OR @idcategoria=0
END