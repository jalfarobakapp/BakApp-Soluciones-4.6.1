USE [#Base#]


CREATE TABLE [dbo].[Zw_St_OT_DetProd](
	[Id_Ot] [int] NOT NULL DEFAULT (0),
	[Semilla] [int] IDENTITY(1,1) NOT NULL,
	[Utilizado] [bit] NOT NULL DEFAULT (0),
	[Codigo] [varchar](13) NOT NULL DEFAULT (''),
	[Descripcion] [varchar](50) NOT NULL DEFAULT (''),
	[Cantidad] [float] NOT NULL DEFAULT (0),
	[Cantidad_Utilizada] [float] NOT NULL DEFAULT (0),
	[Ud] [char](2) NOT NULL DEFAULT (''),
	[Un] [int] NOT NULL DEFAULT (0),
	[CantUd1] [float] NOT NULL DEFAULT (0),
	[CantUd2] [float] NOT NULL DEFAULT (0),
	[Precio] [float] NOT NULL DEFAULT (0),
	[Neto_Linea] [float] NOT NULL DEFAULT (0),
	[Iva_Linea] [float] NOT NULL DEFAULT (0),
	[Total_Linea] [float] NOT NULL DEFAULT (0),
	[Desde_COV] [bit] NOT NULL DEFAULT (0),
	[Idmaeedo_Cov] [int] NOT NULL DEFAULT (0),
	[Idmaeddo_Cov] [int] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_St_OT_DetProd] PRIMARY KEY CLUSTERED 
(
	[Semilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

