
-- Informe de estado de avance de OT segun operaciones realizadas
Select POTPR.NUMOT,Cast('' As Varchar(100)) As REFERENCIA,
       Cast(Null As date) As FIOT,
       Cast(0 As Int) As Dias_Transc,
       Cast(0 As Int) As Dias_Hb,
	   Cast(0 As Int) As Dias_Sb,
	   Cast(0 As Int) As Dias_Dm,
    --   Sum(POTL.FABRICAR) As Fabricar,
	   --Sum(POTL.REALIZADO) As Realizado,
	   (Select Sum(FABRICAR) From POTL Where POTPR.NUMOT = POTL.NUMOT) As Fabricar,
	   (Select Sum(REALIZADO) From POTL Where POTPR.NUMOT = POTL.NUMOT) As Realizado,
	   ----POTL.FABRICAR As Fabricar,
	   --POTL.REALIZADO As Realizado,

       SUM(Case When POTPR.REALIZADO >= POTPR.FABRICAR Then 1 Else 0 End) As Operaciones_Realizadas,
	   Sum(Cast(1 As Float)) As Cant_Operaciones,
	   Sum(Case When POTPR.REALIZADO <= POTPR.FABRICAR Then POTPR.REALIZADO Else POTPR.FABRICAR End) As Fabricar_SubOt,--Cast(0 As Float) As Avance_OT 
	   Cast(0 As int) As Realizado_SubOt--(Select FABRICAR From POTD Z2 Where Z1.IDPOTL = Z2.IDPOTL) As Fabricar_SubOt
	   --Sum(FABRICAR) As Fabricar_SubOt
Into #Paso1 
From POTPR 
--Inner Join POTL On POTL.IDPOTL = POTPR.IDPOTL
Where 1 > 0 
--And NUMOT = ''
And POTPR.NUMOT In (Select NUMOT From POTE Where ESODD = '')-- And ESTADO = 'V')
Group By POTPR.NUMOT--,POTL.FABRICAR,POTL.REALIZADO

Update #Paso1 Set FIOT = (Select FIOT From POTE Z2 Where Z1.NUMOT = Z2.NUMOT)
From #Paso1 Z1

Update #Paso1 Set Dias_Transc = Datediff(D,FIOT,Getdate())

Update #Paso1 Set REFERENCIA = (Select REFERENCIA From POTE Where POTE.NUMOT = #Paso1.NUMOT)
--Update #Paso1 Set Fabricar_SubOt = (Select REFERENCIA From POTE Where POTE.NUMOT = #Paso1.NUMOT)



-- 
Select POTPR.*,CAST('' As VARCHAR(50)) As DESCRIPCION_PR,POPER.NOMBREOP,POPER.UDAD,POPER.OBREROS,POPER.CODMAQ,PVELPROP.NOOPPR,PVELPROP.CODMAQOPPR,
       Cast('' As varchar(50)) As NOMBREMAQ,
       Cast('' As Varchar(5)) As PERTENECE,  
       Isnull(Porc_Avance_Saldo_Fab,0) As Porc_Avance_Saldo_Fab
Into #Paso
From POTPR WITH ( NOLOCK ) 
Left Outer Join POPER ON POTPR.OPERACION=POPER.OPERACION 
Left Outer Join PVELPROP ON POTPR.OPERACION=PVELPROP.OPERACION AND POTPR.CODIGO = PVELPROP.KOPR
Left Outer Join #Base_Bakapp#Zw_Pdp_MesonVsProductos Pm On Pm.Idpotpr = IDPOTPR
Where 1 > 0 
--And NUMOT = ''


Update #Paso Set DESCRIPCION_PR = (Select Top 1 NOKOPR From MAEPR Where KOPR = CODIGO)
Update #Paso Set NOMBREMAQ = (Select Top 1 NOMBREMAQ From PMAQUI Z2 Where Z2.CODMAQ = Z1.CODMAQ) From #Paso Z1
Update #Paso Set PERTENECE = (Select top 1 PERTENECE From POTD Z2 Where Z2.IDPOTL = Z1.IDPOTL And NIVEL > 0)
From #Paso Z1

Select Distinct Cast('' As Varchar(20)) As NUMOT_PERTENECE,IDPOTL,
       Cast(0 As int) As NIVEL,
       Cast('' As Varchar(5)) As PERTENECE,Cast('' As Char(1)) As MARCANOM,
       NUMOT,NREGOTL,CODIGO,DESCRIPCION_PR,
	   Cast(0 As Float) As FABRICAR,
	   Cast(0 As Float) As REALIZADO,
	   Cast(0 As Float) As Porc_Avance,
	   Cast(0 As Float) As Cant_Operaciones,
	   Cast(0 As Float) As Operaciones_Realizadas,
	   Cast(0 As Float) As Av_Op
Into #Paso2
From #Paso
Group By IDPOTL,NUMOT,NREGOTL,CODIGO,DESCRIPCION_PR,FABRICAR,REALIZADO
Order By NREGOTL


