

SELECT Mdc.IDMAEDPCE,
       Mdc.TIDP AS TIPO_DOC, 
       Mdc.EMDP AS COD_BANCO, 
       (Select Top 1 NOKOENDP From TABENDP Where KOENDP = Mdc.EMDP And TIDPEN = 'CH') As NOM_BANCO,
       Mdc.NUCUDP AS N_DOC,
       Mdc.ENDP AS KOEN, 
       Mae.NOKOEN AS NOKOEN, 
       Mdc.FEVEDP, 
       Mdc.VADP AS MONTO, 
       Mdc.CUDP AS CUENTA
       Into #Paso_Cartera
FROM   dbo.MAEDPCE Mdc INNER JOIN
       dbo.MAEEN Mae ON Mdc.ENDP = Mae.KOEN
WHERE Mdc.TIDP In ('CHV') AND (Mdc.FEVEDP > GETDATE() Or Mdc.ESPGDP In ('P','R') ) 
#Filtro_Entidad#

Select * From #Paso_Cartera
Order By FEVEDP

Drop Table #Paso_Cartera
