-- Datos de cumplimiento de entrega de productos por parte del proveedor

Declare @Endo Char(10) = '#Koen#'
Declare @Suendo Char(10) = '#Suen#'
Declare @Codigo Char(13) = '#Codigo#'
Declare @Meses Int = #Meses#

Select Distinct Edo.IDMAEEDO,Edo.FEEMDO
Into #Paso_Documentos
From MAEDDO Ddo 
Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
Where Ddo.IDMAEEDO In (Select IDMAEEDO From MAEEDO Where TIDO = 'OCC' And ENDO = @Endo And SUENDO = @Suendo And FEEMDO > DATEADD(M,-@Meses,Getdate()))
And KOPRCT = @Codigo

Select Top 3 * Into #Paso_DocUlt3 From #Paso_Documentos Order By IDMAEEDO Desc

Select KOPRCT,NOKOPR
Into #Paso_Prod
From MAEDDO Where IDMAEEDO In (Select IDMAEEDO From #Paso_Documentos)
And KOPRCT = @Codigo
Group By KOPRCT,NOKOPR

Select KOPRCT,Cast('' As Varchar(50)) As NOKOPR,SUM(CAPRCO1) As CAPRCO1,SUM(CAPRAD1) As CAPRAD1,SUM(CAPREX1) As CAPREX1,
	   Round(SUM(CAPREX1)/SUM(CAPRCO1),2) As 'Porc_Cumplimiento',Cast(0 As float) As 'Porc_CumpUlt3Pedidos',Cast(0 As float) As 'Dias_Prom_Entrega'
Into #Paso_Producto
From MAEDDO Where IDMAEEDO In (Select IDMAEEDO From #Paso_Documentos)
And KOPRCT = @Codigo
Group By KOPRCT

Update #Paso_Producto Set Porc_CumpUlt3Pedidos = (Select Round(SUM(CAPREX1)/SUM(CAPRCO1),2) From MAEDDO Where IDMAEEDO In (Select IDMAEEDO From #Paso_DocUlt3) And KOPRCT = @Codigo)
Update #Paso_Producto Set NOKOPR = (Select NOKOPR From MAEPR Where KOPR = KOPRCT)

Select IDMAEEDO,IDMAEDDO,TIDO,NUDO,FEEMLI,ENDO,SUENDO,KOPRCT,UDTRPR,
       UD01PR,CAPRCO1,CAPREX1,CAPRAD1,Round(CAPREX1/CAPRCO1,2) As 'Porc_CumplimientoUd1',
	   UD02PR,CAPRCO2,CAPREX2,CAPRAD2,Round(CAPREX2/CAPRCO2,2) As 'Porc_CumplimientoUd2' 
Into #Paso_OCC
From MAEDDO Where IDMAEEDO In (Select IDMAEEDO From MAEEDO Where TIDO = 'OCC' And ENDO = @Endo And SUENDO = @Suendo And FEEMDO > DATEADD(M,-@Meses,Getdate()))
And KOPRCT = @Codigo
Order By FEEMLI Desc

Select IDMAEEDO,IDMAEDDO,IDRST As IDMAEDDO_OCC,TIDO,NUDO,FEEMLI,ENDO,SUENDO,KOPRCT,UDTRPR,ARCHIRST,
       UD01PR,CAPRCO1,CAPREX1,CAPRAD1,Round(CAPREX1/CAPRCO1,2) As 'PCumplUd1',
	   UD02PR,CAPRCO2,CAPREX2,CAPRAD2,Round(CAPREX2/CAPRCO2,2) As 'PCumplUd2',
	   Cast(Null As Datetime) As FEEMLI_OCC,
	   Cast(0 As Int) As Dias_Llega
Into #Paso_Recepcion
From MAEDDO Where IDRST In (Select IDMAEDDO From #Paso_OCC)
Order By FEEMLI Desc

Update #Paso_Recepcion Set FEEMLI_OCC = (Select FEEMLI From MAEDDO Ds Where IDMAEDDO = #Paso_Recepcion.IDMAEDDO_OCC)
Update #Paso_Recepcion Set Dias_Llega = DATEDIFF(D,FEEMLI_OCC,FEEMLI)
Declare @Reg Int = (Select Count(*) From #Paso_Recepcion)
Update #Paso_Producto Set Dias_Prom_Entrega = ISNULL((Select Sum(Dias_Llega) From #Paso_Recepcion Z1 Where Z1.KOPRCT = KOPRCT)/@Reg,0)

Select * From #Paso_Producto
Select * From #Paso_OCC
Select * From #Paso_Recepcion

Drop Table #Paso_Documentos
Drop Table #Paso_Prod
Drop Table #Paso_Producto
Drop Table #Paso_OCC
Drop Table #Paso_Recepcion
Drop Table #Paso_DocUlt3