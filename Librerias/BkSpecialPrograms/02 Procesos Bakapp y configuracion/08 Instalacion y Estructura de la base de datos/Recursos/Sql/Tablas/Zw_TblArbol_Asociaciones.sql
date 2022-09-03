USE [#Base#]


CREATE TABLE [dbo].[Zw_TblArbol_Asociaciones](
	[Codigo_Nodo] [varchar](13) NOT NULL DEFAULT (''),
	[Identificador_Nodo] [int] IDENTITY(1,1) NOT NULL,
	[Identificacdor_NodoPadre] [int] NOT NULL DEFAULT (0),
	[Descripcion] [varchar](500) NOT NULL DEFAULT (''),
	[Es_Padre] [bit] NOT NULL DEFAULT (0),
	[Es_Seleccionable] [bit] NOT NULL DEFAULT (0),
	[Es_Ubicacion] [bit] NOT NULL DEFAULT (0),
	[Clas_Unica_X_Producto] [bit] NOT NULL DEFAULT (0),
	[Nodo_Raiz] [int] NOT NULL DEFAULT (0),
	[Codigo_Madre] [varchar](20) NOT NULL DEFAULT ('')
) ON [PRIMARY]


