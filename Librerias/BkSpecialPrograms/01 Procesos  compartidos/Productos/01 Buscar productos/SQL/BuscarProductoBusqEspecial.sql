
Declare @Empresa Char(2),
        @Sucursal Char(3),
        @Bodega Char(3),
        @Lista Char(3) 

Select @Empresa = '#Empresa#',@Sucursal = '#Sucursal#',@Bodega = '#Bodega#',@Lista = '#Lista#'

SELECT TOP 100 
       Cast(0 As Bit) As 'Chk',  
       Mp.KOPR as 'Codigo',
       Mp.NOKOPR as 'Descripcion',
       Cast(0 As Bit) As 'Prct',
       Mp.RLUD as 'Rtu',
       Isnull(Lp.PP01UD,0) AS 'Precio_UD1',
       Isnull(Lp.PP01UD,0) * (Mp.POIVPR/100.0)+Isnull(Lp.PP01UD,0) AS 'Precio_UD1_Bruto',
       Isnull(Lp.PP02UD,0) AS 'Precio_UD2',       
	   Isnull(Lp.PP02UD,0) * (Mp.POIVPR/100.0)+Isnull(Lp.PP02UD,0) AS 'Precio_UD2_Bruto',
       Isnull(Lp.ECUACION,'') AS 'Ecuacion_Ud1',
       Isnull(Lp.ECUACIONU2,'') AS 'Ecuacion_Ud2',
       Cast(0 As Bit) 'Ecuacion_Generada',
       
       #Stock#
             
       Isnull(Tc1.NOKOCARAC,'')	AS 'CLALIBPR',
	   Ltrim(Rtrim(Isnull(Tb.DATOSUBIC,''))) AS 'DATOSUBIC',
       Isnull(Tc1.NOKOCARAC,'') AS 'FAMILIA',
	   Cast(Case When Mp.ATPR = 'OCU' Then 1 Else 0 End As Bit) as 'Oculto',
       Mp.KOPRTE As 'Codigo_Tecnico',
       Cast('' As Varchar(Max)) As 'Ficha'

Into #Paso_Maepr      
    From MAEPR Mp WITH (NOLOCK)
        Inner Join MAEPREM Mpn WITH (NOLOCK) On Mpn.EMPRESA = @Empresa And Mpn.KOPR = Mp.KOPR 
		    Left Join TABPRE Lp WITH (NOLOCK) On Lp.KOLT = @Lista And Lp.KOPR = Mp.KOPR
			    Left Join TABCARAC Tc1 WITH (NOLOCK) On Tc1.KOTABLA = 'CLALIBPR' AND Tc1.KOCARAC = Mp.CLALIBPR
				    Left Join TABBOPR Tb WITH (NOLOCK) On Tb.EMPRESA = @Empresa And Tb.KOSU = @Sucursal And Tb.KOBO = @Bodega And Tb.KOPR = Mp.KOPR
                        --Left Join MAEFICHA Mf On Mf.KOPR = Mp.KOPR
                        
WHERE 1 > 0
       #Sql_Filtro1#
       #Sql_Filtro2#
       #Ocultos#
       #Bloquear 
	   #Filtro_Productos#
       #Stock_Disponible#

DECLARE @Kopr AS varchar(13)
DECLARE @Ficha AS varchar(max)
DECLARE ProdInfo CURSOR FOR SELECT Codigo,Ps.Ficha FROM #Paso_Maepr Ps Inner Join MAEFICHD On KOPR = Codigo Where MAEFICHD.FICHA <> '' Order By KOPR,SEMILLA
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

Select * From #Paso_Maepr
Order By Codigo  

Drop Table #Paso_Maepr


