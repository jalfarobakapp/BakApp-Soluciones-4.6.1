Declare @Empresa Char(2) = '#Empresa#'
Declare @Sucursal Char(3) = '#Sucursal#'
Declare @Fecha1 Date 
Declare @Fecha2 Date = Getdate() 
Declare @MesesEstudio Int = #MesesEstudio#
Declare @MesesProyeccion Int = #MesesProyeccion#

Declare @Contador Int = 0

Declare @AAAA As Varchar(4)= Cast(year(Getdate()) As Varchar(4))
Declare @MM As Varchar(2) = Case When month(Getdate()) < 10 Then '0'+Cast(month(Getdate()) As Varchar(2)) Else Cast(month(Getdate()) As Varchar(2)) end
Declare @Fecha As Datetime = @AAAA+@MM+'01'
Declare @FechaDesde As Datetime
Declare @FechaHasta As Datetime
Declare @PromConsolid Bit = 1
Declare @SqlQueryTbl Varchar(Max);

-- Ventas de un a�o
Set @Fecha1 = DATEADD(M,-@MesesEstudio,@Fecha2) 

Create Table #PasoVentas(
[Empresa]					Char(2)			NOT NULL DEFAULT (''),
[RAZON]						Varchar(50)		NOT NULL DEFAULT (''),
[Sucursal]					Varchar(3)		NOT NULL DEFAULT (''),
[NOKOSU]					Varchar(50)		NOT NULL DEFAULT (''),
[Bodega]					Varchar(3)		NOT NULL DEFAULT (''),
[NOKOBO]					Varchar(50)		NOT NULL DEFAULT (''),
[Identificacdor_NodoPadre]	Varchar(30)		NOT NULL DEFAULT (0),
[Descripcion_NP]			Varchar(50)		NOT NULL DEFAULT (''),
[TIPR]						Varchar(3)		NOT NULL DEFAULT (''),
[Codigo]					Varchar(13)		NOT NULL DEFAULT (''),
[Codigo_Nodo]				Varchar(30)		NOT NULL DEFAULT (0),
[Codigo_Madre]				Varchar(13)		NOT NULL DEFAULT (''),
[Descripcion_Consolid]		Varchar(100)	NOT NULL DEFAULT (''),
[Descripcion]				Varchar(50)		NOT NULL DEFAULT (''),
[CantUd1]					Float			NOT NULL DEFAULT (0),
[CantUd1_Consolid]			Float			NOT NULL DEFAULT (0),
[PromVta]					Float			NOT NULL DEFAULT (0),
[PromVta_Consolid]			Float			NOT NULL DEFAULT (0),
[PromVta_Calculo]			Float			NOT NULL DEFAULT (0),
[Stock_Fisico]				Float			NOT NULL DEFAULT (0),
[Stock_Pendiente]			Float			NOT NULL DEFAULT (0),
[Desde]						Datetime,
[Hasta]						Datetime,
[MRPR]						Varchar(20)		NOT NULL DEFAULT (''),
[NOKOMR]					Varchar(30)		NOT NULL DEFAULT (''),
[FMPR]						Varchar(4)		NOT NULL DEFAULT (''),
[NOKOFM]					Varchar(30)		NOT NULL DEFAULT (''),
[PFPR]						Varchar(4)		NOT NULL DEFAULT (''),
[NOKOPF]					Varchar(30)		NOT NULL DEFAULT (''),
[HFPR]						Varchar(4)		NOT NULL DEFAULT (''),
[NOKOHF]					Varchar(30)		NOT NULL DEFAULT (''),
[RUPR]						Varchar(3)		NOT NULL DEFAULT (''),
[NOKORU]					Varchar(30)		NOT NULL DEFAULT (''),
[CLALIBPR]					Varchar(10)		NOT NULL DEFAULT (''),
[NOKOCARAC]					Varchar(200)	NOT NULL DEFAULT (''),
)

Create Table #Tbl2Ps#(
[CODIGO]					Varchar(30)			NOT NULL DEFAULT (''),
[DESCRIPCION]				Varchar(200)		NOT NULL DEFAULT (''),
[PromVta]					Float			NOT NULL DEFAULT (0),
[PromVta_Original]			Float			NOT NULL DEFAULT (0),
[Stock_Fisico]				Float			NOT NULL DEFAULT (0),
)

Insert Into #PasoVentas(Empresa,RAZON,Sucursal,NOKOSU,Bodega,NOKOBO,Codigo,Descripcion,TIPR,MRPR,NOKOMR,FMPR,NOKOFM,PFPR,NOKOPF,HFPR,NOKOHF,RUPR,NOKORU,CLALIBPR,NOKOCARAC)

