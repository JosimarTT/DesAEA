CREATE TABLE [dbo].[productos] (
    [idproducto]           INT          NOT NULL,
    [nombreProducto]       VARCHAR (40) NULL,
    [idProveedor]          INT          NULL,
    [idCategoria]          INT          NULL,
    [cantidadPorUnidad]    VARCHAR (20) NULL,
    [precioUnidad]         DECIMAL (18) NULL,
    [unidadesEnExistencia] SMALLINT     NULL,
    [unidadesEnPedido]     SMALLINT     NULL,
    [nivelNuevoPedido]     SMALLINT     NULL,
    [suspendido]           SMALLINT     NULL,
    [categoriaProducto]    VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([idproducto] ASC),
    CONSTRAINT [fk_3] FOREIGN KEY ([idProveedor]) REFERENCES [dbo].[proveedores] ([idProveedor]),
    CONSTRAINT [fk_7] FOREIGN KEY ([idCategoria]) REFERENCES [dbo].[categorias] ([idcategoria])
);

