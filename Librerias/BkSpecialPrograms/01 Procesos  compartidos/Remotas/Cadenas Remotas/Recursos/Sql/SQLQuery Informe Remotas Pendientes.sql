Declare @Tido Char(3),
		@Ver_Todas Bit,
		@CodFuncionario Char(3)

Select @Tido = '#Tido#',@Ver_Todas = #Ver_Todas#,@CodFuncionario = '#CodFuncionario#'

Select Case When Edo.IDMAEEDO Is Null Then Z2.Empresa Else Edo.EMPRESA End As 'Empresa',
	   Case When Edo.IDMAEEDO Is Null Then Z2.Sucursal Else Edo.SUDO End As 'Sucursal',
	   Id_Enc, 
	   Cast(0 As Int) As Anotaciones,
	   Estado, 
       Case Estado 
	       When '' Then 'Enviada' 
		   When 'P' then 'En Proceso' 
		   When 'A' then 'Aceptado' 
		   When 'N' then 'Anulada' 
		   When 'R' then 'Rechazado' 
		   When 'r' then 'Reenviada'
		   When 'E' then 'Reemplazada'
		   Else '???' End 
		As 'Estado_Str',
        Nro_RCadena,
        Fecha_Hora As Fecha,
        Fecha_Hora As Hora,
        Z1.CodEntidad,
		Z1.CodSucEntidad,
		Z1.Nombre_Entidad,
		Tido, 
		(Select Top 1 NOTIDO From TABTIDO Z2 Where Z2.TIDO = Z1.Tido) As Tipo,
		Nudo,
		Case When Edo.IDMAEEDO Is Null Then Z2.Moneda_Doc Else Edo.MODO End As Moneda_Doc,
		Total_Documento,
		Case When Edo.IDMAEEDO Is Null Then Z2.Valor_Dolar Else Edo.TAMODO End As Valor_TC,
		Z1.Id_DocEnc, 
		 Case When Idmaeedo > 0 Then '' Else Isnull(Z2.NroDocumento,'X') End  As NroDocumento,
		Usuario_Solicita, NOKOFU As Nombre_Usuario_Solicita,Fecha_Hora, Idmaeedo,Fecha_Hora_Grab,Id_Enc_Padre,
		Isnull(Reserva_NroOCC,0) As 'Reserva_NroOCC' 
	Into #Paso1
		From   
		#_Global_BaseBk#Zw_Remotas_En_Cadena_01_Enc Z1
			Left Join #_Global_BaseBk#Zw_Casi_DocEnc Z2 On Z1.Id_DocEnc = Z2.Id_DocEnc
				Left Join MAEEDO Edo On Edo.IDMAEEDO = Z1.Idmaeedo 
					Left Join TABFU On KOFU = Usuario_Solicita
Where 1 > 0
#Filtro_Inf_01#

Update #Paso1 Set Anotaciones = (Select Count(*) From #_Global_BaseBk#Zw_Casi_DocTag Z2 Where Z2.Id_DocEnc = Z1.Id_DocEnc And Z2.Kofu <> Usuario_Solicita )
From #Paso1 Z1 
Where Idmaeedo = 0

Update #Paso1 Set Anotaciones = (Select Count(*) From MEVENTO Where ARCHIRVE = 'MAEEDO' And IDRVE = Idmaeedo)
Where Idmaeedo <> 0

Update #Paso1 Set Nudo = NroDocumento Where Reserva_NroOCC = 1

