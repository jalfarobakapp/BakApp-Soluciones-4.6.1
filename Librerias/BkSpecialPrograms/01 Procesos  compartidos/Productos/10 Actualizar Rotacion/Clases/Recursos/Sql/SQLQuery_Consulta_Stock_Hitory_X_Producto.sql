
DECLARE  @Empresa  As Varchar(2)  = '#Empresa#',
         @Sucursal As Varchar(3)  = '#Sucursal#',
         @Bodega   As Varchar(3)  = '#Bodega#',
         @Codigo   As Varchar(13) = '#Codigo#' 


Select Distinct Codigo,Empresa,Sucursal,Bodega,Fecha_Stock, 
       Sum(Cast(Dia_Habil As Int)) As Dia_Habil,
	   Sum(Cast(Dia_Sabado As Int)) As Dia_Sabado,
	   Sum(Cast(Dia_Domingo As Int)) As Dia_Domingo
Into #Paso1
From Zw_Prod_Stock_History
Where Codigo = @Codigo And (Hubo_Stock =1) And Empresa = @Empresa And Sucursal = @Sucursal And Bodega = @Bodega
Group by Codigo,Fecha_Stock,Empresa,Sucursal,Bodega

Update #Paso1 Set Dia_Habil = 1 Where Dia_Habil > 0
Update #Paso1 Set Dia_Sabado = 1 Where Dia_Sabado > 0
Update #Paso1 Set Dia_Domingo = 1 Where Dia_Domingo > 0


Select Codigo,Empresa,Sucursal,Bodega,Sum(Dia_Habil) As Dia_Habil,Sum(Dia_Sabado) As Dia_Sabado,Sum(Dia_Domingo) As Dia_Domingo From #Paso1
Group by Codigo,Empresa,Sucursal,Bodega

Drop table #Paso1
Drop table #Paso2





