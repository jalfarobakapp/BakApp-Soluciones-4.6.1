USE [#Base#]

CREATE TABLE [dbo].[Zw_Inv_Sector](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[IdInventario]		[int]				NOT NULL DEFAULT (0),
	[Empresa]			[char](2)			NOT NULL DEFAULT (''),
	[Sucursal]			[varchar](3)		NOT NULL DEFAULT (''),
	[Bodega]			[varchar](3)		NOT NULL DEFAULT (''),
	[Sector]			[varchar](30)		NOT NULL DEFAULT (''),
	[NombreSector]		[varchar](50)		NOT NULL DEFAULT (''),
	[CodFuncionario]	[varchar](3)		NOT NULL DEFAULT (''),
	[Abierto]			[bit]				NOT NULL DEFAULT (0)
) ON [PRIMARY]
