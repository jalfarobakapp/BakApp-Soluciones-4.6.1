USE [#Base#]

CREATE TABLE [dbo].[Zw_DTE_NotifxCorreo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Dte]		        [int]          NOT NULL DEFAULT (0),
	[Idmaeedo]		        [int]          NOT NULL DEFAULT (0),
	[FechaEnvio]	        [datetime]     NULL DEFAULT (''),
	[Destinatarios]         [varchar](500) NOT NULL DEFAULT (''),
    [AmbienteCertificacion]	[bit]          NOT NULL DEFAULT (0),
    [Id_Trackid]            [int]          NOT NULL DEFAULT (0),
) ON [PRIMARY]