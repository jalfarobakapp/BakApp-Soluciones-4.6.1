
Declare 

@Dias_R1         Int = #Dias_R1#,
@Dias_R2         Int = #Dias_R2#,
@Meses_R1        Int = #Meses_R1#,
@Meses_R2        Int = #Meses_R2#,
@Total_R1 Float,
@Total_R2 Float,
@TotalCant_R1 Float,
@Totalcant_R2 Float,

@Dias_Actuales   Int   = #Dias_Actuales#,
@Dias_Faltantes  Int,
@Dias_Total_Mes  Int   = #Dias_Total_Mes#,
@Total_Meta      Float = #Total_Meta#,
@Proyeccion_Meta Float

Set @Dias_Faltantes = @Dias_Total_Mes-@Dias_Actuales

CREATE TABLE [dbo].[#Paso](
    [CODIGO]				[varchar](50)  DEFAULT '',
	[DESCRIPCION]			[varchar](100) DEFAULT '',
	[VND]					[varchar](3)   DEFAULT '',
	[Cant_R1]				[float]        DEFAULT (0),
	[Prom_Diario_R1]		[float]        DEFAULT (0),
	[Prom_R1]				[float]        DEFAULT (0),
	[Porc_R1]				[float]        DEFAULT (0),
	[Cant_R2]				[float]        DEFAULT (0),
	[Prom_Diario_R2]		[float]        DEFAULT (0),
	[Prom_R2]				[float]        DEFAULT (0),
	[Porc_R2]				[float]        DEFAULT (0),
	[PromCant_Diario_R1]    [float]        DEFAULT (0),
	[PromCant_R1]           [float]        DEFAULT (0),
	[PorcCant_R1]           [float]        DEFAULT (0),
	[PromCant_Diario_R2]    [float]        DEFAULT (0),
	[PromCant_R2]           [float]        DEFAULT (0),
	[PorcCant_R2]           [float]        DEFAULT (0),
	[Total_R1]				[float]        DEFAULT (0),
	[Total_R2]				[float]        DEFAULT (0),
	[Expectativa]			[float]        DEFAULT (0),
	[Realidad]				[float]        DEFAULT (0),
	[ExpectativaCant]		[float]        DEFAULT (0),
	[RealidadCant]			[float]        DEFAULT (0),
	[Diferencia_Valor]		[float]        DEFAULT (0),
	[Diferencia_Porc]		[float]        DEFAULT (0)
	)



CREATE TABLE [dbo].[#Paso_Proyeccion](
    [CODIGO]					[varchar](50)  DEFAULT '',
	[DESCRIPCION]				[varchar](100) DEFAULT '',
	[VND]                       [varchar](3)   DEFAULT '',
	[Porc_Prorrogado]           [float]        DEFAULT (0),
	[Total_Venta_RE]            [float]        DEFAULT (0),
	[Prom_Diario_Escogido]      [float]        DEFAULT (0),
	[Total_Venta]               [float]        DEFAULT (0),
	[Proyeccion]                [float]        DEFAULT (0),
	[Total+Proyeccion]          [float]        DEFAULT (0),
	[Proyeccion_Adic_Meta_Emp]  [float]        DEFAULT (0),
	[Saldo_Meta]                [float]        DEFAULT (0),
	[Ventas_Diarias_Para_Meta]  [float]        DEFAULT (0),
	[Total+Proyeccion_Emp]      [float]         DEFAULT (0)
	)       



Insert Into #Paso (CODIGO,DESCRIPCION)
Select #Cp_Codigo# As CODIGO,#Cp_Descripcion# As DESCRIPCION
From #Tabla_Paso#
Where 1 > 0
#_SqlFiltro_Rango_01#
Or 1 > 0
#_SqlFiltro_Rango_02#
Group By #Cp_Codigo#,#Cp_Descripcion#

Update #Paso Set Cant_R1 = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.#Cp_Codigo# = #Paso.CODIGO #_Filtro_Nodos# #_SqlFiltro_Rango_01#),0)
Update #Paso Set Cant_R2 = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.#Cp_Codigo# = #Paso.CODIGO #_Filtro_Nodos# #_SqlFiltro_Rango_02#),0)
Update #Paso Set Total_R1 = Isnull((Select SUM(VANELI) From #Tabla_Paso# Tp Where Tp.#Cp_Codigo# = #Paso.CODIGO #_Filtro_Nodos# #_SqlFiltro_Rango_01#),0)
Update #Paso Set Total_R2 = Isnull((Select SUM(VANELI) From #Tabla_Paso# Tp Where Tp.#Cp_Codigo# = #Paso.CODIGO #_Filtro_Nodos# #_SqlFiltro_Rango_02#),0)

