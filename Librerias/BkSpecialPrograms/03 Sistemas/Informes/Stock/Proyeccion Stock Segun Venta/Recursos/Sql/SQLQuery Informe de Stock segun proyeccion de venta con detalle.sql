DECLARE @Fecha1 Date, -- Fecha de un año atras
        @Fecha2 Date = Getdate(), -- Fecha de Hoy
		@MesesEstudio Int = #MesesEstudio#,
		@MesesProyeccion Int = #MesesProyeccion#

-- Ventas de un año
Set @Fecha1 = DATEADD(M,-@MesesEstudio,@Fecha2) 

Create Table #PasoVentas(
[Empresa]					Char(2)			NOT NULL DEFAULT (''),
[RAZON]						Varchar(50)		NOT NULL DEFAULT (''),
[Sucursal]					Varchar(3)		NOT NULL DEFAULT (''),
[NOKOSU]					Varchar(50)		NOT NULL DEFAULT (''),
[Bodega]					Varchar(3)		NOT NULL DEFAULT (''),
[NOKOBO]					Varchar(50)		NOT NULL DEFAULT (''),
[Identificacdor_NodoPadre]	Int				NOT NULL DEFAULT (0),
[Descripcion_NP]			Varchar(50)		NOT NULL DEFAULT (''),
[TIPR]						Varchar(3)		NOT NULL DEFAULT (''),
[Codigo]					Varchar(13)		NOT NULL DEFAULT (''),
[Codigo_Nodo]				Int				NOT NULL DEFAULT (0),
[Codigo_Madre]				Varchar(13)		NOT NULL DEFAULT (''),
[Descripcion_Consolid]		Varchar(100)	NOT NULL DEFAULT (''),
[Descripcion]				Varchar(50)		NOT NULL DEFAULT (''),
[CantUd1]					Float			NOT NULL DEFAULT (0),
[CantUd1_Consolid]			Float			NOT NULL DEFAULT (0),
[PromVta]					Float			NOT NULL DEFAULT (0),
[PromVta_Consolid]			Float			NOT NULL DEFAULT (0),
[Stock_Fisico]				Float			NOT NULL DEFAULT (0),
[Stock_Pendiente]			Float			NOT NULL DEFAULT (0),
[Desde]						Datetime,
[Hasta]						Datetime,
)

Insert Into #PasoVentas(Empresa,RAZON,Sucursal,NOKOSU,Bodega,NOKOBO,Codigo,Descripcion,TIPR)

