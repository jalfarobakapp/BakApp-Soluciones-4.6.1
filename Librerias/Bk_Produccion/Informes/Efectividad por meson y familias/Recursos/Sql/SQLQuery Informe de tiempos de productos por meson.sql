Declare @Fecha_Desde Date 

Set @Fecha_Desde = '#Fecha_Desde#'

SELECT REFERENCIA,IdMeson, Pd_Ms.Codmeson,Mss.Nommeson, Pd_Ms.Orden_Meson, Estado, Idpotpr, Idpotl, Idpote, Empresa,Cfp.RAZON, Numot, Orden_Potpr,Pd_Ms.Operacion, Nombreop, Nreg, Desde, Nivel, 
	   Codigo, Glosa, Mp.NOKOPR As DescripcionPr,
	   Mp.FMPR,Isnull(SFm.NOKOFM,'') As NOKOFM,Isnull(Mp.PFPR,'') As PFPR,Isnull(Ffm.NOKOPF,'') As NOKOPF,Mp.HFPR,Isnull(Sbf.NOKOHF,'') As NOKOHF,
	   Asignado_Por, 
	   FIOT,Fecha_Asignacion,
	   DATEDIFF(Day,FIOT,Fecha_Asignacion) As Dias,
	   (Select Max(Fecha_Hora_Termino) From Zw_Pdp_MaquinaVsProductos Zmq Where Zmq.IdMeson = Pd_Ms.IdMeson) As Fecha_Fabr_MQ,
	   Cast(0 As Float) As Prod_En_Meson_Antes,
	   Cast(0 As Float) As [Prom.Carga SubOt],
	   Cast(0 As Float) As Piezas_En_Meson_Antes,
	   Cast(0 As Float) As [Prom.Carga xPiezas],
	   Cast(0 As Float) As Ss,
	   Cast(0 As Float) As Mm,
	   Cast(0 As Float) As Hh,
	   Cast(0 As Float) As Dd,
	   Cast(0 As Float) As Dias_Mq,
	   Cast(Null As Datetime) As Fecha_Ini_MQ,
	   Cast(Null As Datetime) As Fecha_Fin_MQ,
	  -- Cast(0 As Float) As Dias_Hb, -- Dias Laborales
	  -- Cast(0 As Float) As Ss_Hb,   -- Segundo laborales
	   Fabricar_Recep, 
       Fabricado_Recep, Saldo_Fabricar_Recep, Porc_Fabricacion_Recep, Fabricar_OT, Fabricado_OT, Saldo_Fabricar_OT, Porc_Fabricacion, Fabricar, Fabricado, Fabricando, Saldo_Fabricar, Porc_Avance_Saldo_Fab, 
       Cod_Funcionario_Asigna, Prox_Meson, Pertenece, Reproceso, Cant_Reproceso, IdMeson_Reproceso, Idpotl_Padre,1 As Uno
		 Into #Paso_Operaciones
FROM Zw_Pdp_MesonVsProductos Pd_Ms
Inner Join POTE On POTE.IDPOTE = Idpote
Inner Join MAEPR Mp On Pd_Ms.Codigo = Mp.KOPR
Left Join TABFM SFm On Mp.FMPR = SFm.KOFM
Left Join TABPF Ffm On Mp.FMPR = Ffm.KOFM And Mp.PFPR = Ffm.KOPF
Left Join TABHF Sbf On Mp.FMPR = Sbf.KOFM And Mp.PFPR = Sbf.KOPF And Mp.HFPR = Sbf.KOHF 
Left Join Zw_Pdc_Mesones Mss On  Pd_Ms.Codmeson = Mss.Codmeson
Left Join CONFIGP Cfp On Cfp.EMPRESA = Pd_Ms.Empresa
WHERE 1>0
--#Filtros_Informe#
And Fabricado = Fabricar 
And FIOT > @Fecha_Desde 
--And Operacion = 'IFCP' 
--And Mp.FMPR = 'TFRE' 
--And Mp.PFPR = 'SU  '
--And Pd_Ms.Codigo = 'ICCABCESCU002'
--And Pd_Ms.Codmeson = '000026'
And POTE.REFERENCIA Not Like '%INGEMAD%'-- <> 'INGEMAD CONSTITUCION                              ' and POTE.REFERENCIA <> 'INGEMAD - SANTIAGO                                '
--And Idpotpr = 36330
And Estado <> 'MQ'
ORDER BY Codigo DESC

Update #Paso_Operaciones Set Fecha_Asignacion = (Select Max(Fecha_Hora_Inicio) From Zw_Pdp_MaquinaVsProductos Zmq Where Zmq.IdMeson = #Paso_Operaciones.IdMeson)
From #Paso_Operaciones
Where Fecha_Asignacion >= Fecha_Fabr_MQ

Update #Paso_Operaciones Set Ss = dbo.SegundosDifDias(Fecha_Asignacion,Fecha_Fabr_MQ)--DATEDIFF(SS,Fecha_Asignacion,Fecha_Fabr_MQ)
Update #Paso_Operaciones Set Mm = Round(Ss/60,3),Hh = Round((Ss/60)/60,3),Dd = Round(((Ss/60)/60)/24,3)

Select *,
       Cast(0 As Float) As Ss,
	   Cast(0 As Float) As Mm,
	   Cast(0 As Float) As Hh,
	   Cast(0 As Float) As Dd 
