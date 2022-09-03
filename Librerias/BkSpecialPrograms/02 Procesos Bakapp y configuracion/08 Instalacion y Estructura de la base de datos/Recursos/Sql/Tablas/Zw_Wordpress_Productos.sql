USE [#Base#]


CREATE TABLE [dbo].[Zw_Wordpress_Productos](
	[Empresa]		[varchar](2)	NOT NULL DEFAULT (''),
	[Id_Producto]	[int]			NOT NULL DEFAULT (0),
	[Sku]			[varchar](13)	NOT NULL DEFAULT (''),
	[Descripcion]	[varchar](128)	NOT NULL DEFAULT (''),
	[Stock]			[float]			NOT NULL DEFAULT (0),
	[Precio]		[float]			NOT NULL DEFAULT (0),
	[Actualizacion] [datetime]		NULL,
	[Log_Producto]	[varchar](150)	NOT NULL DEFAULT ('')
) ON [PRIMARY]



