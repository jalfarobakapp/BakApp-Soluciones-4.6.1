USE [#Base#]


CREATE TABLE [dbo].[Zw_TmpInv_InvParcial](
	[Semilla]				[int] IDENTITY(1,1) NOT NULL,
	[Empresa]				[char](2)		NOT NULL DEFAULT (''),
	[Sucursal]				[char](3)		NOT NULL DEFAULT (''),
	[Bodega]				[char](3)		NOT NULL DEFAULT (''),
	[CodigoPr]				[varchar](13)	NOT NULL DEFAULT (''),
	[FechaInv]				[datetime]		NOT NULL,
	[HoraInv]				[datetime]		NOT NULL,
	[Levantado]				[bit]			NOT NULL DEFAULT (0),
	[CodBarras]				[varchar](20)	NOT NULL DEFAULT (''),
	[Descripcion]			[varchar](50)	NOT NULL DEFAULT (''),
	[Rtu]					[float]			NOT NULL DEFAULT (0),
	[CantidadUd1]			[float]			NOT NULL DEFAULT (0),
	[CantidadUd2]			[float]			NOT NULL DEFAULT (0),
	[CostoUnitUd1]			[float]			NOT NULL DEFAULT (0),
	[CostoUnitUd2]			[float]			NOT NULL DEFAULT (0),
	[TotalCostoUd1]			[float]			NOT NULL DEFAULT (0),
	[TotalCostoUd2]			[float]			NOT NULL DEFAULT (0),
	[StockActual]			[float]			NOT NULL DEFAULT (0),
	[ConsolidStockUd1]		[float]			NOT NULL DEFAULT (0),
	[ConsolidStockUd2]		[float]			NOT NULL DEFAULT (0),
	[DejaStockCero]			[bit]			NOT NULL DEFAULT (0),
	[GDI_Idmaeedo_Aj]		[int]			NOT NULL DEFAULT (0),
	[Nro_GDI_Stock_Cero]	[varchar](20)	NOT NULL DEFAULT (''),
	[GRI_Idmaeedo_Aj]		[int]			NOT NULL DEFAULT (0),
	[Nro_GRI_Stock_Cero]	[varchar](20)	NOT NULL DEFAULT (''),
	[IDMAEEDO_Aj]			[int]			NOT NULL DEFAULT (0),
	[Nro_GRI_Ajuste_Stock]	[varchar](20)	NOT NULL DEFAULT (''),
	[Foto_Stock_Ud1]		[float]			NOT NULL DEFAULT (0),
	[Foto_Stock_Ud2]		[float]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_TmpInv_InvParcial] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Sucursal] ASC,
	[Bodega] ASC,
	[CodigoPr] ASC,
	[FechaInv] ASC,
	[HoraInv] ASC,
	[Levantado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
