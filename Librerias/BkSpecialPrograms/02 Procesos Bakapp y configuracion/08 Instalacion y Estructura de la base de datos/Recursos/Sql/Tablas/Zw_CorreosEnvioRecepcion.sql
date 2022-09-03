USE [#Base#]


CREATE TABLE [dbo].[Zw_CorreosEnvioRecepcion](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Remitente]		[varchar](100) NOT NULL DEFAULT (''),
	[Para]			[varchar](100) NOT NULL DEFAULT (''),
	[CC]			[varchar](200) NOT NULL DEFAULT (''),
	[Fecha]			[datetime] NULL,
	[Hora]			[datetime] NULL,
	[Idmaeedo]		[varchar](20) NOT NULL DEFAULT (''),
	[Estado]		[char](1) NOT NULL DEFAULT (''),
	[Asunto]		[varchar](300) NOT NULL DEFAULT (''),
	[Mensaje]		[text] NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_CorreosEnvioRecepcion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


