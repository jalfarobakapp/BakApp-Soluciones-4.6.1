

Select *,
       Case Tipo_Doc_As When 'BLV' Then 'BOLETA' Else 'FACTURA' End As Tipo,
       NroDoc_Doc_As,
       Isnull((Select Top 1 NOKOEN From MAEEN Where KOEN = CodEntidad And SUEN = SucEntidad),'') As Razon,
       Case 
                When Estado = 'M' Then 'Marcado' -- Marcada en caja para ser trabajada, aun no rebaja stock
                When Estado = 'A' Then 'Activo'  -- Marcada por Despacho, devuelve el stock del documento a la bodega para hacer GDV
                When Estado = 'C' Then 'Cerrado' -- Completa con todos los productos despachados, sin saldo
                When Estado = 'N' Then 'Nulo'    -- Nula, no se puede volver a usar el vale, se debe crear otro para el documento.
       End
       as 'NomEstado',
       Case     When Id_Doc_As <> 0 Then (Select Case When CAPREX > 0 Then CAPREX/CAPRCO Else 0 End From MAEEDO 
                                          Where IDMAEEDO = Id_Doc_As) 
                Else 0
       End 
       As 'PorcCumplimiento'                               
From Zw_Vales_Enc
Where 1 > 0

#Filtro_Consulta#		  

--Case When CAPREX > 0 Then CAPREX/CAPRCO Else 0 End As 'PorcCumplimiento',
	   

			  