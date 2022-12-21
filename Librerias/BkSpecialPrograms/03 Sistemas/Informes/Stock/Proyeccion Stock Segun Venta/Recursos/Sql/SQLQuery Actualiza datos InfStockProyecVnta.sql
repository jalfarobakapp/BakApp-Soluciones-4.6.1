DECLARE @Fecha1 Date, -- Fecha de un año atras
        @Fecha2 Date = Getdate(), -- Fecha de Hoy
		@MesesEstudio Int = #MesesEstudio#,
		@MesesProyeccion Int = #MesesProyeccion#

-- Ventas de un año
Set @Fecha1 = DATEADD(M,-@MesesEstudio,@Fecha2) 

Declare @Contador Int = 0

Declare @AAAA As Varchar(4)= Cast(year(Getdate()) As Varchar(4))
Declare @MM As Varchar(2) = Case When month(Getdate()) < 10 Then '0'+Cast(month(Getdate()) As Varchar(2)) Else Cast(month(Getdate()) As Varchar(2)) end

Declare @Fecha As Datetime = @AAAA+@MM+'01'
Declare @FechaDesde As Datetime
Declare @FechaHasta As Datetime
Declare @PromConsolid Bit = 1
Declare @SqlQueryTbl Varchar(Max);

Update #TblPs# Set PromVta_Calculo = PromVta_Consolid --#Condicion1Adicional#

--Update#TblPs#CondicionExtraordinaria

While @Contador <= @MesesProyeccion 
Begin

	Set @Contador = @Contador+1
	Declare @sqlTbl Varchar(Max);
	Declare @Campo  Varchar(30);
	Declare @CampoMesAnterior As Varchar(30);
	Declare @FechaMesAnterior As Datetime

	Set @Campo = Substring(Datename(Month,@Fecha),1,3)+'-'+Cast(Year(@Fecha) As Varchar(4))

	Set @sqlTbl = 'Update #TblPs# Set [P'+@Campo+'] = 0,[RSF'+@Campo+'] = 0,[S'+@Campo+'] = 0 --#CondicionAdicional#'
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

	Set @sqlTbl = 'Update #TblPs# Set [P'+@Campo+'] = Isnull((Select Sum(Isnull(CAPRCO1,0)-(Isnull(CAPRAD1,0)+Isnull(CAPREX1,0))) 
				   From MAEDDO Where EMPRESA = Empresa And SULIDO = Sucursal And BOSULIDO = Bodega And TIDO = ''OCC'' And KOPRCT = Codigo And FEERLI Between '''+CONVERT(varchar,@FechaDesde,112)+''' And '''+CONVERT(varchar,@FechaHasta,112)+'''),0)
                   --#CondicionAdicional#'
	Exec(@sqlTbl)

    Set @sqlTbl = 'Update #TblPs# Set [RSF'+@Campo+'] = Isnull((Select Sum(Isnull(CAPRCO1,0)-(Isnull(CAPRAD1,0)+Isnull(CAPREX1,0))) 
				   From MAEDDO Where EMPRESA = Empresa And SULIDO = Sucursal And BOSULIDO = Bodega And TIDO = ''FCC'' And KOPRCT = Codigo And FEERLI Between '''+CONVERT(varchar,@FechaDesde,112)+''' And '''+CONVERT(varchar,@FechaHasta,112)+'''),0)'
	Exec(@sqlTbl)
	Print @sqlTbl

	--	Set @sqlTbl = 'Update #TblPs# Set [RSF'+@Campo+'] = Isnull((Select Sum(Isnull(CAPRCO1,0)-(Isnull(CAPRAD1,0)+Isnull(CAPREX1,0))) 
	--			   From MAEDDO Where EMPRESA = Empresa And SULIDO = Sucursal And BOSULIDO = Bodega And TIDO = ''FCC'' And KOPRCT = Codigo And FEERLI < '''+CONVERT(varchar,@FechaDesde,112)+'''),0)
 --                  --#CondicionAdicional#'
	--Exec(@sqlTbl)
	--Print @sqlTbl

	--	Set @sqlTbl = 'Update #TblPs# Set [RSF'+@Campo+'] = [RSF'+@Campo+'] + Isnull((Select Sum(Isnull(CAPRCO1,0)-(Isnull(CAPRAD1,0)+Isnull(CAPREX1,0))) 
	--			   From MAEDDO Where EMPRESA = Empresa And SULIDO = Sucursal And BOSULIDO = Bodega And TIDO = ''FCC'' And KOPRCT = Codigo And FEERLI Between '''+CONVERT(varchar,@FechaDesde,112)+''' And '''+CONVERT(varchar,@FechaHasta,112)+'''),0)
 --                  --#CondicionAdicional#'
	--Exec(@sqlTbl)
	--Print @sqlTbl

	Set @sqlTbl = 'Update #TblPs# Set [RSF'+@Campo+'] = Round([RSF'+@Campo+'],0)
                   --#CondicionAdicional#'
	Exec(@sqlTbl)
	Print @sqlTbl

		--If @PromConsolid = 1
		--	Begin
		--		If @Contador = 1
		--			Begin
		--				Set @sqlTbl = 'Update #TblPs# Set [S'+@Campo+'] = Case When ((Stock_Fisico+[P'+@Campo+'])-PromVta) < 0 Then 0 
		--							   Else Round((Stock_Fisico+[P'+@Campo+'])-PromVta,2) End
  --                                     --#CondicionAdicional#'
		--				Exec(@sqlTbl)
		--				Print @Campo+ ' Eje 1'
		--			End
		--		Else
		--			Begin
		--				Set @sqlTbl = 'Update #TblPs# Set [S'+@Campo+'] = Case When (([S'+@CampoMesAnterior+']+[P'+@Campo+'])-PromVta) < 0 Then 0 
		--							   Else Round(([S'+@CampoMesAnterior+']+[P'+@Campo+'])-PromVta,2) End
  --                                     --#CondicionAdicional#'
		--				Exec(@sqlTbl)			
		--				Print @Campo+ ' Eje 2'
		--		End				
		--	End
		--Else
		--	Begin
		--		If @Contador = 1
		--			Begin
		--				Set @sqlTbl = 'Update #TblPs# Set [S'+@Campo+'] = Case When ((Stock_Fisico+[P'+@Campo+'])-PromVta) < 0 Then 0 Else Round((Stock_Fisico+[P'+@Campo+'])-PromVta,2) End
  --                                     --#CondicionAdicional#'
		--				Exec(@sqlTbl)
		--				Print @Campo+ ' Eje 3'
		--			End
		--		Else
		--			Begin
		--				Set @sqlTbl = 'Update #TblPs# Set [S'+@Campo+'] = Case When (([S'+@CampoMesAnterior+']+[P'+@Campo+'])-PromVta) < 0 Then 0 Else Round(([S'+@CampoMesAnterior+']+[P'+@Campo+'])-PromVta,2) End
  --                                    --#CondicionAdicional#'
		--				Exec(@sqlTbl)
		--				Print @Campo+ ' Eje 4'
		--			End
		--	End
	

	Set @SqlQueryTbl = 'Sum([P'+@Campo+']) As [P'+@Campo+'],Sum([S'+@Campo+']) As [S'+@Campo+'],'
	Set @Fecha =DATEADD(D,1,@FechaHasta)

End

Select * From #TblPs#

