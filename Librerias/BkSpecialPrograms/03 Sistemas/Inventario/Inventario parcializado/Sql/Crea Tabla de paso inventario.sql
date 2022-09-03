Declare @Fecha Date = '#Fecha#'

CREATE TABLE [dbo].[#Zw_TmpInv_#](
	[Semilla]          [int] NOT NULL,
	[Empresa]          [char](2) NOT NULL DEFAULT '',
	[Sucursal]         [char](3) NOT NULL DEFAULT '',
	[Bodega]           [char](3) NOT NULL DEFAULT '',
	[CodigoPr]         [varchar](13) NOT NULL DEFAULT '',
	[CodBarras]        [varchar](20) DEFAULT '',
	[Descripcion]      [varchar](50) NOT NULL DEFAULT '',
	[Rtu]              [float] NOT NULL DEFAULT (0),
	[CantidadUd1]      [float] NOT NULL DEFAULT (0),
	[CantidadUd2]      [float] NOT NULL DEFAULT (0),
	[CostoUnitUd1]     [float] NOT NULL DEFAULT (0),
	[CostoUnitUd2]     [float] NOT NULL DEFAULT (0),
	[TotalCostoUd1]    [float] NOT NULL DEFAULT (0),
	[TotalCostoUd2]    [float] NOT NULL DEFAULT (0),
	[StockActual]      [float] NOT NULL DEFAULT (0),
	[FechaInv]         [date] NOT NULL,
	[HoraInv]          [time](7) NOT NULL,
	[ConsolidStockUd1] [float] NOT NULL DEFAULT (0),
	[ConsolidStockUd2] [float] NOT NULL DEFAULT (0),
	[IDMAEEDO]         [int] NULL,
	[Levantado]        [bit] NOT NULL DEFAULT (0),
	[DejaStockCero]    [bit] NOT NULL DEFAULT (0),
	[GRI_Idmaeedo]     [varchar](20) DEFAULT '',
	[GDI_Idmaeedo]     [varchar](20) DEFAULT '',
) ON [PRIMARY]


Insert Into #Zw_TmpInv_# 
                       (Empresa, Sucursal, Bodega, CodigoPr, CodBarras, Descripcion, Rtu, 
                       CantidadUd1, CantidadUd2, CostoUnitUd1, CostoUnitUd2, TotalCostoUd1, 
                       TotalCostoUd2, StockActual, FechaInv,  
                       ConsolidStockUd1, ConsolidStockUd2, GRI_Idmaeedo,GDI_Idmaeedo, 
                       Levantado, Semilla, DejaStockCero)
                Select Empresa, Sucursal, Bodega, CodigoPr, CodBarras, Descripcion, Rtu, 
                       CantidadUd1, CantidadUd2, CostoUnitUd1, CostoUnitUd2, TotalCostoUd1, 
                       TotalCostoUd2, StockActual, FechaInv,  
                       ConsolidStockUd1, ConsolidStockUd2, GRI_Idmaeedo,GDI_Idmaeedo, 
                       Levantado, Semilla, DejaStockCero 
                       FROM Zw_TmpInv_InvParcial 
                       Where FechaInv = @Fecha 
                       And Levantado = 0 