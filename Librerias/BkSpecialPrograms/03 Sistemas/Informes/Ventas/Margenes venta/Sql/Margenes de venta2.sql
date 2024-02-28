declare 
@Empresa     Char(2),
@Sucursal    Char(3),
@Bodega      Char(3),
@Fecha1      Date,
@Fecha2      Date,
@Ila         Float,
@Opcion      Int,
@ListaCosto  Char(3),
@Funcionario Char(3),
@Nodo_Raiz   Int

Select @Funcionario = '#_Funcionario_Activo#',
       @Opcion = #Opcion#,
       @Fecha1 = '#Fecha1#',
       @Fecha2   = '#Fecha2#',
       @Empresa  = '#Empresa#', 
       @ListaCosto = '#ListaCosto#',
       @Nodo_Raiz = #Nodo_Raiz#

--BEGIN TRY

--  BEGIN TRANSACTION
    
CREATE TABLE #Zw_TblDetalle_Venta(
     Empresa           Char(2)     default '',  -- Empresa
     Sulido            Char(3)     default '',  -- Sucursal
     Bosulido          Char(3)     default '',  -- Bodega
     Tido              Char(3)     default '',  -- Tipo de documento
     Nudo              Char(10)    default '',  -- Numero de documento
     Feemli            Date        default Getdate(), -- Fecha de emisión de docuemto
     Nulido            Char(5)     default '',  -- Numero de linea del documenmto
     Koprct            Varchar(13) default '',  -- Código de producto
     Nokopr            Varchar(50) default '',  -- Descripción de producto
     CantidadUd1       Float       default (0), -- Cantidad de venta de la unidad 1
     PNetoUnit         Float       default (0), -- Precio unitario neto de la unidad 1
     CostoUnit         Float       default (0), -- Costo unitario neto de la unidad 1
     AdicImp           Float       default (0), -- Valor adicional al costo, impuestos especificos
     CostoUnitIm       Float       default (0), -- Costo mas impuestos especificos
     TotalCosto        Float       default (0), -- Valor total del costo
     TotalPrecio       Float       default (0), -- Valor total del precio neto
     Porct_Ila         Float       default (0), -- Porcentaje de Ila %
     Porct_Iva         Float       default (0), -- Porcentaje de Iva %
     Ila               Float       default (0), -- Valor Ila
     Iva               Float       default (0), -- Valor Iva
     PrecioBruto       Float       default (0), -- Precio Bruto unitario de la unidad 1
     Val_MrgUnit       Float       default (0), -- Valor unitario del margen
     Total_Mrg         Float       default (0), -- Total margen 
     Porc_Markup       Float       default (0), -- Porcentaje de Markup % (Margen de venta)
     Porc_Margen       Float       default (0), -- Porcentaje de Margen % (Margen de costo)
     Marca             Varchar(20) DEFAULT '',
	 Rubro             Varchar(20) DEFAULT '',
	 ClasLibre         Varchar(20) DEFAULT '',
	 Zona              Varchar(20) DEFAULT '',
	 SuperFamilia      Varchar(20) DEFAULT '',
	 Familia           Varchar(20) DEFAULT '',
	 SubFamilia        Varchar(20) DEFAULT '',
	 Nom_Marca         Varchar(50) DEFAULT '',
	 Nom_Rubro         Varchar(50) DEFAULT '',
	 Nom_ClasLibre     Varchar(50) DEFAULT '',
	 Nom_Zona          Varchar(50) DEFAULT '',
	 Nom_SuperFamilia  Varchar(50) DEFAULT '',
	 Nom_Familia       Varchar(50) DEFAULT '',
	 Nom_SubFamilia    Varchar(50) DEFAULT '',
	 Codigo_Nodo_Clas  Int DEFAULT (0),
	 Codigo_Madre_Clas Varchar(20) DEFAULT '',
	 Descripcion_Clas  Varchar(100) DEFAULT '',
	 Funcionario	   Char(3)     default '',
	 Vendedor		   Char(3)     default '',
	 Precio_Cambiado   Bit         default(0))   
     
   Select MAEPR.KOPR As Koprct,SUM(ISNULL(dbo.TABIM.POIM, 0)) AS Impuestos
   Into #Zw_TblMrgImp
             From         dbo.MAEPR LEFT OUTER JOIN
                          dbo.TABIMPR ON dbo.MAEPR.KOPR = dbo.TABIMPR.KOPR LEFT OUTER JOIN
                          dbo.TABIM ON dbo.TABIMPR.KOIM = dbo.TABIM.KOIM
             GROUP BY dbo.MAEPR.KOPR, dbo.MAEPR.NOKOPR 
   
  
   Insert INTO #Zw_TblDetalle_Venta (Empresa,Sulido,Bosulido,Tido,Nudo,Feemli,Nulido,Koprct,Nokopr,CantidadUd1,CostoUnit,PNetoUnit,
                            Porct_Ila,Porct_Iva,Ila,Iva,Funcionario,Vendedor,
                            Marca,Rubro,ClasLibre,Zona,SuperFamilia,Familia,SubFamilia,Precio_Cambiado)       

   Select   DDO.EMPRESA,DDO.SULIDO,DDO.BOSULIDO,DDO.TIDO,DDO.NUDO,FEEMLI,NULIDO,KOPRCT AS 'Codigo',DDO.NOKOPR AS 'Descripcion',
            ROUND(CASE 
                    WHEN DDO.TIDO IN ('NCE','NCV','NCX','NCZ','NEV') 
                    THEN - 1 * CAPRCO1
                    --Editada
				    ELSE Case When DDO.TIDO In ('GDV','GDP') Then CAPRCO1-(CAPREX1+CAPRAD1) Else CAPRCO1 End
					END,2) AS 'CantidadUd1',
			PPPRPM,
			PPPRNERE1, 
			Impuestos AS 'Porct_Ila',
			POIVLI AS 'Porct_Iva',	
			  CASE 
			      WHEN CAPRCO1 > 0 THEN	ROUND(VAIMLI/CAPRCO1,2)
			      ELSE 0 END As 'Ila',
			  CASE 
			      WHEN CAPRCO1 > 0 THEN	ROUND(VAIVLI/CAPRCO1,2)
			      ELSE 0 END As 'Iva',
           #Funcionario#,DDO.KOFULIDO,
           MAEPR.MRPR,MAEPR.RUPR,MAEPR.CLALIBPR,MAEPR.ZONAPR,MAEPR.FMPR,MAEPR.PFPR,MAEPR.HFPR,
           Case When DDO.PPPRNE < DDO.PPPRNELT Then 1 Else 0 End
           From   MAEEDO AS EDO WITH ( NOLOCK )  
	        INNER JOIN MAEDDO DDO ON DDO.IDMAEEDO=EDO.IDMAEEDO 
	        AND DDO.LILG NOT IN ( 'GR','IM' )  
	        LEFT JOIN MAEPR ON MAEPR.KOPR=DDO.KOPRCT  
	        LEFT JOIN #Zw_TblMrgImp ON #Zw_TblMrgImp.Koprct=DDO.KOPRCT  
              WHERE 
               EDO.FEEMDO BETWEEN @Fecha1 AND @Fecha2
			   AND EDO.EMPRESA=@Empresa  
			   #FiltroDocumentos#       --AND DDO.TIDO IN #FiltroDocumentos#
			   #FiltroSucursal#         --AND EDO.SULIDO IN #FiltroSucursal#
			   #FiltroFuncionarios#
			   AND NOT ( EDO.TIDO='GDV' AND DDO.ARCHIRST IN ('POTD','POTPR','POTL') )  
			   AND NOT ( EDO.TIDO='GDP' AND EDO.SUBTIDO<>'CON' )  
			   --AND MAEPR.TIPR NOT IN ('SSN','FLN')  -- NO INCLUIR PRODUCTOS TIPO SERVICIO NI MULTIPROPOSITO   
               AND DDO.PRCT=0  
               AND DDO.TICT = ''                    -- NO INCLUIR CONCEPTOS  ('R') Recargo,('D') Descuento    
               #Filtro_No_SSN_FLN#
               #FiltroProductos#
               #FiltroEntExcluidas#
               --   And  LTRIM(RTRIM(EDO.ENDO))+RTRIM(LTRIM(EDO.SUENDO))  
	           --NOT IN (Select  LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From #Tbl_EntExcluidas#
	           --        Where Funcionario = @Funcionario)
               
   
       Update #Zw_TblDetalle_Venta Set 
                       Nom_Rubro = Isnull((Select top 1 NOKORU From TABRU Where KORU = Rubro),'Sin Rubro'),
                       Nom_Marca = Isnull((Select Top 1 NOKOMR From TABMR Where KOMR = Marca),'Sin Marca'),
                       Nom_Zona = Isnull((Select Top 1 NOKOZO From TABZO Where KOZO = Zona),''),
                       Nom_SuperFamilia = Isnull((Select Top 1 NOKOFM From TABFM Where KOFM = SuperFamilia),'Sin Super Familia'),
                       Nom_Familia = Isnull((Select Top 1 NOKOPF From TABPF 
                                            Where KOFM = SuperFamilia And KOPF = Familia),'Sin Familia'),
                       Nom_SubFamilia = Isnull((Select Top 1 NOKOHF From TABHF
                                            Where KOFM = SuperFamilia And KOPF = Familia And KOHF = SubFamilia),'Sin SubFamilia'),
                       Nom_ClasLibre = Isnull((Select Top 1 NOKOCARAC From TABCARAC 
                                            Where KOTABLA = 'CLALIBPR' And KOCARAC = ClasLibre),'Sin Clas. Libre')

   
