USE [#Base#]

CREATE TABLE [dbo].[Zw_CrucePAuto_Tom](
	[CodFuncionario]	[varchar](3)    NOT NULL DEFAULT (''),
	[FechaToma]			[datetime]      NULL,
	[NombreEquipo]		[varchar](50)   NOT NULL DEFAULT ('')
) ON [PRIMARY]


