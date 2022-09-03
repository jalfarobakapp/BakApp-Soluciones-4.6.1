USE [#Base#]

CREATE TABLE [dbo].[Zw_Demonio_Doc_Emitidos_Aviso_Correo_Adjuntos](
	[Id]            [int] IDENTITY(1,1) NOT NULL,
	[Id_Padre]      [int]           NOT NULL DEFAULT (0),
	[Idmaeedo]      [int]           NOT NULL DEFAULT (0),
	[Tido]          [varchar](3)    NOT NULL DEFAULT (''),
	[Nudo]          [varchar](10)   NOT NULL DEFAULT (''),
	[NombreFormato] [varchar](50)   NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Demonio_Doc_Emitidos_Aviso_Correo_Adjuntos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


