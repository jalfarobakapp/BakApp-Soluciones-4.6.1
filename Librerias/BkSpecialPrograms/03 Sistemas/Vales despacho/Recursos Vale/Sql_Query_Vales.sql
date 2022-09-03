Declare @NroVale Int = #NroVale#,
        @Porc_cumpl Float



Select *,
       Isnull((Select Top 1 NOKOEN From MAEEN Where KOEN = CodEntidad And SUEN = SucEntidad),'') As Razon,
       Case 
                When Estado = 'M' Then 'Marcado' -- Marcada en caja para ser trabajada, aun no rebaja stock
                When Estado = 'A' Then 'Activo'  -- Marcada por Despacho, devuelve el stock del documento a la bodega para hacer GDV
                When Estado = 'C' Then 'Cerrado' -- Completa con todos los productos despachados, sin saldo
                When Estado = 'N' Then 'Nulo'    -- Nula, no se puede volver a usar el vale, se debe crear otro para el documento.
       End
       as 'NomEstado',
       	Case 
                When Tipo_Entrega = 'C' Then 'RETIRA CLIENTE' 
                When Tipo_Entrega = 'D' Then 'DESPACHO A DOMICILIO' 
       End 
       As 'TEntrega'	
From Zw_Vales_Enc
	   Where NroVale = @NroVale				  
					  
Select * From Zw_Vales_Obs Where NroVale = @NroVale

-- CAPREX es el campo que suma los despachos realizados con guia
-- CAPRAD es el campo que suma los despachos realizados con el documento propiamente tal
-- CAPRCO es el campo que suma el total de las cantidades del documento

Select (Select top 1 NOTIDO From TABTIDO TDO Where TDO.TIDO = EDO.TIDO) As Tipo,*,
        Case 
             When ESDO = 'C' Then CAPRAD/CAPRCO 
             Else 
                 Case 
                     When CAPREX > 0 Then CAPREX/CAPRCO 
                     Else 0 
                 End
        End          
        As 'PorcCumplimiento',
       (Select Distinct Count(TIDOPA) From MAEDDO DDO 
        Where DDO.TIDOPA = EDO.TIDO And DDO.NUDOPA = EDO.NUDO AND DDO.TIDO = 'GDV') As 'Guias',
       (Select Distinct Count(TIDOPA) From MAEDDO DDO 
        Where DDO.TIDOPA = EDO.TIDO And DDO.NUDOPA = EDO.NUDO AND DDO.TIDO = 'NCV') As 'NCredito'  
From MAEEDO EDO Where IDMAEEDO = (Select Id_Doc_As From Zw_Vales_Enc Where NroVale = @NroVale)

Select *,
       CASE WHEN UDTRPR = 1 THEN
                        UD01PR
                   ELSE UD02PR
              END     
              AS 'UD', -- Unidad de transaccion (Caracter)
              CASE WHEN TICT = '' THEN
                   CASE
                        WHEN UDTRPR = 1 THEN
                             CAPRCO1
                        ELSE CAPRCO2
                   END     
                   ELSE 0
              END 
              AS 'CANTIDAD',
              CASE 
                   WHEN ESLIDO = 'C' AND UDTRPR = 1 THEN
                        CAPRAD1
                   WHEN ESLIDO = 'C' AND UDTRPR = 2 THEN
                        CAPRAD2
                   ELSE          
                        CASE
                             WHEN UDTRPR = 1 THEN
                             CAPREX1
                        ELSE CAPREX2
                        END
              END               
              AS 'DESPACHADO', -- Cantidad Despachada
              CASE 
                   WHEN ESLIDO = 'C' THEN 0
                   ELSE          
                        CASE
                             WHEN UDTRPR = 1 THEN
                                  (CAPRCO1-CAPREX1)
                             ELSE (CAPRCO2-CAPREX2)
                        END
              END               
              AS 'SALDO', -- Saldo Cantidad 
              Isnull((Select top 1 RLUD From MAEPR Where KOPR = KOPRCT),'') as 'RTU',
              Isnull((Select top 1 KOPRTE From MAEPR Where KOPR = KOPRCT),'') as 'COD_TECNICO'
 From MAEDDO Where IDMAEEDO = (Select Id_Doc_As From Zw_Vales_Enc Where NroVale = @NroVale)



			  