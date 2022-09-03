Declare @Empresa Char(2) = '#Empresa#',
        @Sucursal Char(3) = '#Sucursal#',
		@Bodega Char(3) = '#Bodega#'


Select Codigo,Descripcion,
       Codigo_Nodo_Madre,Cast(Descripcion As Varchar(100)) As Descripcion_Madre,RotDiariaUd#Ud#,
	   CantSugeridaTot,Stock_Fisico_Ud#Ud#,Stock_CriticoUd#Ud#_Rd,Con_Stock_CriticoUd#Ud#, Cast(0 As Float) As Stock_#Bodega#
Into #Paso
From Zw_InfCompras


Update #Paso Set Descripcion_Madre = Z2.Descripcion 
From #Paso 
		Inner Join _Global_BakappZw_TblArbol_Asociaciones Z2 On Z2.Codigo_Nodo = Codigo_Nodo_Madre
Where Codigo <> Codigo_Nodo_Madre

Update #Paso Set Stock_#Bodega# = STFI#Ud#
From #Paso Inner Join MAEST 
	On KOPR = Codigo And EMPRESA = @Empresa And KOSU = @Sucursal And KOBO = @Bodega
		

Select Codigo,Codigo_Nodo_Madre,Descripcion,Descripcion_Madre,RotDiariaUd#Ud#,Stock_CriticoUd#Ud#_Rd,Con_Stock_CriticoUd#Ud#,CantSugeridaTot,
	Sum(Stock_Fisico_Ud#Ud#) As Stock_Fisico_Ud#Ud#,
	Sum(Stock_#Bodega#) As Stock_#Bodega#,
 	Sum(CantSugeridaTot)-Sum(Stock_Fisico_Ud#Ud#) As Pedir,
	(Select DATOSUBIC From TABBOPR Where EMPRESA = @Empresa And KOSU = @Sucursal And KOBO = @Bodega And KOPR = Codigo) As Ubicacion 
Into #Paso2
From #Paso
Where Stock_#Bodega# > Stock_Fisico_Ud#Ud# And CantSugeridaTot > Stock_Fisico_Ud#Ud#
Group by Codigo,Codigo_Nodo_Madre,Descripcion,Descripcion_Madre,RotDiariaUd#Ud#,Stock_CriticoUd#Ud#_Rd,Con_Stock_CriticoUd#Ud#,CantSugeridaTot

Update #Paso2 Set Pedir = Stock_#Bodega# Where Pedir > Stock_#Bodega#

Select Codigo,Descripcion,RotDiariaUd#Ud# As Rot_Diaria,
	   --Round(#Ud#/RotDiariaUd#Ud#,0) AS 'Vende #Ud# cada [n] días',
	   --Rtrim(ltrim(Str(Round(#Ud#/RotDiariaUd#Ud#,0))))+' día(s)' AS 'Vende #Ud# C.',
	   CantSugeridaTot As Cant_Necesaria,Stock_CriticoUd#Ud#_Rd,
	   Case When Con_Stock_CriticoUd#Ud# = #Ud# then 'Si' Else 'No' End As Stock_Critico,
	   Stock_Fisico_Ud#Ud# As Stock_#Bodega_Resep#,Stock_#Bodega#,Pedir,Ubicacion
	   --Round((CantSugeridaTot+Stock_Fisico_Ud#Ud#) / RotDiariaUd#Ud#,0) As 'Alcanza para [n] días' ,Ubicacion 
From #Paso2
--Where Con_Stock_CriticoUd#Ud# = 1
Order by Ubicacion

Drop table #Paso
Drop table #Paso2