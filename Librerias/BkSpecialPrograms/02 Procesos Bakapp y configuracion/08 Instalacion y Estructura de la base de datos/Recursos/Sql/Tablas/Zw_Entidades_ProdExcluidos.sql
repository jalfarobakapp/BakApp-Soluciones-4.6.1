USE [#Base#]


CREATE TABLE [dbo].[Zw_Entidades_ProdExcluidos](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[CodEntidad]	[varchar](13) NOT NULL DEFAULT (''),
	[CodSucEntidad] [varchar](10) NOT NULL DEFAULT (''),
	[Chk]			[bit] NOT NULL DEFAULT (0),
	[Codigo]		[varchar](13) NOT NULL DEFAULT (''),
	[Motivo]		[varchar](200) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Entidades_ProdExcluidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



