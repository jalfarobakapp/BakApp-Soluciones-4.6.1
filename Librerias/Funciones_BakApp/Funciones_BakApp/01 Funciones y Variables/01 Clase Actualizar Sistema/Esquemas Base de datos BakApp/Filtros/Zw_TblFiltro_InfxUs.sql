USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

	
CREATE TABLE [dbo].[Zw_TblFiltro_InfxUs](
	[Funcionario] [char](3)  NOT NULL DEFAULT (''),
	[Informe] [varchar](20)  NOT NULL DEFAULT (''),
	[Tabla] [varchar](20)    NOT NULL DEFAULT (''),
	[Codigo] [varchar](20)   NOT NULL DEFAULT (''),
	[Filtro] [varchar](1000) NULL DEFAULT (''),
	[MarcarTodo] [bit]       NOT NULL DEFAULT ((1)),
 CONSTRAINT [PK_Zw_TblFiltro_InfxUs] PRIMARY KEY CLUSTERED 
(
	[Funcionario] ASC,
	[Informe] ASC,
	[Tabla] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]