Select Tb.EMPRESA,Cp.RAZON,Tb.KOSU,Ts.NOKOSU,Tb.KOBO,Tb.NOKOBO,Mp.KOPR,NOKOPR,TIPR 
From MAEPR Mp
Inner Join TABBOPR Tbp On Tbp.KOPR = Mp.KOPR
Left Join TABBO Tb On Tb.EMPRESA = Tbp.EMPRESA And Tb.KOSU = Tbp.KOSU And Tb.KOBO = Tbp.KOBO
Left Join CONFIGP Cp On Cp.EMPRESA = Tbp.EMPRESA
Left Join TABSU Ts On Ts.EMPRESA = Tbp.EMPRESA And Ts.KOSU = Tbp.KOSU
Where Tbp.EMPRESA = '#Empresa#' And Mp.TIPR = 'FPN'
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
From #Global_BaseBk#Zw_Prod_Asociacion Asoc
Left Join #Global_BaseBk#Zw_TblArbol_Asociaciones Arb1 On Asoc.Codigo_Nodo = Arb1.Codigo_Nodo
Left Join #Global_BaseBk#Zw_TblArbol_Asociaciones Arb2 On Arb1.Identificacdor_NodoPadre = Arb2.Codigo_Nodo
Where Asoc.Codigo_Nodo In (Select Codigo_Nodo From #Global_BaseBk#Zw_TblArbol_Asociaciones Where Nodo_Raiz = 1 And Es_Seleccionable = 1)
And Asoc.Codigo = #PasoVentas.Codigo

Update #PasoVentas Set CantUd1_Consolid = (Select Sum(CantUd1) From #PasoVentas Z1 Where Z1.Codigo_Madre = Z2.Codigo_Madre)
From #PasoVentas Z2

Update #PasoVentas Set PromVta = Round(CantUd1/@MesesEstudio,2),PromVta_Consolid = Round(CantUd1_Consolid/@MesesEstudio,2)

Update #PasoVentas Set Stock_Fisico = Isnull(STFI1,0),Stock_Pendiente = Isnull(STOCNV1C,0)
From #PasoVentas 
Inner Join MAEST On Empresa = MAEST.EMPRESA And KOSU = Sucursal And KOBO = Bodega And KOPR = Codigo

--Select * From #PasoVentas
--Drop Table #PasoVentas

Declare @Contador Int = 0

Declare @AAAA As Varchar(4)= Cast(year(Getdate()) As Varchar(4))
Declare @MM As Varchar(2) = Case When month(Getdate()) < 10 Then '0'+Cast(month(Getdate()) As Varchar(2)) Else Cast(month(Getdate()) As Varchar(2)) end

Declare @Fecha As Datetime = @AAAA+@MM+'01'
Declare @FechaDesde As Datetime
Declare @FechaHasta As Datetime
Declare @PromConsolid Bit = 1
Declare @SqlQueryTbl Varchar(Max);

While @Contador <= @MesesProyeccion 
Begin

	Set @Contador = @Contador+1
	Declare @sqlTbl Varchar(Max);
	Declare @Campo  Varchar(30);
	Declare @CampoMesAnterior As Varchar(30);
	Declare @FechaMesAnterior As Datetime

	Set @Campo = Substring(Datename(Month,@Fecha),1,3)+'-'+Cast(Year(@Fecha) As Varchar(4))

	Set @sqlTbl = 'Alter Table #PasoVentas'+Char(13) + 'ADD [P'+@Campo+'] Float Default(0),[RSF'+@Campo+'] Float Default(0),[S'+@Campo+'] Float Default(0)'					
	Exec(@sqlTbl)
	
	Set @sqlTbl = 'Update #PasoVentas Set [P'+@Campo+'] = 0,[RSF'+@Campo+'] = 0,[S'+@Campo+'] = 0'
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

	--Print 'Primer día del mes==>>' + @PrimerDiaMes
	--Print 'Último día del mes==>>' + @UltimoDiaMes

	Set @sqlTbl = 'Update #PasoVentas Set [P'+@Campo+'] = Isnull((Select Sum(Isnull(CAPRCO1,0)-(Isnull(CAPRAD1,0)+Isnull(CAPREX1,0))) 
				   From MAEDDO Where EMPRESA = Empresa And SULIDO = Sucursal And BOSULIDO = Bodega And TIDO = ''OCC'' And KOPRCT = Codigo And FEERLI Between '''+CONVERT(varchar,@FechaDesde,112)+''' And '''+CONVERT(varchar,@FechaHasta,112)+'''),0)'
	Exec(@sqlTbl)

		Set @sqlTbl = 'Update #PasoVentas Set [RSF'+@Campo+'] = Isnull((Select Sum(Isnull(CAPRCO1,0)-(Isnull(CAPRAD1,0)+Isnull(CAPREX1,0))) 
				   From MAEDDO Where EMPRESA = Empresa And SULIDO = Sucursal And BOSULIDO = Bodega And TIDO = ''FCC'' And KOPRCT = Codigo And FEERLI < '''+CONVERT(varchar,@FechaDesde,112)+'''),0)'
	Exec(@sqlTbl)
	Print @sqlTbl

		Set @sqlTbl = 'Update #PasoVentas Set [RSF'+@Campo+'] = [RSF'+@Campo+'] + Isnull((Select Sum(Isnull(CAPRCO1,0)-(Isnull(CAPRAD1,0)+Isnull(CAPREX1,0))) 
				   From MAEDDO Where EMPRESA = Empresa And SULIDO = Sucursal And BOSULIDO = Bodega And TIDO = ''FCC'' And KOPRCT = Codigo And FEERLI Between '''+CONVERT(varchar,@FechaDesde,112)+''' And '''+CONVERT(varchar,@FechaHasta,112)+'''),0)'
	Exec(@sqlTbl)
	Print @sqlTbl

	Set @sqlTbl = 'Update #PasoVentas Set [RSF'+@Campo+'] = Round([RSF'+@Campo+'],0)'
	Exec(@sqlTbl)
	Print @sqlTbl

		If @PromConsolid = 1
			Begin
				If @Contador = 1
					Begin
						Set @sqlTbl = 'Update #PasoVentas Set [S'+@Campo+'] = Case When ((Stock_Fisico+[P'+@Campo+'])-PromVta) < 0 Then 0 
									   Else Round((Stock_Fisico+[P'+@Campo+'])-PromVta,2) End'
						Exec(@sqlTbl)
						Print @Campo+ ' Eje 1'
					End
				Else
					Begin
						Set @sqlTbl = 'Update #PasoVentas Set [S'+@Campo+'] = Case When (([S'+@CampoMesAnterior+']+[P'+@Campo+'])-PromVta) < 0 Then 0 
									   Else Round(([S'+@CampoMesAnterior+']+[P'+@Campo+'])-PromVta,2) End'
						Exec(@sqlTbl)			
						Print @Campo+ ' Eje 2'
				End				
			End
		Else
			Begin
				If @Contador = 1
					Begin
						Set @sqlTbl = 'Update #PasoVentas Set [S'+@Campo+'] = Case When ((Stock_Fisico+[P'+@Campo+'])-PromVta) < 0 Then 0 Else Round((Stock_Fisico+[PJul-2022])-PromVta,2) End'
						Exec(@sqlTbl)
						Print @Campo+ ' Eje 3'
					End
				Else
					Begin
						Set @sqlTbl = 'Update #PasoVentas Set [S'+@Campo+'] = Case When (([S'+@CampoMesAnterior+']+[P'+@Campo+'])-PromVta) < 0 Then 0 Else Round(([S'+@CampoMesAnterior+']+[PJul-2022])-PromVta,2) End'
						Exec(@sqlTbl)
						Print @Campo+ ' Eje 4'
					End
			End
	
	Set @SqlQueryTbl = 'Sum([P'+@Campo+']) As [P'+@Campo+'],Sum([S'+@Campo+']) As [S'+@Campo+'],'
	Set @Fecha =DATEADD(D,1,@FechaHasta)

