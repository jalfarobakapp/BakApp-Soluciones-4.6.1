Declare @Fecha_R1_Desde as Date = '#Fecha_R1_Desde#',
        @Fecha_R1_Hasta as Date = '#Fecha_R1_Hasta#',
        @Fecha_R2_Desde as Date = '#Fecha_R2_Desde#',
        @Fecha_R2_Hasta as Date = '#Fecha_R2_Hasta#',
        @Dias_Habiles_R1 as int = #dias_Habiles_R1#,
        @Dias_Habiles_R2 as int = #dias_Habiles_R2#

CREATE TABLE [dbo].[#TblPaso](
    [_ENDO]      [char](13)    DEFAULT '',
	[_SUENDO]         [varchar](10) DEFAULT '',
	[_RAZON]          [varchar](50) DEFAULT '',
	[Fecha_DR1]       [Date],
	[Fecha_HR1]       [Date],
	[Fecha_DR2]       [Date],
	[Fecha_HR2]       [Date],
	[Rango_1]         [float]       DEFAULT (0),
	[Rango_2]         [float]       DEFAULT (0),
	[Promedio_R1]     [float]       DEFAULT (0),
	[Promedio_R2]     [float]       DEFAULT (0),
	[Expectativa]     [float]       DEFAULT (0),
	[Realidad]        [float]       DEFAULT (0),
	[Diferencia]      [float]       DEFAULT (0),
	[Porc_diferencia] [float]       DEFAULT (0)
	)
	
	--'CONSTRAINT PK_#TablaPaso#_Codigo PRIMARY KEY(ENDO))
--ON [PRIMARY]

Insert Into #TblPaso (_ENDO,_SUENDO,_RAZON)
Select Distinct ENDO,SUENDO,RAZON 
From #Tabla_Paso#
Where 1 > 0
#Filtro#

Update #TblPaso Set Fecha_DR1 = @Fecha_R1_Desde,Fecha_HR1 = @Fecha_R1_Hasta,
                    Fecha_DR2 = @Fecha_R2_Desde,Fecha_HR2 = @Fecha_R2_Hasta

Update #TblPaso Set Rango_1 = Isnull((Select SUM(VANELI) From #Tabla_Paso# Where ENDO = _ENDO And SUENDO = _SUENDO And 
                              FEEMLI between @Fecha_R1_Desde And @Fecha_R1_Hasta #Filtro#),0)
Update #TblPaso Set Rango_2 = Isnull((Select SUM(VANELI) From #Tabla_Paso# Where ENDO = _ENDO And SUENDO = _SUENDO And 
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

Select * From #TblPaso
ORDER BY _ENDO
Drop table #TblPaso


--Select * From #Tabla_Paso# Where FEEMLI between '20170601' And ''

--Select TIDO,NUDO,VANELI, * From #Tabla_Paso# 
--Where ENDO = '76202172' AND FEEMLI between @Fecha_R2_Desde And @Fecha_R2_Hasta

