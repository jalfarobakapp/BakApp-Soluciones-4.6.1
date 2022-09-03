USE [#Base#]


CREATE TABLE [dbo].[Zw_Notificaciones](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Empresa]				[char](2)		NOT NULL DEFAULT (''),
	[Usuario_Destino]		[varchar](3)	NOT NULL DEFAULT (''),
	[Usuario_Solicita]		[varchar](3)	NOT NULL DEFAULT (''),
	[Fecha]					[datetime] NULL,
	[Hora]					[datetime] NULL,
	[Titulo]				[varchar](200)	NOT NULL DEFAULT (''),
	[Texto]					[varchar](1000) NOT NULL DEFAULT (''),
	[Icono]					[int]			NOT NULL DEFAULT (0),
	[Accion]				[varchar](20)	NOT NULL DEFAULT (''),
	[NroRemota]				[varchar](10)	NOT NULL DEFAULT (''),
	[Leido]					[int]			NOT NULL DEFAULT (0),
	[Cerrado]				[int]			NOT NULL DEFAULT (0),
	[Mostrar]				[bit]			NOT NULL DEFAULT (1),
	[Solicita_Confirmacion] [bit]			NOT NULL DEFAULT (0),
	[IdRespuesta]			[int]			NOT NULL DEFAULT (0),
	[Log_Notificacion]		[varchar](1000) NOT NULL DEFAULT (''),
	[Autorizado]			[bit]			NOT NULL DEFAULT (0),
	[Rechazado]				[bit]			NOT NULL DEFAULT (0),
	[RCadena_Id_Enc]		[int]			NOT NULL DEFAULT (0),
	[Id_Soc]				[int]			NOT NULL DEFAULT (0),
	[Id_SCom]				[int]			NOT NULL DEFAULT (0),
    [No_Volver_A_Notificar] [bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Notificaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

