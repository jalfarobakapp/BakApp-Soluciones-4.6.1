Declare @Id_DocEnc int 

Select @Id_DocEnc = #Id_DocEnc#   

Select Top 1 *,
       ISNULL((Select Top 1 NOTIDO From TABTIDO Where TipoDoc = TIDO),'') As 'TipoDocumento',
	   --CONVERT(NVARCHAR, CONVERT(datetime, (EDO.HORAGRAB*1.0/3600)/24), 108) AS HORA,
	   CAST('' AS Varchar(10)) As NUMECOM,
       '' As 'Ent_Fisica',
       '' As 'Razon_Fisica',
       'No' As 'Electronico',
       'Vigente' As 'Estado' 

From #Base_Bakapp#Zw_Casi_DocEnc WITH ( NOLOCK )  
Where  Id_DocEnc = @Id_DocEnc  


Select 
        Id_DocDet,
        Id_DocEnc,
		SUBSTRING(NroLinea,4,2) AS Item,
        Empresa,            -- Empresa de la linea
        Sucursal,           -- Sucursal de la linea
        Bodega,             -- Bodega de la linea
		CodVendedor,        -- Vendedor
		NroLinea,           -- Nro. linea
        Codigo,             -- Código producto
        Descripcion,        -- Descripcion producto
        Rtu,                -- Rtu
        UnTrans,            -- Unidad de transaccion (Número)
        UdTrans,            -- Unidad de transaccion (Caracter)
        CASE WHEN Tict = '' 
           THEN
            CASE
              WHEN UnTrans = 1 
              THEN CantUd1
              ELSE CantUd2
            END     
           ELSE 0
        END AS Cantidad,    -- Unidad de transaccion (Caracter)
        Ud01PR,             -- Unidad 1
        Ud02PR,             -- Unidad 2
        CantUd1,            -- Cantidad documento Ud1
        CantUd2,            -- Cantidad documento Ud1
        0 As Saldo,         -- Saldo Cantidad
        CodLista,           -- Lista de precios de la línea
        Moneda,             -- Moneda de la línea
        Tipo_Moneda,        -- Tipo de Moneda, Nacional o Extranjera
        Tipo_Cambio,        -- Tipo de cambio
        PrecioNetoUd,       -- Precio Neto del producto Unidad de venta
        PrecioBrutoUd,      -- Precio Bruto del producto Unidad de venta
        PmLinea,            -- Costo Promedio al momento de la transacción, por documento
        DescuentoPorc,      -- Porcentaje de descuento de la linea 
         CASE 
            WHEN DescuentoPorc > 0 
            THEN DescuentoPorc/100 
            ELSE 0
         END AS Pc_Desc,    -- Porcentaje de descuento de la linea 
        ValNetoLinea,       -- Valor Neto descuento de la linea 
		PorIva,             -- Porcentaje IVA
		PorIla,             -- Porcentaje Otros Impuestos
		ValIvaLinea,	    -- Valor IVA linea	
		ValIlaLinea,        -- Valor Otros Impuestos linea
        ValNetoLinea,       -- Valor Neto de la linea (total neto)
        ValBrutoLinea,      -- Valor Bruto de la linea (total bruto)
     
		Tipr,		        -- Tipo de producto	
		Prct,	            -- Es producto (0) o concepto (1)
		Tict,		        -- Tipo de Concepto (R) Recargo, (D) Descuento
		'' As 'Estado',
		Observa,            -- Observacion de la linea

		CodigoProv,         -- Código alternativo del proveedor
        Potencia
			  
   From #Base_Bakapp#Zw_Casi_DocDet
   Where  
        Id_DocEnc = @Id_DocEnc  
        ORDER BY Id_DocDet
        
Select * From #Base_Bakapp#Zw_Casi_DocObs
Where Id_DocEnc = @Id_DocEnc      

        
