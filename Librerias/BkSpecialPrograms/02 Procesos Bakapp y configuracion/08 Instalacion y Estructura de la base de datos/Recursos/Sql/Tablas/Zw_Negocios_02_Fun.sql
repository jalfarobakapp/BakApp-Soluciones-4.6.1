USE [#Base#]


CREATE TABLE [dbo].[Zw_Negocios_02_Fun](
	[Nro_Negocio] [varchar](10) NOT NULL DEFAULT (''),
	[Stand_By] [bit] NOT NULL DEFAULT (0),
	[CodFuncionario] [varchar](3) NOT NULL DEFAULT (''),
	[NomFuncionario] [varchar](50) NOT NULL DEFAULT (''),
	[Email] [varchar](50) NOT NULL DEFAULT (''),
	[Enviar_copia_al_cierre] [bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Negocios_02_Fun] PRIMARY KEY CLUSTERED 
(
	[Nro_Negocio] ASC,
	[Stand_By] ASC,
	[CodFuncionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


