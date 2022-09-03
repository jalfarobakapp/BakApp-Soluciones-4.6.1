USE [#Base#]


CREATE TABLE [dbo].[Zw_Prod_Asociacion_Respaldo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [char](13) NOT NULL DEFAULT (''),
	[Codigo_Nodo] [int] NOT NULL DEFAULT (0),
	[DescripcionBusqueda] [varchar](500) NOT NULL DEFAULT (''),
	[Para_filtro] [bit] NOT NULL DEFAULT (0),
	[Nodo_origen] [int] NOT NULL DEFAULT (0),
	[Clas_unica] [bit] NOT NULL DEFAULT (0),
	[Producto] [bit] NOT NULL DEFAULT (0)
) ON [PRIMARY]



