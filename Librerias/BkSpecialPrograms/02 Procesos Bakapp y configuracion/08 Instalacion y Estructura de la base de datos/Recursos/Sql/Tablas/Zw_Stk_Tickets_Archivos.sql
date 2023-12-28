USE [#Base#]

CREATE TABLE [dbo].[Zw_Stk_Tickets_Archivos](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Id_Ticket]			[int]			NOT NULL DEFAULT (0),
	[Id_TicketAc]		[int]			NOT NULL DEFAULT (0),
	[Nombre_Archivo]	[varchar](200)	NOT NULL DEFAULT (''),
	[Archivo]			[image]			NULL,
	[Fecha]				[datetime]		NOT NULL,
	[CodFuncionario]	[char](3)		NOT NULL DEFAULT (''),
	[En_Construccion]	[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Stk_Tickets_Archivos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



