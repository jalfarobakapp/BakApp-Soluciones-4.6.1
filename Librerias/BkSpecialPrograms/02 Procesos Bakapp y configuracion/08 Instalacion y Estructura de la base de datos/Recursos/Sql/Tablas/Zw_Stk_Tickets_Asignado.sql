USE [#Base#]

CREATE TABLE [dbo].[Zw_Stk_Tickets_Asignado](
	[Id]			[int]			IDENTITY(1,1) NOT NULL,
	[Id_Ticket]		[int]			NOT NULL DEFAULT (0),
	[CodAgente]		[varchar](3)	NOT NULL DEFAULT (''),
	[Activo]		[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Stk_Tickets_Asignado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



