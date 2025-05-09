USE [#Base#]


CREATE TABLE [dbo].[Zw_Demonio_Conf_Correo](
	[Id]						[int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]				[varchar](50)	NOT NULL DEFAULT (''),
	[Id_Padre]					[int]			NOT NULL DEFAULT (0),
	[EnviarCorreo]				[bit]			NOT NULL DEFAULT (0),
	[Nombre_ConfCorreo]			[varchar](50)	NOT NULL DEFAULT (''),
	[Id_Correo]					[int]			NOT NULL DEFAULT (0),
	[Nombre_Correo]				[varchar](100)	NOT NULL DEFAULT (''),
	[Enviar_Remitente]			[bit]			NOT NULL DEFAULT (0),
	[MailRemitente]				[varchar](200)	NOT NULL DEFAULT (''),
	[Enviar_VendedorCliente]	[bit]			NOT NULL DEFAULT (0),
	[Enviar_VendedorLinea]		[bit]			NOT NULL DEFAULT (0),
	[Enviar_ResponsableDoc]		[bit]			NOT NULL DEFAULT (0),
	[Enviar_EntidadDoc]			[bit]			NOT NULL DEFAULT (0),
	[CC_Remitente]				[bit]			NOT NULL DEFAULT (0),
	[MailCC]					[varchar](200)	NOT NULL DEFAULT (''),
	[CC_VendedorCliente]		[bit]			NOT NULL DEFAULT (0),
	[CC_VendedorLinea]			[bit]			NOT NULL DEFAULT (0),
	[CC_ResponsableDoc]			[bit]			NOT NULL DEFAULT (0),
	[CC_EntidadDoc]				[bit]			NOT NULL DEFAULT (0),
	[EnvioAnticipacion]			[bit]			NOT NULL DEFAULT (0),
	[DiasEnvioAnticipacion]		[int]			NOT NULL DEFAULT (0),
) ON [PRIMARY]
