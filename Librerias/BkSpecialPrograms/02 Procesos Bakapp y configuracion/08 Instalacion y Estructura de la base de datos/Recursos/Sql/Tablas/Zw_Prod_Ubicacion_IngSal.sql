USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_Ubicacion_IngSal](
	[Id]					[int]			IDENTITY(1,1) NOT NULL,
	[Semilla]				[int]			NOT NULL,
	[Empresa]				[varchar](2)	NOT NULL,
	[Sucursal]				[varchar](3)	NOT NULL,
	[Bodega]				[varchar](3)	NOT NULL,
	[Id_Mapa]				[int]			NOT NULL,
	[Codigo_Sector]			[varchar](20)	NOT NULL,
	[Codigo_Ubic]			[varchar](20)	NOT NULL,
	[Codigo]				[char](13)		NOT NULL,
	[NombreEquipo]			[varchar](50)	NOT NULL,
	[CodFuncionario_Ing]	[char](3)		NOT NULL,
	[Ingreso]				[bit]			NOT NULL,
	[FechaIngreso]			[datetime]		NULL,
	[CodFuncionario_Sal]	[char](3)		NOT NULL,
	[Salida]				[bit]			NOT NULL,
	[FechaSalida]			[datetime]		NULL,
 CONSTRAINT [PK_Zw_Prod_Ubicacion_IngSal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
