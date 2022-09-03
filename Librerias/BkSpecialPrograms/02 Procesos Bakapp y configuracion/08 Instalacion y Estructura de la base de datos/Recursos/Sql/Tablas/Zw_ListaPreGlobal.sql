USE [#Base#]


CREATE TABLE [dbo].[Zw_ListaPreGlobal](
	[Tipo] [char](1) NOT NULL DEFAULT (''),
	[Moneda] [char](3) NOT NULL DEFAULT (''),
	[Permiso] [varchar](20) NOT NULL DEFAULT (''),
	[Lista] [char](3) NOT NULL DEFAULT (''),
	[Nombre_Lista] [varchar](50) NOT NULL DEFAULT (''),
	[FormulaPrecio] [varchar](8000) NOT NULL DEFAULT (''),
	[Redondear] [float] NOT NULL DEFAULT (0),
	[FormulaGrabarRD] [varchar](8000) NOT NULL DEFAULT (''),
	[ListaCostoxDefecto] [char](3) NOT NULL DEFAULT (''),
	[TipoValor] [char](1) NOT NULL DEFAULT ('N'),
	[ValoresNetos] [bit] NOT NULL DEFAULT (0),
	[Margen_Ud1] [float] NOT NULL DEFAULT (0),
	[Margen_Ud2] [float] NOT NULL DEFAULT (0),
	[FormulaPrecio2] [varchar](8000) NOT NULL DEFAULT (''),
	[Ej_Fx_documento] [bit] NOT NULL DEFAULT (0),
	[Ej_Fx_documento2] [bit] NOT NULL DEFAULT (0),
	[DsctoMax] [float] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_ListaPreGlobal] PRIMARY KEY CLUSTERED 
(
	[Lista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


