declare 
@Empresa     Char(2),
@Sucursal    Char(3),
@Bodega      Char(3),
@Fecha1      Date,
@Fecha2      Date,
@Ila         Float,
@Opcion      Int,
@ListaCosto  Char(3),
@Funcionario Char(3) 

Select @Funcionario = '#_Funcionario_Activo#',
       @Opcion = #Opcion#,
       @Fecha1 = '#Fecha1#',
       @Fecha2   = '#Fecha2#',
       @Empresa  = '#Empresa#', 
       @ListaCosto = '#ListaCosto#'

--TIDO,NUDO,FEEMLI,NULIDO,KOPRCT,NOKOPR'
-- DECLARA TABLA VARIABLE PARA ALMACENAR DETALLE DE OCC --

BEGIN TRY

  BEGIN TRANSACTION

  
   CREATE TABLE Zw_TblMargen(
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
     Funcionario Char(3)     default '') 


   IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_TblMrgImp') BEGIN
   DROP TABLE Zw_TblMrgImp
   END

   CREATE TABLE Zw_TblMrgImp(
     Koprct      char(13) default '', 
     Impuestos   Float    default (0),
     )

   Insert Into Zw_TblMrgImp (Koprct,Impuestos) 
   SELECT   dbo.MAEPR.KOPR,SUM(ISNULL(dbo.TABIM.POIM, 0)) AS Impuestos
             FROM         dbo.MAEPR LEFT OUTER JOIN
                          dbo.TABIMPR ON dbo.MAEPR.KOPR = dbo.TABIMPR.KOPR LEFT OUTER JOIN
                          dbo.TABIM ON dbo.TABIMPR.KOIM = dbo.TABIM.KOIM
             GROUP BY dbo.MAEPR.KOPR, dbo.MAEPR.NOKOPR 
   
  
   INSERT INTO Zw_TblMargen (Tido,Nudo,Feemli,Nulido,Koprct,Nokopr,CantidadUd1,CostoUnit,PNetoUnit,
                            Porct_Ila,Porct_Iva,Ila,Iva,Funcionario,
                            Marca,Rubro,ClasLibre,Zona,SuperFamilia,Familia,SubFamilia)       

   SELECT   DDO.TIDO,DDO.NUDO,FEEMLI,NULIDO,KOPRCT AS 'Codigo',DDO.NOKOPR AS 'Descripcion',
            ROUND(CASE 
                    WHEN DDO.TIDO IN ('NCE','NCV','NCX','NCZ','NEV') 
                    THEN - 1 * CAPRCO1
				    ELSE CAPRCO1 
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
           #Funcionario#,MAEPR.MRPR,MAEPR.RUPR,MAEPR.CLALIBPR,MAEPR.ZONAPR,MAEPR.FMPR,MAEPR.PFPR,MAEPR.HFPR
           FROM   MAEEDO AS EDO WITH ( NOLOCK )  
	        INNER JOIN MAEDDO DDO ON DDO.IDMAEEDO=EDO.IDMAEEDO 
	        AND DDO.LILG NOT IN ( 'GR','IM' )  
	        LEFT JOIN MAEPR ON MAEPR.KOPR=DDO.KOPRCT  
	        LEFT JOIN Zw_TblMrgImp ON Zw_TblMrgImp.Koprct=DDO.KOPRCT  
              WHERE 
               EDO.FEEMDO BETWEEN @Fecha1 AND @Fecha2
			   AND EDO.EMPRESA=@Empresa  
			   #FiltroDocumentos#       --AND DDO.TIDO IN #FiltroDocumentos#
			   #FiltroSucursal#         --AND EDO.SULIDO IN #FiltroSucursal#
			   #FiltroFuncionarios#
			   AND NOT ( EDO.TIDO='GDV' AND DDO.ARCHIRST IN ('POTD','POTPR','POTL') )  
			   AND NOT ( EDO.TIDO='GDP' AND EDO.SUBTIDO<>'CON' )  
			   AND DDO.PRCT=0  
			   AND MAEPR.TIPR NOT IN ('SSN','FLN')  -- NO INCLUIR PRODUCTOS TIPO SERVICIO NI MULTIPROPOSITO   
               AND DDO.TICT = ''                    -- NO INCLUIR CONCEPTOS  ('R') Recargo,('D') Descuento    
               #FiltroProductos#
               And  LTRIM(RTRIM(EDO.ENDO))+RTRIM(LTRIM(EDO.SUENDO))  
	           NOT IN (SELECT  LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From #Tbl_EntExcluidas#--Zw_TblInf_EntExcluidas
	                   Where Funcionario = @Funcionario)
               
   
       Update Zw_TblMargen Set 
                       Nom_Rubro = Isnull((Select top 1 NOKORU From TABRU Where KORU = Rubro),''),
                       Nom_Marca = Isnull((Select Top 1 NOKOMR From TABMR Where KOMR = Marca),''),
                       Nom_Zona = Isnull((Select Top 1 NOKOZO From TABZO Where KOZO = Zona),''),
                       Nom_SuperFamilia = Isnull((Select Top 1 NOKOFM From TABFM Where KOFM = SuperFamilia),''),
                       Nom_Familia = Isnull((Select Top 1 NOKOPF From TABPF 
                                            Where KOFM = SuperFamilia And KOPF = Familia),''),
                       Nom_SubFamilia = Isnull((Select Top 1 NOKOHF From TABHF
                                            Where KOFM = SuperFamilia And KOPF = Familia And KOHF = SubFamilia),''),
                       Nom_ClasLibre = Isnull((Select Top 1 NOKOCARAC From TABCARAC 
                                            Where KOTABLA = 'CLALIBPR' And KOCARAC = ClasLibre),'')

   
   
   
   
   
   -----  EN ESTA LINEA SE QUEDA PEGADO

   
-------------------------------------------------------------------------------------------------------------
   IF @Opcion = 1 Begin-- PM, Sistema			
      UPDATE Zw_TblMargen SET  
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
      FROM         Zw_TblMargen LEFT OUTER JOIN
                      dbo.MAEPREM ON Koprct  = dbo.MAEPREM.KOPR
    End                  
----------------------------------------------------------------------------------------------------------
    IF @Opcion = 2 Begin-- Ultima compra, Sistema 			
       UPDATE Zw_TblMargen SET  
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
        FROM         Zw_TblMargen LEFT OUTER JOIN
                      dbo.MAEPREM ON Koprct  = dbo.MAEPREM.KOPR   
     End                                    

---------------------------------------------------------------------------------------------------------
    IF @Opcion = 3 Begin-- Desde Lista de precios
       UPDATE Zw_TblMargen SET  
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
        FROM         Zw_TblMargen LEFT OUTER JOIN
                      dbo.TABPRE ON Koprct  = dbo.TABPRE.KOPR 
                      WHERE dbo.TABPRE.KOLT = @ListaCosto                     
    End

---------------------------------------------------------------------------------------------------------
    IF @Opcion = 4 Begin -- Costo Pm al momento de la transacción
       UPDATE Zw_TblMargen SET  
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



   UPDATE Zw_TblMargen Set 
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



   UPDATE Zw_TblMargen SET 
                       Porc_Margen=Porc_Margen*-1,
                       Porc_Markup=Porc_Markup*-1
   Where Tido in ('NCE', 'NCV', 'NCX', 'NCZ', 'NEV')


   --IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_TblMrgProductos') BEGIN
   --DROP TABLE Zw_TblMrgProductos
   --END

   CREATE TABLE Zw_TblMrgProductos(
     Koprct            Varchar(13) default '',  -- Código de producto
     Nokopr            Varchar(50) default '',  -- Descripción de producto
     Documentos        Float       default (0), -- Cantidad de documentos en los cuales aparece el producto
     CantidadUd1       Float       default (0), -- Total cantidad de productos vendidos
     TotalCosto        Float       default (0), -- Valor total del costo
     TotalPrecio       Float       default (0), -- Valor total del precio neto
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
     Grupo_Mg          Float       default 0,
     Grupo_Mk          Float       default 0)
      

   Insert into Zw_TblMrgProductos (Koprct,Nokopr,Documentos,CantidadUd1,TotalCosto,TotalPrecio,
                                   Total_Mrg,Porc_Markup,Porc_Margen,
                                   Marca,Rubro,ClasLibre,Zona,SuperFamilia,Familia,SubFamilia,
                                   Nom_Marca,Nom_Rubro,Nom_ClasLibre,Nom_Zona,
                                   Nom_SuperFamilia,Nom_Familia,Nom_SubFamilia)
     Select Koprct,
         MAEPR.NOKOPR,
         COUNT(Tido) as Documentos, 
         Round(SUM(CantidadUd1),2) as 'CantidadUd1',
         Round(SUM(TotalCosto),0) as 'TotalCosto',
         Round(SUM(TotalPrecio),0) as 'TotalPrecio',
         Round(SUM(Total_Mrg),2) as 'Total Margen', 
         Case When Round(SUM(TotalPrecio),0) > 0 then
               Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalPrecio),0)),3)
              Else 100 End
         as '% Markup',      
         Case When Round(SUM(TotalCosto),0) > 0 then
               Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalCosto),0)),3)
              Else 100 End 
          as '% Margen',
          Marca,Rubro,ClasLibre,Zona,SuperFamilia,Familia,SubFamilia,
          Nom_Marca,Nom_Rubro,Nom_ClasLibre,Nom_Zona,
          Nom_SuperFamilia,Nom_Familia,Nom_SubFamilia       
   From Zw_TblMargen
   LEFT JOIN MAEPR ON MAEPR.KOPR=Koprct
   Group By Koprct,MAEPR.NOKOPR,Marca,Rubro,ClasLibre,Zona,SuperFamilia,Familia,SubFamilia,
          Nom_Marca,Nom_Rubro,Nom_ClasLibre,Nom_Zona,
          Nom_SuperFamilia,Nom_Familia,Nom_SubFamilia
   Order by Koprct
   

  Update Zw_TblMrgProductos Set Grupo_Mg = round(Porc_Margen,0)
  Update Zw_TblMrgProductos Set Grupo_Mk = round(Porc_Markup,0)

  
  
   --IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_TblMrgImp') BEGIN
   --DROP TABLE Zw_TblMrgImp
   --END
 
COMMIT TRANSACTION
    
END TRY
BEGIN CATCH
   ROLLBACK TRANSACTION
   --RAISERROR('Se ha producido un error : %d', 16, 1,"Error")
   --'RETURN 0
END CATCH
    
  --Select * from Zw_TblMargen Order by Tido, Nudo
  --Select * from Zw_TblMargenProductos
  
--*/
--  Porc_Markup = ROUND(((PNetoUnit-CostoUnit)/PNetoUnit)* 100,3),
--  Porc_Margen = ROUND(((PNetoUnit-CostoUnit)/CostoUnit)*100,3),