USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos_Email_Envios](
	[Id_Email]			[int] IDENTITY(1,1) NOT NULL,
	[Nro_Despacho]		[varchar](10)		NOT NULL Default(''),
	[Estado]			[varchar](3)		NOT NULL Default(''),
	[Fecha_Envio]		[datetime]			NOT NULL Default Getdate(),
	[Enviar]			[bit]				NOT NULL Default(1),
	[Enviado]			[bit]				NOT NULL Default(0),
	[Para]				[varchar](500)		NOT NULL Default(''),
	[Cc]				[varchar](500)		NOT NULL Default(''),
	[Asunto]			[varchar](200)		NOT NULL Default(''),
	[Mensaje]			[text]				NOT NULL Default(''),
	[Doc_Adjuntos]		[varchar](500)		NOT NULL Default(''),
	[Log_Informacion]	[varchar](1000)		NOT NULL Default(''),
 CONSTRAINT [PK_Zw_Despachos_Email_Envios] PRIMARY KEY CLUSTERED 
(
	[Id_Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