Select Tb.EMPRESA,Cp.RAZON,Tb.KOSU,Ts.NOKOSU,Tb.KOBO,Tb.NOKOBO,Mp.KOPR,NOKOPR,TIPR,
	   Mp.MRPR,Isnull(Mr.NOKOMR,'') As NOKOMR,
       Mp.FMPR,ISNULL(SFm.NOKOFM,'') As NOKOFM,
       Mp.PFPR,ISNULL(PFm.NOKOPF,'') As NOKOPF,
       Mp.HFPR,ISNULL(HFm.NOKOHF,'') As NOKOHF,
	   Mp.RUPR,ISNULL(Rub.NOKORU,'') As NOKORU,
       Mp.CLALIBPR,ISNULL(Tcl.NOKOCARAC,'') As NOKOCARAC 
From MAEPR Mp
Inner Join TABBOPR Tbp On Tbp.KOPR = Mp.KOPR
	Left Join TABBO Tb On Tb.EMPRESA = Tbp.EMPRESA And Tb.KOSU = Tbp.KOSU And Tb.KOBO = Tbp.KOBO
		Left Join CONFIGP Cp On Cp.EMPRESA = Tbp.EMPRESA
			Left Join TABSU Ts On Ts.EMPRESA = Tbp.EMPRESA And Ts.KOSU = Tbp.KOSU
				Left Join TABMR Mr On Mp.MRPR = Mr.KOMR
					Left Join TABFM SFm On SFm.KOFM = Mp.FMPR
						Left Join TABPF PFm On PFm.KOFM = Mp.FMPR And PFm.KOPF = Mp.PFPR
							Left Join TABHF HFm On HFm.KOFM = Mp.FMPR And HFm.KOPF = Mp.PFPR And HFm.KOHF = Mp.HFPR
								Left Join TABRU Rub On Rub.KORU = Mp.RUPR
									Left Join TABCARAC Tcl On Tcl.KOTABLA = 'CLALIBPR' And KOCARAC = Mp.CLALIBPR  

Where Tbp.EMPRESA = @Empresa And Ts.KOSU = @Sucursal And Mp.TIPR = 'FPN'
Order By Tbp.KOPR,Tbp.EMPRESA,Tbp.KOSU,Tbp.KOBO

Update #PasoVentas Set CantUd1 = Isnull((Select ROUND(SUM(
            CASE WHEN TIDO IN ('NCE','NCV','NCX','NCZ','NEV') THEN - 1 * Isnull(CAPRCO1,0)
	        WHEN TIDO IN ('GDV','GDP') THEN Isnull(CAPRCO1-CAPREX1,0)
	       	ELSE Isnull(CAPRCO1,0) END	       	
	       	),2) From MAEDDO Ddo Where 
			#PasoVentas.Empresa = Ddo.EMPRESA And #PasoVentas.Sucursal = Ddo.SULIDO And #PasoVentas.Bodega = Ddo.BOSULIDO And #PasoVentas.Codigo = Ddo.KOPRCT And
			TIDO In ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV',
	         'GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV') And FEEMLI BETWEEN @Fecha1 And @Fecha2 #FiltroBodegas#),0)

Update  #PasoVentas Set Codigo_Nodo = Asoc.Codigo_Nodo,
				  Identificacdor_NodoPadre = Arb1.Identificacdor_NodoPadre,
				  Descripcion_NP = Arb2.Descripcion, Codigo_Madre = Arb1.Codigo_Madre,Descripcion_Consolid = Arb1.Descripcion
From BAKAPP_SG.dbo.Zw_Prod_Asociacion Asoc
Left Join BAKAPP_SG.dbo.Zw_TblArbol_Asociaciones Arb1 On Asoc.Codigo_Nodo = Arb1.Codigo_Nodo
Left Join BAKAPP_SG.dbo.Zw_TblArbol_Asociaciones Arb2 On Arb1.Identificacdor_NodoPadre = Arb2.Codigo_Nodo
Where Asoc.Codigo_Nodo In (Select Codigo_Nodo From BAKAPP_SG.dbo.Zw_TblArbol_Asociaciones Where Nodo_Raiz = 1 And Es_Seleccionable = 1)
And Asoc.Codigo = #PasoVentas.Codigo


--Update #PasoVentas Set CantUd1 = Isnull((Select ROUND(SUM(
--            CASE WHEN TIDO IN ('NCE','NCV','NCX','NCZ','NEV') THEN - 1 * Isnull(CAPRCO1,0)
--	        WHEN TIDO IN ('GDV','GDP') THEN Isnull(CAPRCO1-CAPREX1,0)
--	       	ELSE Isnull(CAPRCO1,0) END	       	
--	       	),2) From MAEDDO Ddo Where 
--			#PasoVentas.Empresa = Ddo.EMPRESA And #PasoVentas.Sucursal = Ddo.SULIDO And #PasoVentas.Bodega = Ddo.BOSULIDO And #PasoVentas.Codigo = Ddo.KOPRCT And
--			TIDO In ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV',
--	         'GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV') And FEEMLI BETWEEN @Fecha1 And @Fecha2 ),0)

