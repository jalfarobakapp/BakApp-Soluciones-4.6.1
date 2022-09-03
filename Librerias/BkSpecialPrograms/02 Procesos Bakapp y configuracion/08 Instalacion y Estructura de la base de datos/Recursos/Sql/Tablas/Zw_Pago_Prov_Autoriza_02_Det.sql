USE [#Base#]

CREATE TABLE [dbo].[Zw_Pago_Prov_Autoriza_02_Det](
	[Id_Autoriza]           [int]           NOT NULL DEFAULT (0),
	[Idmaeedo]              [int]           NOT NULL DEFAULT (0),
	[Idmaeven]              [int]           NOT NULL DEFAULT (0),
	[Revisado]              [bit]           NOT NULL DEFAULT (0),
	[Sospecha_Stock]        [bit]           NOT NULL DEFAULT (0),
	[Sospecha_Devolucion]   [bit]           NOT NULL DEFAULT (0),
	[Autorizado]            [bit]           NOT NULL DEFAULT (0),
	[Funcionario_Autoriza]  [varchar](3)    NOT NULL DEFAULT (''),
	[Saldo]                 [float]         NOT NULL DEFAULT (0),
	[Pagado]                [bit]           NOT NULL DEFAULT (0),
	[Idmaedpce]             [int]           NOT NULL DEFAULT (0),
	[Tidp]                  [varchar](3)    NOT NULL DEFAULT (''),
	[Nudp]                  [varchar](10)   NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Pago_Prov_Autoriza_02_Det] PRIMARY KEY CLUSTERED 
(
	[Idmaeedo] ASC,
	[Idmaeven] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



