USE [#Base#]

CREATE TABLE [dbo].[Zw_WMS_Ubicaciones_Sectores](
	[Id_Sector]			[int] IDENTITY(1,1) NOT NULL,
	[Id_Mapa]			[int]				NOT NULL DEFAULT (0),
	[Empresa]			[char](2)			NOT NULL DEFAULT (''),
	[Sucursal]			[char](3)			NOT NULL DEFAULT (''),
	[Bodega]			[char](3)			NOT NULL DEFAULT (''),
	[Codigo_Sector]		[varchar](20)		NOT NULL DEFAULT (''),
	[Nombre_Sector]		[varchar](50)		NOT NULL DEFAULT (''),
	[Es_SubSector]		[bit]				NOT NULL DEFAULT (0),
	[EsCabecera]		[bit]				NOT NULL DEFAULT (0),
	[SoloUnaUbicacion]  [bit]				NOT NULL DEFAULT (0),
	[OblConfimarUbic]   [bit]				NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_WMS_Ubicaciones_Sectores] PRIMARY KEY CLUSTERED 
(
	[Id_Sector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



