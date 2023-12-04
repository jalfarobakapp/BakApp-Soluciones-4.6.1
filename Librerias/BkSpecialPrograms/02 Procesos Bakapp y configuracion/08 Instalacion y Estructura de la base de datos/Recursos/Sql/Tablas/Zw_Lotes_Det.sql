USE [#Base#]

CREATE TABLE [dbo].[Zw_Lotes_Det](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Id_Lote]		[int]			NOT NULL Default(0),
	[NroLote]		[varchar](20)	NOT NULL Default(''),
	[NomTabla]		[varchar](20)	NOT NULL Default(''),
	[IdTabla]		[int]			NOT NULL Default(0),
) ON [PRIMARY]