Update #Zw_TblDetalle_Venta Set Codigo_Madre_Clas = Asoc.Codigo_Madre,Codigo_Nodo_Clas = Asoc.Codigo_Nodo,Descripcion_Clas = Asoc.Descripcion
From #Zw_TblDetalle_Venta
Left Join #Global_Bakapp#Zw_Prod_Asociacion PrAsoc On Koprct = PrAsoc.Codigo
	Inner Join #Global_Bakapp#Zw_TblArbol_Asociaciones Asoc On Asoc.Codigo_Nodo = PrAsoc.Codigo_Nodo And Asoc.Nodo_Raiz = @Nodo_Raiz And Asoc.Es_Seleccionable = 1 
  
   
   
   -----  EN ESTA LINEA SE QUEDA PEGADO

   
-------------------------------------------------------------------------------------------------------------
   IF @Opcion = 1 Begin-- PM, Sistema			
      UPDATE #Zw_TblDetalle_Venta SET  
                         CostoUnit = ROUND(dbo.MAEPREM.PM,2),                                                
                         AdicImp = 
                                    Case        
                                      When Tido = 'BLV' Then 
                                      ROUND((1+(Porct_Ila/100))*dbo.MAEPREM.PM,2)-ROUND(dbo.MAEPREM.PM,2)
                                      Else 0
                                     End,
                         CostoUnitIm = 
                                     Case 
                                      When Tido = 'BLV' Then ROUND((1+(Porct_Ila/100))*dbo.MAEPREM.PM,2)
                                      Else ROUND(dbo.MAEPREM.PM,2)
                                     End                                
      From         #Zw_TblDetalle_Venta LEFT OUTER JOIN
                      dbo.MAEPREM ON Koprct  = dbo.MAEPREM.KOPR
    End                  
