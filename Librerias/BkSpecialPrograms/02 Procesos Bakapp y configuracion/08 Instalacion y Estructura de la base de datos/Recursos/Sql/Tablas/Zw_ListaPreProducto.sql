USE [#Base#]


CREATE TABLE [dbo].[Zw_ListaPreProducto](
	[Lista] [char](3) NOT NULL DEFAULT (''),
	[Codigo] [char](13) NOT NULL DEFAULT (''),
	[Formula] [varchar](1000) NOT NULL DEFAULT (''),
	[Redondear] [float] NOT NULL DEFAULT (0),
	[Costo] [float] NOT NULL DEFAULT (0),
	[Precio] [float] NOT NULL DEFAULT (0),
	[Margen] [float] NOT NULL DEFAULT (0),
	[Margen_Adicional] [float] NOT NULL DEFAULT (0),
	[Costo2] [float] NOT NULL DEFAULT (0),
	[Precio2] [float] NOT NULL DEFAULT (0),
	[Margen2] [float] NOT NULL DEFAULT (0),
	[Margen_Adicional2] [float] NOT NULL DEFAULT (0),
	[DsctoMax] [float] NOT NULL DEFAULT (0),
	[Dscto1] [float] NOT NULL DEFAULT (0),
	[Dscto2] [float] NOT NULL DEFAULT (0),
	[Dscto3] [float] NOT NULL DEFAULT (0),
	[Dscto4] [float] NOT NULL DEFAULT (0),
	[Dscto5] [float] NOT NULL DEFAULT (0),
	[Flete] [float] NOT NULL DEFAULT (0),
	[Rtu] [float] NOT NULL DEFAULT (0),
	[Ud1] [char](2) NOT NULL DEFAULT (''),
	[Ud2] [char](2) NOT NULL DEFAULT (''),
	[Formula2] [varchar](1000) NOT NULL DEFAULT (''),
	[Ej_Fx_documento] [bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_ListaPreProducto] PRIMARY KEY CLUSTERED 
(
	[Lista] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