End

Select #PasoVentas.*,
       Mp.MRPR,Isnull(Mr.NOKOMR,'') As NOKOMR,
       Mp.FMPR,ISNULL(SFm.NOKOFM,'') As NOKOFM,
       Mp.PFPR,ISNULL(PFm.NOKOPF,'') As NOKOPF,
       Mp.HFPR,ISNULL(HFm.NOKOHF,'') As NOKOHF,
	   Mp.RUPR,ISNULL(Rub.NOKORU,'') As NOKORU,
       Mp.CLALIBPR,ISNULL(Tcl.NOKOCARAC,'') As NOKOCARAC
Into #TblPs# From #PasoVentas
Left Join MAEPR Mp On Mp.KOPR = Codigo
Left Join TABMR Mr On Mp.MRPR = Mr.KOMR
Left Join TABFM SFm On SFm.KOFM = Mp.FMPR
Left Join TABPF PFm On PFm.KOFM = Mp.FMPR And PFm.KOPF = Mp.PFPR
Left Join TABHF HFm On HFm.KOFM = Mp.FMPR And HFm.KOPF = Mp.PFPR And HFm.KOHF = Mp.HFPR
Left Join TABRU Rub On Rub.KORU = Mp.RUPR
Left Join TABCARAC Tcl On Tcl.KOTABLA = 'CLALIBPR' And KOCARAC = Mp.CLALIBPR  
Drop Table #PasoVentas

/*
Select * From TblPsJa
Order By Identificacdor_NodoPadre,Codigo_Madre,Codigo

Select Identificacdor_NodoPadre As Campo,Descripcion_Consolid As Descripcion,
	   SUM(CantUd1) As CantUd1,Sum(Stock_Fisico) As Stock_Fisico,Sum(Stock_Pendiente) As Stock_Pendiente,
	   --SUM([PJul-2022]) As [PJul-2022],SUM([RSFJul-2022]) As [RSFJul-2022],SUM([SJul-2022]) As [SAgo-2022],
	   SUM([PAgo-2022]) As [PAgo-2022],SUM([RSFAgo-2022]) As [RSFAgo-2022],SUM([SAgo-2022]) As [SAgo-2022],
	   SUM([PSep-2022]) As [PSep-2022],SUM([RSFSep-2022]) As [RSFSep-2022],SUM([SSep-2022]) As [SSep-2022],
	   SUM([POct-2022]) As [POct-2022],SUM([RSFOct-2022]) As [RSFOct-2022],SUM([SOct-2022]) As [SOct-2022],
	   SUM([PNov-2022]) As [PNov-2022],SUM([RSFNov-2022]) As [RSNov-2022],SUM([SNov-2022]) As [SNov-2022],
	   SUM([PDic-2022]) As [PDic-2022],SUM([RSFDic-2022]) As [RSDic-2022],SUM([SDic-2022]) As [SDic-2022],
	   SUM([PEne-2023]) As [PEne-2023],SUM([RSFEne-2023]) As [RSEne-2023],SUM([SEne-2023]) As [SEne-2023]
From TblPsJa
Group By Identificacdor_NodoPadre,Descripcion_Consolid


Select Codigo As Campo,Descripcion As Descripcion,
	   SUM(CantUd1) As CantUd1,SUM(PromVta) As PromVta,Sum(Stock_Fisico) As Stock_Fisico,Sum(Stock_Pendiente) As Stock_Pendiente,
	   --SUM([PJul-2022]) As [PJul-2022],SUM([RSFJul-2022]) As [RSFJul-2022],SUM([SJul-2022]) As [SAgo-2022],
	   SUM([PAgo-2022]) As [PAgo-2022],SUM([RSFAgo-2022]) As [RSFAgo-2022],SUM([SAgo-2022]) As [SAgo-2022],
	   SUM([PSep-2022]) As [PSep-2022],SUM([RSFSep-2022]) As [RSFSep-2022],SUM([SSep-2022]) As [SSep-2022],
	   SUM([POct-2022]) As [POct-2022],SUM([RSFOct-2022]) As [RSFOct-2022],SUM([SOct-2022]) As [SOct-2022],
	   SUM([PNov-2022]) As [PNov-2022],SUM([RSFNov-2022]) As [RSNov-2022],SUM([SNov-2022]) As [SNov-2022],
	   SUM([PDic-2022]) As [PDic-2022],SUM([RSFDic-2022]) As [RSDic-2022],SUM([SDic-2022]) As [SDic-2022],
	   SUM([PEne-2023]) As [PEne-2023],SUM([RSFEne-2023]) As [RSEne-2023],SUM([SEne-2023]) As [SEne-2023]
From TblPsJa
Where Identificacdor_NodoPadre = 2
Group By Codigo,Descripcion
*/

--Drop table TblPsJa







