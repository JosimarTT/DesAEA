CREATE PROC USP_Lab05_InsCategoria
@nombrecategoria varchar(100),
@descripcion text
AS
BEGIN
DECLARE @idcategoria INT
SET @idcategoria = (SELECT MAX(idcategoria)+1 from categorias)
INSERT INTO categorias(idcategoria, nombrecategoria, descripcion)
VALUES (@idcategoria, @nombrecategoria, @descripcion)
END