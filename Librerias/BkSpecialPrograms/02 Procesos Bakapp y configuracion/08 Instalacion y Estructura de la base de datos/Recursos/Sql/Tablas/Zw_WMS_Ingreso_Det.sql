USE [#Base#]


CREATE TABLE [dbo].[Zw_WMS_Ingreso_Det](
	[Id] [int] NOT NULL DEFAULT (0),
	[Id_WMS] [int] NOT NULL DEFAULT (0),
	[Id_Mapa] [int] NOT NULL DEFAULT (0),
	[Empresa] [varchar](2) NOT NULL DEFAULT (''),
	[Sucursal] [varchar](3) NOT NULL DEFAULT (''),
	[Bodega] [varchar](3) NOT NULL DEFAULT (''),
	[TipoDoc] [varchar](3) NOT NULL DEFAULT (''),
	[Nro_WMS] [varchar](10) NOT NULL DEFAULT (''),
	[Codigo_Sector] [varchar](20) NOT NULL DEFAULT (''),
	[Codigo_Ubic] [varchar](20) NOT NULL DEFAULT (''),
	[Codigo] [varchar](13) NOT NULL DEFAULT (''),
	[Descripcion] [varchar](50) NOT NULL DEFAULT (''),
	[CantUd1] [float] NOT NULL DEFAULT (0),
	[CantUd2] [float] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_WMS_Ingreso_Det] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

