USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos_MiniCompXProd](
	[Empresa]				[char](2)		NOT NULL DEFAULT (''),
	[Codigo]				[varchar](13)	NOT NULL DEFAULT (''),
	[Valor_Min_Despacho]	[float]			NOT NULL DEFAULT (0),
	[Peso_Min_Despacho]	    [float]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Despachos_MiniCompXProd] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
