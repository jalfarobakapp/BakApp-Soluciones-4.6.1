Declare @NroVale Int = #NroVale#

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
       As 'TEntrega',
       Isnull((Select top 1 NOKOFU From TABFU Where KOFU = Funcionario_Marca),'') as 'Nom_Funcionario_Marca',
       Isnull((Select top 1 NOKOFU From TABFU Where KOFU = Funcionario_Activa),'') as 'Nom_Funcionario_Activa'	
From Zw_Vales_Enc
	   Where NroVale = @NroVale				  
					  
Select * From Zw_Vales_Obs Where NroVale = @NroVale

					  