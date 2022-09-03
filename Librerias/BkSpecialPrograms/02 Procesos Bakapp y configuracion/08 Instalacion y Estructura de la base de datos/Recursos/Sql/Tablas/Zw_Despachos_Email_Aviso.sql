USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos_Email_Aviso](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Tipo_Envio]			[varchar](5)    NOT NULL DEFAULT (''),
	[Tipo_Venta]			[varchar](5)    NOT NULL DEFAULT (''),
	[Estado]				[varchar](3)    NOT NULL DEFAULT (''),
	[Id_Correo]				[int]           NOT NULL DEFAULT (0),
	[Adjuntar_Documentos]	[bit]           NOT NULL DEFAULT (0),
	[Enviar_al_otro_dia]	[bit]           NOT NULL DEFAULT (0),
    [Format_BLV]            [varchar](50)   NOT NULL DEFAULT (''),
	[Format_FCV]            [varchar](50)   NOT NULL DEFAULT (''),
	[Format_GDV]            [varchar](50)   NOT NULL DEFAULT (''),
	[Format_GTI]            [varchar](50)   NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Despachos_Email_Aviso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


