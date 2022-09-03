USE [#Base#]


CREATE TABLE [dbo].[Zw_WMS_Ubicaciones_Mapa_Enc](
	[Id_Mapa] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [char](2) NOT NULL DEFAULT (''),
	[Sucursal] [char](3) NOT NULL DEFAULT (''),
	[Bodega] [char](3) NOT NULL DEFAULT (''),
	[Nombre_Mapa] [varchar](100) NOT NULL DEFAULT (''),
	[Suelo_es_Ubicacion] [bit] NOT NULL DEFAULT (0),
	[Nivel] [int] NOT NULL DEFAULT (0),
	[Orden] [int] NOT NULL DEFAULT (0),
	[Id_Mapa_Padre] [int] NOT NULL DEFAULT (0),
	[Es_Sub_Mapa] [bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_WMS_Ubicaciones_Mapa_Enc] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Sucursal] ASC,
	[Bodega] ASC,
	[Nombre_Mapa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



