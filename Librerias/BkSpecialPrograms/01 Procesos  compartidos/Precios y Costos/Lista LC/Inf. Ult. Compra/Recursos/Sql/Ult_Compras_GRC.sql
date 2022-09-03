Declare @Fecha_Desde As Datetime,
		@Fecha_Hasta As Datetime

Select @Fecha_Desde = '#Fecha_Desde#',@Fecha_Hasta = '#Fecha_Hasta#'

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
		Left Join MAEPREM Mpen On Mpen.KOPR = Ddo.KOPRCT And Mpen.EMPRESA = '01' 
Where Ddo.TIDO = 'GRC' And Ddo.FEEMLI BETWEEN @Fecha_Desde AND @Fecha_Hasta
Group By Ddo.IDMAEEDO,Ddo.IDMAEDDO,Ddo.NUDO, Ddo.ENDO, Ddo.SUENDO, dbo.MAEEN.NOKOEN, Ddo.KOPRCT, Ddo.UDTRPR, Ddo.RLUDPR, 
                      Ddo.CAPRCO1, Ddo.CAPRCO2, Ddo.UD01PR, Ddo.UD02PR, Ddo.PPPRNE, Ddo.NOKOPR, 
                      Ddo.FEEMLI, Ddo.TIDO,Ddo.SULIDO,Ddo.BOSULIDO,Ddo.PPPRNERE1,Ddo.PPPRNERE2,Mpen.PPUL01,Mpen.PPUL02,Mpen.PM
Order By Ddo.KOPRCT

Select *,
		ROUND(ISNULL(PPPRNERE2, 0) / ISNULL(RLUDPR, 0), 3) AS Ult_Compra,
		ISNULL(Zw_ListaLC_ValPro.Mcosto, 0) AS Mcosto
From #Tbl_Paso2
	Left Join Zw_ListaLC_ValPro ON #Tbl_Paso2.KOPRCT = Zw_ListaLC_ValPro.Codigo 
#Condicion#

--Select  --dbo.Zw_TblPasoUltGRCA72.Id, 
--		dbo.Zw_TblPasoUltGRCA72.KOPRCT, 
--		dbo.Zw_TblPasoUltGRCA72.NOKOPR, 
--		dbo.Zw_TblPasoUltGRCA72.RLUDPR,
--		dbo.Zw_TblPasoUltGRCA72.CAPRCO2, 
--		dbo.Zw_TblPasoUltGRCA72.UD02PR, 
--		dbo.Zw_TblPasoUltGRCA72.PPPRNE, 
--		dbo.MAEPREM.PM,
--		ROUND(ISNULL(dbo.Zw_TblPasoUltGRCA72.PPPRNERE2, 0) / ISNULL(dbo.Zw_TblPasoUltGRCA72.RLUDPR, 0), 3) AS Ult_Compra, 
--		ISNULL(dbo.Zw_ListaLC_ValPro.Mcosto, 0) AS Mcosto, 
--		dbo.Zw_TblPasoUltGRCA72.TIDO, 
--		dbo.Zw_TblPasoUltGRCA72.NUDO, 
--		dbo.Zw_TblPasoUltGRCA72.FEEMLI, 
--		dbo.Zw_TblPasoUltGRCA72.ENDO, 
--		dbo.Zw_TblPasoUltGRCA72.SUENDO, 
--		dbo.Zw_TblPasoUltGRCA72.NOKOEN, 
--		dbo.Zw_TblPasoUltGRCA72.SULIDO, 
--		dbo.Zw_TblPasoUltGRCA72.BOSULIDO
--FROM dbo.Zw_TblPasoUltGRCA72 
--	LEFT OUTER JOIN dbo.Zw_ListaLC_ValPro ON dbo.Zw_TblPasoUltGRCA72.KOPRCT = dbo.Zw_ListaLC_ValPro.Codigo 
--		LEFT OUTER JOIN dbo.MAEPREM ON dbo.Zw_TblPasoUltGRCA72.KOPRCT = dbo.MAEPREM.KOPR
--where 
--dbo.Zw_ListaLC_ValPro.FechaModif <> (SELECT replace(convert(varchar, getdate(), 111), '/',''))
--OR dbo.Zw_ListaLC_ValPro.FechaModif IS NULL

--Select * From Zw_ListaLC_ValPro

Drop Table #Tbl_Paso2


