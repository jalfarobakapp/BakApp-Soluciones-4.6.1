USE [#Base#]

CREATE TABLE [dbo].[Zw_Pago_Prov_Autoriza_02_Det_Eli](
	[Id_Autoriza]   [int]           NOT NULL DEFAULT (0),
	[Idmaeedo]      [int]           NOT NULL DEFAULT (0),
	[Idmaeven]      [int]           NOT NULL DEFAULT (0),
	[Saldo]         [float]         NOT NULL DEFAULT (''),
	[Observacion]   [varchar](200)  NOT NULL DEFAULT (''),
) ON [PRIMARY]
