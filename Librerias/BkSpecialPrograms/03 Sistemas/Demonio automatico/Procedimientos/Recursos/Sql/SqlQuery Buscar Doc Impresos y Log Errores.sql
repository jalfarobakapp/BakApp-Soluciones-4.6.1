
Declare 
@Fecha as date = '#Fecha#',
@NombreEquipo as Varchar(30) = '#NombreEquipo#',
@Tido as Varchar(3) = '#Tido#'

Select IDMAEEDO,
       Cast(0 as Bit) as Chk,
       TIDO,
       NUDO,
       ENDO,
       SUENDO,
	   (Select Top 1 NOKOEN From MAEEN Where KOEN = ENDO And SUEN = SUENDO) As 'RAZON',
	   VABRDO,
	   (SELECT DISTINCT COUNT(NULIDO) AS CAMPO FROM MAEDDO Do WHERE Do.IDMAEEDO = Edo.IDMAEEDO) As Items,
	   KOFUDO,
	   (Select Top 1 NOKOFU From TABFU Where KOFU = KOFUDO) As 'FUNCIONARIO',
       Cast(0 As bit) As 'Impreso',
       Cast('' As Varchar(500)) As Log_Error,
       CAST(0 As bit) As 'Error_Al_Imprimir'
    Into #Paso001
       From MAEEDO Edo
Where 
	TIDO = @Tido
	#Filtro_Fechas#
	#Filtro_Funcionarios#
    And NUDONODEFI = 0
   
Update #Paso001 Set Impreso = Isnull((Select Top 1 Impreso 
	                                  From #Zw_Demonio_Doc_Emitidos_Cola_Impresion# 
	                                  Where Idmaeedo = #Paso001.IDMAEEDO 
										And Fecha = @Fecha 
											And NombreEquipo = @NombreEquipo),0),
					Log_Error = Isnull((Select Top 1 Log_Error 
									  From #Zw_Demonio_Doc_Emitidos_Cola_Impresion# 
									  Where Idmaeedo = #Paso001.IDMAEEDO 
										And Fecha = @Fecha 
											And NombreEquipo = @NombreEquipo),''),
                    Error_Al_Imprimir = Isnull((Select Top 1 Error_Al_Imprimir 
	                                            From #Zw_Demonio_Doc_Emitidos_Cola_Impresion# 
	                                            Where Idmaeedo = #Paso001.IDMAEEDO 
										          And Fecha = @Fecha 
											         And NombreEquipo = @NombreEquipo),0)
--1 Where Log_Error <> '' And Impreso = 0

Select * From #Paso001
Drop Table #Paso001

