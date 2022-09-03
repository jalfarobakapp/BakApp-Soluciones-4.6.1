USE [#Base#]


CREATE TABLE [dbo].[Zw_Pdc_MesonVsOperario](
	[Codigoob]          [char](8)        NOT NULL DEFAULT (''),
	[Nombreob]          [varchar](30)    NOT NULL DEFAULT (''),
	[Codmeson]          [char](13)       NOT NULL DEFAULT (''),
	[Fecha_Hora_Asig]   [datetime]       NOT NULL DEFAULT (Getdate()),
    [Por_Defecto]       [bit]            NOT NULL DEFAULT (0),
) ON [PRIMARY]



