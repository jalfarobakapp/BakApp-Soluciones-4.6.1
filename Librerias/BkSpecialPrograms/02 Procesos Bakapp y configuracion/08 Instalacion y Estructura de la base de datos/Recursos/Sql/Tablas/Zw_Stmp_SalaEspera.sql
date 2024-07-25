USE [#Base#]

CREATE TABLE [dbo].[Zw_Stmp_SalaEspera](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Numero]		[varchar](10)	NOT NULL DEFAULT (''),
	[NroTicket]		[varchar](4)	NOT NULL DEFAULT (''),
	[Tido]			[char](3)		NOT NULL DEFAULT (''),
	[Nudo]			[varchar](10)	NOT NULL DEFAULT (''),
	[TidoGen]		[char](3)		NOT NULL DEFAULT (''),
	[NudoGen]		[varchar](10)	NOT NULL DEFAULT (''),
	[Estado]		[varchar](10)	NOT NULL DEFAULT (''),
	[Sudo]			[char](3)		NOT NULL DEFAULT (''),
	[Nokoen]		[varchar](50)	NOT NULL DEFAULT (''),
	[Estado_Str]	[varchar](50)	NOT NULL DEFAULT (''),
	[InfoCliente]	[varchar](50)	NOT NULL DEFAULT (''),
	[Beep]			[int]			NOT NULL DEFAULT (0)
) ON [PRIMARY]



