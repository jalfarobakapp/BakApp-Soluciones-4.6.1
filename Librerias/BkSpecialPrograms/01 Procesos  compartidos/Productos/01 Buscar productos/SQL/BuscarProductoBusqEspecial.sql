
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
       Lp.PP01UD * (Mp.POIVPR/100.0)+Lp.PP01UD AS 'Precio_UD1_Bruto',
       Isnull(Lp.PP02UD,0) AS 'Precio_UD2',       
	   Lp.PP02UD * (Mp.POIVPR/100.0)+Lp.PP02UD AS 'Precio_UD2_Bruto',
       Isnull(Lp.ECUACION,'') AS 'Ecuacion_Ud1',
       Isnull(Lp.ECUACIONU2,'') AS 'Ecuacion_Ud2',
       Cast(0 As Bit) 'Ecuacion_Generada',
       
       #Stock#
             
       Isnull(Tc1.NOKOCARAC,'')	AS 'CLALIBPR',
	   Ltrim(Rtrim(Isnull(Tb.DATOSUBIC,''))) AS 'DATOSUBIC',
       Isnull(Tc1.NOKOCARAC,'') AS 'FAMILIA',
	   Cast(Case When Mp.ATPR = 'OCU' Then 1 Else 0 End As Bit) as 'Oculto',
       Mp.KOPRTE As 'Codigo_Tecnico',
       Isnull(Mf.FICHA,'') As Ficha

Into #Paso_Maepr      
    From MAEPR Mp
        Inner Join MAEPREM Mpn On Mpn.EMPRESA = @Empresa And Mpn.KOPR = Mp.KOPR 
		    Inner Join TABPRE Lp On Lp.KOLT = @Lista And Lp.KOPR = Mp.KOPR
			    Left Join TABCARAC Tc1 On Tc1.KOTABLA = 'CLALIBPR' AND Tc1.KOCARAC = Mp.CLALIBPR
				    Left Join TABBOPR Tb On Tb.EMPRESA = @Empresa And Tb.KOSU = @Sucursal And Tb.KOBO = @Bodega And Tb.KOPR = Mp.KOPR
                        Left Join MAEFICHA Mf On Mf.KOPR = Mp.KOPR
                        
WHERE 1 > 0
       #Sql_Filtro1#
       #Sql_Filtro2#
       #Ocultos#
       #Bloquear 
	   #Filtro_Productos#
       #Stock_Disponible#

Select * From #Paso_Maepr
Order By Codigo  

Drop Table #Paso_Maepr


