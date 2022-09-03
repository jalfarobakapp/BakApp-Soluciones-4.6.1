USE [#Base#]

CREATE TABLE [dbo].[Zw_Casi_DocPer](
	[Id_DocEnc]				  [int]			 NOT NULL,
	[CodPermiso]			  [varchar](20)  NOT NULL DEFAULT (''),
	[DescripcionPermiso]	  [varchar](200) NOT NULL DEFAULT (''),
	[Necesita_Permiso]		  [bit]			 NOT NULL DEFAULT (0),
	[Autorizado]		      [bit]			 NOT NULL DEFAULT (0),
	[CodFuncionario_Autoriza] [varchar](3)   NOT NULL DEFAULT (''),
	[NomFuncionario_Autoriza] [varchar](50)  NOT NULL DEFAULT (''),
	[NroRemota]				  [varchar](10)  NOT NULL DEFAULT (''),
	[Permiso_Presencial]	  [bit]			 NOT NULL DEFAULT (0),
	[Solicitado_Por_Cadena]   [bit]			 NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Casi_DocPer] PRIMARY KEY CLUSTERED 
(
	[Id_DocEnc] ASC,
	[CodPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