----------------------------------------------------------------------------------------------------------
    IF @Opcion = 2 Begin-- Ultima compra, Sistema 			
       UPDATE #Zw_TblDetalle_Venta SET  
                         CostoUnit = ROUND(dbo.MAEPREM.PPUL01,2),                                                
                         AdicImp = 
                                    Case        
                                      When Tido = 'BLV' Then 
                                      ROUND((1+(Porct_Ila/100))*dbo.MAEPREM.PPUL01,2)-ROUND(dbo.MAEPREM.PPUL01,2)
                                      Else 0
                                     End,
                         CostoUnitIm = 
                                     Case 
                                      When Tido = 'BLV' Then ROUND((1+(Porct_Ila/100))*dbo.MAEPREM.PPUL01,2)
                                      Else ROUND(dbo.MAEPREM.PPUL01,2)
                                     End                                
        From         #Zw_TblDetalle_Venta LEFT OUTER JOIN
                      dbo.MAEPREM ON Koprct  = dbo.MAEPREM.KOPR   
     End                                    

---------------------------------------------------------------------------------------------------------
    IF @Opcion = 3 Begin-- Desde Lista de precios
       UPDATE #Zw_TblDetalle_Venta SET  
                         CostoUnit = ISNULL(ROUND(dbo.TABPRE.PP01UD,2),0),                                                
                         AdicImp = 
                                    Case        
                                      When Tido = 'BLV' Then 
                                      ISNULL(ROUND((1+(Porct_Ila/100))*dbo.TABPRE.PP01UD,2)-
                                      ROUND(dbo.TABPRE.PP01UD,2),0)
                                      Else 0
                                     End,
                         CostoUnitIm = 
                                     Case 
                                      When Tido = 'BLV' Then ISNULL(ROUND((1+(Porct_Ila/100))*
                                                             dbo.TABPRE.PP01UD,2),0)
                                      Else ISNULL(ROUND(dbo.TABPRE.PP01UD,2),0)
                                     End                                
        From         #Zw_TblDetalle_Venta LEFT OUTER JOIN
                      dbo.TABPRE ON Koprct  = dbo.TABPRE.KOPR 
                      WHERE dbo.TABPRE.KOLT = @ListaCosto                     
    End

