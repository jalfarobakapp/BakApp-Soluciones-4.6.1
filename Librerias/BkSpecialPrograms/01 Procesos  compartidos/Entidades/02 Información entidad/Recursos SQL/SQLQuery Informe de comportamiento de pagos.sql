-- COMPORTAMIENTO DE PAGO

SELECT  Edo.IDMAEEDO, 
        Edo.TIDO AS TIPO_DOC, 
        Edo.NUDO AS NO_DOC, 
        Edo.ESPGDO AS ESTADO_PAGO,
        Edo.ENDO AS CODIGO, 
        Me.NOKOEN AS CLIENTE, 
        Edo.FEEMDO AS EMISION, 
        Edo.FEULVEDO AS FECHA_VCMTO, 
        DATEDIFF(d,Edo.FEEMDO,Edo.FEULVEDO) as DIAS_VCTO,
        CASE 
		    WHEN Edo.TIDO = 'NCV' THEN Edo.VABRDO * - 1 
		    ELSE Edo.VABRDO * 1 
		END AS VALOR_DOCTO, 
        CASE 
            WHEN Edo.TIDO = 'NCV' THEN Edo.VAABDO * - 1 
            ELSE Edo.VAABDO * 1 
        END AS ABONOS, 
        CASE 
            WHEN Edo.TIDO = 'NCV' THEN (Edo.VABRDO - Edo.VAABDO) * - 1 
            ELSE (Edo.VABRDO - Edo.VAABDO) * 1 
        END AS SALDO_DOCTO, 
        Mpc.TIDP AS TDP, 
        Mpc.NUCUDP AS NUCUDP, 
        Mpd.VAASDP AS MONTO_DP, 
        Mpc.FEVEDP AS FEC_VCMTO, 
        DATEDIFF(d,Edo.FEULVEDO,Mpc.FEVEDP) as DIAS_PAGO,
        CAST(0 as Float) As DIAS_REAL_PAGO,
        CAST(0 As Float) As MAX_DIAS_REAL_PAGO,
        Cast(GetDate() As Datetime) As FECHA_ULT_PAGO
        Into #Paso_Informe_Ep
FROM     dbo.MAEEN Me FULL OUTER JOIN
                      dbo.MAEEDO Edo LEFT OUTER JOIN
                      dbo.MAEDPCD Mpd INNER JOIN
                      dbo.MAEDPCE Mpc ON 
						Mpd.IDMAEDPCE = Mpc.IDMAEDPCE ON 
						Edo.IDMAEEDO = Mpd.IDRST ON 
						Me.KOEN = Edo.ENDO AND 
                      Me.SUEN = Edo.SUENDO
WHERE  
      Edo.ESDO <> 'N'
	   #Filtro_Entidad#
	  AND Edo.TIDO IN ('FCV','FDV','NCV')
	  --ORDER BY CODIGO, Edo.ESDO

Update #Paso_Informe_Ep Set DIAS_REAL_PAGO = DIAS_PAGO+DIAS_VCTO
Update #Paso_Informe_Ep Set MAX_DIAS_REAL_PAGO = (Select MAX(DIAS_REAL_PAGO) 
                            From #Paso_Informe_Ep TblP Where TblP.IDMAEEDO = #Paso_Informe_Ep.IDMAEEDO)
Update #Paso_Informe_Ep Set FECHA_ULT_PAGO = (Select MAX(FEC_VCMTO) 
                            From #Paso_Informe_Ep TblP Where TblP.IDMAEEDO = #Paso_Informe_Ep.IDMAEEDO) 

-- NIVEL DOCUMENTO
Select Distinct IDMAEEDO,TIPO_DOC,NO_DOC,ESTADO_PAGO,VALOR_DOCTO,EMISION,FECHA_VCMTO,DIAS_VCTO,FECHA_ULT_PAGO,MAX_DIAS_REAL_PAGO 
From #Paso_Informe_Ep
Where 1 > 0 
#Filtro_2#
Order By EMISION

-- NIEVEL DETALLE
Select * From #Paso_Informe_Ep
Where 1 > 0 
#Filtro_2#
Order By EMISION




Drop Table #Paso_Informe_Ep