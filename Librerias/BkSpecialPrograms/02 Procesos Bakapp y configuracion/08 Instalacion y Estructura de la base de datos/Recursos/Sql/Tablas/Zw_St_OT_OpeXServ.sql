USE [#Base#]

CREATE TABLE [dbo].[Zw_St_OT_OpeXServ](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Id_Ot]					[int]			NOT NULL DEFAULT (0),
	[Semilla]				[int]			NOT NULL DEFAULT (0),
	[Codigo]				[varchar](13)	NOT NULL DEFAULT (''),
	[CodReceta]				[varchar](20)	NOT NULL DEFAULT (''),
	[Operacion]				[varchar](5)	NOT NULL DEFAULT (''),
	[Orden]					[int]			NOT NULL DEFAULT (0),
	[CantMayor1]			[bit]			NOT NULL DEFAULT (0),
	[Cantidad]				[int]			NOT NULL DEFAULT (0),
	[CantidadRealizada]		[int]			NOT NULL DEFAULT (0),
	[Precio]				[float]			NOT NULL DEFAULT (0),
	[Total]					[float]			NOT NULL DEFAULT (0),
	[Realizado]				[bit]			NOT NULL DEFAULT (0),
	[Externa]				[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_St_OT_OpeXServ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
