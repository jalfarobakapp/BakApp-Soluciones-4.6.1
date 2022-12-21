
Declare @Empresa Char(2),
        @Sucursal Char(3),
        @Bodega Char(3),
        @Lista Char(3) 

Select @Empresa = '#Empresa#',@Sucursal = '#Sucursal#',@Bodega = '#Bodega#',@Lista = '#Lista#'


Select Top 20 MAEDDO.KOPRCT,MAEDDO.NOKOPR,MAEDDO.PRCT,SUM(MAEDDO.VANELI*(CASE WHEN LEFT(MAEEDO.TIDO,2)='NC' THEN -1 ELSE 1 END ) ) AS SUMA,Cast(0 As Float) As Porc
Into #Paso
FROM MAEDDO WITH (NOLOCK)  
	INNER JOIN MAEEDO WITH (NOLOCK) ON MAEEDO.IDMAEEDO=MAEDDO.IDMAEEDO  
  Where 
	MAEEDO.EMPRESA = @Empresa AND 
	MAEEDO.FEEMDO> DATEADD(YEAR,-1,Getdate()) And 
	MAEEDO.TIDO IN  (#Filtro_Tido#) AND 
	MAEEDO.ENDO = '#Endo#' AND MAEDDO.LILG IN ('SI','GR')  
Group By MAEDDO.KOPRCT,MAEDDO.NOKOPR,MAEDDO.PRCT  Order by SUMA Desc

Declare @Suma_Total As Float
Select @Suma_Total = (Select Sum(SUMA) From #Paso)

Update #Paso Set Porc = Round(SUMA/@Suma_Total,4)
Where @Suma_Total > 0

--Select *,Case When @Suma_Total > 0 Then Round(SUMA/@Suma_Total,4) Else 0 End As Porc From #Paso

Select Top 20 
       Porc, 
       KOPRCT As Codigo,
       #Paso.NOKOPR as 'Descripcion',
       #Paso.PRCT As 'Prct',
       --Isnull(Mp.NOKOPR,Isnull(Tc.NOKOCT,'xxxxx')) as 'Descripcion',
       Isnull(Mp.RLUD,0) as 'Rtu',
       Isnull(Lp.PP01UD,0) AS 'Precio_UD1',
       Isnull(Lp.PP01UD * (Mp.POIVPR/100.0)+Lp.PP01UD,0) AS 'Precio_UD1_Bruto',
       Isnull(Lp.PP02UD,0) AS 'Precio_UD2',       
	   Isnull(Lp.PP02UD * (Mp.POIVPR/100.0)+Lp.PP02UD,0) AS 'Precio_UD2_Bruto',
       Isnull(Lp.ECUACION,'') AS 'Ecuacion_Ud1',
       Isnull(Lp.ECUACIONU2,'') AS 'Ecuacion_Ud2',
       Cast(0 As Bit) 'Ecuacion_Generada',
       
       #Stock#
             
       Isnull(Tc1.NOKOCARAC,'')	AS 'CLALIBPR',
	   Ltrim(Rtrim(Isnull(Tb.DATOSUBIC,''))) AS 'DATOSUBIC',
       Isnull(Tc1.NOKOCARAC,'') AS 'FAMILIA',
	   Cast(Case When Mp.ATPR = 'OCU' Then 1 Else 0 End As Bit) as 'Oculto',
       Cast('' As Varchar(Max)) As Ficha

Into #Paso_Maepr      
    From #Paso--MAEPR Mp
        Left Join MAEPR Mp On #Paso.KOPRCT = Mp.KOPR
            Left Join MAEPREM Mpn On Mpn.EMPRESA = @Empresa And Mpn.KOPR = Mp.KOPR 
		        Left Join TABPRE Lp On Lp.KOLT = @Lista And Lp.KOPR = Mp.KOPR
			        Left Join TABCARAC Tc1 On Tc1.KOTABLA = 'CLALIBPR' AND Tc1.KOCARAC = Mp.CLALIBPR
				        Left Join TABBOPR Tb On Tb.EMPRESA = @Empresa And Tb.KOSU = @Sucursal And Tb.KOBO = @Bodega And Tb.KOPR = Mp.KOPR
							Left Join TABCT Tc On Tc.KOCT = #Paso.KOPRCT
                                Left Join MAEFICHA Mf On Mf.KOPR = Mp.KOPR
                        
Select * From #Paso_Maepr
Order BY Porc Desc  

DECLARE @Kopr AS varchar(13)
DECLARE @Ficha AS varchar(max)
DECLARE ProdInfo CURSOR FOR SELECT Codigo,FICHA FROM #Paso_Maepr Inner Join MAEFICHD On KOPR = Codigo Where FICHA <> '' Order By KOPR,SEMILLA
OPEN ProdInfo
FETCH NEXT FROM ProdInfo INTO @Kopr,@Ficha
WHILE @@fetch_status = 0
BEGIN
    --PRINT @Kopr
    --PRINT @Ficha
    FETCH NEXT FROM ProdInfo INTO @Kopr,@Ficha
	Update #Paso_Maepr Set Ficha = Ficha+@Ficha+' ' Where Codigo = @Kopr
END
CLOSE ProdInfo
DEALLOCATE ProdInfo	 

Drop Table #Paso_Maepr
Drop Table #Paso


