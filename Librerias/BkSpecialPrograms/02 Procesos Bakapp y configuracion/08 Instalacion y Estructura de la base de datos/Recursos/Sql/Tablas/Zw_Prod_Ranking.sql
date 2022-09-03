USE [#Base#]


CREATE TABLE [dbo].[Zw_Prod_Ranking](
	[Codigo] [varchar](13) NOT NULL DEFAULT (''),
	[Descripcion] [varchar](50) NOT NULL DEFAULT (''),
	[Puntos_Rk] [float] NOT NULL DEFAULT (0),
	[Ranking_Top] [int] NOT NULL DEFAULT (0),
	[Rk_Presencia] [int] NOT NULL DEFAULT (0),
	[Rk_Cantidad] [int] NOT NULL DEFAULT (0),
	[Rk_Precio] [int] NOT NULL DEFAULT (0),
	[Rk_Margen] [int] NOT NULL DEFAULT (0),
	[Bv] [float] NOT NULL DEFAULT (0),
	[Fv] [float] NOT NULL DEFAULT (0),
	[Gv] [float] NOT NULL DEFAULT (0),
	[Nc] [float] NOT NULL DEFAULT (0),
	[Otro] [float] NOT NULL DEFAULT (0),
	[Presencia] [float] NOT NULL DEFAULT (0),
	[Top_Ranking] [char](1) NOT NULL DEFAULT (''),
	[Top_Presencia] [char](1) NOT NULL DEFAULT (''),
	[Top_Cantidad] [char](1) NOT NULL DEFAULT (''),
	[Top_Precio] [char](1) NOT NULL DEFAULT (''),
	[Top_Margen] [char](1) NOT NULL DEFAULT (''),
	[Cod_Clas] [varchar](20) NOT NULL DEFAULT (''),
	[Clasificacion] [varchar](50) NOT NULL DEFAULT (''),
	[Pc_Ranking] [numeric](8, 3) NOT NULL DEFAULT (''),
	[Pc_Presencia] [numeric](8, 3) NOT NULL DEFAULT (''),
	[Pc_Cantidad] [numeric](8, 3) NOT NULL DEFAULT (''),
	[Pc_Precio] [numeric](8, 3) NOT NULL DEFAULT (''),
	[Pc_Margen] [numeric](8, 3) NOT NULL DEFAULT (''),
	[TotalCosto] [float] NOT NULL DEFAULT (0),
	[TotalPrecio] [float] NOT NULL DEFAULT (0),
	[TotalCantid] [float] NOT NULL DEFAULT (0),
	[Total_Mrg] [float] NOT NULL DEFAULT (0),
	[Porc_Markup] [float] NOT NULL DEFAULT (0),
	[Porc_Margen] [float] NOT NULL DEFAULT (0),
	[Star] [int] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Prod_Ranking] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


