CREATE TABLE [dbo].[detallesdepedidos] (
    [idpedido]     INT          NULL,
    [idproducto]   INT          NULL,
    [preciounidad] DECIMAL (18) NOT NULL,
    [cantidad]     INT          NOT NULL,
    [descuento]    DECIMAL (18) NOT NULL,
    CONSTRAINT [fk_1] FOREIGN KEY ([idpedido]) REFERENCES [dbo].[Pedidos] ([IdPedido]),
    CONSTRAINT [fk_2] FOREIGN KEY ([idproducto]) REFERENCES [dbo].[productos] ([idproducto])
);

