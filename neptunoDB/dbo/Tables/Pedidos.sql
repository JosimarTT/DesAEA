CREATE TABLE [dbo].[Pedidos] (
    [IdPedido]              INT          NOT NULL,
    [IdCliente]             VARCHAR (5)  NOT NULL,
    [IdEmpleado]            INT          NOT NULL,
    [FechaPedido]           DATE         NULL,
    [FechaEntrega]          DATE         NULL,
    [FechaEnvio]            DATE         NULL,
    [FormaEnvio]            INT          NULL,
    [Cargo]                 DECIMAL (18) NULL,
    [Destinatario]          VARCHAR (60) NULL,
    [DireccionDestinatario] VARCHAR (60) NULL,
    [CiudadDestinatario]    VARCHAR (60) NULL,
    [RegionDestinatario]    VARCHAR (60) NULL,
    [CodPostalDestinatario] VARCHAR (60) NULL,
    [PaisDestinatario]      VARCHAR (60) NULL,
    PRIMARY KEY CLUSTERED ([IdPedido] ASC),
    CONSTRAINT [fk_4] FOREIGN KEY ([FormaEnvio]) REFERENCES [dbo].[compañiasdeenvios] ([idCompañiaEnvios]),
    CONSTRAINT [fk_5] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[clientes] ([idCliente]),
    CONSTRAINT [fk_6] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[Empleados] ([IdEmpleado])
);

