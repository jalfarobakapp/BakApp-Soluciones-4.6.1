USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[Zw_Prod_Asociacion](
	[Id]                  [int] IDENTITY(1,1) NOT NULL,
	[Codigo]              [char](13)     NOT NULL Default '',
	[Codigo_Nodo]         [int]          NOT NULL Default (0),
	[DescripcionBusqueda] [varchar](500) NOT NULL Default '',
	[Para_filtro]         [bit]          NOT NULL Default (0),
	[Nodo_origen]         [int]          NOT NULL Default (0),
	[Clas_unica]          [bit]          NOT NULL Default (0),
	[Producto] [bit] NOT NULL,
 CONSTRAINT [PK_Zw_Prod_Asociacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


