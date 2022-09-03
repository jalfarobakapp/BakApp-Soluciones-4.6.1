Declare 
@Empresa        Char(2) = '#Empresa#',
@Ila            Float,
@Opcion         Int = #Opcion#,
@ListaCosto     Char(3) = '#ListaCostos#',
@Presencia      Float,
@Cantidad       Float,
@Costo          Float,
@Precio         Float,
@ValorMargen    Float,
@Margen         Float,
@Markup         Float,
@Fecha1         Date = '#FechaDesde#',
@Fecha2         Date = '#FechaHasta#',
@CodFuncionario Char(3) = '#Funcionario#'

 
IF @Opcion = 0 Begin-- Costo Promedio del documento
      UPDATE Zw_TblMargen SET  
                                                                 
                         AdicImp = 
                                    Case        
                                      When Tido = 'BLV' Then 
                                      ROUND((1+(Porct_Ila/100))*CostoUnit,2)-ROUND(CostoUnit,2)
                                      Else 0
                                     End,
                         CostoUnitIm = 
                                     Case 
                                      When Tido = 'BLV' Then ROUND((1+(Porct_Ila/100))*CostoUnit,2)
                                      Else ROUND(CostoUnit,2)
                                     End                                
     
    End     



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


   


 CREATE TABLE #TblPasoRanking(
     Codigo        Varchar(13)    default '',  -- Código de producto
     Descripcion   Varchar(50)    default '',  -- Descripción de producto
     Puntos_Rk     Float          default (0),
     Ranking_Top   Int            default (0), -- Ranking presencia
     Rk_Presencia  Int            default (0), -- Ranking presencia
     Rk_Cantidad   Int            default (0), -- Ranking presencia
     Rk_Precio     Int            default (0), -- Ranking presencia
     Rk_Margen     Int            default (0), -- Ranking presencia
     Bv            float          default (0), -- Venta en Boletas
     Fv            float          default (0), -- Venta en Facturas
     Gv            float          default (0), -- Venta en Guías sin Facturar
     Nc            float          default (0), -- Notas de credito
     Otro          float          default (0), -- Otro tipo de documento
     Presencia     float          default (0), -- Cantidad de documentos en los cuales aparece el producto
     Top_Ranking   Char(1)        default  '', -- Porcentaje de Ranking Top 
     Top_Presencia Char(1)        default  '', -- Porcentaje de Presencia 
     Top_Cantidad  Char(1)        default  '', -- Porcentaje de Cantidad 
     Top_Precio    Char(1)        default  '', -- Porcentaje de Precio 
     Top_Margen    Char(1)        default  '', -- Porcentaje de Margen
     Cod_Clas      varchar(20)    default  '', -- Código de clasificación según Tabla escogida
     Clasificacion Varchar(50)    default  '', -- Porcentaje de Margen
     Pc_Ranking    float          default (0), -- Porcentaje de Ranking Top 
     Pc_Presencia  float          default (0), -- Porcentaje de Presencia 
     Pc_Cantidad   float          default (0), -- Porcentaje de Cantidad 
     Pc_Precio     float          default (0), -- Porcentaje de Precio 
     Pc_Margen     float          default (0), -- Porcentaje de Margen
     TotalCosto    float          default (0), -- Valor total del costo
     TotalPrecio   float          default (0), -- Valor total del precio neto
     TotalCantid   Float          default (0), -- Total cantidad de productos vendidos
     Total_Mrg     Float          default (0), -- Total margen 
     Porc_Markup   float          default (0), -- Porcentaje de Markup % (Margen de venta)
     Porc_Margen   float          default (0), -- Porcentaje de Margen % (Margen de costo)
     Star          Int            default (1), -- Estrellas al producto
     Star2         Varchar(5)     default  '') 


   Insert Into #TblPasoRanking (Codigo,Descripcion,Bv,Fv,Gv,Nc,Otro,Presencia,TotalCantid,TotalCosto,TotalPrecio,Total_Mrg,Porc_Markup,Porc_Margen)
     Select 
         Koprct,
         Nokopr,
         Isnull((Select SUM(Presencia) From Zw_TblMargen Where Tido in ('BLV','BLX','BSV') And Koprct = Zw.Koprct),0),
         Isnull((Select SUM(Presencia) From Zw_TblMargen Where Tido in ('FCV','FDB','FDV','FDX','FDZ',
                                                                        'FEE','FEV','FVL','FVT','FVX','FVZ') 
                                                                        And Koprct = Zw.Koprct),0),
         Isnull((Select SUM(Presencia) From Zw_TblMargen Where Tido in ('GDD','GDP','GDV') And Koprct = Zw.Koprct And CantidadUd1 > 0),0),
         Isnull((Select SUM(Presencia) From Zw_TblMargen Where Tido in ('NCE','NCV','NCX','NCZ','NEV') And Koprct = Zw.Koprct),0),
         Isnull((Select SUM(Presencia) From Zw_TblMargen Where Tido in ('ESC','RIN') And Koprct = Zw.Koprct),0),
         SUM(Presencia) As Documento,
         Round(SUM(CantidadUd1),5) as 'CantidadUd1',
         Round(SUM(TotalCosto),5) as 'TotalCosto',
         Round(SUM(TotalPrecio),5) as 'TotalPrecio',
         Round(SUM(Total_Mrg),5) as 'Total Margen', 
         Case When Round(SUM(TotalPrecio),0) > 0 then
               Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalPrecio),0)),5)
              Else 0 End
         as '% Markup',      
         Case When Round(SUM(TotalCosto),0) > 0 then
               Round(100 * ((Round(SUM(TotalPrecio),0)-Round(SUM(TotalCosto),0))/Round(SUM(TotalCosto),0)),5)
              Else 100 End 
          as '% Margen'       
   From Zw_TblMargen Zw
        
   Where CantidadUd1 <> 0     
   Group By Koprct,Nokopr
   Order by Koprct
   
   
 
 
 Insert Into #TblPasoRanking (Codigo,Descripcion)
 Select KOPR,NOKOPR 
 from MAEPR 
 Where TIPR <> 'SSN' And ATPR = '' And KOPR not in (Select Codigo From #TblPasoRanking)
 

     
       
       
        
     Declare @Total_Doc Float = 
                          (SELECT COUNT(Case 
                                            When EDO.TIDO IN ('NCE', 'NCV', 'NCX', 'NCZ', 'NEV') Then -1
                                            Else 1 End) 
                           FROM MAEEDO AS EDO WITH ( NOLOCK )  
	                        INNER JOIN MAEDDO DDO ON DDO.IDMAEEDO=EDO.IDMAEEDO 
	                        AND DDO.LILG NOT IN ( 'GR','IM' )  
                           WHERE 
                           EDO.FEEMDO BETWEEN @Fecha1 AND @Fecha2
			            AND EDO.EMPRESA=@Empresa  
			            AND DDO.TIDO IN 
			           ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT',
                        'FVX','FVZ','GDP','GDV','NCE','NCV','NCX','NCZ','NEV','RIN') 
			            AND NOT ( EDO.TIDO='GDV' AND DDO.ARCHIRST IN ('POTD','POTPR','POTL') ) -- No incluye Guias desde OT 
			            AND NOT ( EDO.TIDO='GDP' AND EDO.SUBTIDO<>'CON' )  -- No incluye Guias en consignación
			            AND DDO.PRCT=0  
			            AND DDO.TIPR NOT IN ('SSN','FLN')  -- NO INCLUIR PRODUCTOS TIPO SERVICIO NI MULTIPROPOSITO   
                        AND DDO.TICT = ''                    -- NO INCLUIR CONCEPTOS  ('R') Recargo,('D') Descuento 
                        AND  LTRIM(RTRIM(EDO.ENDO))+RTRIM(LTRIM(EDO.SUENDO))  
	                    NOT IN (SELECT  LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From Zw_TblInf_EntExcluidas
                        Where Funcionario = @CodFuncionario And Excluida in ('V','A','T'))) 
            
       Select 
       @Presencia = SUM(Presencia),
       @Cantidad = ROUND(Sum(TotalCantid),0),
       @Costo=Round(SUM(TotalCosto),0),
       @Precio=Round(SUM(TotalPrecio),0),
       @ValorMargen = ROUND(Round(SUM(TotalPrecio),2)- Round(SUM(TotalCosto),2),0),
       @Margen= Round((SUM(TotalPrecio-TotalCosto)/sum(TotalCosto))*100,2),
       @Markup= Round((SUM(TotalPrecio-TotalCosto)/sum(TotalPrecio))*100,2)
               
       From #TblPasoRanking
      

