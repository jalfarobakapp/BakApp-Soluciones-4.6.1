

Declare @Fecha_R1_Desde as Date = '#Fecha_R1_Desde#',
        @Fecha_R1_Hasta as Date = '#Fecha_R1_Hasta#',
        @Fecha_R2_Desde as Date = '#Fecha_R2_Desde#',
        @Fecha_R2_Hasta as Date = '#Fecha_R2_Hasta#',
        @Dias_Habiles_R1 as int = #dias_Habiles_R1#,
        @Dias_Habiles_R2 as int = #dias_Habiles_R2#,
        @Empresa as varchar(2)  = '#Empresa#',
        @Sucursal as varchar(3) = '#Sucursal#',
        @Bodega as varchar(3)   = '#Bodega#'

CREATE TABLE [dbo].[#TblPaso](
    [CODIGO]            [char](13)    DEFAULT '',
	[COD]               [varchar](10) DEFAULT '',
	[DESCRIPCION]       [varchar](50) DEFAULT '',
	[Vendidos]          [bit]         DEFAULT (0),
	[Fecha_DR1]         [Date],
	[Fecha_HR1]         [Date],
	[Fecha_DR2]         [Date],
	[Fecha_HR2]         [Date],
	[Cant_Rango_1]      [float]       DEFAULT (0),
	[Cant_Rango_2]      [float]       DEFAULT (0),
	[Cant_Promedio_R1]  [float]       DEFAULT (0),
	[Cant_Promedio_R2]  [float]       DEFAULT (0),
	[Cant_Expectativa]  [float]       DEFAULT (0),
	[Cant_Realidad]     [float]       DEFAULT (0),
	--[Diferencia]      [float]       DEFAULT (0),
	--[Porc_diferencia] [float]       DEFAULT (0)
	[Rango_1]           [float]       DEFAULT (0),
	[Rango_2]           [float]       DEFAULT (0),
	[Promedio_R1]       [float]       DEFAULT (0),
	[Promedio_R2]       [float]       DEFAULT (0),
	[Expectativa]       [float]       DEFAULT (0),
	[Realidad]          [float]       DEFAULT (0),
	[Diferencia]        [float]       DEFAULT (0),
	[Porc_diferencia]   [float]       DEFAULT (0),
	[StockUd1]          [float]       DEFAULT (0),
	[StockUd2]          [float]       DEFAULT (0),
	[StockComprUd1]     [float]       DEFAULT (0),
	[StockComprUd2]     [float]       DEFAULT (0),
	[StockTeoriUd1]     [float]       DEFAULT (0),
	[StockTeoriUd2]     [float]       DEFAULT (0)
	)
	
--'CONSTRAINT PK_#TablaPaso#_Codigo PRIMARY KEY(ENDO))
--ON [PRIMARY]

Insert Into #TblPaso (CODIGO)
Select Distinct KOPRCT
From #Nombre_Tabla_Paso#
Where 1 > 0
#Filtro#


Update #TblPaso Set DESCRIPCION = Isnull((Select Top 1 NOKOPR From MAEPR Where KOPR = CODIGO),'?????')

Update #TblPaso Set Fecha_DR1 = @Fecha_R1_Desde,Fecha_HR1 = @Fecha_R1_Hasta,
                    Fecha_DR2 = @Fecha_R2_Desde,Fecha_HR2 = @Fecha_R2_Hasta

-- CANTIDADES

Update #TblPaso Set Fecha_DR1 = @Fecha_R1_Desde,Fecha_HR1 = @Fecha_R1_Hasta,
                    Fecha_DR2 = @Fecha_R2_Desde,Fecha_HR2 = @Fecha_R2_Hasta

Update #TblPaso Set Cant_Rango_1 = Isnull((Select SUM(CAPRCO1) From #Nombre_Tabla_Paso# Where CODIGO = KOPRCT And COD = '' And 
                                   FEEMLI between @Fecha_R1_Desde And @Fecha_R1_Hasta #Filtro#),0)

