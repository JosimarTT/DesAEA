CREATE TABLE [dbo].[categorias] (
    [idcategoria]     INT           NOT NULL,
    [nombrecategoria] VARCHAR (100) NOT NULL,
    [descripcion]     TEXT          NULL,
    PRIMARY KEY CLUSTERED ([idcategoria] ASC)
);

