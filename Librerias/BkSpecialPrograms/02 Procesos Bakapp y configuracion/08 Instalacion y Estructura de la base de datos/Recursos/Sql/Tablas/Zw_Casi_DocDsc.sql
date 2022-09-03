USE [#Base#]

CREATE TABLE [dbo].[Zw_Casi_DocDsc](
	[Id_DocDsc] [int] IDENTITY(1,1) NOT NULL,
	[Id_DocEnc] [int]               NOT NULL DEFAULT (0),
	[Nulido]    [varchar](5)        NOT NULL DEFAULT (''),
	[Kodt]      [char](10)          NOT NULL DEFAULT (''),
	[Podt]      [float]             NOT NULL DEFAULT (0),
	[Vadt]      [float]             NOT NULL DEFAULT (0)
) ON [PRIMARY]