---------------------------------------------------------------------------------------------------------
    IF @Opcion = 4 Begin -- Costo Pm al momento de la transacción
       UPDATE #Zw_TblDetalle_Venta SET  
                         --CostoUnit = ISNULL(ROUND(dbo.TABPRE.PP01UD,2),0),                                                
                         AdicImp = 
                                    Case        
                                      When Tido = 'BLV' Then 
                                      ISNULL(ROUND((1+(Porct_Ila/100))*CostoUnit,2)-
                                      ROUND(CostoUnit,2),0)
                                      Else 0
                                     End,
                         CostoUnitIm = 
                                     Case 
                                      When Tido = 'BLV' Then 
                                      ISNULL(ROUND((1+(Porct_Ila/100))*CostoUnit,2),0)
                                      Else ISNULL(ROUND(CostoUnit,2),0)
                                     End                                
        
End



UPDATE #Zw_TblDetalle_Venta Set 
                   PrecioBruto =  Round(PNetoUnit+Ila+Iva,0),
                   Val_MrgUnit = PNetoUnit-CostoUnit,
                   Porc_Markup = 
                   Case when PNetoUnit > 0 then
                      ROUND(((PNetoUnit-CostoUnitIm)/PNetoUnit)* 100,3) 
                     else 0 end 
                    ,
                   Porc_Margen = 
                   Case When  CostoUnit > 0 then
                      ROUND(((PNetoUnit-CostoUnit)/CostoUnit)*100,3)
                     else 100 end ,
                   TotalCosto = ROUND(CostoUnitIm * CantidadUd1,2),
                   TotalPrecio = ROUND(PNetoUnit * CantidadUd1,2),
                   Total_Mrg = ROUND((PNetoUnit-CostoUnitIm) * CantidadUd1,2)                   



Update #Zw_TblDetalle_Venta SET 
                       Porc_Margen=Porc_Margen*-1,
                       Porc_Markup=Porc_Markup*-1
Where Tido in ('NCE', 'NCV', 'NCX', 'NCZ', 'NEV')

Select Koprct,
         MAEPR.NOKOPR As Nokopr,
         COUNT(Tido) as Documentos, 
         Round(SUM(CantidadUd1),2) as 'CantidadUd1',
         Round(SUM(TotalCosto),0) as 'TotalCosto',
         Round(SUM(TotalPrecio),0) as 'TotalPrecio',
         Round(SUM(Total_Mrg),2) as 'Total_Mrg', 
         Case When Round(SUM(TotalPrecio),0) > 0 then
               Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalPrecio),0)),3)
              Else 100 End
         As 'Porc_Markup',--'% Markup',      
         Case When Round(SUM(TotalCosto),0) > 0 then
               Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalCosto),0)),3)
              Else 100 End 
          As 'Porc_Margen',--'% Margen',
          Marca,Rubro,ClasLibre,Zona,SuperFamilia,Familia,SubFamilia,
          Nom_Marca,Nom_Rubro,Nom_ClasLibre,Nom_Zona,
          Nom_SuperFamilia,Nom_Familia,Nom_SubFamilia, 
          Codigo_Nodo_Clas,
          Codigo_Madre_Clas,
          Descripcion_Clas,
		  Cast(0 As Float) As Grupo_Mg,    
		  Cast(0 As Float) As Grupo_Mk    
	
Into #Zw_TblMargenXProducto

   From #Zw_TblDetalle_Venta
   LEFT JOIN MAEPR ON MAEPR.KOPR=Koprct
   Group By Koprct,MAEPR.NOKOPR,Marca,Rubro,ClasLibre,Zona,SuperFamilia,Familia,SubFamilia,
          Nom_Marca,Nom_Rubro,Nom_ClasLibre,Nom_Zona,
          Nom_SuperFamilia,Nom_Familia,Nom_SubFamilia,Codigo_Nodo_Clas,Codigo_Madre_Clas,Descripcion_Clas
   Order by Koprct

  Update #Zw_TblMargenXProducto Set Grupo_Mg = Round(Porc_Margen,0)
  Update #Zw_TblMargenXProducto Set Grupo_Mk = Round(Porc_Markup,0)


-- NUEVAS LINEAS

-- Por Asociaciones