Update #TblPaso Set Cant_Rango_2 = Isnull((Select SUM(CAPRCO1) From #Nombre_Tabla_Paso# Where CODIGO = KOPRCT And COD = '' And 
                                   FEEMLI between @Fecha_R2_Desde And @Fecha_R2_Hasta #Filtro#),0)

Update #TblPaso Set Cant_Promedio_R1 = ROUND( Cant_Rango_1/@Dias_Habiles_R1,5)
Update #TblPaso Set Cant_Promedio_R2 = ROUND( Cant_Rango_2/@Dias_Habiles_R2,5)

Update #TblPaso Set Cant_Expectativa = ROUND( Cant_Promedio_R1*@Dias_Habiles_R2,0)
Update #TblPaso Set Cant_Realidad = ROUND(Cant_Rango_2,0)



-- VALORES

Update #TblPaso Set Rango_1 = Isnull((Select SUM(VANELI) From #Nombre_Tabla_Paso# Where CODIGO = KOPRCT And COD = '' And 
                              FEEMLI between @Fecha_R1_Desde And @Fecha_R1_Hasta #Filtro#),0)
Update #TblPaso Set Rango_2 = Isnull((Select SUM(VANELI) From #Nombre_Tabla_Paso# Where CODIGO = KOPRCT And COD = '' And 
                              FEEMLI between @Fecha_R2_Desde And @Fecha_R2_Hasta #Filtro#),0)

Update #TblPaso Set Promedio_R1 = ROUND( Rango_1/@Dias_Habiles_R1,0)
Update #TblPaso Set Promedio_R2 = ROUND( Rango_2/@Dias_Habiles_R2,0)

Update #TblPaso Set Expectativa = Promedio_R1*@Dias_Habiles_R2
Update #TblPaso Set Realidad = Rango_2

Update #TblPaso Set Diferencia = Realidad-Expectativa


Update #TblPaso Set Porc_diferencia = ROUND( Diferencia/Expectativa,5)
Where Diferencia > 0 And Expectativa <> 0

Update #TblPaso Set Porc_diferencia = ROUND( Diferencia/Realidad,5)
Where Diferencia < 0 And Realidad <> 0

Update #TblPaso Set Porc_diferencia = -1 Where Porc_diferencia = 0 And Diferencia < 0
Update #TblPaso Set Porc_diferencia = 1 Where Porc_diferencia = 0 And Diferencia > 0

Update #TblPaso Set StockUd1 = (Select SUM(STFI1) From MAEST 
                                Where EMPRESA = @Empresa And KOSU = @Sucursal And KOBO = @Bodega And KOPR = CODIGO)
Update #TblPaso Set StockUd2 = (Select SUM(STFI2) From MAEST 
                                Where EMPRESA = @Empresa And KOSU = @Sucursal And KOBO = @Bodega And KOPR = CODIGO)

Update #TblPaso Set StockComprUd1 = (Select SUM(STOCNV1) From MAEST 
                                     Where EMPRESA = @Empresa And KOSU = @Sucursal And KOBO = @Bodega And KOPR = CODIGO)
Update #TblPaso Set StockComprUd1 = (Select SUM(STOCNV2) From MAEST 
                                     Where EMPRESA = @Empresa And KOSU = @Sucursal And KOBO = @Bodega And KOPR = CODIGO)


Update #TblPaso Set StockTeoriUd1 = StockUd1 - StockComprUd1
Update #TblPaso Set StockTeoriUd2 = StockUd2 - StockComprUd2

Update #TblPaso Set Vendidos = 1
Where Cant_Rango_1 > 0 Or Cant_Rango_2 > 0

Select * From #TblPaso
Where 1 > 0
And Vendidos = 1 

ORDER BY CODIGO
Drop table #TblPaso


--Select * From #Nombre_Tabla_Paso# Where FEEMLI between '20170601' And ''

--Select TIDO,NUDO,VANELI, * From #Nombre_Tabla_Paso# 
--Where ENDO = '76202172' AND FEEMLI between @Fecha_R2_Desde And @Fecha_R2_Hasta

