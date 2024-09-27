USE [#Base#]


CREATE TABLE [dbo].[Zw_WMS_Ubicaciones_Bodega](
	[Id_Mapa]           [int]               NOT NULL DEFAULT (0),
	[Id_Ubicacion]      [int] IDENTITY(1,1) NOT NULL,
	[Empresa]           [char](2)           NOT NULL DEFAULT (''),
	[Sucursal]          [char](3)           NOT NULL DEFAULT (''),
	[Bodega]            [char](3)           NOT NULL DEFAULT (''),
	[Codigo_Sector]     [varchar](20)       NOT NULL DEFAULT (''),
	[Columna]           [varchar](10)       NOT NULL DEFAULT (''),
	[NomColumna]        [varchar](20)       NOT NULL DEFAULT (''),
	[Fila]              [varchar](10)       NOT NULL DEFAULT (''),
	[Alto]              [float]             NOT NULL DEFAULT (0),
	[Largo]             [float]             NOT NULL DEFAULT (0),
	[Ancho]             [float]             NOT NULL DEFAULT (0),
	[Peso_Max]          [float]             NOT NULL DEFAULT (0),
	[Es_SubSector]      [bit]               NOT NULL DEFAULT (0),
	[Padre_Ubic]        [varchar](20)       NOT NULL DEFAULT (''),
	[Codigo_Ubic]       [varchar](20)       NOT NULL DEFAULT (''),
	[Descripcion_Ubic]  [varchar](300)      NOT NULL DEFAULT (''),
	[Nombre_SubSector]  [varchar](50)       NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_WMS_Ubicaciones_Bodega] PRIMARY KEY CLUSTERED 
(
	[Id_Ubicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