Select Codigo_Nodo_Clas,
	   Codigo_Madre_Clas,
       Descripcion_Clas,
       COUNT(Tido) as Documentos, 
       Round(SUM(CantidadUd1),2) as 'CantidadUd1',
       Round(SUM(TotalCosto),0) as 'TotalCosto',
       Round(SUM(TotalPrecio),0) as 'TotalPrecio',
       Round(SUM(Total_Mrg),2) as 'Total_Mrg', 
       Case When Round(SUM(TotalPrecio),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalPrecio),0)),3)
              Else 100 End
       As 'Porc_Markup',--'% Markup',      
       Case When Round(SUM(TotalCosto),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalCosto),0)),3)
              Else 100 End 
       As 'Porc_Margen',--'% Margen',
       Cast(0 As Float) As Grupo_Mg,    
	   Cast(0 As Float) As Grupo_Mk    
	
Into #Zw_TblMargenXAsociacion

   From #Zw_TblDetalle_Venta
   LEFT JOIN MAEPR ON MAEPR.KOPR=Koprct
   Group By Codigo_Nodo_Clas,Codigo_Madre_Clas,Descripcion_Clas
   Order by Codigo_Madre_Clas

  Update #Zw_TblMargenXAsociacion Set Grupo_Mg = Round(Porc_Margen,0)
  Update #Zw_TblMargenXAsociacion Set Grupo_Mk = Round(Porc_Markup,0)

  -- Margenes por Vendedor

Select Vendedor,
	   NOKOFU As Nom_Vendedor,	
       COUNT(Tido) as Documentos, 
       Round(SUM(CantidadUd1),2) as 'CantidadUd1',
       Round(SUM(TotalCosto),0) as 'TotalCosto',
       Round(SUM(TotalPrecio),0) as 'TotalPrecio',
       Round(SUM(Total_Mrg),2) as 'Total_Mrg', 
       Case When Round(SUM(TotalPrecio),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalPrecio),0)),3)
              Else 100 End
       As 'Porc_Markup',--'% Markup',      
       Case When Round(SUM(TotalCosto),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalCosto),0)),3)
              Else 100 End 
       As 'Porc_Margen',--'% Margen',
       Cast(0 As Float) As Grupo_Mg,    
	   Cast(0 As Float) As Grupo_Mk    
	
Into #Zw_TblMargenXVendedor

   From #Zw_TblDetalle_Venta
   LEFT JOIN MAEPR ON MAEPR.KOPR=Koprct
   Left Join TABFU On KOFU = Vendedor
   Group By Vendedor,TABFU.NOKOFU
   Order by Vendedor

  Update #Zw_TblMargenXVendedor Set Grupo_Mg = Round(Porc_Margen,0)
  Update #Zw_TblMargenXVendedor Set Grupo_Mk = Round(Porc_Markup,0)

  -- Margenes por Super Familias

Select SuperFamilia,
	   Nom_SuperFamilia,	
       COUNT(Tido) as Documentos, 
       Round(SUM(CantidadUd1),2) as 'CantidadUd1',
       Round(SUM(TotalCosto),0) as 'TotalCosto',
       Round(SUM(TotalPrecio),0) as 'TotalPrecio',
       Round(SUM(Total_Mrg),2) as 'Total_Mrg', 
       Case When Round(SUM(TotalPrecio),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalPrecio),0)),3)
              Else 100 End
       As 'Porc_Markup',--'% Markup',      
       Case When Round(SUM(TotalCosto),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalCosto),0)),3)
              Else 0 End 
       As 'Porc_Margen',--'% Margen',
       Cast(0 As Float) As Grupo_Mg,    
	   Cast(0 As Float) As Grupo_Mk    
	
Into #Zw_TblMargenXSuperFamilia
From #Zw_TblDetalle_Venta
Group By SuperFamilia,Nom_SuperFamilia
Order by SuperFamilia,Nom_SuperFamilia

-- Margenes por Empresa

Select Empresa,RAZON As Razon,
	   COUNT(Tido) as Documentos, 
       Round(SUM(CantidadUd1),2) as 'CantidadUd1',
       Round(SUM(TotalCosto),0) as 'TotalCosto',
       Round(SUM(TotalPrecio),0) as 'TotalPrecio',
       Round(SUM(Total_Mrg),2) as 'Total_Mrg', 
       Case When Round(SUM(TotalPrecio),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalPrecio),0)),3)
              Else 100 End
       As 'Porc_Markup',--'% Markup',      
       Case When Round(SUM(TotalCosto),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalCosto),0)),3)
              Else 0 End 
       As 'Porc_Margen',--'% Margen',
       Cast(0 As Float) As Grupo_Mg,    
	   Cast(0 As Float) As Grupo_Mk    
	
Into #Zw_TblMargenXEmpresa
From #Zw_TblDetalle_Venta
Left Join CONFIGP On EMPRESA = Empresa
Group By Empresa,RAZON
Order by Empresa

-- Margenes por Sucursal

