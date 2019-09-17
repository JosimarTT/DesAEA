
CREATE PROC USP_Lab05_UpdCategoria
@idcategoria INT,
@nombrecategoria varchar(100),
@descripcion text
AS
BEGIN
UPDATE categorias SET nombrecategoria = @nombrecategoria, descripcion = @descripcion
WHERE idcategoria = @idcategoria
END