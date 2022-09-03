

Select Z1.*,Z2.Fecha_Otorga,
    Z3.Tido,
	Z3.CodEntidad,
	Z3.Nombre_Entidad,
	Isnull(Z2.CodFuncionario_Solicita,'') As CodFuncionario_Solicita,
	Isnull(NOKOFU,'???') As Nombre_Usuario_Solicita,
	Isnull(Z2.CodFuncionario_Autoriza,'') As CodFuncionario_Autoriza,	
	Isnull(Z2.Otorga,'') As Otorga,
	Isnull(Z2.Permiso_Otorgado,0) As Permiso_Otorgado,
	Isnull(Z2.Observaciones,0) As Observaciones,
	Isnull((Select Top 1 CodFuncionario From #_Global_BaseBk#Zw_Casi_DocTom Z3 Where Z1.NroRemota = Z3.NroRemota),'') As 'Revisando',
	Cast('' As Varchar(200)) As Estado,
	Cast('' As Varchar(500)) As Fun_Solicitados
	Into #Paso2
From #_Global_BaseBk#Zw_Remotas_En_Cadena_02_Det AS Z1 
		Left Outer Join #_Global_BaseBk#Zw_Remotas Z2 ON Z1.NroRemota = Z2.NroRemota
			Left Join TABFU On Z2.CodFuncionario_Solicita = KOFU
				Left Join #_Global_BaseBk#Zw_Remotas_En_Cadena_01_Enc Z3 On Z3.Id_Enc = Z1.Id_Enc	
Where 1 > 0

#Filtro_Inf_01#

Update #Paso2 Set Otorga = (Case When NroRemota <> '' Then Case When Otorga <> '' Then Otorga Else 'Enviado' end Else 'Pendiente...' End)

Update #Paso2 Set Estado = UPPER(Otorga+ ' por: '+(Select Top 1 NOKOFU From TABFU Where KOFU = CodFuncionario_Autoriza))
Where Otorga = 'Autorizado'

Update #Paso2 Set Estado = UPPER(Otorga+ ' por: '+(Select Top 1 NOKOFU From TABFU Where KOFU = CodFuncionario_Autoriza))--+', motivo: ' +Observaciones
Where Otorga = 'Rechazado'

Update #Paso2 Set Estado = UPPER('Esta siendo revisado por: '+(Select Top 1 NOKOFU From TABFU Where KOFU = Revisando))
Where Revisando <> '' And Otorga = 'Enviado'

Update #Paso2 Set Estado = UPPER('En espera de ser revisado...')
Where Revisando = '' And Otorga = 'Enviado'


Select * From #Paso2
Drop Table #Paso2