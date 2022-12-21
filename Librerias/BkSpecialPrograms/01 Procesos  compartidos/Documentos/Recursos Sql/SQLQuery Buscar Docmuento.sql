SELECT  Top #CantidadDoc#
        Cast(0 As Bit) As Chk,
        IDMAEEDO,
        Edo.TIDO,
        --ISNULL((SELECT TOP 1 NOTIDO FROM TABTIDO WHERE TIDO = MAEEDO.TIDO),'') AS 'TipoDoc',
        Isnull(Tid.NOTIDO,'') As 'TipoDoc',
		NUDO,
        ENDO,
        SUENDO,
        --ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = ENDO AND SUEN = SUENDO ),'') AS RAZON,
        Isnull(Mae1.NOKOEN,'') As RAZON,
		ENDOFI,
        #Campo_SUENDOFI#
        --ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = ENDOFI ),'') AS RAZON_FISICA,
        Isnull(Mae2.NOKOEN,'') As RAZON_FISICA,
		FEEMDO,
        FEULVEDO,
        KOFUDO,
        SUDO,
		Isnull(NOKOSU,'Suc ???') As NOKOSU,
        CASE 
            WHEN ESDO = '' THEN 'Vigente'
            WHEN ESDO = 'C' THEN 'Cerrado'
            WHEN ESDO = 'N' THEN 'Nulo'
            ELSE 'Otro' 
		End As ESTADO,
        Edo.EMPRESA,
        CASE 
            WHEN NUDONODEFI = 0 THEN 'Definitivo'
            WHEN NUDONODEFI = 1 THEN 'Transitorio'
            ELSE 'Otro' 
		End As NRO_DEF,
        NUDONODEFI,
		ESPGDO,
		MODO,
		VABRDO,
		VABRDO-VAABDO AS SALDO_ACTUAL,
		VAABDO,
        Edo.TIDOELEC
     FROM MAEEDO Edo WITH ( NOLOCK )    
		Left Join TABSU Tsu On Edo.EMPRESA = Tsu.EMPRESA And Edo.SUDO = Tsu.KOSU 
			Left Join MAEEN Mae1 On Edo.ENDO = Mae1.KOEN And Edo.SUENDO = Mae1.SUEN 
				--Left Join MAEEN Mae2 On Edo.ENDOFI = Mae2.KOEN 
                #Left_Join_MAEEN_ENDOFI_SUENDOFI#
					Left Join TABTIDO Tid On Edo.TIDO = Tid.TIDO 
        WHERE  
             Edo.EMPRESA = '#Empresa#' 
			 #SucursalDocumento#    --AND TIDO='COV'  
			 #TipoDocumento#        --AND TIDO='COV'  
			 #NroDocumento#         --AND NUDO IN ('')
			 #Entidad#              --AND ENDO='15463484'  AND SUENDO = '' 
             #Fecha#                --AND FEEMDO BETWEEN '20140714' AND '20140714'
             #Estado#               --AND ESDO = '' 
             #Otro_Filtro#          -- Otro filtro adicional, extra
             #Funcionario#          -- AND KODU IN ('')
             #Producto#             -- AND KODU IN ('')
             #Observaciones#
             #ValesTransitorios#    -- AND NUDONODEFI In (0,1)

    #Orden#