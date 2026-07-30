USE [#Base#]


CREATE TABLE [dbo].[Zw_InterStock_Equivalencia](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Empresa_A]		[char](2)		NOT NULL    DEFAULT (''),
	[Sucursal_A]	[varchar](3)	NOT NULL    DEFAULT (''),
	[Bodega_A]		[varchar](3)	NOT NULL    DEFAULT (''),
	[Empresa_B]		[char](2)		NOT NULL    DEFAULT (''),
	[Sucursal_B]	[varchar](3)	NULL        DEFAULT (''),
	[Bodega_B]		[varchar](3)	NOT NULL    DEFAULT (''),
	[Activo]		[bit]			NOT NULL    DEFAULT (0),
	[FechaCreacion] [datetime]      NULL,
    [Activo2]		[bit]			NOT NULL    DEFAULT (0),
) ON [PRIMARY]


