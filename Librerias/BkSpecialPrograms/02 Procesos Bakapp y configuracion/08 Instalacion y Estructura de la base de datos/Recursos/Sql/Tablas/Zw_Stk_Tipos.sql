USE [#Base#]


CREATE TABLE [dbo].[Zw_Stk_Tipos](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Id_Area]			[int]			NOT NULL DEFAULT (0),
	[Tipo]				[varchar](50)	NOT NULL DEFAULT (''),
	[ExigeProducto]		[bit]			NOT NULL DEFAULT (0),
	[RevInventario]		[bit]			NOT NULL DEFAULT (0),
	[AjusInventario]	[bit]			NOT NULL DEFAULT (0),
	[SobreStock]		[bit]			NOT NULL DEFAULT (0),
	[Asignado]			[bit]			NOT NULL DEFAULT (0),
	[AsignadoGrupo]		[bit]			NOT NULL DEFAULT (0),
	[AsignadoAgente]	[bit]			NOT NULL DEFAULT (0),
	[Id_Grupo]			[int]			NOT NULL DEFAULT (0),
	[CodAgente]			[varchar](3)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Stk_Tipos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

