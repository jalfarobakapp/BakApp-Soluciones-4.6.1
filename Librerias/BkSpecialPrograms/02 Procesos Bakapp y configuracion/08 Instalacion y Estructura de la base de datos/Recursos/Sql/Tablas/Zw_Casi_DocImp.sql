USE [#Base#]

CREATE TABLE [dbo].[Zw_Casi_DocImp](
	[Id_DocImp] [int]         NOT NULL DEFAULT (0),
	[Id_DocEnc] [int]         NOT NULL DEFAULT (0),
	[Nulido]    [varchar](5)  NOT NULL DEFAULT (''),
	[Koimli]    [varchar](13) NOT NULL DEFAULT (''),
	[Poimli]    [float]       NOT NULL DEFAULT (0),
	[Vaimli]    [float]       NOT NULL DEFAULT (0),
	[Lilg]      [varchar](2)  NOT NULL DEFAULT ('')
) ON [PRIMARY]

