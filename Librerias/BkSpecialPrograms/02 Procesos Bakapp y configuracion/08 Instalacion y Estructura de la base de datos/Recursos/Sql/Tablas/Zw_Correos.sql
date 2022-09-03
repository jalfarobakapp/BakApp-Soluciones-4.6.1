USE [#Base#]


CREATE TABLE [dbo].[Zw_Correos](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Nombre_Correo]		[varchar](100)  NOT NULL DEFAULT (''),
	[Remitente]			[varchar](200)  NOT NULL DEFAULT (''),
	[Contrasena]		[varchar](15)   NOT NULL DEFAULT (''),
	[Host]				[varchar](100)  NOT NULL DEFAULT (''),
	[Puerto]			[int]           NOT NULL DEFAULT (0),
	[Asunto]			[varchar](300)  NOT NULL DEFAULT (''),
	[Auto_Asunto]		[bit]           NOT NULL DEFAULT (0),
	[Para]				[varchar](500)  NOT NULL DEFAULT (''),
	[CC]				[varchar](500)  NOT NULL DEFAULT (''),
	[CuerpoMensaje]		[text]          NOT NULL DEFAULT (''),
	[Firma]				[bit]           NOT NULL DEFAULT (0),
	[SSL]				[bit]           NOT NULL DEFAULT (0),
	[Envio_Automatico]	[bit]           NOT NULL DEFAULT (0),
	[Es_Html]			[bit]           NOT NULL DEFAULT (0),    
 CONSTRAINT [PK_Zw_Correos] PRIMARY KEY CLUSTERED 
(
	[Nombre_Correo] ASC,
	[Remitente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


