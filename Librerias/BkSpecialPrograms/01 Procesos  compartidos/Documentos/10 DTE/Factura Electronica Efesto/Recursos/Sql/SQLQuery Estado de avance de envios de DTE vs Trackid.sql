

Select Cast(0 As Int) As Existe, 
        Isnull(Doc.Id_Dte,0) As 'Id_Dte',
        IDMAEEDO,TIDO,Edo.NUDO,
        TIDO+'-'+Edo.NUDO As 'Tido_Nudo',
        VABRDO As Monto,SUDO,Ts.NOKOSU,KOFUDO,Kf.NOKOFU,FEEMDO,KOEN,SUEN,NOKOEN,
        Isnull(Tid.Id,'') As 'Id_Trackid',
        Isnull(Tid.Trackid,'') As 'Trackid',
        Cast((Case When Isnull(Doc.Firma,'') <> '' Then 1 Else 0 End) As Bit) As 'DocFirmado',
		Cast((Case When Isnull(Tid.Aceptado,0) = 1 
                        Or Isnull(Tid.Informado,0) = 1 
                            Or Isnull(Tid.Rechazado,0) = 1 
                                Or Isnull(Tid.Reparo,0) = 1 Then 1 Else 0 End) As Bit) As 'EnviadoSII',
		Cast(Isnull(Tid.Aceptado,0) As Bit) As 'AceptadoSII',
		Cast(Isnull(Tid.Informado,0) As Bit) As 'InformadoSII',
		Cast(Isnull(Tid.Rechazado,0) As Bit) As 'RechazadoSII',
		Cast(Isnull(Tid.Reparo,0) As Bit) As 'ReparoSII',
		Cast(Isnull(Tid.MailEnviado,0) As Bit) As 'MailEnviado',
        Cast(Isnull(Tid.MailToDiablito,0) As Bit) As 'MailToDiablito',
		Cast(Isnull(Tid.ErrorMailToDiablito,0) As Bit) As 'ErrorMailToDiablito',
		Cast(Isnull(Tid.ErrorEnviarMail,0) As Bit) As 'ErrorEnviarMail',
		Cast(Isnull(Tid.EnviarMail,0) As Bit) As 'EnviarMail',        
		Isnull(Tid.Estado,'') As 'Estado',
		Isnull(Tid.Glosa,'') As 'Glosa',
		Isnull(Doc.Procesar,'') As 'Procesar',
		Isnull(Doc.Procesado,'') As 'Procesado',								   
        Case When Doc.ErrorEnvioDTE = 0 Then Isnull(Tid.Respuesta,'') Else Isnull(Doc.Respuesta,'') End As 'Respuesta',
		Isnull(Doc.ErrorEnvioDTE,0) As 'ErrorEnvioDTE',
        Isnull(Doc.Eliminado,0) As 'Eliminado',
        Cast('' As Varchar(300)) As 'LeyendaEmail',
        Isnull(Correo.Destinatarios,'') As 'Destinatarios'
Into #PasoDTE
From MAEEDO Edo
	Left Join MAEEN En On En.KOEN = Edo.ENDO And En.SUEN = Edo.SUENDO
		Left Join TABSU Ts On Ts.EMPRESA = Edo.EMPRESA And Ts.KOSU = Edo.SUDO 
			Left Join TABFU Kf On Kf.KOFU = Edo.KOFUDO
				Left Join #Global_BaseBk#Zw_DTE_Documentos Doc On Edo.IDMAEEDO = Doc.Idmaeedo And Doc.AmbienteCertificacion = #AmbienteCertificacion#
					Left Join #Global_BaseBk#Zw_DTE_Trackid Tid On Tid.Id_Dte = Doc.Id_Dte And Tid.AmbienteCertificacion = #AmbienteCertificacion#
						Left Join #Global_BaseBk#Zw_DTE_NotifxCorreo Correo On Correo.Id_Dte = Doc.Id_Dte And Correo.AmbienteCertificacion = #AmbienteCertificacion#
Where 1 > 0 
#Filtros#
And TIDOELEC = 1
And FEEMDO Between '#Fecha_Desde#' And '#Fecha_Hasta#'
#SoloFirmadosPorBakapp#
Order By Edo.TIDO,Edo.NUDO,Id_Dte

Select * Into #PasoDTEResp From #PasoDTE
Delete #PasoDTE Where Eliminado = 1

Update #PasoDTE Set Glosa = 'Firmado Ok' Where DocFirmado = 1 And Trackid = ''
Update #PasoDTE Set Glosa = 'Error al enviar DTE al SII' Where ErrorEnvioDTE = 1
Update #PasoDTE Set Glosa = 'A la espera de consultar Trackid en SII' Where DocFirmado = 1 And Trackid <> '' And Estado = ''

Update #PasoDTE Set LeyendaEmail = 'A la espera de envia el correo.' Where EnviarMail = 1
Update #PasoDTE Set LeyendaEmail = 'El correo esta en la bandeja de salida del diablito de correos.' Where MailToDiablito = 1
Update #PasoDTE Set LeyendaEmail = 'Error, el correo no pudo ser enviado al diablito de correos. Revise la ficha del cliente' Where ErrorMailToDiablito = 1 And Destinatarios <> ''
Update #PasoDTE Set LeyendaEmail = 'Error, el correo no pudo ser enviado al diablito de correos. No existe destinatario, revise la ficha del cliente' Where ErrorMailToDiablito = 1 And Destinatarios = ''
Update #PasoDTE Set LeyendaEmail = 'Correo enviado correctamente. '+Destinatarios Where MailEnviado = 1
Update #PasoDTE Set LeyendaEmail = 'Error, correo no enviado al cliente. avise al administrador del sistema' Where ErrorEnviarMail = 1 And Destinatarios <> ''
Update #PasoDTE Set LeyendaEmail = 'Error, correo no enviado al cliente. Falta correo de destinatario, revise la ficha del cliente' Where ErrorEnviarMail = 1 And Destinatarios = ''

Update #PasoDTE Set AceptadoSII = 1 Where Estado = 'RPR'

Update #PasoDTE Set Existe = (Select Count(*) From #PasoDTE Ps Where Ps.IDMAEEDO = #PasoDTE.IDMAEEDO And #PasoDTE.AceptadoSII = 1)
Update #PasoDTE Set Existe = Isnull((Select top 1 Existe From #PasoDTE Ps Where #PasoDTE.IDMAEEDO = Ps.IDMAEEDO And Existe > 0),0)
Where Existe = 0

Delete #PasoDTE Where Existe > 1 And AceptadoSII = 0

-- Esto eliminaria los documentos DTE que tubieron problemas con el envio, solo se quedan los documentos sin problemas y aquellos que aun no tienen solución.
-- Delete BAKAPP_SMARTRADING.dbo.Zw_DTE_Documentos Where Id_Dte In (Select Id_Dte From #PasoDTEResp Where Id_Dte Not In (Select Id_Dte From #PasoDTE))

Select Distinct * From #PasoDTE 
Order By TIDO,NUDO

Drop Table #PasoDTE
Drop Table #PasoDTEResp