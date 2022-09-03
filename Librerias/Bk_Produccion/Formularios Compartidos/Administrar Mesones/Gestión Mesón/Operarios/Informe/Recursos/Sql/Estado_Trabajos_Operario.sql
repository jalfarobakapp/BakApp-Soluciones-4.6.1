Declare @Codigoob as varchar(20) = '#Codigoob#',
		@FechaDesde as Date = '#FechaDesde#',
		@FechaHasta as Date

Set @FechaHasta = DATEADD(D,1,@FechaDesde)

Select Distinct Ms.Codmeson,CODIGOOB,NOMBREOB, Ms.Nommeson,NOMBREOP
From PMAEOB
Left Join #Base_Bakapp#Zw_Pdp_MaquinaVsProductos Mq On CODIGOOB = Obrero And 
			(((Fecha_Hora_Inicio > @FechaDesde And Fecha_Hora_Inicio < @FechaHasta) And 
			  (Fecha_Hora_Termino > @FechaDesde And Fecha_Hora_Termino < @FechaHasta)) Or 
			  (Estado = 'EMQ' And Fecha_Hora_Inicio > @FechaDesde And Fecha_Hora_Inicio < @FechaHasta ))
Left Join #Base_Bakapp#Zw_Pdc_Mesones Ms On Mq.Codmeson = Ms.Codmeson
Left Join PMAQUI On CODMAQ = Mq.CodMaq
Left Join POPER On OPERACION = Mq.Operacion

Where CODIGOOB = @Codigoob


Select	NOMBREMAQ,REFERENCIA,Mq.*,Mop.Nreg As SubOt,CODIGOOB,NOMBREOB, Ms.Nommeson,
		Case When Mq.Estado = 'EMQ' Then 'En proceso...' When Mq.Estado = 'FMQ' Then 
		Case When Mq.Fabricar > Mq.Fabricado Then 'Avance...' Else 'Finalizado' End
		Else '...' end As Estado_Ob,
		SUBSTRING(CONVERT(varchar,Fecha_Hora_Inicio,108),1,5) As Hora_Inicio,
		Case When Mq.Estado = 'EMQ' Then '...' Else SUBSTRING(CONVERT(varchar,Fecha_Hora_Termino,108),1,5) End As Hora_Termino, 
		Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, Case When Mq.Estado = 'EMQ' Then Getdate() Else Fecha_Hora_Termino end) / 60) / 24)) As Dias_En_Mq,
		Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, Case When Mq.Estado = 'EMQ' Then Getdate() Else Fecha_Hora_Termino end) / 60)%24)) As Horas_En_Mq,
		Convert(VARCHAR(200), DateDiff(Minute, Fecha_Hora_Inicio, Case When Mq.Estado = 'EMQ' Then Getdate() Else Fecha_Hora_Termino end)%60) As Minutos_En_Mq,
		Cast('' As Varchar) As Tiempo_En_Maquina,
NOMBREOP 
From PMAEOB
Left Join #Base_Bakapp#Zw_Pdp_MaquinaVsProductos Mq On CODIGOOB = Obrero And 
			(((Fecha_Hora_Inicio > @FechaDesde And Fecha_Hora_Inicio < @FechaHasta) And 
			  (Fecha_Hora_Termino > @FechaDesde And Fecha_Hora_Termino < @FechaHasta)) Or 
			  (Mq.Estado = 'EMQ' And Fecha_Hora_Inicio > @FechaDesde And Fecha_Hora_Inicio < @FechaHasta ))
Left Join #Base_Bakapp#Zw_Pdc_Mesones Ms On Mq.Codmeson = Ms.Codmeson
Left Join PMAQUI On CODMAQ = Mq.CodMaq
Left Join POPER On OPERACION = Mq.Operacion
Left Join POTE On IDPOTE = Mq.Idpote
Left Join #Base_Bakapp#Zw_Pdp_MesonVsProductos Mop On Mop.Idpotpr = Mq.Idpotpr

Where CODIGOOB = @Codigoob
Order by Mq.Fecha_Hora_Inicio