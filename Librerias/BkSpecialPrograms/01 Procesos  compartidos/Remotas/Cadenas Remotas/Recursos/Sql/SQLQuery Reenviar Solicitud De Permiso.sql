
-- CONSULTA PARA REENVIAR SOLICITUD DE PEDIDO

Declare @New_Nro_Remota Varchar(10),
		@Old_Nro_Remota Varchar(10),
		@Id_Enc Int,
		@Id_Det Int

Select @New_Nro_Remota = '#New_NroRemota#',
	   @Old_Nro_Remota = '#Old_NroRemota#',
	   @Id_Enc = #Id_Enc#,
	   @Id_Det = #Id_Det#

Update #_Global_BaseBk#Zw_Remotas_En_Cadena_01_Enc Set Estado = 'r'
WHERE Id_Enc = @Id_Enc

Insert Into #_Global_BaseBk#Zw_Remotas (Empresa, NroRemota, CodFuncionario_Solicita, CodFuncionario_Autoriza, CodPermiso, Descripcion_Adicional, Id_Casi_DocEnc, Fecha_Solicita, CodEntidad, 
       CodSucEntidad, NomEntidad, TotalBruto, Espera_En_Linea, Observaciones, Id_Notificacion, 
	   RCadena, RCadena_Id_Enc, Padre_NroRemota, Crear_Doc_Def_Al_Grabar, 
       Nro_RCadena, Permiso_Presencial, Monto_Aprobacion)

SELECT Empresa, @New_Nro_Remota, CodFuncionario_Solicita, '', CodPermiso, Descripcion_Adicional, Id_Casi_DocEnc, Fecha_Solicita, CodEntidad, 
       CodSucEntidad, NomEntidad, TotalBruto, Espera_En_Linea, 'Reenvio de solucitud rechazada', Id_Notificacion, 
	   RCadena, RCadena_Id_Enc, Padre_NroRemota, Crear_Doc_Def_Al_Grabar, 
       Nro_RCadena, Permiso_Presencial, Monto_Aprobacion
FROM   #_Global_BaseBk#Zw_Remotas
WHERE  NroRemota = @Old_Nro_Remota
ORDER BY Id_Rem DESC

Update #_Global_BaseBk#Zw_Remotas Set Eliminada = 1 Where NroRemota = @Old_Nro_Remota

Update #_Global_BaseBk#Zw_Remotas_En_Cadena_02_Det Set NroRemota = @New_Nro_Remota
Where Id_Det = @Id_Det

Delete #_Global_BaseBk#Zw_Remotas_En_Cadena_03_Usu 
Where Id_Det = @Id_Det

