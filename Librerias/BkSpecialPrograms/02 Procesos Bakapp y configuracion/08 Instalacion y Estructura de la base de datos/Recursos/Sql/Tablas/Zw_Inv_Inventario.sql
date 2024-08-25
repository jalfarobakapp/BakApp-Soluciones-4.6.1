USE [#Base#]

CREATE TABLE [dbo].[Zw_Inv_Inventario](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Ano]					[char](4)		NOT NULL DEFAULT (''),
	[Mes]					[char](2)		NOT NULL DEFAULT (''),
	[Dia]					[char](2)		NOT NULL DEFAULT (''),
	[Fecha_Inventario]		[datetime]		NULL,
	[Empresa]				[char](2)		NOT NULL DEFAULT (''),
	[Sucursal]				[char](3)		NOT NULL DEFAULT (''),
	[Bodega]				[char](3)		NOT NULL DEFAULT (''),
	[Nombre_Empresa]		[varchar](50)	NOT NULL DEFAULT (''),
	[Nombre_Sucursal]		[varchar](50)	NOT NULL DEFAULT (''),
	[Nombre_Bodega]			[varchar](50)	NOT NULL DEFAULT (''),
	[NombreInventario]		[varchar](50)	NOT NULL DEFAULT (''),
	[FuncionarioCargo]		[char](3)		NOT NULL DEFAULT (''),
	[NombreFuncionario]		[varchar](50)	NOT NULL DEFAULT (''),
	[Activo]				[bit]			NOT NULL DEFAULT (0),
	[FechaCierre]			[datetime]		NULL
) ON [PRIMARY]