Select Empresa,Sulido,NOKOSU As Nosulido,
	   COUNT(Tido) as Documentos, 
       Round(SUM(CantidadUd1),2) as 'CantidadUd1',
       Round(SUM(TotalCosto),0) as 'TotalCosto',
       Round(SUM(TotalPrecio),0) as 'TotalPrecio',
       Round(SUM(Total_Mrg),2) as 'Total_Mrg', 
       Case When Round(SUM(TotalPrecio),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalPrecio),0)),3)
              Else 100 End
       As 'Porc_Markup',--'% Markup',      
       Case When Round(SUM(TotalCosto),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalCosto),0)),3)
              Else 0 End 
       As 'Porc_Margen',--'% Margen',
       Cast(0 As Float) As Grupo_Mg,    
	   Cast(0 As Float) As Grupo_Mk    
	
Into #Zw_TblMargenXSucursalLinea
From #Zw_TblDetalle_Venta
Left Join TABSU On EMPRESA = Empresa And KOSU = Sulido
Group By Empresa,Sulido,NOKOSU
Order by Empresa,Sulido

-- Margenes por Bodega

Select Empresa,Sulido,NOKOSU As Nosulido,Bosulido,NOKOBO As Nokobo,
	   COUNT(Tido) as Documentos, 
       Round(SUM(CantidadUd1),2) as 'CantidadUd1',
       Round(SUM(TotalCosto),0) as 'TotalCosto',
       Round(SUM(TotalPrecio),0) as 'TotalPrecio',
       Round(SUM(Total_Mrg),2) as 'Total_Mrg', 
       Case When Round(SUM(TotalPrecio),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalPrecio),0)),3)
              Else 100 End
       As 'Porc_Markup',--'% Markup',      
       Case When Round(SUM(TotalCosto),0) <> 0 then
              Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalCosto),0)),3)
              Else 0 End 
       As 'Porc_Margen',--'% Margen',
       Cast(0 As Float) As Grupo_Mg,    
	   Cast(0 As Float) As Grupo_Mk    
	
Into #Zw_TblMargenXBodega
From #Zw_TblDetalle_Venta
Left Join TABSU On EMPRESA = Empresa And KOSU = Sulido
Left Join TABBO On TABBO.EMPRESA = Empresa And TABBO.KOSU = Sulido And KOBO = Bosulido
Group By Empresa,Sulido,NOKOSU,Bosulido,NOKOBO
Order by Empresa,Sulido


Update #Zw_TblMargenXProducto Set Porc_Markup = 0,Porc_Margen = 0
Update #Zw_TblMargenXAsociacion Set Porc_Markup = 0,Porc_Margen = 0
Update #Zw_TblMargenXVendedor Set Porc_Markup = 0,Porc_Margen = 0
Update #Zw_TblMargenXSuperFamilia Set Porc_Markup = 0,Porc_Margen = 0
Update #Zw_TblMargenXSucursalLinea Set Porc_Markup = 0,Porc_Margen = 0
Update #Zw_TblMargenXBodega Set Porc_Markup = 0,Porc_Margen = 0
Update #Zw_TblMargenXEmpresa Set Porc_Markup = 0,Porc_Margen = 0

Update #Zw_TblMargenXProducto Set Porc_Markup = Round(Total_Mrg/TotalPrecio,4) Where TotalPrecio <> 0
Update #Zw_TblMargenXProducto Set Porc_Margen = Round(Total_Mrg/TotalCosto,4) Where TotalCosto <> 0
Update #Zw_TblMargenXAsociacion Set Porc_Markup = Round(Total_Mrg/TotalPrecio,4) Where TotalPrecio <> 0
Update #Zw_TblMargenXAsociacion Set Porc_Margen = Round(Total_Mrg/TotalCosto,4) Where TotalCosto <> 0
Update #Zw_TblMargenXVendedor Set Porc_Markup = Round(Total_Mrg/TotalPrecio,4) Where TotalPrecio <> 0
Update #Zw_TblMargenXVendedor Set Porc_Margen = Round(Total_Mrg/TotalCosto,4) Where TotalCosto <> 0
Update #Zw_TblMargenXSuperFamilia Set Porc_Markup = Round(Total_Mrg/TotalPrecio,4) Where TotalPrecio <> 0
Update #Zw_TblMargenXSuperFamilia Set Porc_Margen = Round(Total_Mrg/TotalCosto,4) Where TotalCosto <> 0
Update #Zw_TblMargenXSucursalLinea Set Porc_Markup = Round(Total_Mrg/TotalPrecio,4) Where TotalPrecio <> 0
Update #Zw_TblMargenXSucursalLinea Set Porc_Margen = Round(Total_Mrg/TotalCosto,4) Where TotalCosto <> 0
Update #Zw_TblMargenXBodega Set Porc_Markup = Round(Total_Mrg/TotalPrecio,4) Where TotalPrecio <> 0
Update #Zw_TblMargenXBodega Set Porc_Margen = Round(Total_Mrg/TotalCosto,4) Where TotalCosto <> 0
Update #Zw_TblMargenXEmpresa Set Porc_Markup = Round(Total_Mrg/TotalPrecio,4) Where TotalPrecio <> 0
Update #Zw_TblMargenXEmpresa Set Porc_Margen = Round(Total_Mrg/TotalCosto,4) Where TotalCosto <> 0

