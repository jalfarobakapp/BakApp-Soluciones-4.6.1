USE [#Base#]


CREATE TABLE [dbo].[Zw_Stk_Tickets_Acciones](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Id_Ticket]			[int]               NOT NULL DEFAULT (0),
	[Accion]			[varchar](4)        NOT NULL DEFAULT (''),
	[Descripcion]		[varchar](max)      NOT NULL DEFAULT (''),
	[Fecha]				[datetime]          NULL,
	[CodFuncionario]	[varchar](3)        NOT NULL DEFAULT (''),
	[CodAgente]			[varchar](3)        NOT NULL DEFAULT (''),
	[En_Construccion]	[bit]               NOT NULL DEFAULT (0),
	[Visto]				[bit]               NOT NULL DEFAULT (0),
	[Cierra_Ticket]		[bit]               NOT NULL DEFAULT (0),
	[Solicita_Cierre]	[bit]               NOT NULL DEFAULT (0),
	[CreaNewTicket]		[bit]               NOT NULL DEFAULT (0),
	[AnulaTicket]		[bit]               NOT NULL DEFAULT (0),
	[CodFunGestiona]	[varchar](3)        NOT NULL DEFAULT (''),
    [Rechazado]			[bit]               NOT NULL DEFAULT (0),
    [Aceptado]			[bit]               NOT NULL DEFAULT (0),
    [Id_Raiz]			[int]               NOT NULL DEFAULT (0),
    [Id_Ticket_Cierra]  [int]               NOT NULL DEFAULT (0),
    [Asunto]			[varchar](50)       NOT NULL DEFAULT (''),
    [Tido_Cierra]		[varchar](3)        NOT NULL DEFAULT (''),
    [Nudo_Cierra]		[varchar](10)       NOT NULL DEFAULT (''),
    [Idmaeedo_Cierra]   [int]               NOT NULL DEFAULT (0),
    [ConfSinDoc_Cierra] [bit]               NOT NULL DEFAULT (0),
    [Motivo_Cierra]     [varchar](20)       NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Stk_Tickets_Acciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

