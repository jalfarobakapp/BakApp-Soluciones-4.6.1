USE [#Base#]

CREATE TABLE [dbo].[Zw_ListaPreCosto](
	[Id]				    [int] IDENTITY(1,1) NOT NULL,
	[Lista]				    [char](3)		NOT NULL DEFAULT (''),
	[Proveedor]			    [varchar](13)	NOT NULL DEFAULT (''),
	[Sucursal]			    [varchar](10)	NOT NULL DEFAULT (''),
	[CodAlternativo]	    [varchar](20)	NOT NULL DEFAULT (''),
	[Codigo]			    [varchar](13)	NOT NULL DEFAULT (''),
	[Descripcion]		    [varchar](50)	NOT NULL DEFAULT (''),
	[Descripcion_Alt]	    [varchar](100)	NOT NULL DEFAULT (''),
	[CostoUd1]			    [float]			NOT NULL DEFAULT (0),
	[CostoUd2]			    [float]			NOT NULL DEFAULT (0),
	[Rtu]				    [float]			NOT NULL DEFAULT (0),
	[FechaVigencia]		    [datetime]		NULL,
	[Desc1]				    [float]			NOT NULL DEFAULT (0),
	[Desc2]				    [float]			NOT NULL DEFAULT (0),
	[Desc3]				    [float]			NOT NULL DEFAULT (0),
	[Desc4]				    [float]			NOT NULL DEFAULT (0),
	[Desc5]				    [float]			NOT NULL DEFAULT (0),
	[DescSuma]			    [float]			NOT NULL DEFAULT (0),
	[Flete]				    [float]			NOT NULL DEFAULT (0),
	[Un_Compra]			    [char](2)		NOT NULL DEFAULT (''),
	[Un_MinCompra]		    [int]			NOT NULL DEFAULT (1),
	[Ac_Oferta]			    [bit]			NOT NULL DEFAULT (0),
	[Ac_Disponible]		    [bit]			NOT NULL DEFAULT (1),
	[Ac_Cotizar]		    [bit]			NOT NULL DEFAULT (0),
	[No_Usar]			    [bit]			NOT NULL DEFAULT (0),
    [Id_Padre]              [int]           NOT NULL DEFAULT (0),
	[CodFuncionario_Edita]  [varchar](3)    NOT NULL DEFAULT (''),
	[FechaEdita]            [datetime]      NULL
 CONSTRAINT [PK_Zw_ListaPreCosto] PRIMARY KEY CLUSTERED 
(
	[Lista] ASC,
	[Proveedor] ASC,
	[CodAlternativo] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



