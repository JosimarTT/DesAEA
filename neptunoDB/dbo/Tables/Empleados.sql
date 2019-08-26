CREATE TABLE [dbo].[Empleados] (
    [IdEmpleado]        INT          NOT NULL,
    [Apellidos]         VARCHAR (20) NULL,
    [Nombre]            VARCHAR (20) NULL,
    [cargo]             VARCHAR (40) NULL,
    [Tratamiento]       VARCHAR (40) NULL,
    [FechaNacimiento]   DATE         NULL,
    [FechaContratacion] DATE         NULL,
    [direccion]         VARCHAR (60) NULL,
    [ciudad]            VARCHAR (15) NULL,
    [region]            VARCHAR (15) NULL,
    [codPostal]         VARCHAR (10) NULL,
    [pais]              VARCHAR (15) NULL,
    [TelDomicilio]      VARCHAR (24) NULL,
    [Extension]         VARCHAR (4)  NULL,
    [notas]             TEXT         NULL,
    [Jefe]              INT          NULL,
    [sueldoBasico]      DECIMAL (18) NULL,
    PRIMARY KEY CLUSTERED ([IdEmpleado] ASC)
);

