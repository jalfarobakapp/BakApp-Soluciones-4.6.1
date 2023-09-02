USE [#Base#]

CREATE TABLE [dbo].[Zw_St_OT_Recetas_Ope](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Id_Rec]		[int]			NOT NULL DEFAULT (0),
	[Empresa]		[char](2)		NOT NULL DEFAULT (''),
	[CodReceta]		[varchar](20)	NOT NULL DEFAULT (''),
	[Operacion]		[varchar](5)	NOT NULL DEFAULT (''),
	[Orden]			[int]			NOT NULL DEFAULT (0),
	[Cantidad]		[int]			NOT NULL DEFAULT (0),
	[CantMayor1]	[bit]			NOT NULL DEFAULT (0),
	[Externa]		[bit]			NOT NULL DEFAULT (0),
	[TienePrecio]	[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_St_OT_Recetas_Ope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

