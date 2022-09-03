USE [#Base#]


CREATE TABLE [dbo].[ZW_SOC_Log](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Id_SOC]			[int]			NULL,
	[Nro_SOC]			[char](10)		NOT NULL DEFAULT (''),
	[Fecha]				[datetime]		NULL,
	[hora]				[datetime]		NULL,
	[CodFuncionario]	[char](3)		NOT NULL DEFAULT (''),
	[Accion]			[varchar](1000) NOT NULL DEFAULT (''),
	[Accion_Etapa]		[int]			NOT NULL DEFAULT (1)
) ON [PRIMARY]


