USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[Zw_TblArbol_Asociaciones](
	[Codigo_Nodo]              [varchar](10) NOT NULL DEFAULT (''),
	[Identificador_Nodo]       [int] IDENTITY(1,1) NOT NULL,
	[Identificacdor_NodoPadre] [int] NOT NULL DEFAULT (0),
	[Descripcion]              [varchar](200) NOT NULL DEFAULT (''),
	[Es_Padre]                 [bit] NOT NULL DEFAULT (0),
	[Es_Seleccionable]         [bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_TblArbol_Asociaciones] PRIMARY KEY CLUSTERED 
(
	[Identificador_Nodo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
