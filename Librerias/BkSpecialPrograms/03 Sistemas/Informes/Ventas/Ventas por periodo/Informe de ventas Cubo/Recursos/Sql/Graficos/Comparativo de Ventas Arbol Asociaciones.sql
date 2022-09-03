
Declare 

@Dias_R1         Int = #Dias_R1#,
@Dias_R2         Int = #Dias_R2#,
@Meses_R1        Int = #Meses_R1#,
@Meses_R2        Int = #Meses_R2#,
@Total_R1 Float,
@Total_R2 Float,

@Dias_Actuales   Int   = #Dias_Actuales#,
@Dias_Faltantes  Int,
@Dias_Total_Mes  Int   = #Dias_Total_Mes#,
@Total_Meta      Float = #Total_Meta#,
@Proyeccion_Meta Float,
@Codigo_Nodo     Int   = #Codigo_Nodo#

Set @Dias_Faltantes = @Dias_Total_Mes-@Dias_Actuales

CREATE TABLE [dbo].[#Paso](
    [CODIGO]            [varchar](50)  DEFAULT '',
	--[COD]             [varchar](10)  DEFAULT '',
	[DESCRIPCION]       [varchar](100) DEFAULT '',
	[VND]               [varchar](3)   DEFAULT '',
	[Cant_R1]           [float]        DEFAULT (0),
	[Prom_Diario_R1]    [float]        DEFAULT (0),
	[Prom_R1]           [float]        DEFAULT (0),
	[Porc_R1]           [float]        DEFAULT (0),
	[Cant_R2]           [float]        DEFAULT (0),
	[Prom_Diario_R2]    [float]        DEFAULT (0),
	[Prom_R2]           [float]        DEFAULT (0),
	[Porc_R2]           [float]        DEFAULT (0),
	[Total_R1]          [float]        DEFAULT (0),
	[Total_R2]          [float]        DEFAULT (0),
	[Expectativa]       [float]        DEFAULT (0),
	[Realidad]          [float]        DEFAULT (0),
	[Diferencia_Valor]  [float]        DEFAULT (0),
	[Diferencia_Porc]   [float]        DEFAULT (0)
	)


CREATE TABLE [dbo].[#Paso_Proyeccion](
    [CODIGO]                    [varchar](50)  DEFAULT '',
	--[COD]                     [varchar](10)  DEFAULT '',
	[DESCRIPCION]               [varchar](100) DEFAULT '',
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
	[Total+Proyeccion_Emp]      [float]        DEFAULT (0)
	)       


Insert Into #Paso (CODIGO,DESCRIPCION)
Select Distinct Codigo_Nodo As CODIGO,Descripcion As DESCRIPCION
FROM #Zw_TblArbol_Asociaciones#
Where 1 > 0
And Identificacdor_NodoPadre = @Codigo_Nodo And Clas_Unica_X_Producto = 1
Order By DESCRIPCION

/*--Filtro_Sin_Clasificacion#
Insert Into #Paso (CODIGO,DESCRIPCION) Values (-1,'Sin Clasificación')
Insert Into #Paso (CODIGO,DESCRIPCION) Values (-2,'Prod. Desconocidos')
*/--Filtro_Sin_Clasificacion#

Update #Paso Set Cant_R1  = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.KOPRCT In (Select Codigo From #Zw_Prod_Asociacion# Where Codigo_Nodo = CODIGO) #_Filtro_Nodos# #_SqlFiltro_Rango_01#),0)
Update #Paso Set Cant_R2  = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.KOPRCT In (Select Codigo From #Zw_Prod_Asociacion# Where Codigo_Nodo = CODIGO) #_Filtro_Nodos# #_SqlFiltro_Rango_02#),0)
Update #Paso Set Total_R1 = Isnull((Select SUM(VANELI) From #Tabla_Paso# Tp Where Tp.KOPRCT In (Select Codigo From #Zw_Prod_Asociacion# Where Codigo_Nodo = CODIGO) #_Filtro_Nodos# #_SqlFiltro_Rango_01#),0)
Update #Paso Set Total_R2 = Isnull((Select SUM(VANELI) From #Tabla_Paso# Tp Where Tp.KOPRCT In (Select Codigo From #Zw_Prod_Asociacion# Where Codigo_Nodo = CODIGO) #_Filtro_Nodos# #_SqlFiltro_Rango_02#),0)

