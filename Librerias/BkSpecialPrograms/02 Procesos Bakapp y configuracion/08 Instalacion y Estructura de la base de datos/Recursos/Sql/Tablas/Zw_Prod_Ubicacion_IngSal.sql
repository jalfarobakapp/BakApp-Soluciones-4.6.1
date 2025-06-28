USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_Ubicacion_IngSal](
	[Id]					[int]			IDENTITY(1,1) NOT NULL,
	[Semilla]				[int]			NOT NULL DEFAULT (0),
	[Empresa]				[varchar](2)	NOT NULL DEFAULT (''),
	[Sucursal]				[varchar](3)	NOT NULL DEFAULT (''),
	[Bodega]				[varchar](3)	NOT NULL DEFAULT (''),
	[Id_Mapa]				[int]			NOT NULL DEFAULT (0),
	[Codigo_Sector]			[varchar](20)	NOT NULL DEFAULT (''),
	[Codigo_Ubic]			[varchar](20)	NOT NULL DEFAULT (''),
	[Codigo]				[char](13)		NOT NULL DEFAULT (''),
	[NombreEquipo]			[varchar](50)	NOT NULL DEFAULT (''),
	[CodFuncionario_Ing]	[char](3)		NOT NULL DEFAULT (''),
	[Ingreso]				[bit]			NOT NULL DEFAULT (0),
	[FechaIngreso]			[datetime]		NULL,
	[CodFuncionario_Sal]	[char](3)		NOT NULL DEFAULT (''),
	[Salida]				[bit]			NOT NULL DEFAULT (0),
	[FechaSalida]			[datetime]		NULL,
 CONSTRAINT [PK_Zw_Prod_Ubicacion_IngSal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