DECLARE @Rk_Presencia TABLE(
  Ranking int identity(1,1) not null primary key,
  Codigo Char(13) Default ''
)

DECLARE @Rk_Cantidad TABLE(
  Ranking int identity(1,1) not null primary key,
  Codigo Char(13) Default ''
)

DECLARE @Rk_Margen TABLE(
  Ranking int identity(1,1) not null primary key,
  Codigo Char(13) Default ''
)

DECLARE @Rk_Precio TABLE(
  Ranking int identity(1,1) not null primary key,
  Codigo Char(13) Default ''
)

DECLARE @Rk_Top TABLE(
  Ranking int identity(1,1) not null primary key,
  Codigo Char(13) Default ''
)

Update #TblPasoRanking Set
       Pc_Presencia = Case When Presencia <> 0 and @Presencia <> 0 Then Presencia/@Presencia Else 0 End,
       Pc_Cantidad = Case When TotalCantid <> 0 and @Cantidad <> 0 Then TotalCantid/@Cantidad Else 0 End,
       Pc_Precio = Case When TotalPrecio <> 0 and @Precio <> 0 Then TotalPrecio/@Precio Else 0 End,
       Pc_Margen = Case When Total_Mrg <> 0 and @ValorMargen <> 0 Then Total_Mrg/@ValorMargen Else 0 End


