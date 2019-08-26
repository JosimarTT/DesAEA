CREATE TABLE [dbo].[proveedores] (
    [idProveedor]     INT          NOT NULL,
    [nombreCompañia]  VARCHAR (40) NOT NULL,
    [nombrecontacto]  VARCHAR (30) NULL,
    [cargocontacto]   VARCHAR (30) NULL,
    [direccion]       VARCHAR (60) NULL,
    [ciudad]          VARCHAR (15) NULL,
    [region]          VARCHAR (15) NULL,
    [codPostal]       VARCHAR (10) NULL,
    [pais]            VARCHAR (15) NULL,
    [telefono]        VARCHAR (24) NULL,
    [fax]             VARCHAR (24) NULL,
    [paginaprincipal] TEXT         NULL,
    PRIMARY KEY CLUSTERED ([idProveedor] ASC)
);

