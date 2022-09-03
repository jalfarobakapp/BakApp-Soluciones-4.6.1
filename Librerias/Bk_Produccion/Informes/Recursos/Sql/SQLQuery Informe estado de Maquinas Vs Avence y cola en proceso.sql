
Select IDPOTPR,IDPOTL,NUMOT,Cast('' As varchar(100)) As REFERENCIA,NREGOTL,CODIGO,Cast('' As varchar(50)) As DESCRIPCION_PR,OPERACION,Cast('' As Varchar(50)) As NOMBREOP,CODMAQOT,
       (Select NOMBREMAQ From PMAQUI Where CODMAQ = CODMAQOT) As MAQUINA,FABRICAR,REALIZADO,Cast(0 As Float) AS AVANCE 
Into #Paso1	   
From POTPR
Where NUMOT In (Select NUMOT From POTE Where ESODD = '' And ESTADO = 'V')

Update #Paso1 Set REFERENCIA = (Select Top 1 REFERENCIA From POTE Z2 Where Z1.NUMOT = Z2.NUMOT)
From #Paso1 Z1

Update #Paso1 Set NOMBREOP = (Select Top 1 NOMBREOP From POPER Z2 Where Z1.OPERACION = Z2.OPERACION),
                  DESCRIPCION_PR = (Select Top 1 NOKOPR From MAEPR Z3 Where Z1.CODIGO = Z3.KOPR)
From #Paso1 Z1

Update #Paso1 Set REALIZADO = FABRICAR Where REALIZADO > FABRICAR
Update #Paso1 Set AVANCE = FABRICAR-REALIZADO

Select CODMAQOT,MAQUINA,Sum(FABRICAR) As FABRICAR,Sum(REALIZADO) As REALIZADO,Cast(0 As Float) As Porc_Fabricado,Cast(0 As Float) As Porc_Cola
Into #Paso2
From #Paso1 
Group By CODMAQOT,MAQUINA


Update #Paso2 Set Porc_Fabricado = Round((REALIZADO*1.0/FABRICAR*1.0),2)
Update #Paso2 Set Porc_Cola = 1-Porc_Fabricado

Select * From #Paso2
Order By CODMAQOT

Select * From #Paso2
Union 
Select CODMAQ As CODMAQOT, NOMBREMAQ As MAQUINA,0,0,0,0 From PMAQUI Where CODMAQ Not IN (Select CODMAQOT From #Paso1)
Order By CODMAQOT

Select * From #Paso1 
Order By CODMAQOT,NUMOT,NREGOTL


Drop Table #Paso1
Drop Table #Paso2

