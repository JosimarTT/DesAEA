CREATE TABLE [dbo].[clientes] (
    [idCliente]      VARCHAR (5)   NOT NULL,
    [NombreCompañia] VARCHAR (100) NOT NULL,
    [NombreContacto] VARCHAR (100) NULL,
    [CargoContacto]  VARCHAR (100) NULL,
    [Direccion]      VARCHAR (100) NULL,
    [Ciudad]         VARCHAR (100) NULL,
    [Region]         VARCHAR (100) NULL,
    [CodPostal]      VARCHAR (100) NULL,
    [Pais]           VARCHAR (100) NULL,
    [Telefono]       VARCHAR (30)  NULL,
    [Fax]            VARCHAR (30)  NULL,
    PRIMARY KEY CLUSTERED ([idCliente] ASC)
);

