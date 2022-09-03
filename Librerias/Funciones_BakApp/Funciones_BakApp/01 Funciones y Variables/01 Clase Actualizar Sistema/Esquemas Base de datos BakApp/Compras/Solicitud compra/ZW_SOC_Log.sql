USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[ZW_SOC_Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_SOC]         [int] NULL,
	[Nro_SOC]        [char](10)      NULL DEFAULT (''),
	[Fecha]          [datetime]      NULL DEFAULT (''),
	[hora]           [time](7)       NULL DEFAULT (''),
	[CodFuncionario] [char](3)       NULL DEFAULT (''),
	[Accion]         [varchar](1000) NULL DEFAULT (''),
	[Accion_Etapa]   [int]           NOT NULL DEFAULT (1)
) ON [PRIMARY]

	