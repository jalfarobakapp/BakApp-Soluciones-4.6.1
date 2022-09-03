USE [#Base#]


CREATE TABLE [dbo].[Zw_Demonio_Wordpress](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Empresa]		[varchar](2)		NOT NULL DEFAULT (''),
	[Id_Producto]	[varchar](13)		NOT NULL DEFAULT (''),
	[Sku]			[varchar](13)		NOT NULL DEFAULT (''),
	[Stock]			[float]				NOT NULL DEFAULT (0),
	[Descripcion]	[varchar](50)		NOT NULL DEFAULT (''),
	[Fecha]			[datetime]			NULL,
	[Revisado]		[bit]				NOT NULL DEFAULT (0),
	[Error]			[bit]				NOT NULL DEFAULT (0),
	[Log_Error]		[varchar](5000)		NOT NULL DEFAULT (''),
	[Fecha_Hora]	[datetime]			NOT NULL DEFAULT (Getdate()),
    [Precio]		[float]				NOT NULL DEFAULT (0),
) ON [PRIMARY]



