Select SULIDO,SUCURSAL,Sum(CAPRCO#Ud#) As CAPRCO#Ud#,Sum(PPPRNERE#Ud#) As PPPRNERE#Ud#
From #Tabla_Paso#
Group By SULIDO,SUCURSAL
Union 
Select 'ZZZ','TOTAL',Sum(CAPRCO#Ud#),Sum(PPPRNERE#Ud#)
From #Tabla_Paso#