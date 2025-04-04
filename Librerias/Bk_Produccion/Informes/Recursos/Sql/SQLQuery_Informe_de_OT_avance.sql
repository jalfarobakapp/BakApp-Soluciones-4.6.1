
-- Informe de estado de avance de OT segun operaciones realizadas
Select NUMOT,Cast('' As Varchar(100)) As REFERENCIA,
       Cast(Null As date) As FIOT,
       Cast(0 as Int) As Dias_Transc,
       Cast(0 As Int) As Dias_Hb,
	   Cast(0 As Int) As Dias_Sb,
	   Cast(0 As Int) As Dias_Dm,
       (Select Sum(FABRICAR) From POTL Where Z1.NUMOT = POTL.NUMOT) As Fabricar,
	   (Select Sum(REALIZADO) From POTL Where Z1.NUMOT = POTL.NUMOT) As Realizado,
       SUM( Case When REALIZADO >= FABRICAR Then 1 Else 0 End) As Operaciones_Realizadas,
	   Sum(Cast(1 As Float)) As Cant_Operaciones,
	   Sum(Case When REALIZADO <= FABRICAR Then REALIZADO Else FABRICAR End) As Fabricar_SubOt,--Cast(0 As Float) As Avance_OT 
	   Cast(0 As int) As Realizado_SubOt--(Select FABRICAR From POTD Z2 Where Z1.IDPOTL = Z2.IDPOTL) As Fabricar_SubOt
	   --Sum(FABRICAR) As Fabricar_SubOt
Into #Paso1 
From POTPR Z1
WHERE 1 > 0 --And NUMOT = '0000025437'
And NUMOT In (Select NUMOT From POTE Where ESODD = '' And ESTADO = 'V')
Group By NUMOT

Update #Paso1 Set FIOT = (Select FIOT From POTE Z2 Where Z1.NUMOT = Z2.NUMOT)
From #Paso1 Z1

Update #Paso1 Set Dias_Transc = Datediff(D,FIOT,Getdate())

Update #Paso1 Set REFERENCIA = (Select REFERENCIA From POTE Where POTE.NUMOT = #Paso1.NUMOT)
--Update #Paso1 Set Fabricar_SubOt = (Select REFERENCIA From POTE Where POTE.NUMOT = #Paso1.NUMOT)

Select *,Round(Realizado/Fabricar,4) As Av_Fb_Ot,
         Round(Operaciones_Realizadas/Cant_Operaciones,4) As Av_Op,
         Case When Fabricar_SubOt > 0 then Round(Realizado_SubOt/Fabricar_SubOt,4) Else 0 End As Av_Fb_Partes_SubOt
From #Paso1
Drop Table #Paso1

