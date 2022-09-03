USE [#Base#]


CREATE TABLE [dbo].[Zw_Reclamo_Estados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Reclamo] [int] NOT NULL  DEFAULT (0),
	[Estado] [char](3) NOT NULL  DEFAULT (''),
	[CodFuncionario] [varchar](3) NOT NULL  DEFAULT (''),
	[Observacion] [text] NOT NULL  DEFAULT (''),
	[Fecha_Fijacion] [datetime] NOT NULL  DEFAULT (Getdate()),
	[Mail_Enviado] [bit] NOT NULL  DEFAULT (0),
	[Mail_Fecha_Envio] [datetime] NULL,
	[Mail_Para] [varchar](500) NOT NULL  DEFAULT (''),
	[Mail_CC] [varchar](500) NOT NULL  DEFAULT (''),
	[Mail_Error] [varchar](1000) NOT NULL  DEFAULT (''),
	[CodReceptor] [char](3) NOT NULL  DEFAULT (''),
	[Idmaeedo] [int] NOT NULL  DEFAULT (0),
	[Tido] [char](3) NOT NULL  DEFAULT (''),
	[Nudo] [varchar](10) NOT NULL  DEFAULT (''),
	[Fecha_recepcion] [datetime] NULL,
 CONSTRAINT [PK_Zw_Reclamo_Estados] PRIMARY KEY CLUSTERED 
(
	[Id_Reclamo] ASC,
	[Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