--Update  #PasoVentas Set Codigo_Nodo = Asoc.Codigo_Nodo,
--				  Identificacdor_NodoPadre = Arb1.Identificacdor_NodoPadre,
--				  Descripcion_NP = Arb2.Descripcion, Codigo_Madre = Arb1.Codigo_Madre,Descripcion_Consolid = Arb1.Descripcion
--From BAKAPP_SG.dbo.Zw_Prod_Asociacion Asoc
--Left Join BAKAPP_SG.dbo.Zw_TblArbol_Asociaciones Arb1 On Asoc.Codigo_Nodo = Arb1.Codigo_Nodo
--Left Join BAKAPP_SG.dbo.Zw_TblArbol_Asociaciones Arb2 On Arb1.Identificacdor_NodoPadre = Arb2.Codigo_Nodo
--Where Asoc.Codigo_Nodo In (Select Codigo_Nodo From BAKAPP_SG.dbo.Zw_TblArbol_Asociaciones Where Nodo_Raiz = 1 And Es_Seleccionable = 1)
--And Asoc.Codigo = #PasoVentas.Codigo

Update #PasoVentas Set CantUd1_Consolid = (Select Sum(CantUd1) From #PasoVentas Z1 Where Z1.Codigo_Madre = Z2.Codigo_Madre)
From #PasoVentas Z2

Update #PasoVentas Set PromVta = Round(CantUd1/@MesesEstudio,2),PromVta_Consolid = Round(CantUd1_Consolid/@MesesEstudio,2)
Update #PasoVentas Set PromVta_Calculo = PromVta_Consolid 

Update #PasoVentas Set Stock_Fisico = Isnull(STFI1,0),Stock_Pendiente = Isnull(STOCNV1C,0)
From #PasoVentas 
Inner Join MAEST On Empresa = MAEST.EMPRESA And KOSU = Sucursal And KOBO = Bodega And KOPR = Codigo


While @Contador <= @MesesProyeccion 
Begin

	Set @Contador = @Contador+1
	Declare @sqlTbl Varchar(Max);
	Declare @Campo  Varchar(30);
	Declare @CampoMesAnterior As Varchar(30);
	Declare @FechaMesAnterior As Datetime

	Set @Campo = Substring(Datename(Month,@Fecha),1,3)+'-'+Cast(Year(@Fecha) As Varchar(4))

    -- TABLA 1
	Set @sqlTbl = 'Alter Table #PasoVentas'+Char(13) + 'ADD [P'+@Campo+'] Float Default(0),[RSF'+@Campo+'] Float Default(0),[S'+@Campo+'] Float Default(0)'					
	Exec(@sqlTbl)
	
	Set @sqlTbl = 'Update #PasoVentas Set [P'+@Campo+'] = 0,[RSF'+@Campo+'] = 0,[S'+@Campo+'] = 0'
	Exec(@sqlTbl)

    -- TABLA 2

    	Set @sqlTbl = 'Alter Table #Tbl2Ps#'+Char(13) + 'ADD [P'+@Campo+'] Float Default(0),[RSF'+@Campo+'] Float Default(0),[S'+@Campo+'] Float Default(0)'					
	Exec(@sqlTbl)
	
	Set @sqlTbl = 'Update #Tbl2Ps# Set [P'+@Campo+'] = 0,[RSF'+@Campo+'] = 0,[S'+@Campo+'] = 0'
	Exec(@sqlTbl)

	Declare @d varchar(2),@m varchar(2),@a varchar(4), @FE varchar(50), @PrimerDiaMes varchar(50), @FN varchar(50),@UltimoDiaMes varchar(50)

	Set @d= Case When day(@Fecha) < 10 Then '0'+Cast(day(@Fecha) As Varchar(2)) Else Cast(day(@Fecha) As Varchar(2)) End  
	set @m= Case When month(@Fecha) < 10 Then '0'+Cast(month(@Fecha) As Varchar(2)) Else Cast(month(@Fecha) As Varchar(2)) end
	set @a= Cast(year(@Fecha) As Varchar(4))
	set @PrimerDiaMes= @a+@m+'01'
	set @FN=dateadd( month,1,@PrimerDiaMes) -1
	Set @d= Case When day(@FN) < 10  Then '0'+Cast(day(@FN) As Varchar(2)) Else Cast(day(@FN) As Varchar(2)) End
	set @m= Case When month(@FN) < 10 Then '0'+Cast(month(@FN) As Varchar(2)) Else Cast(month(@FN) As Varchar(2)) end
	set @a= Cast(year(@FN) As Varchar(4))
	set @UltimoDiaMes= @a+@m+@d
	Set @FechaDesde = @PrimerDiaMes
	Set @FechaHasta = @UltimoDiaMes

	Set @FechaMesAnterior = DATEADD(D,-1,@FechaDesde)
	Set @CampoMesAnterior = Substring(Datename(Month,@FechaMesAnterior),1,3)+'-'+Cast(Year(@FechaMesAnterior) As Varchar(4))

	Set @Fecha =DATEADD(D,1,@FechaHasta)	

End

Select * Into #TblPs# From #PasoVentas
Drop Table #PasoVentas