Insert into @Rk_Presencia (Codigo)
Select Codigo From #TblPasoRanking Order by Pc_Presencia Desc --Pc_Presencia Desc

Insert into @Rk_Precio (Codigo)
Select Codigo From #TblPasoRanking Order by TotalPrecio Desc --Pc_Precio Desc

Insert into @Rk_Cantidad (Codigo)
Select Codigo From #TblPasoRanking Order by TotalCantid Desc --Pc_Cantidad Desc

Insert into @Rk_Margen (Codigo)
Select Codigo From #TblPasoRanking Order by Total_Mrg Desc--Pc_Margen Desc


Update #TblPasoRanking Set 
       Rk_Presencia = (Select Ranking From @Rk_Presencia Where Codigo = #TblPasoRanking.Codigo),
       Rk_Precio = (Select Ranking From @Rk_Precio Where Codigo = #TblPasoRanking.Codigo),
       Rk_Cantidad = (Select Ranking From @Rk_Cantidad Where Codigo = #TblPasoRanking.Codigo),
       Rk_Margen = (Select Ranking From @Rk_Margen Where Codigo = #TblPasoRanking.Codigo)

Update #TblPasoRanking set Puntos_Rk = Rk_Presencia+Rk_Precio+Rk_Cantidad+Rk_Margen

Insert into @Rk_Top (Codigo)
Select Codigo From #TblPasoRanking Order by Puntos_Rk --Desc

Update #TblPasoRanking Set 
       Ranking_Top = (Select Ranking From @Rk_Top Where Codigo = #TblPasoRanking.Codigo)

Declare @CantReg Float = (Select COUNT(Puntos_Rk) From #TblPasoRanking)

Update #TblPasoRanking set Puntos_Rk = @CantReg-Ranking_Top+1

Update #TblPasoRanking Set
       Pc_Ranking = Case When Puntos_Rk <> 0 and @CantReg <> 0 Then Round((Puntos_Rk/@CantReg),5) Else 0 End
       

Select * From #TblPasoRanking
      
Drop Table #TblPasoRanking      
Drop Table Zw_TblMargen

IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_TblMrgImp') BEGIN
DROP TABLE Zw_TblMrgImp
END