Update #Paso Set DESCRIPCION = '???' Where DESCRIPCION = ''
Update #Paso Set VND = Isnull((Select KOFUEN From MAEEN Where CODIGO = KOEN+SUEN),'???')


Select SUM(Cant_R1) as Cant_R1,SUM(Cant_R2) as Cant_R2,SUM(Total_R1) as Total_R1,SUM(Total_R2) as Total_R2
Into #Paso_Total
From #Paso

Set @Total_R1 = (Select Total_R1 From #Paso_Total)
Set @Total_R2 = (Select Total_R2 From #Paso_Total)
Set @TotalCant_R1 = (Select Cant_R1 From #Paso_Total)
Set @Totalcant_R2 = (Select Cant_R2 From #Paso_Total)

Update #Paso Set Prom_Diario_R1 = Case When @Dias_R1 > 0 Then Isnull(Total_R1/@Dias_R1,0) Else 0 End,
                 Prom_Diario_R2 = Case When @Dias_R2 > 0 Then Isnull(Total_R2/@Dias_R2,0) Else 0 End, 
                 Prom_R1 = Case When @Meses_R1 > 0 Then Isnull(Total_R1/@Meses_R1,0) Else 0 End,
                 Prom_R2 = Case When @Meses_R2 > 0 Then Isnull(Total_R2/@Meses_R2,0) Else 0 End,
                 Porc_R1 = Case When @Total_R1 > 0 Then Isnull((Round(Total_R1/@Total_R1,4)),0) Else 0 End,
                 Porc_R2 = Case When @Total_R2 > 0 Then Isnull((Round(Total_R2/@Total_R2,4)),0) Else 0 End
                 
Update #Paso Set Expectativa = Case When @Dias_R2 > 0 Then Prom_Diario_R1*@Dias_R2 Else 0 End,
                 Realidad = Prom_Diario_R2 * @Dias_R2 


Update #Paso Set PromCant_Diario_R1 = Case When @Dias_R1 > 0 Then Isnull(Cant_R1/@Dias_R1,0) Else 0 End,
                 PromCant_Diario_R2 = Case When @Dias_R2 > 0 Then Isnull(Cant_R2/@Dias_R2,0) Else 0 End, 
                 PromCant_R1 = Case When @Meses_R1 > 0 Then Isnull(Cant_R1/@Meses_R1,0) Else 0 End,
                 PromCant_R2 = Case When @Meses_R2 > 0 Then Isnull(Cant_R2/@Meses_R2,0) Else 0 End,
                 PorcCant_R1 = Case When @Total_R1 > 0 Then Isnull((Round(Cant_R1/@TotalCant_R1,4)),0) Else 0 End,
                 PorcCant_R2 = Case When @Total_R2 > 0 Then Isnull((Round(Cant_R2/@Totalcant_R2,4)),0) Else 0 End

Update #Paso Set ExpectativaCant = Case When @Dias_R2 > 0 Then Round(PromCant_Diario_R1*@Dias_R2,0) Else 0 End,
                 RealidadCant = Round(PromCant_Diario_R2 * @Dias_R2,0) 


Insert Into #Paso_Proyeccion (CODIGO,DESCRIPCION,Porc_Prorrogado,Total_Venta_RE,Prom_Diario_Escogido,Total_Venta)
Select CODIGO,DESCRIPCION,#Porc_R1#,Total_R1,ROUND(#Prom_Diario_Escogido#,0),Total_R2
From #Paso

--Update #Paso_Proyeccion Set Total_Venta = Prom_Diario_Escogido*@Dias_Actuales
Update #Paso_Proyeccion Set Proyeccion  = Prom_Diario_Escogido*@Dias_Faltantes
Update #Paso_Proyeccion Set [Total+Proyeccion] = Total_Venta+Proyeccion

Update #Paso_Proyeccion Set DESCRIPCION = '???' Where DESCRIPCION = ''
Update #Paso_Proyeccion Set VND = Isnull((Select KOFUEN From MAEEN Where CODIGO = KOEN+SUEN),'???')


IF @Total_Meta = 0
Begin
Set @Total_Meta = (Select SUM([Total+Proyeccion]) From #Paso_Proyeccion)
End

Set @Proyeccion_Meta = @Total_Meta - (Select SUM(Isnull(Total_Venta,0))+SUM(Isnull(Proyeccion,0)) From #Paso_Proyeccion)

Update #Paso_Proyeccion Set [Proyeccion_Adic_Meta_Emp] = ROUND( @Proyeccion_Meta * Porc_Prorrogado,0)
Update #Paso_Proyeccion Set Saldo_Meta = [Proyeccion_Adic_Meta_Emp]+Proyeccion

Update #Paso_Proyeccion Set [Ventas_Diarias_Para_Meta] = Saldo_Meta/@Dias_Faltantes
Update #Paso_Proyeccion Set [Total+Proyeccion_Emp] = [Proyeccion_Adic_Meta_Emp]+[Total+Proyeccion]


--Select SUM(Isnull(Total_Venta,0))+SUM(Isnull(Proyeccion,0)) From #Paso_Proyeccion

Select * From #Paso
Where 1 > 0
#Chk_Mayor_Cero#
Order By CODIGO

Select * From #Paso_Total
Where 1 > 0

Select * From #Paso_Proyeccion
Where 1 > 0
Order By CODIGO

Select SUM([Total+Proyeccion]) As [Total+Proyeccion],CAST(0 As Float) As Porc_Proyeccion,
       CAST(0 As Float) As Proyeccion_Meta,CAST(0 As Float) As Total_Meta  
From #Paso_Proyeccion

Select CODIGO,DESCRIPCION,VND,Expectativa,Realidad From #Paso
Where 1 > 0
#Chk_Mayor_Cero#
Order By CODIGO


--CONSULTA PARA QUE MUESTRE LOS CLIENTES QUE ESTAN EN EL RANGO 1, PERO NO ESTAN EN EL RANGO 2

Select Distinct ENDO,SUENDO Into #PasoEndo1 
From Zw_Informe_Venta 
Where 1 > 0
#_SqlFiltro_Rango_01#

Select Distinct ENDO,SUENDO Into #PasoEndo2 
From Zw_Informe_Venta 
Where 1 > 0
#_SqlFiltro_Rango_02#

Delete #PasoEndo1
From #PasoEndo1 P1 
Inner Join #PasoEndo2 P2 On P1.ENDO = P2.ENDO And P1.SUENDO = P2.SUENDO

Select KOEN As 'Codigo',SUEN As 'Suc',NOKOEN As 'RazonSocial',
	   (Select Max(FEEMDO) From Zw_Informe_Venta Inf Where TIDO In ('FCV','BLV') #_SqlFiltro_Fecha_Rango_01# And Inf.ENDO = KOEN And Inf.SUENDO = SUEN) As 'Fecha_Ult_Vnta'
From MAEEN Where KOEN+SUEN In 
(Select Distinct ENDO+SUENDO From #PasoEndo1)


--CONSULTA PARA QUE MUESTRE LOS PRODUCTOS QUE ESTAN EN EL RANGO 1, PERO NO ESTAN EN EL RANGO 2

Select Distinct KOPRCT Into #PasoKopr1 
From Zw_Informe_Venta 
Where 1 > 0
And TIPR = 'FPN'
#_SqlFiltro_Rango_01#


Select Distinct KOPRCT Into #PasoKopr2 
From Zw_Informe_Venta 
Where 1 > 0
And TIPR = 'FPN'
#_SqlFiltro_Rango_02#

Delete #PasoKopr1
From #PasoKopr1 P1 
Inner Join #PasoKopr2 P2 On P1.KOPRCT = P2.KOPRCT

Select KOPR,NOKOPR,
	   (Select Max(FEEMDO) From Zw_Informe_Venta Inf Where TIDO In ('FCV','BLV') #_SqlFiltro_Fecha_Rango_01#  And Inf.KOPRCT = KOPR) As 'Fecha_Ult_Vnta'
From MAEPR Where KOPR In 
(Select KOPRCT From #PasoKopr1)


Drop table #Paso
Drop table #Paso_Proyeccion
Drop table #Paso_Total
Drop Table #PasoEndo1
Drop Table #PasoEndo2
Drop Table #PasoKopr1
Drop Table #PasoKopr2