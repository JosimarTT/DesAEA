CREATE PROC USP_Lab05_DelCategoria
@idcategoria INT
AS
BEGIN
DELETE FROM categorias WHERE idcategoria=@idcategoria
END