Update #Zw_TblDetalle_Venta Set Porc_Margen = Porc_Margen/100,Porc_Markup =Porc_Markup/100

Update #Zw_TblMargenXProducto Set Porc_Margen = Round(Porc_Margen,4) * -1 Where Total_Mrg < 0 And Porc_Margen > 0
Update #Zw_TblMargenXProducto Set Porc_Markup = Round(Porc_Markup,4) * -1 Where Total_Mrg < 0 And Porc_Markup > 0
Update #Zw_TblMargenXAsociacion Set Porc_Margen = Round(Porc_Margen,4) * -1 Where Total_Mrg < 0 And Porc_Margen > 0
Update #Zw_TblMargenXAsociacion Set Porc_Markup = Round(Porc_Markup,4) * -1 Where Total_Mrg < 0 And Porc_Markup > 0
Update #Zw_TblMargenXVendedor Set Porc_Margen = Round(Porc_Margen,4) * -1 Where Total_Mrg < 0 And Porc_Margen > 0
Update #Zw_TblMargenXVendedor Set Porc_Markup = Round(Porc_Markup,4) * -1 Where Total_Mrg < 0 And Porc_Markup > 0
Update #Zw_TblMargenXSuperFamilia Set Porc_Margen = Round(Porc_Margen,4) * -1 Where Total_Mrg < 0 And Porc_Margen > 0
Update #Zw_TblMargenXSuperFamilia Set Porc_Markup = Round(Porc_Markup,4) * -1 Where Total_Mrg < 0 And Porc_Markup > 0
Update #Zw_TblMargenXSucursalLinea Set Porc_Margen = Round(Porc_Margen,4) * -1 Where Total_Mrg < 0 And Porc_Margen > 0
Update #Zw_TblMargenXSucursalLinea Set Porc_Markup = Round(Porc_Markup,4) * -1 Where Total_Mrg < 0 And Porc_Markup > 0
Update #Zw_TblMargenXBodega Set Porc_Margen = Round(Porc_Margen,4) * -1 Where Total_Mrg < 0 And Porc_Margen > 0
Update #Zw_TblMargenXBodega Set Porc_Markup = Round(Porc_Markup,4) * -1 Where Total_Mrg < 0 And Porc_Markup > 0
Update #Zw_TblMargenXEmpresa Set Porc_Margen = Round(Porc_Margen,4) * -1 Where Total_Mrg < 0 And Porc_Margen > 0
Update #Zw_TblMargenXEmpresa Set Porc_Markup = Round(Porc_Markup,4) * -1 Where Total_Mrg < 0 And Porc_Markup > 0

Update #Zw_TblDetalle_Venta Set Porc_Margen = Round(Porc_Margen,4) * -1 Where Total_Mrg < 0 And Porc_Margen > 0
Update #Zw_TblDetalle_Venta Set Porc_Markup = Round(Porc_Markup,4) * -1 Where Total_Mrg < 0 And Porc_Markup > 0


Select * From #Zw_TblMargenXProducto
Select Koprct As 'Código',Nokopr As 'Descripción', Documentos, CantidadUd1 As 'CantUd1', TotalCosto As 'Total Costo', TotalPrecio As 'Total Precio',  
       Total_Mrg As 'Total Margen', Porc_Markup As 'Margen',
       --Cast(Porc_Markup as decimal(10,2)) as Porc_Markup, 
       --Cast(Porc_Margen as decimal(10,2)) as Porc_Margen, 
       Marca,Nom_Marca,ClasLibre,Nom_ClasLibre,Zona,Nom_Zona,Rubro,Nom_Rubro, 
       SuperFamilia,Familia,SubFamilia,Nom_SuperFamilia,Nom_Familia,Nom_SubFamilia 
From #Zw_TblMargenXProducto
Order by Koprct