Update #Paso2 Set FABRICAR =Isnull((Select Top 1 Fabricar From #Base_Bakapp#Zw_Pdp_MesonVsProductos Z1 Where IDPOTL = Z1.Idpotl),0) 
Update #Paso2 Set REALIZADO = Isnull((Select Top 1 Fabricado From #Base_Bakapp#Zw_Pdp_MesonVsProductos Z1 Where IDPOTL = Z1.Idpotl And Estado = 'PT'),0) 

Update #Paso2 Set Porc_Avance = Round(REALIZADO/FABRICAR,2) Where FABRICAR > 0 

Update #Paso2 Set NIVEL = (Select NIVEL From POTL Z2 Where Z1.IDPOTL = Z2.IDPOTL)
From #Paso2 Z1
Update #Paso2 Set MARCANOM = (Select TOP 1 MARCANOM From POTD Z2 Where Z1.IDPOTL = Z2.IDPOTL AND Z1.NREGOTL = Z2.NREG AND Z2.MARCANOM <> '')
From #Paso2 Z1
Update #Paso2 Set PERTENECE = ISNULL((Select TOP 1 PERTENECE From POTD Z2 Where  Z1.CODIGO = Z2.CODIGO AND Z1.NIVEL = 1),Z1.NREGOTL)
From #Paso2 Z1
Update #Paso2 Set NUMOT_PERTENECE = NUMOT+'_'+PERTENECE

Update #Paso2 Set Cant_Operaciones = Isnull((Select Count(*) From POTPR Z2 Where Z2.IDPOTL = Z1.IDPOTL),0),
                  Operaciones_Realizadas = Isnull((Select Count(*) From #Base_Bakapp#Zw_Pdp_MesonVsProductos Where Idpotl = IDPOTL And Fabricar-Fabricado = 0),0)
From #Paso2 Z1

Update #Paso2 Set Av_Op = Case When Cant_Operaciones <> 0 Then Round(Operaciones_Realizadas/Cant_Operaciones,4) Else 0 End


Select  Pd.IDPDATFAD,IDPDATFAE,ARCHIRST,IDRST,Pd.EMPRESA,NUMDF,NUMOT,NUMODC,Pd.OPERACION,
        --Op.NOMBREOP,
        Pd.CODMAQ,Mq.NOMBREMAQ,FECHA,NREGOTL,CODIGO,OBRERO,NOMBREOB,Pd.UDAD,REALJOR,FECHINI,
        HORAINI,FECHTER,HORATER,TIEMPO
		--OBRERO1,OBRERO2,OBRERO3,OBRERO4,OBRERO5,OBRERO6,ESULTOPER,UDAD2,REALJOR2,RLUD
		,Mqb.Porc_Avance_Saldo_Fab,Mqb.Porc_Fabricacion,Pd.KOCAUDET,Isnull(Tc.NOCAUDET,'') As NOCAUDET
        --,FACTOR,IDGDI,KOMOLDE,CAVIUSADAS,CICLOUSADO,IDOCCOPEXT,NUDOOCC
Into #Paso3
From   PDATFAD Pd
Left Join PMAQUI Mq On Mq.CODMAQ = Pd.CODMAQ
Inner Join POBREFAD Pf On Pd.IDPDATFAD = Pf.IDPDATFAD
Inner Join PMAEOB Ob On Pf.OBRERO = Ob.CODIGOOB
--Inner Join POPER Op On Pd.OPERACION = Op.OPERACION
Left Join TCAUDET Tc On Tc.KOCAUDET = Pd.KOCAUDET 
Left Join #Base_Bakapp#Zw_Pdp_MaquinaVsProductos Mqb On Pd.IDPDATFAE = Mqb.Idpdatfae
Where ARCHIRST = 'POTPR' And IDRST IN (Select IDPOTPR From #Paso)

Select  IDOBREFAD,IDPDATFAD,OBRERO,FECHINIOB,HORAINIOB,FECHTEROB,HORATEROB,TIEMPOOB,VALHORA,VALUNID,VALADI1,VALADI2,KOJORNADA,TIEMPOOBHE
Into #Paso4
From   POBREFAD
Where IDPDATFAD In (Select IDPDATFAD From #Paso3)



----------------------------
--Select * From #Paso

Select *,Round(Realizado/Fabricar,4) As Av_Fb_Ot,
         Round(Operaciones_Realizadas/Cant_Operaciones,4) As Av_Op,
         Case When Fabricar_SubOt > 0 then Round(Realizado_SubOt/Fabricar_SubOt,4) Else 0 End As Av_Fb_Partes_SubOt
From #Paso1

Select *
From #Paso2 Z1
--Where NIVEL = 0



Select * From #Paso2 Order By NIVEL,PERTENECE

Select IDPOTPR,IDPOTL,EMPRESA,NUMOT,NREGOTL,CODIGO,DESCRIPCION_PR,ORDEN,OPERACION,NOMBREOP,CODMAQ,NOMBREMAQ,FABRICAR,REALIZADO,
       Case When REALIZADO <> 0 Then REALIZADO/FABRICAR Else 0 End As Porc_Avance,Porc_Avance_Saldo_Fab
From #Paso
Order By NREGOTL,ORDEN

Select * From #Paso3
Select * From #Paso4

Drop Table #Paso
Drop Table #Paso1
Drop Table #Paso2
Drop Table #Paso3
Drop Table #Paso4
