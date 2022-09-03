Declare @Endo Char(10) = '#Endo#'
Declare @Suendo Char(10) = '#Suendo#'
Declare @Codigo Char(13)
Declare @Meses Int = 3
Declare @UltDocumentos Int = 3
Declare @Codigo_Nodo_Madre Varchar(20)
Declare @Porc_CumpUlt3Pedidos Float

DECLARE authors_cursor CURSOR FOR
Select Codigo_Nodo_Madre From #TablaPaso#

OPEN authors_cursor
FETCH NEXT FROM authors_cursor INTO @Codigo_Nodo_Madre
WHILE @@FETCH_STATUS = 0
BEGIN

Select Distinct Edo.IDMAEEDO,Edo.FEEMDO
Into #Paso_Documentos
From MAEDDO Ddo 
Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
Where Ddo.IDMAEEDO In (Select IDMAEEDO From MAEEDO Where TIDO = 'OCC' And ENDO = @Endo And SUENDO = @Suendo And FEEMDO > DATEADD(M,-@Meses,Getdate()))
And KOPRCT = @Codigo_Nodo_Madre

Select Top 3 * Into #Paso_DocUlt3 From #Paso_Documentos Order By IDMAEEDO Desc

Set @Porc_CumpUlt3Pedidos = (Select Round(SUM(CAPREX1)/SUM(CAPRCO1),2) From MAEDDO Where IDMAEEDO In (Select IDMAEEDO From #Paso_DocUlt3) And KOPRCT = @Codigo_Nodo_Madre)
Update #TablaPaso# Set Porc_CumpUlt3Pedidos = Isnull(@Porc_CumpUlt3Pedidos,0)
Where Codigo_Nodo_Madre = @Codigo_Nodo_Madre

--Select IDMAEEDO,IDMAEDDO,TIDO,NUDO,FEEMLI,KOPRCT,CAPREX1,CAPRCO1 From MAEDDO Where IDMAEEDO In (Select IDMAEEDO From #Paso_DocUlt3) And KOPRCT = @Codigo_Nodo_Madre 
--Select @Codigo_Nodo_Madre,* From #Paso_Documentos
Select @Codigo_Nodo_Madre,@Porc_CumpUlt3Pedidos,* From #Paso_DocUlt3

Drop table #Paso_Documentos
Drop table #Paso_DocUlt3

FETCH NEXT FROM authors_cursor INTO @Codigo_Nodo_Madre

END
CLOSE authors_cursor
DEALLOCATE authors_cursor

--Select * From #TablaPaso#


