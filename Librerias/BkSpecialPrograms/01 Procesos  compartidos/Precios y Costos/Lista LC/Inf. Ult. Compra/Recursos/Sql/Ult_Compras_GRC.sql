Declare @Fecha_Desde As Datetime,
		@Fecha_Hasta As Datetime,
        @Empresa As Char(2)

Select @Fecha_Desde = '#Fecha_Desde#',@Fecha_Hasta = '#Fecha_Hasta#',@Empresa = '#Empresa#'

SELECT DISTINCT    Ddo.IDMAEEDO,
				   Ddo.IDMAEDDO,	
                   Ddo.TIDO, 
                   Ddo.NUDO, 
				   Ddo.SULIDO,
				   Ddo.BOSULIDO,
                   Ddo.FEEMLI As FECHA, 
                   Ddo.ENDO, 
                   Ddo.SUENDO, 
                   dbo.MAEEN.NOKOEN, 
                   Ddo.KOPRCT, 
                   Ddo.UDTRPR, 
                   Ddo.RLUDPR, 
                   Ddo.CAPRCO1, 
                   Ddo.CAPRCO2, 
                   Ddo.UD01PR, 
                   Ddo.UD02PR, 
                   Ddo.NOKOPR,
                   Ddo.PPPRNE,
                   Ddo.PPPRNERE1,
                   Ddo.PPPRNERE2,
				   Mpen.PPUL01,
				   Mpen.PPUL02,
				   Mpen.PM
Into #Tbl_Paso2
From MAEDDO Ddo 
	   Left Join MAEEN On Ddo.ENDO = dbo.MAEEN.KOEN AND Ddo.SUENDO = dbo.MAEEN.SUEN
		Left Join MAEPREM Mpen On Mpen.KOPR = Ddo.KOPRCT And Mpen.EMPRESA = @Empresa
Where Ddo.TIDO = 'GRC' And Ddo.FEEMLI BETWEEN @Fecha_Desde AND @Fecha_Hasta
Group By Ddo.IDMAEEDO,Ddo.IDMAEDDO,Ddo.NUDO, Ddo.ENDO, Ddo.SUENDO, dbo.MAEEN.NOKOEN, Ddo.KOPRCT, Ddo.UDTRPR, Ddo.RLUDPR, 
                      Ddo.CAPRCO1, Ddo.CAPRCO2, Ddo.UD01PR, Ddo.UD02PR, Ddo.PPPRNE, Ddo.NOKOPR, 
                      Ddo.FEEMLI, Ddo.TIDO,Ddo.SULIDO,Ddo.BOSULIDO,Ddo.PPPRNERE1,Ddo.PPPRNERE2,Mpen.PPUL01,Mpen.PPUL02,Mpen.PM
Order By Ddo.KOPRCT

Select *,
		ROUND(ISNULL(PPPRNERE2, 0) / ISNULL(RLUDPR, 0), 3) AS Ult_Compra,
		ISNULL(#Global_BaseBk#Zw_ListaLC_ValPro.Mcosto, 0) AS Mcosto
From #Tbl_Paso2
	Left Join #Global_BaseBk#Zw_ListaLC_ValPro ON #Tbl_Paso2.KOPRCT = #Global_BaseBk#Zw_ListaLC_ValPro.Codigo 
#Condicion#

Drop Table #Tbl_Paso2