--Isnull((Select Sum(VANELI) From Zw_TblPasoMAF Where KOPRCT In (Select Codigo From BAKAPP_SG.dbo.Zw_Prod_Asociacion Where Codigo_Nodo = CODIGO)

/*--Filtro_Sin_Clasificacion#
Update #Paso Set Cant_R1  = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.KOPRCT In (Select KOPR From MAEPR Where KOPR Not In (Select Distinct Codigo From #Zw_Prod_Asociacion# Where Producto = 0)) #_SqlFiltro_Rango_01#),0) Where CODIGO = -1  
Update #Paso Set Cant_R2  = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.KOPRCT In (Select KOPR From MAEPR Where KOPR Not In (Select Distinct Codigo From #Zw_Prod_Asociacion# Where Producto = 0)) #_SqlFiltro_Rango_02#),0) Where CODIGO = -1  
Update #Paso Set Total_R1 = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.KOPRCT In (Select KOPR From MAEPR Where KOPR Not In (Select Distinct Codigo From #Zw_Prod_Asociacion# Where Producto = 0)) #_SqlFiltro_Rango_01#),0) Where CODIGO = -1  
Update #Paso Set Total_R2 = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.KOPRCT In (Select KOPR From MAEPR Where KOPR Not In (Select Distinct Codigo From #Zw_Prod_Asociacion# Where Producto = 0)) #_SqlFiltro_Rango_02#),0) Where CODIGO = -1  

Update #Paso Set Cant_R1  = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.KOPRCT Not In (Select KOPR From MAEPR) #_SqlFiltro_Rango_01#),0) Where CODIGO = -2  
Update #Paso Set Cant_R2  = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.KOPRCT Not In (Select KOPR From MAEPR) #_SqlFiltro_Rango_01#),0) Where CODIGO = -2  
Update #Paso Set Total_R1 = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.KOPRCT Not In (Select KOPR From MAEPR) #_SqlFiltro_Rango_01#),0) Where CODIGO = -2  
Update #Paso Set Total_R2 = Isnull((Select SUM(CAPRCO1) From #Tabla_Paso# Tp Where Tp.KOPRCT Not In (Select KOPR From MAEPR) #_SqlFiltro_Rango_01#),0) Where CODIGO = -2  
*/--Filtro_Sin_Clasificacion#

Update #Paso Set DESCRIPCION = '???' Where DESCRIPCION = ''
Update #Paso Set VND = Isnull((Select KOFUEN From MAEEN Where CODIGO = KOEN+SUEN),'???')

Select SUM(Cant_R1) as Cant_R1,SUM(Cant_R2) as Cant_R2,SUM(Total_R1) as Total_R1,SUM(Total_R2) as Total_R2
Into #Paso_Total
From #Paso

Set @Total_R1 = (Select Total_R1 From #Paso_Total)
Set @Total_R2 = (Select Total_R2 From #Paso_Total)

Update #Paso Set Prom_Diario_R1 = Case When @Dias_R1 > 0 Then Isnull(Total_R1/@Dias_R1,0) Else 0 End,
                 Prom_Diario_R2 = Case When @Dias_R2 > 0 Then Isnull(Total_R2/@Dias_R2,0) Else 0 End, 
                 Prom_R1 = Case When @Meses_R1 > 0 Then Isnull(Total_R1/@Meses_R1,0) Else 0 End,
                 Prom_R2 = Case When @Meses_R2 > 0 Then Isnull(Total_R2/@Meses_R2,0) Else 0 End,
                 Porc_R1 = Case When @Total_R1 > 0 Then Isnull((Round(Total_R1/@Total_R1,4)),0) Else 0 End,
                 Porc_R2 = Case When @Total_R2 > 0 Then Isnull((Round(Total_R2/@Total_R2,4)),0) Else 0 End
                 
Update #Paso Set Expectativa = Case When @Dias_R2 > 0 Then Prom_Diario_R1*@Dias_R2 Else 0 End,
                 Realidad = Prom_Diario_R2 * @Dias_R2 


Insert Into #Paso_Proyeccion (CODIGO,DESCRIPCION,Porc_Prorrogado,Total_Venta_RE,Prom_Diario_Escogido,Total_Venta)
Select CODIGO,DESCRIPCION,#Porc_R1#,Total_R1,ROUND(#Prom_Diario_Escogido#,0),Total_R2
From #Paso

--Update #Paso_Proyeccion Set Total_Venta = Prom_Diario_Escogido*@Dias_Actuales
Update #Paso_Proyeccion Set Proyeccion  = Prom_Diario_Escogido*@Dias_Faltantes
Update #Paso_Proyeccion Set [Total+Proyeccion] = Total_Venta+Proyeccion

IF @Total_Meta = 0
Begin
Set @Total_Meta = (Select SUM([Total+Proyeccion]) From #Paso_Proyeccion)
End

Set @Proyeccion_Meta = @Total_Meta - (Select SUM(Isnull(Total_Venta,0))+SUM(Isnull(Proyeccion,0)) From #Paso_Proyeccion)

Update #Paso_Proyeccion Set [Proyeccion_Adic_Meta_Emp] = ROUND( @Proyeccion_Meta * Porc_Prorrogado,0)
Update #Paso_Proyeccion Set Saldo_Meta = [Proyeccion_Adic_Meta_Emp]+Proyeccion

Update #Paso_Proyeccion Set [Ventas_Diarias_Para_Meta] = Saldo_Meta/@Dias_Faltantes
Update #Paso_Proyeccion Set [Total+Proyeccion_Emp] = [Proyeccion_Adic_Meta_Emp]+[Total+Proyeccion]

Update #Paso_Proyeccion Set DESCRIPCION = '???' Where DESCRIPCION = ''
Update #Paso_Proyeccion Set VND = Isnull((Select KOFUEN From MAEEN Where CODIGO = KOEN+SUEN),'???')

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

Drop table #Paso
Drop table #Paso_Proyeccion
Drop table #Paso_Total