CREATE TABLE [dbo].[#TablaPaso#](
    [Codigo]                    [Char](13)     DEFAULT '',
    [Comprar]                   [Bit]          DEFAULT (0),
    [Comprar_Igual]             [Bit]          DEFAULT (0),
    [Es_Agrupador]              [Bit]          DEFAULT (0),
	[Codigo_Nodo]               [Int]	       DEFAULT (0),
	[Codigo_Nodo_Madre]         [VarChar](20)  DEFAULT '',
	[Es_Reemplazo]              [Bit]          DEFAULT (0),
	[CodAlternativo]            [VarChar](30)  DEFAULT '',
	[CodProveedor]              [Char](13)     DEFAULT '',
	[CodSucProveedor]           [Char](10)     DEFAULT '',
	[Descripcion]               [VarChar](50)  DEFAULT '',
	[Descripcion_Madre]         [VarChar](500) DEFAULT '',
	[UD1]                       [Char](2)      DEFAULT '',
	[UD2]                       [Char](2)      DEFAULT '',
	[Rtu]                       [Float]        DEFAULT (0),
	[Iva]                       [Float]        DEFAULT (0),
	[Ila]                       [Float]        DEFAULT (0),

	[Stock_Fisico_Ud1]          [Float]        DEFAULT (0),
	[Stock_Fisico_Ud2]          [Float]        DEFAULT (0),
	[StockUd1]                  [Float]        DEFAULT (0),
	[StockUd2]                  [Float]        DEFAULT (0),
    [Stock_Devengado_Ud1]       [Float]        DEFAULT (0),
	[Stock_Devengado_Ud2]       [Float]        DEFAULT (0),
    [Stock_Fisico_Ud1_Negativo] [Bit]          DEFAULT (0),
    [Stock_Fisico_Ud2_Negativo] [Bit]          DEFAULT (0),
    [StockPedidoUd1]            [Float]        DEFAULT (0),
	[StockPedidoUd2]            [Float]        DEFAULT (0),
    [StockPedidoNVIUd1]         [Float]        DEFAULT (0),
	[StockPedidoNVIUd2]         [Float]        DEFAULT (0),
    [StockTransitoUd1]          [Float]        DEFAULT (0),
    [StockTransitoUd2]          [Float]        DEFAULT (0),
    [StockEnTransitoUd1]        [Float]        DEFAULT (0),
    [StockEnTransitoUd2]        [Float]        DEFAULT (0),

	[StockFacSinRecepUd1]       [Float]        DEFAULT (0),
	[StockFacSinRecepUd2]       [Float]        DEFAULT (0),

	[Stock_Fisico_Ud1_Prod]     [Float]        DEFAULT (0),
	[Stock_Fisico_Ud2_Prod]     [Float]        DEFAULT (0),
	[StockUd1_Prod]             [Float]        DEFAULT (0),
	[StockUd2_Prod]             [Float]        DEFAULT (0),
    [Stock_Devengado_Ud1_Prod]  [Float]        DEFAULT (0),
	[Stock_Devengado_Ud2_Prod]  [Float]        DEFAULT (0),
	[StockPedidoUd1_Prod]       [Float]        DEFAULT (0),
	[StockPedidoUd2_Prod]       [Float]        DEFAULT (0),
    [StockPedidoNVIUd1_Prod]    [Float]        DEFAULT (0),
    [StockPedidoNVIUd2_Prod]    [Float]        DEFAULT (0),
    [StockTransitoUd1_Prod]     [Float]        DEFAULT (0),
    [StockTransitoUd2_Prod]     [Float]        DEFAULT (0),

    [StockEnTransitoUd1_Prod]   [Float]        DEFAULT (0),
    [StockEnTransitoUd2_Prod]   [Float]        DEFAULT (0),
	
    [StockFacSinRecepUd1_Prod]  [Float]        DEFAULT (0),
	[StockFacSinRecepUd2_Prod]  [Float]        DEFAULT (0),

	[Ranking_Top]               [Int]          DEFAULT (0),
	[Clasificacion_Rk]          [VarChar](20)  DEFAULT '', 
	[Star]                      [Int]          DEFAULT (0),
	[Marca]                     [VarChar](20)  DEFAULT '',
	[Rubro]                     [VarChar](20)  DEFAULT '',
	[ClasificacionLibre]        [VarChar](20)  DEFAULT '',
	[Zona]                      [VarChar](20)  DEFAULT '',
	[SuperFamilia]              [VarChar](20)  DEFAULT '',
	[Familia]                   [VarChar](20)  DEFAULT '',
	[SubFamilia]                [VarChar](20)  DEFAULT '',
	[Nom_Marca]                 [VarChar](50)  DEFAULT '',
	[Nom_Rubro]                 [VarChar](50)  DEFAULT '',
	[Nom_ClasificacionLibre]    [VarChar](50)  DEFAULT '',
	[Nom_Zona]                  [VarChar](50)  DEFAULT '',
	[Nom_SuperFamilia]          [VarChar](50)  DEFAULT '',
	[Nom_Familia]               [VarChar](50)  DEFAULT '',
	[Nom_SubFamilia]            [VarChar](50)  DEFAULT '',
	[Tiempo_Reposicion]         [Float]        DEFAULT (0),
	[Stock_CriticoUd1_Rd]       [Float]        DEFAULT (0),
	[Stock_CriticoUd2_Rd]       [Float]        DEFAULT (0),
	[Stock_SeguridadUd1_Rd]     [Float]        DEFAULT (0),
	[Stock_SeguridadUd2_Rd]     [Float]        DEFAULT (0),
	[Con_Stock_CriticoUd1]      [Bit]          DEFAULT (0),
	[Con_Stock_CriticoUd2]      [Bit]          DEFAULT (0),
	[Stock_ProyectadoUd1_Rd]    [Float]        DEFAULT (0),
	[Stock_ProyectadoUd2_Rd]    [Float]        DEFAULT (0),
	[TStock]                    [Float]        DEFAULT (0),
	[CantComprar]               [Float]        DEFAULT (0),
	[CantComprarOri]            [Float]        DEFAULT (0),
	[DiasdeAvas_Rd]             [Float]        DEFAULT (0),
	[MesesAvas_Rd]              [Float]        DEFAULT (0),
	[Dias_Avastecer]            [Float]        DEFAULT (0),
	[Porc_Crecimiento]          [Float]        DEFAULT (0),
	[CantSugeridaTot]           [Float]        DEFAULT (0),

	[RotDiariaUd1]              [Float]        DEFAULT (0),
	[RotDiariaUd2]              [Float]        DEFAULT (0),
	
    [RotMensualUd1]             [Float]        DEFAULT (0),
	[RotMensualUd2]             [Float]        DEFAULT (0),
	
    [RotDiariaUd1_Prod]         [Float]        DEFAULT (0),
	[RotDiariaUd2_Prod]         [Float]        DEFAULT (0),
	
    [RotMensualUd1_Prod]        [Float]        DEFAULT (0),
	[RotMensualUd2_Prod]        [Float]        DEFAULT (0),

	[SumTotalQtyUd1]            [Float]        DEFAULT (0),
	[SumTotalQtyUd2]            [Float]        DEFAULT (0),

	[SumTotalQtyUd1_Ult_3Mes]   [Float]        DEFAULT (0),
	[SumTotalQtyUd2_Ult_3Mes]   [Float]        DEFAULT (0),

    [SumTotalQtyUd1_Ult_3Cio]   [Float]        DEFAULT (0),
	[SumTotalQtyUd2_Ult_3Cio]   [Float]        DEFAULT (0),

	[Promedio_Ud1]              [Float]        DEFAULT (0),
	[Promedio_Ud2]              [Float]        DEFAULT (0),

    [Promedio_MensualUd1]       [Float]        DEFAULT (0),
	[Promedio_MensualUd2]       [Float]        DEFAULT (0),

    [Promedio_Ud1_Prod]         [Float]        DEFAULT (0),
	[Promedio_Ud2_Prod]         [Float]        DEFAULT (0),

    [Promedio_MensualUd1_Prod]  [Float]        DEFAULT (0),
	[Promedio_MensualUd2_Prod]  [Float]        DEFAULT (0),

    [Prom_Ult_Ud1_Ult_3Mes]     [Float]        DEFAULT (0),
	[Prom_Ult_Ud2_Ult_3Mes]     [Float]        DEFAULT (0),

    [TipoRotCalculo]            [Varchar](20)   DEFAULT '',
    [RotCalculo]                [Float]        DEFAULT (0),

	[Tendencia]				    [Float]        DEFAULT (0),
	[SumTotalVal]               [Float]        DEFAULT (0),
	[Fecha_Inicio]              [Date],
	[Fecha_Fin]                 [Date],
	[Dias_Vida_Habiles]         [Float]        DEFAULT (0),
	[Dias_Vida_Sabados]         [Float]        DEFAULT (0),
	[Dias_Vida_Domingos]        [Float]        DEFAULT (0),
	[Dias_Vida_Total]           [Float]        DEFAULT (0),
	[FCV]                       [Float]        DEFAULT (0),
	[BLV]                       [Float]        DEFAULT (0),
	[GDV]                       [Float]        DEFAULT (0),
	[NCV]                       [Float]        DEFAULT (0),
    [GDIodt]                    [Float]        DEFAULT (0),
    [GRIodt]                    [Float]        DEFAULT (0),
	[TDV]                       [Float]        DEFAULT (0),
	[FCV_Ult_Year]              [Float]        DEFAULT (0),
	[BLV_Ult_Year]              [Float]        DEFAULT (0),
	[GDV_Ult_Year]              [Float]        DEFAULT (0),
	[NCV_Ult_Year]              [Float]        DEFAULT (0),
	[GDIodt_Ult_Year]           [Float]        DEFAULT (0),
	[GRIodt_Ult_Year]           [Float]        DEFAULT (0),
	[TDV_Ult_Year]              [Float]        DEFAULT (0),
	[OccGenerada]               [Bit]          DEFAULT (0),
	[Bloqueapr]                 [Char](1)      DEFAULT '',
	[Oculto]                    [VarChar](10)  DEFAULT '',
	[IdOCC]                     [VarChar](20)  DEFAULT '',
	[IdGRC]                     [VarChar](20)  DEFAULT '',
	[IdGDD]                     [VarChar](20)  DEFAULT '',
	[Id_Ult_Compra]             [Int]          DEFAULT (0),
	[Endo_Utl_Compra]           [Char](13)     DEFAULT '',
	[Suendo_Utl_Compra]         [Char](10)     DEFAULT '',
	[Costo_Ult_Compra_RealUd1]  [Float]        DEFAULT (0),
	[Costo_Ult_Compra_RealUd2]  [Float]        DEFAULT (0),
	[Costo_Ult_Compra]          [Float]        DEFAULT (0),
	[Dscto_Ult_Compra]          [Float]        DEFAULT (0),
	[Fecha_Ult_Compra]          [Date],
	[Udtpr_Ult_Compra]          [Int]          DEFAULT (0),
    [Costo_PPP]                 [Float]        DEFAULT (0),
    [Costo_UltComUd1]           [Float]        DEFAULT (0),
    [Costo_UltComUd2]           [Float]        DEFAULT (0),
    [Costo_Ud1Lista_Neto]       [Float]        DEFAULT (0),
    [Costo_Ud2Lista_Neto]       [Float]        DEFAULT (0),
    [Costo_Ud1Lista_Bruto]      [Float]        DEFAULT (0),
    [Costo_Ud2Lista_Bruto]      [Float]        DEFAULT (0),
    [Costo_Flete]               [Float]        DEFAULT (0),
    [Costo_FleteNeto]           [Float]        DEFAULT (0),
    [PorcDifCostoNetUd1]        [Float]        DEFAULT (0),
    [PorcDifCostoBruUd1]        [Float]        DEFAULT (0),
    --#Campos_Descuentos#
    [Porc_Descuento]            [Float]        DEFAULT (0),
	[Orden]                     [Int]          DEFAULT (0),
	[Dias_Venta_Efectivos]      [Float]        DEFAULT (0),
	[Fecha_Ult_Venta]           [Date],
	[Dias_Existencia_Habiles]   [Float]        DEFAULT (0),
	[Dias_Existencia_Sabados]   [Float]        DEFAULT (0),
	[Dias_Existencia_Domingos]  [Float]        DEFAULT (0),
	[Refleo]                    [Bit]          DEFAULT (0),
	[Advierte_Rotacion]         [Bit]          DEFAULT (0),
	[Sospecha_Baja_Rotacion]    [Bit]          DEFAULT (0),
	[Informacion_Fila]          [VarChar](500) DEFAULT '',
	[Fecha_Ultima_Ejecucion]    [Date],
	[Sospecha_Familia]          [Int]          DEFAULT (0),
    [Porc_CumpUlt3Pedidos]      [Float]        DEFAULT (0),
    [StockUd1BodStar]           [Float]        DEFAULT (0),
    [StockUd2BodStar]           [Float]        DEFAULT (0),
    [ProductoExcluido]          [Bit]          DEFAULT (0),
    [NoComprarProvNoTiene]      [Bit]          DEFAULT (0),
    [UdCompra]                  [Int]          DEFAULT (0),
    [MultiploCompra]            [Float]        DEFAULT (0),
    [CantComprarMinXProv]       [Float]        DEFAULT (0),
	CONSTRAInt [PK_Zw_#TablaPaso#_Codigo] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC,
	[Comprar] ASC,
	[Es_Agrupador] ASC,
	[Codigo_Nodo_Madre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