Select CodFuncionario,CodJefe,CodJefeReemplazo Into #Jefes1 From #_Global_BaseBk#Zw_Usuarios_VS_Jefes  Where CodJefe = @CodFuncionario Or CodJefeReemplazo = @CodFuncionario
Select CodFuncionario,CodJefe,CodJefeReemplazo Into #Jefes2 From #_Global_BaseBk#Zw_Usuarios_VS_Jefes  Where CodJefe In (Select CodFuncionario From #Jefes1) Or CodJefeReemplazo In (Select CodFuncionario From #Jefes1)
Select CodFuncionario,CodJefe,CodJefeReemplazo Into #Jefes3 From #_Global_BaseBk#Zw_Usuarios_VS_Jefes  Where CodJefe In (Select CodFuncionario From #Jefes2) Or CodJefeReemplazo In (Select CodFuncionario From #Jefes2)
Select CodFuncionario,CodJefe,CodJefeReemplazo Into #Jefes4 From #_Global_BaseBk#Zw_Usuarios_VS_Jefes  Where CodJefe In (Select CodFuncionario From #Jefes3) Or CodJefeReemplazo In (Select CodFuncionario From #Jefes3)
Select CodFuncionario,CodJefe,CodJefeReemplazo Into #Jefes5 From #_Global_BaseBk#Zw_Usuarios_VS_Jefes  Where CodJefe In (Select CodFuncionario From #Jefes4) Or CodJefeReemplazo In (Select CodFuncionario From #Jefes4)
Select CodFuncionario,CodJefe,CodJefeReemplazo Into #Jefes6 From #_Global_BaseBk#Zw_Usuarios_VS_Jefes  Where CodJefe In (Select CodFuncionario From #Jefes5) Or CodJefeReemplazo In (Select CodFuncionario From #Jefes5)
Select CodFuncionario,CodJefe,CodJefeReemplazo Into #Jefes7 From #_Global_BaseBk#Zw_Usuarios_VS_Jefes  Where CodJefe In (Select CodFuncionario From #Jefes6) Or CodJefeReemplazo In (Select CodFuncionario From #Jefes6)
Select CodFuncionario,CodJefe,CodJefeReemplazo Into #Jefes8 From #_Global_BaseBk#Zw_Usuarios_VS_Jefes  Where CodJefe In (Select CodFuncionario From #Jefes7) Or CodJefeReemplazo In (Select CodFuncionario From #Jefes7)
Select CodFuncionario,CodJefe,CodJefeReemplazo Into #Jefes9 From #_Global_BaseBk#Zw_Usuarios_VS_Jefes  Where CodJefe In (Select CodFuncionario From #Jefes8) Or CodJefeReemplazo In (Select CodFuncionario From #Jefes8)
Select CodFuncionario,CodJefe,CodJefeReemplazo Into #Jefes10 From #_Global_BaseBk#Zw_Usuarios_VS_Jefes  Where CodJefe In (Select CodFuncionario From #Jefes9) Or CodJefeReemplazo In (Select CodFuncionario From #Jefes9)

If @Tido = 'OCC' And @Ver_Todas = 0
	Select * From #Paso1 
	Where 1 > 0
	#Filtro_Empresa_Sucursal# 
		And (Usuario_Solicita In (Select CodFuncionario From #Jefes1) Or Usuario_Solicita In (Select CodFuncionario From #Jefes2) 
		Or Usuario_Solicita In (Select CodFuncionario From #Jefes3) Or Usuario_Solicita In (Select CodFuncionario From #Jefes4)
		Or Usuario_Solicita In (Select CodFuncionario From #Jefes5) Or Usuario_Solicita In (Select CodFuncionario From #Jefes6)
		Or Usuario_Solicita In (Select CodFuncionario From #Jefes7) Or Usuario_Solicita In (Select CodFuncionario From #Jefes8)
        Or Id_Enc In (Select RCadena_Id_Enc From #_Global_BaseBk#Zw_Remotas Where NroRemota In (Select NroRemota From #_Global_BaseBk#Zw_Remotas_Notif Where CodFuncionario_Destino = @CodFuncionario)))
	Order By Fecha_Hora	
	
Else
	Select * From #Paso1 
	Where 1 > 0
	#Filtro_Empresa_Sucursal#
	Order By Fecha_Hora

--Select * From #Paso1 
--#Filtro_Empresa_Sucursal#

Drop Table #Paso1

Drop Table #Jefes1
Drop Table #Jefes2
Drop Table #Jefes3
Drop Table #Jefes4
Drop Table #Jefes5
Drop Table #Jefes6
Drop Table #Jefes7
Drop Table #Jefes8
Drop Table #Jefes9
Drop Table #Jefes10
	   
-- NOTA SI UN DOCUMENTO EN RANDOM FUE ANULADO O ELIMINADO NO SE MUESTRA EN ESTA LISTA, YA QUE SI EL DOCUMENTO EN RANDOM ES ANULADO EL SISTEMA 
-- CAMBIA EL IDMAEEDO POR LO TANTO NO HAY COMO RELACIONAR EL DOCUMENTO APROBADO AL DOCUMENTO QUE SE ANULO EN RANDOM.