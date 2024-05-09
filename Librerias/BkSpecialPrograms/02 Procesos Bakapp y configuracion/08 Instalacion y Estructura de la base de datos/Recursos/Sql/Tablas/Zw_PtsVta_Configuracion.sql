USE [#Base#]

CREATE TABLE [dbo].[Zw_PtsVta_Configuracion](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Empresa]			[char](2)		NOT NULL DEFAULT (''),
	[GCadaPesos]		[float]			NOT NULL DEFAULT (0),
	[GEquivPuntos]		[float]			NOT NULL DEFAULT (0),
	[RCadaPuntos]		[float]			NOT NULL DEFAULT (0),
	[REquivPesos]		[float]			NOT NULL DEFAULT (0),
	[MinPtosCanjear]	[float]			NOT NULL DEFAULT (0),
	[ValMinPedCajear]	[float]			NOT NULL DEFAULT (0),
	[Concepto]			[varchar](13)	NOT NULL DEFAULT (''),
	[Activo]			[bit]			NOT NULL DEFAULT (0)
) ON [PRIMARY]