Select * From #Zw_TblMargenXAsociacion
Select Codigo_Madre_Clas As 'Código',Descripcion_Clas As 'Descripción', Documentos, CantidadUd1 As 'CantUd1', TotalCosto As 'Total Costo', TotalPrecio As 'Total Precio',  
       Total_Mrg As 'Total Margen', Porc_Markup As 'Margen'
       --Cast(Porc_Markup as decimal(10,2)) as Porc_Markup, 
       --Cast(Porc_Margen as decimal(10,2)) as Porc_Margen
From #Zw_TblMargenXAsociacion
Order By Codigo_Madre_Clas

Select * From #Zw_TblMargenXVendedor 
 Select Vendedor As 'Código',Nom_Vendedor As 'Descripción', Documentos, CantidadUd1 As 'CantUd1', TotalCosto As 'Total Costo', TotalPrecio As 'Total Precio',  
       Total_Mrg As 'Total Margen', Porc_Markup As 'Margen'
       --Cast(Porc_Markup as decimal(10,2)) as Porc_Markup, 
       --Cast(Porc_Margen as decimal(10,2)) as Porc_Margen
From #Zw_TblMargenXVendedor
Order By Vendedor

Select * From #Zw_TblMargenXSuperFamilia
Select SuperFamilia As 'Código',Nom_SuperFamilia As 'Descripción', Documentos, CantidadUd1 As 'CantUd1', TotalCosto As 'Total Costo', TotalPrecio As 'Total Precio',  
       Total_Mrg As 'Total Margen', Porc_Markup As 'Margen'
       --Cast(Porc_Markup as decimal(10,2)) as Porc_Markup, 
       --Cast(Porc_Margen as decimal(10,2)) as Porc_Margen
From #Zw_TblMargenXSuperFamilia
Order By SuperFamilia

Select * From #Zw_TblDetalle_Venta Order by Tido, Nudo
Select Tido as Tipo,Nudo as Numero,Feemli as Fecha,Funcionario,Koprct as 'Código', Nokopr as 'Descripción', CantidadUd1, 
        Round(PNetoUnit,2) as 'Precio neto unitario', 
        Round(CostoUnitIm,2) as 'Costo neto unitario',Round(TotalCosto,2) as 'Total Costo', 
        Round(TotalPrecio,2) as 'Total Precio', Round(Total_Mrg,2) as 'Total Margen',  
        Porc_Markup As 'Margen',
        --cast(Porc_Markup as decimal(10,4)) as 'Margen',
        --cast(Porc_Markup as decimal(10,2)) as '% Margen Venta', 
        --cast(Porc_Margen as decimal(10,2)) as '% Margen Costo', 
        Marca,Nom_Marca,ClasLibre,Nom_ClasLibre,Zona,Nom_Zona,Rubro,Nom_Rubro 
        From #Zw_TblDetalle_Venta
Order by Tido, Nudo

Select * From #Zw_TblMargenXEmpresa
Select Empresa As 'Código',Razon As 'Descripción', Documentos, CantidadUd1 As 'CantUd1', TotalCosto As 'Total Costo', TotalPrecio As 'Total Precio',  
       Total_Mrg As 'Total Margen', Porc_Markup As 'Margen'
From #Zw_TblMargenXEmpresa
Order By Empresa

Select * From #Zw_TblMargenXSucursalLinea
Select Sulido As 'Código',Nosulido As 'Descripción', Documentos, CantidadUd1 As 'CantUd1', TotalCosto As 'Total Costo', TotalPrecio As 'Total Precio',  
       Total_Mrg As 'Total Margen', Porc_Markup As 'Margen'
From #Zw_TblMargenXSucursalLinea
Left Join TABSU On EMPRESA = Empresa And KOSU = Sulido
Order By Sulido

Select * From #Zw_TblMargenXBodega
Select Bosulido As 'Código',Nokobo As 'Descripción', Documentos, CantidadUd1 As 'CantUd1', TotalCosto As 'Total Costo', TotalPrecio As 'Total Precio',  
       Total_Mrg As 'Total Margen', Porc_Markup As 'Margen'
From #Zw_TblMargenXBodega
Left Join TABSU On EMPRESA = Empresa And KOSU = Sulido
Order By Sulido

Drop Table #Zw_TblDetalle_Venta
Drop Table #Zw_TblMargenXProducto
Drop Table #Zw_TblMargenXAsociacion
Drop Table #Zw_TblMargenXVendedor
Drop Table #Zw_TblMargenXSuperFamilia
Drop Table #Zw_TblMargenXEmpresa
Drop Table #Zw_TblMargenXSucursalLinea
Drop Table #Zw_TblMargenXBodega
Drop Table #Zw_TblMrgImp   