Into #Paso_Maquinas
From Zw_Pdp_MaquinaVsProductos 
Where Idpotpr In (Select Idpotpr From #Paso_Operaciones)

Update #Paso_Maquinas Set Ss = dbo.SegundosDifDias(Fecha_Hora_Inicio,Fecha_Hora_Termino)
Update #Paso_Maquinas Set Mm = Round(Ss/60,3),Hh = Round((Ss/60)/60,3),Dd = Round(((Ss/60)/60)/24,5)

Update #Paso_Operaciones Set Dias_Mq = (Select Sum(Dd) From #Paso_Maquinas Mq Where Op.Idpotpr = Mq.Idpotpr) 
From #Paso_Operaciones Op --Inner Join #Paso_Maquinas Mq On Op.Idpotpr = Mq.Idpotpr

Update #Paso_Operaciones Set Prod_En_Meson_Antes = (Select count(*) From #Paso_Operaciones Op2 
											Where Op2.Fecha_Asignacion < Op1.Fecha_Asignacion And 
												  Op2.Fecha_Fabr_MQ > Op1.Fecha_Asignacion And 
												  Op1.Codmeson = Op2.Codmeson)
From #Paso_Operaciones Op1

Update #Paso_Operaciones Set Piezas_En_Meson_Antes = (Select Isnull(Sum(Fabricar),0) From #Paso_Operaciones Op2 
											Where Op2.Fecha_Asignacion < Op1.Fecha_Asignacion And 
												  Op2.Fecha_Fabr_MQ > Op1.Fecha_Asignacion And 
												  Op1.Codmeson = Op2.Codmeson)
From #Paso_Operaciones Op1



Update #Paso_Operaciones Set [Prom.Carga SubOt] = (Select Round(Sum(Prod_En_Meson_Antes)/Sum(Uno),3) From #Paso_Operaciones Op2 Where Op2.Codmeson = Op1.Codmeson)
From #Paso_Operaciones Op1

Update #Paso_Operaciones Set [Prom.Carga xPiezas] = (Select Round(Sum(Piezas_En_Meson_Antes)/Sum(Uno),3) From #Paso_Operaciones Op2 Where Op2.Codmeson = Op1.Codmeson)
From #Paso_Operaciones Op1

Select * Into #Tabla_Paso# From #Paso_Operaciones 
Order By Codmeson,Fecha_Asignacion,Fecha_Fabr_MQ-- REFERENCIA

--Drop Table #Paso_Operaciones
--Drop Table #Paso_Maquinas

--Select * From #Paso_Maquinas Order by Idpotpr

-- Promedio de los productos en mesón en forma efectiva
/*
Select Codmeson,Nommeson,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.',[Prom.Carga SubOt],[Prom.Carga xPiezas]
From #Paso_Operaciones
Group By Codmeson,Nommeson,[Prom.Carga SubOt],[Prom.Carga xPiezas]

Select Codmeson,Nommeson,FMPR,NOKOFM,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.',[Prom.Carga SubOt],[Prom.Carga xPiezas]
From #Paso_Operaciones
Group By Codmeson,Nommeson,FMPR,NOKOFM,[Prom.Carga SubOt],[Prom.Carga xPiezas]

Select Codmeson,Nommeson,FMPR,NOKOFM,PFPR,NOKOPF,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.',[Prom.Carga SubOt],[Prom.Carga xPiezas]
From #Paso_Operaciones
Group By Codmeson,Nommeson,FMPR,NOKOFM,PFPR,NOKOPF,[Prom.Carga SubOt],[Prom.Carga xPiezas]

Select Codmeson,Nommeson,FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.',[Prom.Carga SubOt],[Prom.Carga xPiezas]
From #Paso_Operaciones
Group By Codmeson,Nommeson,FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,[Prom.Carga SubOt],[Prom.Carga xPiezas]

Select Codmeson,Nommeson,FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,Codigo,DescripcionPr As Descripcion,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.',[Prom.Carga SubOt],[Prom.Carga xPiezas]
From #Paso_Operaciones
Group By Codmeson,Nommeson,FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,Codigo,DescripcionPr,[Prom.Carga SubOt],[Prom.Carga xPiezas]

Select Numot,REFERENCIA, Codmeson,Nommeson,FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,Codigo,DescripcionPr As Descripcion,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.',[Prom.Carga SubOt],[Prom.Carga xPiezas]
From #Paso_Operaciones
Group By Codmeson,Nommeson,FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,Codigo,DescripcionPr,Numot,REFERENCIA,[Prom.Carga SubOt],[Prom.Carga xPiezas]
*/

-- Promedio de los productos en mesón de forma efectiva

--Select FMPR,NOKOFM,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.'
--From #Paso_Operaciones
--Group By FMPR,NOKOFM

--Select FMPR,NOKOFM,PFPR,NOKOPF,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.'
--From #Paso_Operaciones
--Group By FMPR,NOKOFM,PFPR,NOKOPF

--Select FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.'
--From #Paso_Operaciones
--Group By FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF

--Select FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,Codigo,DescripcionPr As Descripcion,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.'
--From #Paso_Operaciones
--Group By FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,Codigo,DescripcionPr

--Select FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,Codigo,DescripcionPr As Descripcion,Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.'
--From #Paso_Operaciones
--Group By FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,Codigo,DescripcionPr


Drop Table #Paso_Operaciones
Drop Table #Paso_Maquinas

-- Solo incorporar al tratamiento dias habiles OK
-- Incorporar tiempo efectivo en maquina para ver diferencias entre tiempo en mesón vs maquina Ok
-- Incorporar cantidad de productos o Sub OT que estaban antes de ingresar un producto al mesón OK