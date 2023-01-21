USE [#Base#]


CREATE TABLE [dbo].[Zw_Demonio_Doc_Emitidos_Aviso_Correo](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]			[varchar](50)       NOT NULL DEFAULT (''),
	[Nombre_Correo]			[varchar](50)       NOT NULL DEFAULT (''),
	[CodFuncionario]		[char](3)           NOT NULL DEFAULT (''),
	[Asunto]				[varchar](200)      NOT NULL DEFAULT (''),
	[Para]					[varchar](500)      NOT NULL DEFAULT (''),
	[Cc]					[varchar](500)      NOT NULL DEFAULT (''),
	[Idmaeedo]				[int]               NOT NULL DEFAULT (0),
	[Tido]					[varchar](50)       NOT NULL DEFAULT (''),
	[Nudo]					[varchar](10)       NOT NULL DEFAULT (''),
	[NombreFormato]			[varchar](50)       NOT NULL DEFAULT (''),
	[Enviar]				[bit]               NOT NULL DEFAULT (0),
	[Intentos]				[int]               NOT NULL DEFAULT (0),
	[Enviado]				[bit]               NOT NULL DEFAULT (0),
	[Adjuntar_Documento]	[bit]               NOT NULL DEFAULT (0),
	[Mensaje]				[text]              NOT NULL DEFAULT (''),
	[Fecha]					[datetime]          NOT NULL DEFAULT (CONVERT([datetime],floor(CONVERT([float],getdate(),0)),0)),
	[Fecha_Envio]			[datetime]          NULL,
	[Informacion]			[varchar](1000)     NOT NULL DEFAULT (''),
	[Para_Maeenmail]		[bit]               NOT NULL DEFAULT (0),
	[Id_Correo]				[int]               NOT NULL DEFAULT (0),
	[Doc_Adjuntos]			[varchar](500)      NOT NULL DEFAULT (''),
    [Adjuntar_DTE]  		[bit]               NOT NULL DEFAULT (0),
	[Id_Dte]				[int]               NOT NULL DEFAULT (0),
	[Id_Trackid]			[int]               NOT NULL DEFAULT (0),
	[Id_Acp]    			[int]               NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Demonio_Doc_Emitidos_Aviso_Correo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

